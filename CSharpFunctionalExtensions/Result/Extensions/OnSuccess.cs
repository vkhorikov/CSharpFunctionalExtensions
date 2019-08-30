using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Result<K, E> OnSuccess<T, K, E>(this Result<T, E> result,
            Func<T, K> func)
        {
            if (result.IsFailure)
                return Result.Fail<K, E>(result.Error);

            return Result.Ok<K, E>(func(result.Value));
        }

        public static Result<K> OnSuccess<T, K>(this Result<T> result, Func<T, K> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return Result.Ok(func(result.Value));
        }

        public static Result<T> OnSuccess<T>(this Result result, Func<T> func)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            return Result.Ok(func());
        }

        public static Result<K, E> OnSuccess<T, K, E>(this Result<T, E> result,
            Func<T, Result<K, E>> func)
        {
            if (result.IsFailure)
                return Result.Fail<K, E>(result.Error);

            return func(result.Value);
        }

        public static Result<K> OnSuccess<T, K>(this Result<T> result, Func<T, Result<K>> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return func(result.Value);
        }

        public static Result<T> OnSuccess<T>(this Result result, Func<Result<T>> func)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            return func();
        }

        public static Result<K, E> OnSuccess<T, K, E>(this Result<T, E> result,
            Func<Result<K, E>> func)
        {
            if (result.IsFailure)
                return Result.Fail<K, E>(result.Error);

            return func();
        }

        public static Result<K> OnSuccess<T, K>(this Result<T> result, Func<Result<K>> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return func();
        }

        public static Result<K> OnSuccess<T, K, E>(this Result<T, E> result,
            Func<T, Result<K>> func)
        {
            if (result.IsFailure)
                return Result.Fail<K, E>(result.Error);

            return func(result.Value);
        }

        public static Result OnSuccess<T, K, E>(this Result<T, E> result,
            Func<T, Result> func)
        {
            if (result.IsFailure)
                return Result.Fail<K, E>(result.Error);

            return func(result.Value);
        }

        public static Result OnSuccess<T>(this Result<T> result, Func<T, Result> func)
        {
            if (result.IsFailure)
                return Result.Fail(result.Error);

            return func(result.Value);
        }

        public static Result OnSuccess(this Result result, Func<Result> func)
        {
            if (result.IsFailure)
                return result;

            return func();
        }

        public static Result<T, E> OnSuccess<T, E>(this Result<T, E> result,
            Action<T> action)
        {
            if (result.IsSuccess)
            {
                action(result.Value);
            }

            return result;
        }

        public static Result<T> OnSuccess<T>(this Result<T> result, Action<T> action)
        {
            if (result.IsSuccess)
            {
                action(result.Value);
            }

            return result;
        }

        public static Result OnSuccess(this Result result, Action action)
        {
            if (result.IsSuccess)
            {
                action();
            }

            return result;
        }
    }
}
