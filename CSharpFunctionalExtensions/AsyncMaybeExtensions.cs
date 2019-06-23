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

        public static async Task<Result<T, E>> ToResult<T, E>(this Task<Maybe<T>> maybeTask, E error) where T : class
        {
            Maybe<T> maybe = await maybeTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return maybe.ToResult(error);
        }
    }
}
