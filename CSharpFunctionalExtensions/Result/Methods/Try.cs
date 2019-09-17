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
                return Success();
            }
            catch (Exception exc)
            {
                string message = errorHandler(exc);
                return Failure(message);
            }
        }

        public static Result<T> Try<T>(Func<T> func, Func<Exception, string> errorHandler = null)
        {
            errorHandler = errorHandler ?? DefaultTryErrorHandler;

            try
            {
                return Success(func());
            }
            catch (Exception exc)
            {
                string message = errorHandler(exc);
                return Failure<T>(message);
            }
        }

        public static async Task<Result<T>> Try<T>(Func<Task<T>> func, Func<Exception, string> errorHandler = null)
        {
            errorHandler = errorHandler ?? DefaultTryErrorHandler;

            try
            {
                var result = await func().ConfigureAwait(DefaultConfigureAwait);
                return Success(result);
            }
            catch (Exception exc)
            {
                string message = errorHandler(exc);
                return Failure<T>(message);
            }
        }

        public static Result<T, E> Try<T, E>(Func<T> func, Func<Exception, E> errorHandler)
        {
            try
            {
                return Success<T, E>(func());
            }
            catch (Exception exc)
            {
                E error = errorHandler(exc);
                return Failure<T, E>(error);
            }
        }

        public static async Task<Result<T, E>> Try<T, E>(Func<Task<T>> func, Func<Exception, E> errorHandler)
        {
            try
            {
                var result = await func().ConfigureAwait(DefaultConfigureAwait);
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
