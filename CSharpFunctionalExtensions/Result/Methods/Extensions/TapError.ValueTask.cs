#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> TapError<T, E>(this ValueTask<Result<T, E>> resultTask, Func<ValueTask> valueTask)
        {
            Result<T, E> result = await resultTask;

            if (result.IsFailure)
            {
                await valueTask();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> TapError<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask> valueTask)
        {
            Result<T> result = await resultTask;

            if (result.IsFailure)
            {
                await valueTask();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result> TapError(this ValueTask<Result> resultTask, Func<ValueTask> valueTask)
        {
            Result result = await resultTask;

            if (result.IsFailure)
            {
                await valueTask();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result> TapError(this ValueTask<Result> resultTask, Func<string, ValueTask> valueTask)
        {
            Result result = await resultTask;

            if (result.IsFailure)
            {
                await valueTask(result.Error);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> TapError<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, ValueTask> valueTask)
        {
            UnitResult<E> result = await resultTask;

            if (result.IsFailure)
            {
                await valueTask(result.Error);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> TapError<E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask> valueTask)
        {
            UnitResult<E> result = await resultTask;

            if (result.IsFailure)
            {
                await valueTask();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> TapError<T>(this ValueTask<Result<T>> resultTask, Func<string, ValueTask> valueTask)
        {
            Result<T> result = await resultTask;

            if (result.IsFailure)
            {
                await valueTask(result.Error);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> TapError<T, E>(this ValueTask<Result<T, E>> resultTask, Func<E, ValueTask> valueTask)
        {
            Result<T, E> result = await resultTask;

            if (result.IsFailure)
            {
                await valueTask(result.Error);
            }

            return result;
        }
    }
}
#endif
