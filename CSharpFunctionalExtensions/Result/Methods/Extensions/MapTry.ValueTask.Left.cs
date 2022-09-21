#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async ValueTask<Result<K, E>> MapTry<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<T, K> valueTask,
            Func<Exception, E> errorHandler)
        {
            Result<T, E> result = await resultTask;
            return result.MapTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async ValueTask<Result<K, E>> MapTry<K, E>(this ValueTask<UnitResult<E>> resultTask, Func<K> valueTask,
            Func<Exception, E> errorHandler)
        {
            UnitResult<E> result = await resultTask;
            return result.MapTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async ValueTask<Result<K>> MapTry<T, K>(this ValueTask<Result<T>> resultTask, Func<T, K> valueTask,
            Func<Exception, string> errorHandler = null)
        {
            Result<T> result = await resultTask;
            return result.MapTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async ValueTask<Result<K>> MapTry<K>(this ValueTask<Result> resultTask, Func<K> valueTask,
            Func<Exception, string> errorHandler = null)
        {
            Result result = await resultTask;
            return result.MapTry(valueTask, errorHandler);
        }
    }
}
#endif