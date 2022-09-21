using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async Task<Result<K, E>> MapTry<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, K> func,
            Func<Exception, E> errorHandler)
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            return result.MapTry(func, errorHandler);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async Task<Result<K, E>> MapTry<K, E>(this Task<UnitResult<E>> resultTask, Func<K> func,
            Func<Exception, E> errorHandler)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();
            return result.MapTry(func, errorHandler);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async Task<Result<K>> MapTry<T, K>(this Task<Result<T>> resultTask, Func<T, K> func,
            Func<Exception, string> errorHandler = null)
        {
            Result<T> result = await resultTask.DefaultAwait();
            return result.MapTry(func, errorHandler);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async Task<Result<K>> MapTry<K>(this Task<Result> resultTask, Func<K> func,
            Func<Exception, string> errorHandler = null)
        {
            Result result = await resultTask.DefaultAwait();
            return result.MapTry(func, errorHandler);
        }
    }
}
