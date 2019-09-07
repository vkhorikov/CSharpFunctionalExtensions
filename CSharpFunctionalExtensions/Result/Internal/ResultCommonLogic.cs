using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CSharpFunctionalExtensions.Internal
{
    internal class ResultCommonLogic<E>
    {
        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        private readonly E _error;
        public E Error => IsFailure ? _error : throw new ResultSuccessException();

        internal ResultCommonLogic(bool isFailure, E error)
        {
            if (isFailure)
            {
                if (error == null)
                    throw new ArgumentNullException(nameof(error), Result.Messages.ErrorObjectIsNotProvidedForFailure);
            }
            else
            {
                if (!EqualityComparer<E>.Default.Equals(error, default(E)))
                    throw new ArgumentException(Result.Messages.ErrorObjectIsProvidedForSuccess, nameof(error));
            }

            IsFailure = isFailure;
            _error = error;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("IsFailure", IsFailure);
            info.AddValue("IsSuccess", IsSuccess);
            if (IsFailure)
            {
                info.AddValue("Error", Error);
            }
        }
    }

    internal sealed class ResultCommonLogic : ResultCommonLogic<string>
    {
        public static ResultCommonLogic Create(bool isFailure, string error)
        {
            if (isFailure)
            {
                if (string.IsNullOrEmpty(error))
                    throw new ArgumentNullException(nameof(error), Result.Messages.ErrorMessageIsNotProvidedForFailure);
            }
            else
            {
                if (error != null)
                    throw new ArgumentException(Result.Messages.ErrorMessageIsProvidedForSuccess, nameof(error));
            }

            return new ResultCommonLogic(isFailure, error);
        }

        private ResultCommonLogic(bool isFailure, string error) : base(isFailure, error)
        {
        }
    }
}