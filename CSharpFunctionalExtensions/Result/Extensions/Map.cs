using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        // Overloads that construct new results by wrapping a return value from a function
        // 

        public static Result<K, E> Map<T, K, E>(this Result<T, E> result, Func<T, K> func)
        {
            if (result.IsFailure)
                return Result.Fail<K, E>(result.Error);

            return Result.Ok<K, E>(func(result.Value));
        }

        public static Result<K> Map<T, K>(this Result<T> result, Func<T, K> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return Result.Ok(func(result.Value));
        }

        public static Result<T> Map<T>(this Result result, Func<T> func)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            return Result.Ok(func());
        }

        // Overloads that pass on a new Result returned by a function
        // 

        public static Result<K, E> Map<T, K, E>(this Result<T, E> result, Func<T, Result<K, E>> func)
        {
            if (result.IsFailure)
                return Result.Fail<K, E>(result.Error);

            return func(result.Value);
        }

        public static Result<K> Map<T, K>(this Result<T> result, Func<T, Result<K>> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return func(result.Value);
        }

        public static Result<T> Map<T>(this Result result, Func<Result<T>> func)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            return func();
        }

        public static Result<K> Map<T, K, E>(this Result<T, E> result, Func<T, Result<K>> func)
        {
            if (result.IsFailure)
                return Result.Fail<K, E>(result.Error);

            return func(result.Value);
        }

        public static Result Map<T>(this Result<T> result, Func<T, Result> func)
        {
            if (result.IsFailure)
                return Result.Fail(result.Error);

            return func(result.Value);
        }

        public static Result Map(this Result result, Func<Result> func)
        {
            if (result.IsFailure)
                return result;

            return func();
        }
    }
}
