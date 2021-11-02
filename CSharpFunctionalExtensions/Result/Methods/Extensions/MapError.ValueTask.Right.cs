#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async ValueTask<Result> MapError(this Result result, Func<string, ValueTask<string>> errorFactory)
        {
            if (result.IsSuccess)
            {
                return Result.Success();
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return Result.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async ValueTask<UnitResult<E>> MapError<E>(this Result result, Func<string, ValueTask<E>> errorFactory)
        {
            if (result.IsSuccess)
            {
                return UnitResult.Success<E>();
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return UnitResult.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async ValueTask<Result<T>> MapError<T>(this Result<T> result, Func<string, ValueTask<string>> errorFactory)
        {
            if (result.IsSuccess)
            {
                return Result.Success(result.Value);
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return Result.Failure<T>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async ValueTask<Result<T, E>> MapError<T, E>(this Result<T> result, Func<string, ValueTask<E>> errorFactory)
        {
            if (result.IsSuccess)
            {
                return Result.Success<T, E>(result.Value);
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return Result.Failure<T, E>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async ValueTask<Result> MapError<E>(this UnitResult<E> result, Func<E, ValueTask<string>> errorFactory)
        {
            if (result.IsSuccess)
            {
                return Result.Success();
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return Result.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async ValueTask<UnitResult<E2>> MapError<E, E2>(this UnitResult<E> result, Func<E, ValueTask<E2>> errorFactory)
        {
            if (result.IsSuccess)
            {
                return UnitResult.Success<E2>();
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return UnitResult.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async ValueTask<Result<T>> MapError<T, E>(this Result<T, E> result, Func<E, ValueTask<string>> errorFactory)
        {
            if (result.IsSuccess)
            {
                return Result.Success(result.Value);
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return Result.Failure<T>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async ValueTask<Result<T, E2>> MapError<T, E, E2>(this Result<T, E> result, Func<E, ValueTask<E2>> errorFactory)
        {
            if (result.IsSuccess)
            {
                return Result.Success<T, E2>(result.Value);
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return Result.Failure<T, E2>(error);
        }
    }
}
#endif