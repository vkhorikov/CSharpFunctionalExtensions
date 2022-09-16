#if NET5_0_OR_GREATER
using System.Threading.Tasks;
using System;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>        
        /// <param name="resultValueTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Result> BindTry(this ValueTask<Result> resultValueTask, Func<Result> valueTask,
            Func<Exception, string> errorHandler = null)
        {
            var result = await resultValueTask;
            return result.BindTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>        
        /// <typeparam name="K"><paramref name="valueTask" /> Result Type parameter</typeparam>        
        /// <param name="resultValueTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Result<K>> BindTry<K>(this ValueTask<Result> resultValueTask, Func<Result<K>> valueTask,
            Func<Exception, string> errorHandler = null)
        {
            var result = await resultValueTask;
            return result.BindTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>        
        /// <param name="resultValueTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Result> BindTry<T>(this ValueTask<Result<T>> resultValueTask, Func<T, Result> valueTask,
            Func<Exception, string> errorHandler = null)
        {
            var result = await resultValueTask;
            return result.BindTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>
        /// <typeparam name="K"><paramref name="valueTask" /> Result Type parameter</typeparam>        
        /// <param name="resultValueTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Result<K>> BindTry<T, K>(this ValueTask<Result<T>> resultValueTask, Func<T, Result<K>> valueTask,
            Func<Exception, string> errorHandler = null)
        {
            var result = await resultValueTask;
            return result.BindTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>        
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="resultValueTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<UnitResult<E>> BindTry<T, E>(this ValueTask<Result<T, E>> resultValueTask, Func<T, UnitResult<E>> valueTask,
            Func<Exception, E> errorHandler)
        {
            var result = await resultValueTask;
            return result.BindTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>
        /// <typeparam name="K"><paramref name="valueTask" /> Result Type parameter</typeparam>
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="resultValueTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Result<K, E>> BindTry<T, K, E>(this ValueTask<Result<T, E>> resultValueTask, Func<T, Result<K, E>> valueTask,
            Func<Exception, E> errorHandler)
        {
            var result = await resultValueTask;
            return result.BindTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>        
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="resultValueTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<UnitResult<E>> BindTry<E>(this ValueTask<UnitResult<E>> resultValueTask, Func<UnitResult<E>> valueTask,
            Func<Exception, E> errorHandler)
        {
            var result = await resultValueTask;
            return result.BindTry(valueTask, errorHandler);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>        
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="resultValueTask">Extended result</param>
        /// <param name="valueTask">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>
        /// <returns>Binding result</returns>
        public static async ValueTask<Result<T, E>> BindTry<T, E>(this ValueTask<UnitResult<E>> resultValueTask, Func<Result<T, E>> valueTask,
            Func<Exception, E> errorHandler)
        {
            var result = await resultValueTask;
            return result.BindTry(valueTask, errorHandler);
        }        
    }
}
#endif