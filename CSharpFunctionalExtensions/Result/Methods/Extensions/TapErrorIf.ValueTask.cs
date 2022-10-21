#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result> TapErrorIf(this ValueTask<Result> resultTask, bool condition, Func<ValueTask> valueTask)
        {
            if (condition)
            {
                return resultTask.TapError(valueTask);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result> TapErrorIf(this ValueTask<Result> resultTask, bool condition, Func<string, ValueTask> valueTask)
        {
            if (condition)
            {
                return resultTask.TapError(valueTask);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T>> TapErrorIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask> valueTask)
        {
            if (condition)
            {
                return resultTask.TapError(valueTask);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T>> TapErrorIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<string, ValueTask> valueTask)
        {
            if (condition)
            {
                return resultTask.TapError(valueTask);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T, E>> TapErrorIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<ValueTask> valueTask)
        {
            if (condition)
            {
                return resultTask.TapError(valueTask);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T, E>> TapErrorIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<E, ValueTask> valueTask)
        {
            if (condition)
            {
                return resultTask.TapError(valueTask);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Func<ValueTask> valueTask)
        {
            if (condition)
            {
                return resultTask.TapError(valueTask);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Func<E, ValueTask> valueTask)
        {
            if (condition)
            {
                return resultTask.TapError(valueTask);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result> TapErrorIf(this ValueTask<Result> resultTask, Func<string, bool> predicate, Func<ValueTask> valueTask)
        {
            Result result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(valueTask);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result> TapErrorIf(this ValueTask<Result> resultTask, Func<string, bool> predicate, Func<string, ValueTask> valueTask)
        {
            Result result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(valueTask);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> TapErrorIf<T>(this ValueTask<Result<T>> resultTask, Func<string, bool> predicate, Func<ValueTask> valueTask)
        {
            Result<T> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(valueTask);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> TapErrorIf<T>(this ValueTask<Result<T>> resultTask, Func<string, bool> predicate, Func<string, ValueTask> valueTask)
        {
            Result<T> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(valueTask);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> TapErrorIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<E, bool> predicate, Func<ValueTask> valueTask)
        {
            Result<T, E> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(valueTask);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> TapErrorIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<E, bool> predicate, Func<E, ValueTask> valueTask)
        {
            Result<T, E> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(valueTask);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, bool> predicate, Func<ValueTask> valueTask)
        {
            UnitResult<E> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(valueTask);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, bool> predicate, Func<E, ValueTask> valueTask)
        {
            UnitResult<E> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return await result.TapError(valueTask);
            }

            return result;
        }
    }
}
#endif