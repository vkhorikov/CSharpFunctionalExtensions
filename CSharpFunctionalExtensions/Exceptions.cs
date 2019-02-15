using System;

namespace CSharpFunctionalExtensions
{
    public class ResultException : Exception
    {
        internal ResultException(string message) : base(message)
        {
        }
    }

    public class ResultFailedException : ResultException
    {
        internal ResultFailedException() : base(ResultMessages.ValueIsInaccessibleForFailure)
        {
        }
    }

    public class ResultSucceededException : ResultException
    {
        internal ResultSucceededException() : base(ResultMessages.ErrorIsInaccessibleForSuccess)
        {
        }
    }
}
