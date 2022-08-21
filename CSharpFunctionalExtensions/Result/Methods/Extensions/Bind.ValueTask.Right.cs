#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static ValueTask<Result<K, E>> Bind<T, K, E>(this Result<T, E> result, Func<T, ValueTask<Result<K, E>>> func)
        {
            if (result.IsFailure)
                return Result.Failure<K, E>(result.Error).AsCompletedValueTask();

            return func(result.Value);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static ValueTask<Result<K>> Bind<T, K>(this Result<T> result, Func<T, ValueTask<Result<K>>> func)
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error).AsCompletedValueTask();

            return func(result.Value);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static ValueTask<Result<K>> Bind<K>(this Result result, Func<ValueTask<Result<K>>> func)
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error).AsCompletedValueTask();

            return func();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static ValueTask<Result> Bind<T>(this Result<T> result, Func<T, ValueTask<Result>> func)
        {
            if (result.IsFailure)
                return Result.Failure(result.Error).AsCompletedValueTask();

            return func(result.Value);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static ValueTask<Result> Bind(this Result result, Func<ValueTask<Result>> func)
        {
            if (result.IsFailure)
                return result.AsCompletedValueTask();

            return func();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static ValueTask<UnitResult<E>> Bind<E>(this UnitResult<E> result, Func<ValueTask<UnitResult<E>>> func)
        {
            if (result.IsFailure)
                return UnitResult.Failure(result.Error).AsCompletedValueTask();

            return func();
        }
        
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static ValueTask<Result<T, E>> Bind<T, E>(this UnitResult<E> result, Func<ValueTask<Result<T, E>>> func)
        {
            if (result.IsFailure)
                return Result.Failure<T, E>(result.Error).AsCompletedValueTask();

            return func();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static ValueTask<UnitResult<E>> Bind<T, E>(this Result<T, E> result, Func<T, ValueTask<UnitResult<E>>> func)
        {
            if (result.IsFailure)
                return UnitResult.Failure(result.Error).AsCompletedValueTask();

            return func(result.Value);
        }
    }
}
#endif