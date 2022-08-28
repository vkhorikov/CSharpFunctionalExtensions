using System.Threading.Tasks;
using System;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static async Task<Result<K, E>> BindTry<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Result<K, E>> func,
            Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindTry(func, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static async Task<Result<K>> BindTry<T, K>(this Task<Result<T>> resultTask, Func<T, Result<K>> func,
            Func<Exception, string> errorHandler)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindTry(func, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static async Task<Result<K>> BindTry<K>(this Task<Result> resultTask, Func<Result<K>> func,
            Func<Exception, string> errorHandler)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindTry(func, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static async Task<Result> BindTry<T>(this Task<Result<T>> resultTask, Func<T, Result> func,
            Func<Exception, string> errorHandler = null)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindTry(func, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static async Task<Result> BindTry(this Task<Result> resultTask, Func<Result> func,
            Func<Exception, string> errorHandler = null)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindTry(func, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async Task<UnitResult<E>> BindTry<E>(this Task<UnitResult<E>> resultTask, Func<UnitResult<E>> func,
            Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindTry(func, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async Task<Result<T, E>> BindTry<T, E>(this Task<UnitResult<E>> resultTask, Func<Result<T, E>> func,
            Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindTry(func, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async Task<UnitResult<E>> BindTry<T, E>(this Task<Result<T, E>> resultTask, Func<T, UnitResult<E>> func,
            Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindTry(func, errorHandler);
        }
    }
}
