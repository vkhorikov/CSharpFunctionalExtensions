using System.Threading.Tasks;


namespace CSharpFunctionalExtensions
{
    public static class AsyncMaybeExtensions
    {
        public static async Task<Result<T>> ToResult<T>(this Task<Maybe<T>> maybeTask, string errorMessage, bool continueOnCapturedContext = true)
            where T : class
        {
            Maybe<T> maybe = await maybeTask.ConfigureAwait(continueOnCapturedContext);
            return maybe.ToResult(errorMessage);
        }

        public static async Task<Result<T, TError>> ToResult<T, TError>(this Task<Maybe<T>> maybeTask, TError error,
            bool continueOnCapturedContext = true) where T : class where TError : class
        {
            Maybe<T> maybe = await maybeTask.ConfigureAwait(continueOnCapturedContext);
            return maybe.ToResult(error);
        }
    }
}
