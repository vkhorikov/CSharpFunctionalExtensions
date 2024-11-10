using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static Result MapError(this Result result, Func<string, string> errorFactory)
        {
            if (result.IsFailure)
                return Result.Failure(errorFactory(result.Error));

            return Result.Success();
        }

        public static Result MapError<TContext>(
            this Result result,
            Func<string, TContext, string> errorFactory,
            TContext context
        )
        {
            if (result.IsFailure)
                return Result.Failure(errorFactory(result.Error, context));

            return Result.Success();
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static UnitResult<E> MapError<E>(this Result result, Func<string, E> errorFactory)
        {
            if (result.IsFailure)
                return UnitResult.Failure(errorFactory(result.Error));

            return UnitResult.Success<E>();
        }

        public static UnitResult<E> MapError<E, TContext>(
            this Result result,
            Func<string, TContext, E> errorFactory,
            TContext context
        )
        {
            if (result.IsFailure)
                return UnitResult.Failure(errorFactory(result.Error, context));

            return UnitResult.Success<E>();
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static Result<T> MapError<T>(
            this Result<T> result,
            Func<string, string> errorFactory
        )
        {
            if (result.IsFailure)
                return Result.Failure<T>(errorFactory(result.Error));

            return Result.Success(result.Value);
        }

        public static Result<T> MapError<T, TContext>(
            this Result<T> result,
            Func<string, TContext, string> errorFactory,
            TContext context
        )
        {
            if (result.IsFailure)
                return Result.Failure<T>(errorFactory(result.Error, context));

            return Result.Success(result.Value);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static Result<T, E> MapError<T, E>(
            this Result<T> result,
            Func<string, E> errorFactory
        )
        {
            if (result.IsFailure)
                return Result.Failure<T, E>(errorFactory(result.Error));

            return Result.Success<T, E>(result.Value);
        }

        public static Result<T, E> MapError<T, E, TContext>(
            this Result<T> result,
            Func<string, TContext, E> errorFactory,
            TContext context
        )
        {
            if (result.IsFailure)
                return Result.Failure<T, E>(errorFactory(result.Error, context));

            return Result.Success<T, E>(result.Value);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static Result MapError<E>(this UnitResult<E> result, Func<E, string> errorFactory)
        {
            if (result.IsFailure)
                return Result.Failure(errorFactory(result.Error));

            return Result.Success();
        }

        public static Result MapError<E, TContext>(
            this UnitResult<E> result,
            Func<E, TContext, string> errorFactory,
            TContext context
        )
        {
            if (result.IsFailure)
                return Result.Failure(errorFactory(result.Error, context));

            return Result.Success();
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static UnitResult<E2> MapError<E, E2>(
            this UnitResult<E> result,
            Func<E, E2> errorFactory
        )
        {
            if (result.IsFailure)
                return UnitResult.Failure(errorFactory(result.Error));

            return UnitResult.Success<E2>();
        }

        public static UnitResult<E2> MapError<E, E2, TContext>(
            this UnitResult<E> result,
            Func<E, TContext, E2> errorFactory,
            TContext context
        )
        {
            if (result.IsFailure)
                return UnitResult.Failure(errorFactory(result.Error, context));

            return UnitResult.Success<E2>();
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static Result<T> MapError<T, E>(
            this Result<T, E> result,
            Func<E, string> errorFactory
        )
        {
            if (result.IsFailure)
                return Result.Failure<T>(errorFactory(result.Error));

            return Result.Success(result.Value);
        }

        public static Result<T> MapError<T, E, TContext>(
            this Result<T, E> result,
            Func<E, TContext, string> errorFactory,
            TContext context
        )
        {
            if (result.IsFailure)
                return Result.Failure<T>(errorFactory(result.Error, context));

            return Result.Success(result.Value);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static Result<T, E2> MapError<T, E, E2>(
            this Result<T, E> result,
            Func<E, E2> errorFactory
        )
        {
            if (result.IsFailure)
                return Result.Failure<T, E2>(errorFactory(result.Error));

            return Result.Success<T, E2>(result.Value);
        }

        public static Result<T, E2> MapError<T, E, E2, TContext>(
            this Result<T, E> result,
            Func<E, TContext, E2> errorFactory,
            TContext context
        )
        {
            if (result.IsFailure)
                return Result.Failure<T, E2>(errorFactory(result.Error, context));

            return Result.Success<T, E2>(result.Value);
        }
    }
}
