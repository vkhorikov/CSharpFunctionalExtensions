using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        private static readonly Func<Exception, string> DefaultTryErrorHandler = exc => exc.Message;

        public static Result Try(Action action, Func<Exception, string> errorHandler = null)
        {
            errorHandler = errorHandler ?? DefaultTryErrorHandler;

            try
            {
                action();
                return Ok();
            }
            catch (Exception exc)
            {
                string message = errorHandler(exc);
                return Fail(message);
            }
        }

        public static Result<T> Try<T>(Func<T> func, Func<Exception, string> errorHandler = null)
        {
            errorHandler = errorHandler ?? DefaultTryErrorHandler;

            try
            {
                return Ok(func());
            }
            catch (Exception exc)
            {
                string message = errorHandler(exc);
                return Fail<T>(message);
            }
        }

        public static async Task<Result<T>> Try<T>(Func<Task<T>> func, Func<Exception, string> errorHandler = null)
        {
            errorHandler = errorHandler ?? DefaultTryErrorHandler;

            try
            {
                var result = await func().ConfigureAwait(Result.DefaultConfigureAwait);
                return Ok(result);
            }
            catch (Exception exc)
            {
                string message = errorHandler(exc);
                return Fail<T>(message);
            }
        }

        public static Result<T, E> Try<T, E>(Func<T> func, Func<Exception, E> errorHandler)
        {
            try
            {
                return Ok<T, E>(func());
            }
            catch (Exception exc)
            {
                E error = errorHandler(exc);
                return Fail<T, E>(error);
            }
        }

        public static async Task<Result<T, E>> Try<T, E>(Func<Task<T>> func, Func<Exception, E> errorHandler)
        {
            try
            {
                var result = await func().ConfigureAwait(DefaultConfigureAwait);
                return Ok<T, E>(result);
            }
            catch (Exception exc)
            {
                E error = errorHandler(exc);
                return Fail<T, E>(error);
            }
        }
    }
}
