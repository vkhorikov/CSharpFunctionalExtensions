using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        public static async Task<Result<K, E>> Bind<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Task<Result<K, E>>> func)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail<K, E>(result.Error);

            return await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result<K>> Bind<T, K>(this Task<Result<T>> resultTask, Func<T, Task<Result<K>>> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result<K>> Bind<K>(this Task<Result> resultTask, Func<Task<Result<K>>> func)
        {
            Result result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return await func().ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result> Bind<T>(this Task<Result<T>> resultTask, Func<T, Task<Result>> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail(result.Error);

            return await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result> Bind(this Task<Result> resultTask, Func<Task<Result>> func)
        {
            Result result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return result;

            return await func().ConfigureAwait(Result.DefaultConfigureAwait);
        }
    }
}
