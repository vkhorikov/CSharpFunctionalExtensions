using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success and the condition is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static Result TapIfTry(this Result result, bool condition, Action action, Func<Exception, string> errorHandler = null)
        {
            errorHandler ??= Result.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (condition && result.IsSuccess)
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
        ///     Executes the given action if the calling result is a success and the condition is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static Result<T> TapIfTry<T>(this Result<T> result, bool condition, Action action, Func<Exception, string> errorHandler = null)
        {
            errorHandler ??= Result.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (condition && result.IsSuccess)
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
        ///     Executes the given action if the calling result is a success and the condition is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static Result<T> TapIfTry<T>(this Result<T> result, bool condition, Action<T> action, Func<Exception, string> errorHandler = null)
        {
            errorHandler ??= Result.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (condition && result.IsSuccess)
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
        ///     Executes the given action if the calling result is a success and the condition is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static UnitResult<E> TapIfTry<E>(this UnitResult<E> result, bool condition, Action action, Func<Exception, E> errorHandler)
        {
            try
            {
                if (condition && result.IsSuccess)
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
        ///     Executes the given action if the calling result is a success and the condition is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static Result<T, E> TapIfTry<T, E>(this Result<T, E> result, bool condition, Action action, Func<Exception, E> errorHandler)
        {
            try
            {
                if (condition && result.IsSuccess)
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
        ///     Executes the given action if the calling result is a success and the condition is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static Result<T, E> TapIfTry<T, E>(this Result<T, E> result, bool condition, Action<T> action, Func<Exception, E> errorHandler)
        {
            try
            {
                if (condition && result.IsSuccess)
                    action(result.Value);

                return result;
            }
            catch (Exception exc)
            {
                var error = errorHandler(exc);
                return new Result<T, E>(true, error, default);
            }
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and the predicate is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static Result<T> TapIfTry<T>(this Result<T> result, Func<T, bool> predicate, Action action, Func<Exception, string> errorHandler = null)
        {
            errorHandler ??= Result.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (result.IsSuccess && predicate(result.Value) && result.IsSuccess)
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
        ///     Executes the given action if the calling result is a success and the predicate is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static Result<T> TapIfTry<T>(this Result<T> result, Func<T, bool> predicate, Action<T> action, Func<Exception, string> errorHandler = null)
        {
            errorHandler ??= Result.Configuration.DefaultTryErrorHandler;
            
            try
            {
                if (result.IsSuccess && predicate(result.Value))
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
        ///     Executes the given action if the calling result is a success and the predicate is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static Result<T, E> TapIfTry<T, E>(this Result<T, E> result, Func<T, bool> predicate, Action action, Func<Exception, E> errorHandler)
        {
            try
            {
                if (result.IsSuccess && predicate(result.Value))
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
        ///     Executes the given action if the calling result is a success and the predicate is true. Returns the calling result.
        ///     If there is an exception, returns a new failure Result.
        /// </summary>
        public static Result<T, E> TapIfTry<T, E>(this Result<T, E> result, Func<T, bool> predicate, Action<T> action, Func<Exception, E> errorHandler)
        {
            try
            {
                if (result.IsSuccess && predicate(result.Value))
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
