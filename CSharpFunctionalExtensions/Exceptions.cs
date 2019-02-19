using System;

namespace CSharpFunctionalExtensions
{
    public class ResultSuccessException : Exception
    {
        internal ResultSuccessException() : base(ResultMessages.ErrorIsInaccessibleForSuccess)
        {
        }
    }

    public class ResultFailureException : Exception
    {
        public string Error { get; }

        internal ResultFailureException(string error) : base(ResultMessages.ValueIsInaccessibleForFailure)
        {
            Error = error;
        }
    }

    public class ResultFailureException<TError> : ResultFailureException
    {
        public new TError Error { get; }

        internal ResultFailureException(TError error) : base(ResultMessages.ValueIsInaccessibleForFailure)
        {
            Error = error;
        }
    }
}
