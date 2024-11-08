using System;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static Result<T> ToResult<T>(in this Maybe<T> maybe, string errorMessage)
        {
            if (maybe.HasNoValue)
                return Result.Failure<T>(errorMessage);

            return Result.Success(maybe.GetValueOrThrow());
        }

        public static Result<T, E> ToResult<T, E>(in this Maybe<T> maybe, E error)
        {
            if (maybe.HasNoValue)
                return Result.Failure<T, E>(error);

            return Result.Success<T, E>(maybe.GetValueOrThrow());
        }

        public static Result<T, E> ToResult<T, E>(in this Maybe<T> maybe, Func<E> errorFunc)
        {
            if (maybe.HasNoValue)
                return Result.Failure<T, E>(errorFunc());

            return Result.Success<T, E>(maybe.GetValueOrThrow());
        }
    }
}
