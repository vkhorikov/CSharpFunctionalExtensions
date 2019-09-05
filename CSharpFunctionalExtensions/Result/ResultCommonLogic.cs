using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CSharpFunctionalExtensions
{
    internal class ResultCommonLogic<E>
    {
        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly E _error;

        public E Error
        {
            [DebuggerStepThrough]
            get
            {
                if (IsSuccess)
                    throw new ResultSuccessException();

                return _error;
            }
        }

        [DebuggerStepThrough]
        internal ResultCommonLogic(bool isFailure, E error)
        {
            if (isFailure)
            {
                if (error == null)
                    throw new ArgumentNullException(nameof(error), ResultMessages.ErrorObjectIsNotProvidedForFailure);
            }
            else
            {
                if (!EqualityComparer<E>.Default.Equals(error, default(E)))
                    throw new ArgumentException(ResultMessages.ErrorObjectIsProvidedForSuccess, nameof(error));
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
        [DebuggerStepThrough]
        public static ResultCommonLogic Create(bool isFailure, string error)
        {
            if (isFailure)
            {
                if (string.IsNullOrEmpty(error))
                    throw new ArgumentNullException(nameof(error), ResultMessages.ErrorMessageIsNotProvidedForFailure);
            }
            else
            {
                if (error != null)
                    throw new ArgumentException(ResultMessages.ErrorMessageIsProvidedForSuccess, nameof(error));
            }

            return new ResultCommonLogic(isFailure, error);
        }

        private ResultCommonLogic(bool isFailure, string error) : base(isFailure, error)
        {
        }
    }
}