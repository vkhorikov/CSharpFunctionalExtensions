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
        public static ValueTask<Result> TapErrorIf(this ValueTask<Result> resultTask, bool condition, Action action)
        {
            if (condition)
            {
                return resultTask.TapError(action);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result> TapErrorIf(this ValueTask<Result> resultTask, bool condition, Action<string> action)
        {
            if (condition)
            {
                return resultTask.TapError(action);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T>> TapErrorIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Action action)
        {
            if (condition)
            {
                return resultTask.TapError(action);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T>> TapErrorIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Action<string> action)
        {
            if (condition)
            {
                return resultTask.TapError(action);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T, E>> TapErrorIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Action action)
        {
            if (condition)
            {
                return resultTask.TapError(action);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T, E>> TapErrorIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Action<E> action)
        {
            if (condition)
            {
                return resultTask.TapError(action);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Action action)
        {
            if (condition)
            {
                return resultTask.TapError(action);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Action<E> action)
        {
            if (condition)
            {
                return resultTask.TapError(action);
            }

            return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result> TapErrorIf(this ValueTask<Result> resultTask, Func<string, bool> predicate, Action action)
        {
            Result result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result> TapErrorIf(this ValueTask<Result> resultTask, Func<string, bool> predicate, Action<string> action)
        {
            Result result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> TapErrorIf<T>(this ValueTask<Result<T>> resultTask, Func<string, bool> predicate, Action action)
        {
            Result<T> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> TapErrorIf<T>(this ValueTask<Result<T>> resultTask, Func<string, bool> predicate, Action<string> action)
        {
            Result<T> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> TapErrorIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<E, bool> predicate, Action action)
        {
            Result<T, E> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> TapErrorIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<E, bool> predicate, Action<E> action)
        {
            Result<T, E> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, bool> predicate, Action action)
        {
            UnitResult<E> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, bool> predicate, Action<E> action)
        {
            UnitResult<E> result = await resultTask;

            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }
    }
}
#endif