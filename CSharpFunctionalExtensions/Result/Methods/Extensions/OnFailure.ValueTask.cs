#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> OnFailure<T, E>(this ValueTask<Result<T, E>> resultTask, Func<ValueTask> func)
        {
            Result<T, E> result = await resultTask;

            if (result.IsFailure)
            {
                await func();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> OnFailure<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask> func)
        {
            Result<T> result = await resultTask;

            if (result.IsFailure)
            {
                await func();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result> OnFailure(this ValueTask<Result> resultTask, Func<ValueTask> func)
        {
            Result result = await resultTask;

            if (result.IsFailure)
            {
                await func();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result> OnFailure(this ValueTask<Result> resultTask, Func<string, ValueTask> func)
        {
            Result result = await resultTask;

            if (result.IsFailure)
            {
                await func(result.Error);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> OnFailure<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, ValueTask> func)
        {
            UnitResult<E> result = await resultTask;

            if (result.IsFailure)
            {
                await func(result.Error);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> OnFailure<E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask> func)
        {
            UnitResult<E> result = await resultTask;

            if (result.IsFailure)
            {
                await func();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> OnFailure<T>(this ValueTask<Result<T>> resultTask, Func<string, ValueTask> func)
        {
            Result<T> result = await resultTask;

            if (result.IsFailure)
            {
                await func(result.Error);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> OnFailure<T, E>(this ValueTask<Result<T, E>> resultTask, Func<E, ValueTask> func)
        {
            Result<T, E> result = await resultTask;

            if (result.IsFailure)
            {
                await func(result.Error);
            }

            return result;
        }
    }
}
#endif