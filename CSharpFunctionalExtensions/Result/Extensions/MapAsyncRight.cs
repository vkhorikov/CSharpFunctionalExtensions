using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result<K, E>> Map<T, K, E>(this Result<T, E> result, Func<T, Task<K>> func)
        {
            if (result.IsFailure)
                return Result.Failure<K, E>(result.Error);

            K value = await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);

            return Result.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result<K>> Map<T, K>(this Result<T> result, Func<T, Task<K>> func)
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            K value = await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);

            return Result.Success(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result<K>> Map<K>(this Result result, Func<Task<K>> func)
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            K value = await func().ConfigureAwait(Result.DefaultConfigureAwait);

            return Result.Success(value);
        }
    }
}
