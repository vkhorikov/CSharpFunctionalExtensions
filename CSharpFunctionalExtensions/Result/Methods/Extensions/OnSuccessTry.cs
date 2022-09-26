using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Result OnSuccessTry(this Result result, Action action, Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? result
                : Result.Try(action, errorHandler);
        }

        public static Result OnSuccessTry<T>(this Result<T> result, Action<T> action, Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? Result.Failure(result.Error)
                : Result.Try(() => action(result.Value), errorHandler);
        }
    }
}
