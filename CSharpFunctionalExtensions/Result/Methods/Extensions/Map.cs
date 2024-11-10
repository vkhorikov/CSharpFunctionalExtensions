using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result<K, E> Map<T, K, E>(this Result<T, E> result, Func<T, K> func)
        {
            if (result.IsFailure)
                return Result.Failure<K, E>(result.Error);

            return Result.Success<K, E>(func(result.Value));
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result<K, E> Map<T, K, E, TContext>(
            this Result<T, E> result,
            Func<T, TContext, K> func,
            TContext context
        )
        {
            if (result.IsFailure)
                return Result.Failure<K, E>(result.Error);

            return Result.Success<K, E>(func(result.Value, context));
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result<K, E> Map<K, E>(this UnitResult<E> result, Func<K> func)
        {
            if (result.IsFailure)
                return Result.Failure<K, E>(result.Error);

            return Result.Success<K, E>(func());
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result<K, E> Map<K, E, TContext>(
            this UnitResult<E> result,
            Func<TContext, K> func,
            TContext context
        )
        {
            if (result.IsFailure)
                return Result.Failure<K, E>(result.Error);

            return Result.Success<K, E>(func(context));
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result<K> Map<T, K>(this Result<T> result, Func<T, K> func)
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            return Result.Success(func(result.Value));
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result<K> Map<T, K, TContext>(
            this Result<T> result,
            Func<T, TContext, K> func,
            TContext context
        )
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            return Result.Success(func(result.Value, context));
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result<K> Map<K>(this Result result, Func<K> func)
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            return Result.Success(func());
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result<K> Map<K, TContext>(
            this Result result,
            Func<TContext, K> func,
            TContext context
        )
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            return Result.Success(func(context));
        }
    }
}
