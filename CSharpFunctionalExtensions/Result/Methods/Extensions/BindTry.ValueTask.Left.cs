#if NET5_0_OR_GREATER
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
        public static async ValueTask<Result> BindTry(this ValueTask<Result> resultValueTask, Func<Result> func,
            Func<Exception, string> errorHandler = null)
        {
            var result = await resultValueTask;
            return result.BindTry(func, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static async ValueTask<Result<K>> BindTry<K>(this ValueTask<Result> resultValueTask, Func<Result<K>> func,
            Func<Exception, string> errorHandler = null)
        {
            var result = await resultValueTask;
            return result.BindTry(func, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static async ValueTask<Result> BindTry<T>(this ValueTask<Result<T>> resultValueTask, Func<T, Result> func,
            Func<Exception, string> errorHandler = null)
        {
            var result = await resultValueTask;
            return result.BindTry(func, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static async ValueTask<Result<K>> BindTry<T, K>(this ValueTask<Result<T>> resultValueTask, Func<T, Result<K>> func,
            Func<Exception, string> errorHandler = null)
        {
            var result = await resultValueTask;
            return result.BindTry(func, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async ValueTask<UnitResult<E>> BindTry<T, E>(this ValueTask<Result<T, E>> resultValueTask, Func<T, UnitResult<E>> func,
            Func<Exception, E> errorHandler)
        {
            var result = await resultValueTask;
            return result.BindTry(func, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static async ValueTask<Result<K, E>> BindTry<T, K, E>(this ValueTask<Result<T, E>> resultValueTask, Func<T, Result<K, E>> func,
            Func<Exception, E> errorHandler)
        {
            var result = await resultValueTask;
            return result.BindTry(func, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async ValueTask<UnitResult<E>> BindTry<E>(this ValueTask<UnitResult<E>> resultValueTask, Func<UnitResult<E>> func,
            Func<Exception, E> errorHandler)
        {
            var result = await resultValueTask;
            return result.BindTry(func, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async ValueTask<Result<T, E>> BindTry<T, E>(this ValueTask<UnitResult<E>> resultValueTask, Func<Result<T, E>> func,
            Func<Exception, E> errorHandler)
        {
            var result = await resultValueTask;
            return result.BindTry(func, errorHandler);
        }        
    }
}
#endif