using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result> TapTry(this Task<Result> resultTask, Action action)
        {
            var result = await resultTask.DefaultAwait();
            return result.TapTry(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> TapTry<T>(this Task<Result<T>> resultTask, Action action)
        {
            var result = await resultTask.DefaultAwait();
            return result.TapTry(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> TapTry<T>(this Task<Result<T>> resultTask, Action<T> action)
        {
            var result = await resultTask.DefaultAwait();
            return result.TapTry(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<UnitResult<E>> TapTry<E>(this Task<UnitResult<E>> resultTask, Action action, Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();
            return result.TapTry(action, errorHandler);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> TapTry<T, E>(this Task<Result<T, E>> resultTask, Action action, Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();
            return result.TapTry(action, errorHandler);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> TapTry<T, E>(this Task<Result<T, E>> resultTask, Action<T> action, Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();
            return result.TapTry(action, errorHandler);
        }
    }
}
