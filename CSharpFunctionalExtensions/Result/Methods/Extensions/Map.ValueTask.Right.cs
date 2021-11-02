#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K, E>> Map<T, K, E>(this Result<T, E> result, Func<T, ValueTask<K>> func)
        {
            if (result.IsFailure)
                return Result.Failure<K, E>(result.Error);

            K value = await func(result.Value).DefaultAwait();

            return Result.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K, E>> Map<K, E>(this UnitResult<E> result, Func<ValueTask<K>> func) 
        {
            if (result.IsFailure)
                return Result.Failure<K, E>(result.Error);

            K value = await func().DefaultAwait();

            return Result.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K>> Map<T, K>(this Result<T> result, Func<T, ValueTask<K>> func)
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            K value = await func(result.Value).DefaultAwait();

            return Result.Success(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K>> Map<T, K>(this Result<T> result, Func<T, ValueTask<Result<K>>> func)
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            Result<K> value = await func(result.Value).DefaultAwait();
            return value;
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K>> Map<K>(this Result result, Func<ValueTask<K>> func)
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            K value = await func().DefaultAwait();

            return Result.Success(value);
        }
    }
}
#endif
