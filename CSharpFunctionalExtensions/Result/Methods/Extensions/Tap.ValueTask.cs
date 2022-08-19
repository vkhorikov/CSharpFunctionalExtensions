#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result> Tap(this ValueTask<Result> resultTask, Func<ValueTask> func)
        {
            Result result = await resultTask;

            if (result.IsSuccess)
                await func();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> Tap<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask> func)
        {
            Result<T> result = await resultTask;

            if (result.IsSuccess)
                await func();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> Tap<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask> func)
        {
            Result<T> result = await resultTask;

            if (result.IsSuccess)
                await func(result.Value);

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> Tap<E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask> func)
        {
            UnitResult<E> result = await resultTask;

            if (result.IsSuccess)
                await func();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> Tap<T, E>(this ValueTask<Result<T, E>> resultTask, Func<ValueTask> func)
        {
            Result<T, E> result = await resultTask;

            if (result.IsSuccess)
                await func();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> Tap<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask> func)
        {
            Result<T, E> result = await resultTask;

            if (result.IsSuccess)
                await func(result.Value);

            return result;
        }
    }
}
#endif