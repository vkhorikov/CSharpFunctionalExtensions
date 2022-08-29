#if NET5_0_OR_GREATER
using System.Threading.Tasks;
using System;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static async ValueTask<Result<K, E>> BindTry<T, K, E>(this Result<T, E> result, Func<T, ValueTask<Result<K, E>>> func,
            Func<Exception, E> errorHandler, bool _ = default)
        {
            return result.IsFailure
                ? Result.Failure<K, E>(result.Error)
                : await Result.Try(() => func(result.Value),errorHandler).Bind(r => r);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static async ValueTask<Result<K>> BindTry<T, K>(this Result<T> result, Func<T, ValueTask<Result<K>>> func,
            Func<Exception, string> errorHandler = null, bool _ = default)
        {
            return result.IsFailure
                ? Result.Failure<K>(result.Error)
                : await Result.Try(() => func(result.Value), errorHandler).Bind(r => r);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static async ValueTask<Result<K>> BindTry<K>(this Result result, Func<ValueTask<Result<K>>> func,
            Func<Exception, string> errorHandler = null, bool _ = default)
        {
            return result.IsFailure
                ? Result.Failure<K>(result.Error)
                : await Result.Try(() => func(), errorHandler).Bind(r => r);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static async ValueTask<Result> BindTry<T>(this Result<T> result, Func<T, ValueTask<Result>> func,
            Func<Exception, string> errorHandler = null, bool _ = default)
        {
            return result.IsFailure
                ? Result.Failure(result.Error)
                : await Result.Try(() => func(result.Value), errorHandler).Bind(r => r);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static async ValueTask<Result> BindTry(this Result result, Func<ValueTask<Result>> func,
            Func<Exception, string> errorHandler = null, bool _ = default)
        {
            return result.IsFailure
                ? Result.Failure(result.Error)
                : await Result.Try(() => func(), errorHandler).Bind(r => r);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static async ValueTask<UnitResult<E>> BindTry<E>(this UnitResult<E> result, Func<ValueTask<UnitResult<E>>> func,
            Func<Exception, E> errorHandler, bool _ = default)
        {            
            return result.IsFailure
                ? UnitResult.Failure(result.Error)
                : await Result.Try(() => func(), errorHandler).Bind(r => r);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static async ValueTask<Result<T, E>> BindTry<T, E>(this UnitResult<E> result, Func<ValueTask<Result<T, E>>> func,
            Func<Exception, E> errorHandler, bool _ = default)
        {
            return result.IsFailure
                ? Result.Failure<T,E>(result.Error)
                : await Result.Try(() => func(), errorHandler).Bind(r => r);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given (or default) error handler
        /// </summary>
        public static async ValueTask<UnitResult<E>> BindTry<T, E>(this Result<T, E> result, Func<T, ValueTask<UnitResult<E>>> func,
            Func<Exception, E> errorHandler, bool _ = default)
        {
            return result.IsFailure
                ? UnitResult.Failure(result.Error)
                : await Result.Try(() => func(result.Value), errorHandler).Bind(r => r);           
        }
    }
}
#endif