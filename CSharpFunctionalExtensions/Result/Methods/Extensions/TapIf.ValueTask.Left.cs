#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result> TapIf(this ValueTask<Result> resultTask, bool condition, Action action)
        {
            if (condition)
                return resultTask.Tap(action);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T>> TapIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Action action)
        {
            if (condition)
                return resultTask.Tap(action);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T>> TapIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Action<T> action)
        {
            if (condition)
                return resultTask.Tap(action);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T, E>> TapIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Action action)
        {
            if (condition)
                return resultTask.Tap(action);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T, E>> TapIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Action<T> action)
        {
            if (condition)
                return resultTask.Tap(action);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<UnitResult<E>> TapIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Action action)
        {
            if (condition)
                return resultTask.Tap(action);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> TapIf<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Action action)
        {
            Result<T> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(action);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> TapIf<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Action<T> action)
        {
            Result<T> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(action);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> TapIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, Action action)
        {
            Result<T, E> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(action);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> TapIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, Action<T> action)
        {
            Result<T, E> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(action);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> TapIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<bool> predicate, Action action)
        {
            UnitResult<E> result = await resultTask;

            if (result.IsSuccess && predicate())
                return result.Tap(action);
            else
                return result;
        }
    }
}
#endif