using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Task<Result<K, E>> Bind<T, K, E>(this Result<T, E> result, Func<T, Task<Result<K, E>>> func)
        {
            if (result.IsFailure)
                return Result.Failure<K, E>(result.Error).AsCompletedTask();

            return func(result.Value);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Task<Result<K>> Bind<T, K>(this Result<T> result, Func<T, Task<Result<K>>> func)
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error).AsCompletedTask();

            return func(result.Value);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Task<Result<K>> Bind<K>(this Result result, Func<Task<Result<K>>> func)
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error).AsCompletedTask();

            return func();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Task<Result> Bind<T>(this Result<T> result, Func<T, Task<Result>> func)
        {
            if (result.IsFailure)
                return Result.Failure(result.Error).AsCompletedTask();

            return func(result.Value);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Task<Result> Bind(this Result result, Func<Task<Result>> func)
        {
            if (result.IsFailure)
                return result.AsCompletedTask();

            return func();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Task<Result<T, E>> Bind<T, E>(this UnitResult<E> result, Func<Task<Result<T, E>>> func)
        {
            if (result.IsFailure)
                return Result.Failure<T, E>(result.Error).AsCompletedTask();

            return func();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Task<UnitResult<E>> Bind<T, E>(this Result<T, E> result, Func<T, Task<UnitResult<E>>> func)
        {
            if (result.IsFailure)
                return UnitResult.Failure(result.Error).AsCompletedTask();

            return func(result.Value);
        }
    }
}