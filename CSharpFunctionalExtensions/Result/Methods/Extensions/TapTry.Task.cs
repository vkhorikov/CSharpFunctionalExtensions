using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Result> TapTry(this Task<Result> resultTask, Func<Task> func, Func<Exception, string> errorHandler = null)
        {
            var result = await resultTask.DefaultAwait();

            errorHandler ??= Result.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (result.IsSuccess)
                    await func().DefaultAwait();

                return result;
            }
            catch (Exception exc)
            {
                string message = errorHandler(exc);
                return Result.Failure(message);
            }
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Result<T>> TapTry<T>(this Task<Result<T>> resultTask, Func<Task> func, Func<Exception, string> errorHandler = null)
        {
            var result = await resultTask.DefaultAwait();
            
            errorHandler ??= Result.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (result.IsSuccess)
                    await func().DefaultAwait();

                return result;
            }
            catch (Exception exc)
            {
                string message = errorHandler(exc);
                return new Result<T>(true, message, default);
            }
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Result<T>> TapTry<T>(this Task<Result<T>> resultTask, Func<T, Task> func, Func<Exception, string> errorHandler = null)
        {
            var result = await resultTask.DefaultAwait();

            errorHandler ??= Result.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (result.IsSuccess)
                    await func(result.Value).DefaultAwait();

                return result;
            }
            catch (Exception exc)
            {
                string message = errorHandler(exc);
                return new Result<T>(true, message, default);
            }
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<UnitResult<E>> TapTry<E>(this Task<UnitResult<E>> resultTask, Func<Task> func, Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();

            try
            {
                if (result.IsSuccess)
                    await func().DefaultAwait();

                return result;
            }
            catch (Exception exc)
            {
                var error = errorHandler(exc);
                return new UnitResult<E>(true, error);
            }
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Result<T, E>> TapTry<T, E>(this Task<Result<T, E>> resultTask, Func<Task> func, Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();

            try
            {
                if (result.IsSuccess)
                    await func().DefaultAwait();

                return result;
            }
            catch (Exception exc)
            {
                var error = errorHandler(exc);
                return new Result<T, E>(true, error, default);
            }
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static async Task<Result<T, E>> TapTry<T, E>(this Task<Result<T, E>> resultTask, Func<T, Task> func, Func<Exception, E> errorHandler)
        {
            var result = await resultTask.DefaultAwait();

            try
            {
                if (result.IsSuccess)
                    await func(result.Value).DefaultAwait();

                return result;
            }
            catch (Exception exc)
            {
                var error = errorHandler(exc);
                return new Result<T, E>(true, error, default);
            }
        }
    }
}
