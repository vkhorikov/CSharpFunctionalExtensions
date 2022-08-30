#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        /// <summary>
        ///     Attempts to execute the supplied action. Returns a Result indicating whether the action executed successfully.
        /// </summary>
        public static async ValueTask<Result> Try(Func<ValueTask> valueTask, Func<Exception, string> errorHandler = null)
        {
            errorHandler ??= Configuration.DefaultTryErrorHandler;

            try
            {
                await valueTask();
                return Success();
            }
            catch (Exception exc)
            {
                string message = errorHandler(exc);
                return Failure(message);
            }
        }
        
        /// <summary>
        ///     Attempts to execute the supplied valueTask action. Returns a Result indicating whether the valueTask action executed successfully.
        ///     If the valueTask action executed successfully, the result contains its return value.
        /// </summary>
        public static async ValueTask<Result<T>> Try<T>(Func<ValueTask<T>> valueTask, Func<Exception, string> errorHandler = null)
        {
            errorHandler ??= Configuration.DefaultTryErrorHandler;

            try
            {
                var result = await valueTask();
                return Success(result);
            }
            catch (Exception exc)
            {
                string message = errorHandler(exc);
                return Failure<T>(message);
            }
        }
        
        /// <summary>
        ///     Attempts to execute the supplied valueTask action. Returns a Result indicating whether the valueTask action executed successfully.
        ///     If the valueTask action executed successfully, the result contains its return value.
        /// </summary>
        public static async ValueTask<Result<T, E>> Try<T, E>(Func<ValueTask<T>> valueTask, Func<Exception, E> errorHandler)
        {
            try
            {
                var result = await valueTask();
                return Success<T, E>(result);
            }
            catch (Exception exc)
            {
                E error = errorHandler(exc);
                return Failure<T, E>(error);
            }
        }
    }
}
#endif