using CSharpFunctionalExtensions.Internal;
using System;

namespace CSharpFunctionalExtensions
{
    public class ResultFailureException : Exception
    {
        public string Error { get; }

        internal ResultFailureException(string error)
            : base(ResultMessages.ValueIsInaccessibleForFailure)
        {
            Error = error;
        }
    }

    public class ResultFailureException<E> : ResultFailureException
    {
        public new E Error { get; }

        internal ResultFailureException(E error)
            : base(ResultMessages.ValueIsInaccessibleForFailure)
        {
            Error = error;
        }
    }
}
