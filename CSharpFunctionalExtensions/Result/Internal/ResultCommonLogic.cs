using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CSharpFunctionalExtensions.Internal
{
    internal struct ResultCommonLogic<E>
    {
        private readonly E _error;
        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;
        public E Error => IsFailure ? _error : throw new ResultSuccessException();

        public ResultCommonLogic(bool isFailure, E error)
        {
            if (isFailure)
            {
                if (error == null || (error is string && error.Equals(string.Empty)))
                    throw new ArgumentNullException(nameof(error), Result.Messages.ErrorObjectIsNotProvidedForFailure);
            }
            else
            {
                if (!EqualityComparer<E>.Default.Equals(error, default))
                    throw new ArgumentException(Result.Messages.ErrorObjectIsProvidedForSuccess, nameof(error));
            }

            IsFailure = isFailure;
            _error = error;
        }

        public void GetObjectData(SerializationInfo info)
        {
            info.AddValue("IsFailure", IsFailure);
            info.AddValue("IsSuccess", IsSuccess);
            if (IsFailure)
            {
                info.AddValue("Error", Error);
            }
        }

        public void GetObjectData<T>(SerializationInfo info, IValue<T> valueResult)
        {
            GetObjectData(info);
            if (IsSuccess)
            {
                info.AddValue("Value", valueResult.Value);
            }
        }

        public static ResultCommonLogic<E> Deserialize(SerializationInfo info)
        {
            bool isFailure = info.GetBoolean("IsFailure");
            E error = isFailure ? (E)info.GetValue("Error", typeof(E)) : default;
            return new ResultCommonLogic<E>(isFailure, error);
        }
    }
}
