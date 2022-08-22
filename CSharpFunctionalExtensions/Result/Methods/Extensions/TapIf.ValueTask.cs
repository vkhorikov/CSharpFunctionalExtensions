#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result> TapIf(this ValueTask<Result> resultTask, bool condition, Func<ValueTask> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T>> TapIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T>> TapIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T, E>> TapIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<ValueTask> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T, E>> TapIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<T, ValueTask> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<UnitResult<E>> TapIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Func<ValueTask> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> TapIf<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<ValueTask> func)
        {
            Result<T> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return await result.Tap(func);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> TapIf<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, ValueTask> func)
        {
            Result<T> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return await result.Tap(func);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> TapIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, Func<ValueTask> func)
        {
            Result<T, E> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return await result.Tap(func);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> TapIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, ValueTask> func)
        {
            Result<T, E> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return await result.Tap(func);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> TapIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<bool> predicate, Func<ValueTask> func)
        {
            UnitResult<E> result = await resultTask;

            if (result.IsSuccess && predicate())
                return await result.Tap(func);
            else
                return result;
        }
    }
}
#endif