using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Result> MapError(
            this Result result,
            Func<string, Task<string>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return Result.Success();
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return Result.Failure(error);
        }

        public static async Task<Result> MapError<TContext>(
            this Result result,
            Func<string, TContext, Task<string>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return Result.Success();
            }

            var error = await errorFactory(result.Error, context).DefaultAwait();
            return Result.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<UnitResult<E>> MapError<E>(
            this Result result,
            Func<string, Task<E>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return UnitResult.Success<E>();
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return UnitResult.Failure(error);
        }

        public static async Task<UnitResult<E>> MapError<E, TContext>(
            this Result result,
            Func<string, TContext, Task<E>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return UnitResult.Success<E>();
            }

            var error = await errorFactory(result.Error, context).DefaultAwait();
            return UnitResult.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Result<T>> MapError<T>(
            this Result<T> result,
            Func<string, Task<string>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return Result.Success(result.Value);
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return Result.Failure<T>(error);
        }

        public static async Task<Result<T>> MapError<T, TContext>(
            this Result<T> result,
            Func<string, TContext, Task<string>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return Result.Success(result.Value);
            }

            var error = await errorFactory(result.Error, context).DefaultAwait();
            return Result.Failure<T>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Result<T, E>> MapError<T, E>(
            this Result<T> result,
            Func<string, Task<E>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return Result.Success<T, E>(result.Value);
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return Result.Failure<T, E>(error);
        }

        public static async Task<Result<T, E>> MapError<T, E, TContext>(
            this Result<T> result,
            Func<string, TContext, Task<E>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return Result.Success<T, E>(result.Value);
            }

            var error = await errorFactory(result.Error, context).DefaultAwait();
            return Result.Failure<T, E>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Result> MapError<E>(
            this UnitResult<E> result,
            Func<E, Task<string>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return Result.Success();
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return Result.Failure(error);
        }

        public static async Task<Result> MapError<E, TContext>(
            this UnitResult<E> result,
            Func<E, TContext, Task<string>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return Result.Success();
            }

            var error = await errorFactory(result.Error, context).DefaultAwait();
            return Result.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<UnitResult<E2>> MapError<E, E2>(
            this UnitResult<E> result,
            Func<E, Task<E2>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return UnitResult.Success<E2>();
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return UnitResult.Failure(error);
        }

        public static async Task<UnitResult<E2>> MapError<E, E2, TContext>(
            this UnitResult<E> result,
            Func<E, TContext, Task<E2>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return UnitResult.Success<E2>();
            }

            var error = await errorFactory(result.Error, context).DefaultAwait();
            return UnitResult.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Result<T>> MapError<T, E>(
            this Result<T, E> result,
            Func<E, Task<string>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return Result.Success(result.Value);
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return Result.Failure<T>(error);
        }

        public static async Task<Result<T>> MapError<T, E, TContext>(
            this Result<T, E> result,
            Func<E, TContext, Task<string>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return Result.Success(result.Value);
            }

            var error = await errorFactory(result.Error, context).DefaultAwait();
            return Result.Failure<T>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Result<T, E2>> MapError<T, E, E2>(
            this Result<T, E> result,
            Func<E, Task<E2>> errorFactory
        )
        {
            if (result.IsSuccess)
            {
                return Result.Success<T, E2>(result.Value);
            }

            var error = await errorFactory(result.Error).DefaultAwait();
            return Result.Failure<T, E2>(error);
        }

        public static async Task<Result<T, E2>> MapError<T, E, E2, TContext>(
            this Result<T, E> result,
            Func<E, TContext, Task<E2>> errorFactory,
            TContext context
        )
        {
            if (result.IsSuccess)
            {
                return Result.Success<T, E2>(result.Value);
            }

            var error = await errorFactory(result.Error, context).DefaultAwait();
            return Result.Failure<T, E2>(error);
        }
    }
}
