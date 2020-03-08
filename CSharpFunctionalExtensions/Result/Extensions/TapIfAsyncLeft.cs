using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result> TapIf(this Task<Result> resultTask, bool condition, Action action)
        {
            if (condition)
                return resultTask.Tap(action);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result<T>> TapIf<T>(this Task<Result<T>> resultTask, bool condition, Action action)
        {
            if (condition)
                return resultTask.Tap(action);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result<T>> TapIf<T>(this Task<Result<T>> resultTask, bool condition, Action<T> action)
        {
            if (condition)
                return resultTask.Tap(action);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result<T, E>> TapIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Action action)
        {
            if (condition)
                return resultTask.Tap(action);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result<T, E>> TapIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Action<T> action)
        {
            if (condition)
                return resultTask.Tap(action);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result> TapIf<_>(this Task<Result> resultTask, bool condition, Func<_> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result<T>> TapIf<T, _>(this Task<Result<T>> resultTask, bool condition, Func<_> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result<T>> TapIf<T, _>(this Task<Result<T>> resultTask, bool condition, Func<T, _> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result<T, E>> TapIf<T, E, _>(this Task<Result<T, E>> resultTask, bool condition, Func<_> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result<T, E>> TapIf<T, E, _>(this Task<Result<T, E>> resultTask, bool condition, Func<T, _> func)
        {
            if (condition)
                return resultTask.Tap(func);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> TapIf<T>(this Task<Result<T>> resultTask, Func<T, bool> condition, Action action)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsSuccess && condition(result.Value))
                return result.Tap(action);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> TapIf<T>(this Task<Result<T>> resultTask, Func<T, bool> condition, Action<T> action)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsSuccess && condition(result.Value))
                return result.Tap(action);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> TapIf<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> condition, Action action)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsSuccess && condition(result.Value))
                return result.Tap(action);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> TapIf<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> condition, Action<T> action)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsSuccess && condition(result.Value))
                return result.Tap(action);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> TapIf<T, _>(this Task<Result<T>> resultTask, Func<T, bool> condition, Func<_> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsSuccess && condition(result.Value))
                return result.Tap(func);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> TapIf<T, _>(this Task<Result<T>> resultTask, Func<T, bool> condition, Func<T, _> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsSuccess && condition(result.Value))
                return result.Tap(func);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> TapIf<T, E, _>(this Task<Result<T, E>> resultTask, Func<T, bool> condition, Func<_> func)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsSuccess && condition(result.Value))
                return result.Tap(func);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> TapIf<T, E, _>(this Task<Result<T, E>> resultTask, Func<T, bool> condition, Func<T, _> func)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsSuccess && condition(result.Value))
                return result.Tap(func);
            else
                return result;
        }
    }
}
