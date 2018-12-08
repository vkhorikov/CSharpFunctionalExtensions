using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Result<TNewValue, TError> OnSuccess<TValue, TNewValue, TError>(this Result<TValue, TError> result,
            Func<TValue, TNewValue> func) where TError : class
        {
            if (result.IsFailure)
                return Result.Fail<TNewValue, TError>(result.Error);

            return Result.Ok<TNewValue, TError>(func(result.Value));
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

        public static Result<TNewValue, TError> OnSuccess<TValue, TNewValue, TError>(this Result<TValue, TError> result,
            Func<TValue, Result<TNewValue, TError>> func) where TError : class
        {
            if (result.IsFailure)
                return Result.Fail<TNewValue, TError>(result.Error);

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

        public static Result<TNewValue, TError> OnSuccess<TValue, TNewValue, TError>(this Result<TValue, TError> result,
            Func<Result<TNewValue, TError>> func) where TError : class
        {
            if (result.IsFailure)
                return Result.Fail<TNewValue, TError>(result.Error);

            return func();
        }

        public static Result<K> OnSuccess<T, K>(this Result<T> result, Func<Result<K>> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return func();
        }

        public static Result<TNewValue> OnSuccess<TValue, TNewValue, TError>(this Result<TValue, TError> result,
            Func<TValue, Result<TNewValue>> func) where TError : class
        {
            if (result.IsFailure)
                return Result.Fail<TNewValue, TError>(result.Error);

            return func(result.Value);
        }

        public static Result OnSuccess<TValue, TNewValue, TError>(this Result<TValue, TError> result,
            Func<TValue, Result> func) where TError : class
        {
            if (result.IsFailure)
                return Result.Fail<TNewValue, TError>(result.Error);

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

        public static Result<TValue, TError> Ensure<TValue, TError>(this Result<TValue, TError> result,
            Func<TValue, bool> predicate, TError errorObject) where TError : class
        {
            if (result.IsFailure)
                return Result.Fail<TValue, TError>(result.Error);

            if (!predicate(result.Value))
                return Result.Fail<TValue, TError>(errorObject);

            return Result.Ok<TValue, TError>(result.Value);
        }

        public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            if (!predicate(result.Value))
                return Result.Fail<T>(errorMessage);

            return Result.Ok(result.Value);
        }

        public static Result Ensure(this Result result, Func<bool> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return Result.Fail(result.Error);

            if (!predicate())
                return Result.Fail(errorMessage);

            return Result.Ok();
        }

        public static Result<TNewValue, TError> Map<TValue, TNewValue, TError>(this Result<TValue, TError> result,
            Func<TValue, TNewValue> func) where TError : class
        {
            if (result.IsFailure)
                return Result.Fail<TNewValue, TError>(result.Error);

            return Result.Ok<TNewValue, TError>(func(result.Value));
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

        public static Result<TValue, TError> OnSuccess<TValue, TError>(this Result<TValue, TError> result,
            Action<TValue> action) where TError : class
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

        public static T OnBoth<T>(this Result result, Func<Result, T> func)
        {
            return func(result);
        }

        public static K OnBoth<T, K>(this Result<T> result, Func<Result<T>, K> func)
        {
            return func(result);
        }

        public static K OnBoth<T, K, TError>(this Result<T, TError> result, Func<Result<T, TError>, K> func)
        {
            return func(result);
        }

        public static TValue OnBoth<TValue, TError>(this Result<TValue, TError> result,
            Func<Result<TValue, TError>, TValue> func) where TError : class
        {
            return func(result);
        }

        public static Result<TValue, TError> OnFailure<TValue, TError>(this Result<TValue, TError> result,
            Action action) where TError : class
        {
            if (result.IsFailure)
            {
                action();
            }

            return result;
        }

        public static Result<T> OnFailure<T>(this Result<T> result, Action action)
        {
            if (result.IsFailure)
            {
                action();
            }

            return result;
        }

        public static Result OnFailure(this Result result, Action action)
        {
            if (result.IsFailure)
            {
                action();
            }

            return result;
        }

        public static Result<TValue, TError> OnFailure<TValue, TError>(this Result<TValue, TError> result,
            Action<TError> action) where TError : class
        {
            if (result.IsFailure)
            {
                action(result.Error);
            }

            return result;
        }

        public static Result<T> OnFailure<T>(this Result<T> result, Action<string> action)
        {
            if (result.IsFailure)
            {
                action(result.Error);
            }

            return result;
        }

        public static Result OnFailure(this Result result, Action<string> action)
        {
            if (result.IsFailure)
            {
                action(result.Error);
            }

            return result;
        }

        public static Result<TValue, TError> OnFailureCompensate<TValue, TError>(this Result<TValue, TError> result,
            Func<Result<TValue, TError>> func) where TError : class
        {
            if (result.IsFailure)
                return func();

            return result;
        }

        public static Result<T> OnFailureCompensate<T>(this Result<T> result, Func<Result<T>> func)
        {
            if (result.IsFailure)
                return func();

            return result;
        }

        public static Result OnFailureCompensate(this Result result, Func<Result> func)
        {
            if (result.IsFailure)
                return func();

            return result;
        }

        public static Result<TValue, TError> OnFailureCompensate<TValue, TError>(this Result<TValue, TError> result,
            Func<TError, Result<TValue, TError>> func) where TError : class
        {
            if (result.IsFailure)
                return func(result.Error);

            return result;
        }

        public static Result<T> OnFailureCompensate<T>(this Result<T> result, Func<string, Result<T>> func)
        {
            if (result.IsFailure)
                return func(result.Error);

            return result;
        }

        public static Result OnFailureCompensate(this Result result, Func<string, Result> func)
        {
            if (result.IsFailure)
                return func(result.Error);

            return result;
        }
    }
}
