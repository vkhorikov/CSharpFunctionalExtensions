#if NET5_0_OR_GREATER
using System.Threading.Tasks;
using System;

namespace CSharpFunctionalExtensions.ValueTasks
{
	public static partial class AsyncResultExtensionsBothOperands
	{
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>        
        /// <param name="resultTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Result> BindTry(this ValueTask<Result> resultTask, Func<ValueTask<Result>> valueTask,
			Func<Exception, string> errorHandler = null)
		{            
			var result = await resultTask;
			return await result.BindTry(valueTask, errorHandler);
		}

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>        
        /// <typeparam name="K"><paramref name="valueTask" /> Result Type parameter</typeparam>        
        /// <param name="resultTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Result<K>> BindTry<K>(this ValueTask<Result> resultTask, Func<ValueTask<Result<K>>> valueTask,
            Func<Exception, string> errorHandler = null)
        {
            var result = await resultTask;
            return await result.BindTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>        
        /// <param name="resultTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Result> BindTry<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result>> valueTask,
			Func<Exception, string> errorHandler = null)
		{
			var result = await resultTask;
			return await result.BindTry(valueTask, errorHandler);
		}

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>    
        /// <typeparam name="T">Result Type parameter</typeparam>
        /// <typeparam name="K"><paramref name="valueTask" /> Result Type parameter</typeparam>        
        /// <param name="resultTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Result<K>> BindTry<T, K>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<K>>> valueTask,
            Func<Exception, string> errorHandler = null)
        {
            var result = await resultTask;
            return await result.BindTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="resultTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<UnitResult<E>> BindTry<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<UnitResult<E>>> valueTask,
            Func<Exception, E> errorHandler)
        {
            var result = await resultTask;
            return await result.BindTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>
        /// <typeparam name="K"><paramref name="valueTask" /> Result Type parameter</typeparam>
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="resultTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Result<K, E>> BindTry<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<Result<K, E>>> valueTask,
			Func<Exception, E> errorHandler)
		{
			var result = await resultTask;
			return await result.BindTry(valueTask, errorHandler);
		}

        /// <summary>
		///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
		///     If a given function throws an exception, an error is returned from the given error handler
		/// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="resultTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
		public static async ValueTask<Result<T, E>> BindTry<T, E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask<Result<T, E>>> valueTask,
            Func<Exception, E> errorHandler)
        {
            var result = await resultTask;
            return await result.BindTry(valueTask, errorHandler);
        }


        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler        ///             ///     
        /// </summary>        
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="resultTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<UnitResult<E>> BindTry<E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask<UnitResult<E>>> valueTask,
			Func<Exception, E> errorHandler)
		{
			var result = await resultTask;
			return await result.BindTry(valueTask, errorHandler);
		}			
	}
}
#endif