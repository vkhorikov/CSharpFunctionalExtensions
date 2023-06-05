using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static Result TapTry(this Result result, Action action, Func<Exception, string> errorHandler = null)
        {
            errorHandler ??= Result.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (result.IsSuccess)
                    action();

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
        public static Result<T> TapTry<T>(this Result<T> result, Action action, Func<Exception, string> errorHandler = null)
        {
            errorHandler ??= Result.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (result.IsSuccess)
                    action();

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
        public static Result<T> TapTry<T>(this Result<T> result, Action<T> action, Func<Exception, string> errorHandler = null)
        {
            errorHandler ??= Result.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (result.IsSuccess)
                    action(result.Value);

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
        public static UnitResult<E> TapTry<E>(this UnitResult<E> result, Action action, Func<Exception, E> errorHandler)
        {
            try
            {
                if (result.IsSuccess)
                    action();

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
        public static Result<T, E> TapTry<T, E>(this Result<T, E> result, Action action, Func<Exception, E> errorHandler)
        {
            try
            {
                if (result.IsSuccess)
                    action();

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
        public static Result<T, E> TapTry<T, E>(this Result<T, E> result, Action<T> action, Func<Exception, E> errorHandler)
        {
            try
            {
                if (result.IsSuccess)
                    action(result.Value);

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
