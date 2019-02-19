using System.Threading.Tasks;


namespace CSharpFunctionalExtensions
{
    public static class AsyncMaybeExtensions
    {
        public static async Task<Result<T>> ToResult<T>(this Task<Maybe<T>> maybeTask, string errorMessage)
            where T : class
        {
            Maybe<T> maybe = await maybeTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return maybe.ToResult(errorMessage);
        }

        public static async Task<Result<T, TError>> ToResult<T, TError>(this Task<Maybe<T>> maybeTask, TError error) where T : class where TError : class
        {
            Maybe<T> maybe = await maybeTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return maybe.ToResult(error);
        }
    }
}
