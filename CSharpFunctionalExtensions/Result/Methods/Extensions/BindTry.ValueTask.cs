#if NET5_0_OR_GREATER
using System.Threading.Tasks;
using System;

namespace CSharpFunctionalExtensions
{
	public static partial class AsyncResultExtensionsBothOperands
	{
		/// <summary>
		///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
		///     If a given function throws an exception, an error is returned from the given (or default) error handler
		/// </summary>
		public static async ValueTask<Result> BindTry(this ValueTask<Result> resultTask, Func<ValueTask<Result>> func,
			Func<Exception, string> errorHandler = null)
		{
			var result = await resultTask;
			return await result.BindTry(func, errorHandler);
		}

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static async ValueTask<Result<K>> BindTry<K>(this ValueTask<Result> resultTask, Func<ValueTask<Result<K>>> func,
            Func<Exception, string> errorHandler = null)
        {
            var result = await resultTask;
            return await result.BindTry(func, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static async ValueTask<Result> BindTry<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result>> func,
			Func<Exception, string> errorHandler = null)
		{
			var result = await resultTask;
			return await result.BindTry(func, errorHandler);
		}

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static async ValueTask<Result<K>> BindTry<T, K>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<K>>> func,
            Func<Exception, string> errorHandler = null)
        {
            var result = await resultTask;
            return await result.BindTry(func, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async ValueTask<UnitResult<E>> BindTry<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<UnitResult<E>>> func,
            Func<Exception, E> errorHandler)
        {
            var result = await resultTask;
            return await result.BindTry(func, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async ValueTask<Result<K, E>> BindTry<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<Result<K, E>>> func,
			Func<Exception, E> errorHandler)
		{
			var result = await resultTask;
			return await result.BindTry(func, errorHandler);
		}

        /// <summary>
		///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
		///     If a given function throws an exception, an error is returned from the given error handler
		/// </summary>
		public static async ValueTask<Result<T, E>> BindTry<T, E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask<Result<T, E>>> func,
            Func<Exception, E> errorHandler)
        {
            var result = await resultTask;
            return await result.BindTry(func, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        public static async ValueTask<UnitResult<E>> BindTry<E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask<UnitResult<E>>> func,
			Func<Exception, E> errorHandler)
		{
			var result = await resultTask;
			return await result.BindTry(func, errorHandler);
		}			
	}
}
#endif