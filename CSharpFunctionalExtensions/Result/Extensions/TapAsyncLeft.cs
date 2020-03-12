using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result> Tap(this Task<Result> resultTask, Action action)
        {
            Result result = await resultTask.DefaultAwait();
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> Tap<T>(this Task<Result<T>> resultTask, Action action)
        {
            Result<T> result = await resultTask.DefaultAwait();
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> Tap<T>(this Task<Result<T>> resultTask, Action<T> action)
        {
            Result<T> result = await resultTask.DefaultAwait();
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> Tap<T, E>(this Task<Result<T, E>> resultTask, Action action)
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> Tap<T, E>(this Task<Result<T, E>> resultTask, Action<T> action)
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result> Tap<_>(this Task<Result> resultTask, Func<_> func)
        {
            Result result = await resultTask.DefaultAwait();
            return result.Tap(func);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> Tap<T, _>(this Task<Result<T>> resultTask, Func<_> func)
        {
            Result<T> result = await resultTask.DefaultAwait();
            return result.Tap(func);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> Tap<T, _>(this Task<Result<T>> resultTask, Func<T, _> func)
        {
            Result<T> result = await resultTask.DefaultAwait();
            return result.Tap(func);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> Tap<T, E, _>(this Task<Result<T, E>> resultTask, Func<_> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            return result.Tap(func);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> Tap<T, E, _>(this Task<Result<T, E>> resultTask, Func<T, _> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            return result.Tap(func);
        }
    }
}
