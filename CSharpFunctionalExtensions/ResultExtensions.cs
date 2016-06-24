using System;


namespace CSharpFunctionalExtensions
{
    public static class ResultExtensions
    {
        public static Result<K> OnSuccess<T, K>(this Result<T> result, Func<T, K> func)
        {
            if (result.IsFailure)
                return result.MapFailure<K>();

            return Result.Ok(func(result.Value));
        }

        public static Result<K> OnSuccess<T, K>(this Result<T> result, Func<T, Result<K>> func)
        {
            if (result.IsFailure)
                return result.MapFailure<K>();

            return func(result.Value);
        }

        public static Result OnSuccess<T>(this Result<T> result, Func<T, Result> func)
        {
            if (result.IsFailure)
                return result;

            return func(result.Value);
        }

        public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return result;

            if (!predicate(result.Value))
                return Result.Fail<T>(errorMessage);

            return result;
        }

        public static Result<K> Map<T, K>(this Result<T> result, Func<T, K> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return Result.Ok(func(result.Value));
        }

        public static Result<T> MapFailure<T>(this Result result)
        {
            if (result.IsSuccess)
                throw new InvalidOperationException();

            return Result.Fail<T>(result.Error);
        }

        public static Result<T> OnSuccess<T>(this Result<T> result, Action<T> action)
        {
            if (result.IsSuccess)
            {
                action(result.Value);
            }

            return result;
        }

        public static T OnBoth<T>(this Result result, Func<Result, T> func)
        {
            return func(result);
        }

        public static Result OnSuccess(this Result result, Action action)
        {
            if (result.IsSuccess)
            {
                action();
            }

            return result;
        }

        public static Result<T> OnSuccess<T>(this Result result, Func<T> func)
        {
            if (result.IsFailure)
            {
                return result.MapFailure<T>();
            }

            return Result.Ok(func());
        }

        public static Result<T> OnSuccess<T>(this Result result, Func<Result<T>> func)
        {
            if (result.IsFailure)
            {
                return result.MapFailure<T>();
            }

            return func();
        }
    }
}
