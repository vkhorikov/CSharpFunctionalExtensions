using CSharpFunctionalExtensions.Internal;
using System;

namespace CSharpFunctionalExtensions
{
    public class ResultSuccessException : Exception
    {
        internal ResultSuccessException()
            : base(ResultMessages.ErrorIsInaccessibleForSuccess)
        {
        }
    }
}
