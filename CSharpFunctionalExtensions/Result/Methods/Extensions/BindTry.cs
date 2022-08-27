using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static Result BindTry(this Result result, Func<Result> func,
            Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? result
                : Result.Try(() => func(), errorHandler).Bind(r => r);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static Result<K> BindTry<K>(this Result result, Func<Result<K>> func,
            Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? Result.Failure<K>(result.Error)
                : Result.Try(() => func(), errorHandler).Bind(r => r);
        }


        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static Result BindTry<T>(this Result<T> result, Func<T, Result> func,
            Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? Result.Failure(result.Error)
                : Result.Try(() => func(result.Value), errorHandler).Bind(r => r);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static Result<K> BindTry<T, K>(this Result<T> result, Func<T, Result<K>> func,
            Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? Result.Failure<K>(result.Error)
                : Result.Try(() => func(result.Value), errorHandler).Bind(r => r);
        }

        /// <summary>
        ///    Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.        
        ///    If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static Result<K, E> BindTry<T, K, E>(this Result<T, E> result, Func<T, Result<K, E>> func,
            Func<Exception, E> errorHandler)
        {            
            return result.IsFailure
                ? Result.Failure<K,E>(result.Error)
                : Result.Try(() => func(result.Value), errorHandler).Bind(r => r);           
        }


        /// <summary>
        ///     Selects result from the return value of a given function. If the calling UnitResult is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static UnitResult<E> BindTry<E>(this UnitResult<E> result, Func<UnitResult<E>> func,
            Func<Exception, E> errorHandler)
        {
            return result.IsFailure
                ? result
                : Result.Try(() => func(), errorHandler).Bind(r => r);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling UnitResult is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static Result<T, E> BindTry<T, E>(this UnitResult<E> result, Func<Result<T, E>> func,
            Func<Exception, E> errorHandler)
        {
            return result.IsFailure
                ? Result.Failure<T, E>(result.Error)
                : Result.Try(() => func(), errorHandler).Bind(r => r);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static UnitResult<E> BindTry<T, E>(this Result<T, E> result, Func<T, UnitResult<E>> func,
            Func<Exception, E> errorHandler)
        {
            return result.IsFailure
                ? Result.Failure<T, E>(result.Error)
                : Result.Try(() => func(result.Value), errorHandler).Bind(r => r);
        }
    }
}