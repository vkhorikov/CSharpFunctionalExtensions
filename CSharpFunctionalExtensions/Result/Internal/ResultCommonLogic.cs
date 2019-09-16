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

        private ResultCommonLogic(bool isFailure, E error)
        {
            if (isFailure)
            {
                if (error == null || error is string && error.Equals(string.Empty))
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

        public static ResultCommonLogic<E> Create(bool isFailure, E error)
        {
            return new ResultCommonLogic<E>(isFailure, error);
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
}