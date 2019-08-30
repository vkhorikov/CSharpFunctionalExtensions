using System;
using System.Collections.Generic;
using System.Linq;

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

        public static Result<T, E> Ensure<T, E>(this Result<T, E> result,
            Func<T, bool> predicate, E error)
        {
            if (result.IsFailure)
                return result;

            if (!predicate(result.Value))
                return Result.Fail<T, E>(error);

            return result;
        }

        public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return result;

            if (!predicate(result.Value))
                return Result.Fail<T>(errorMessage);

            return result;
        }

        public static Result Ensure(this Result result, Func<bool> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return result;

            if (!predicate())
                return Result.Fail(errorMessage);

            return result;
        }

        public static Result<K, E> Map<T, K, E>(this Result<T, E> result,
            Func<T, K> func)
            => result.OnSuccess(func);

        public static Result<K> Map<T, K>(this Result<T> result, Func<T, K> func)
            => result.OnSuccess(func);

        public static Result<T> Map<T>(this Result result, Func<T> func)
            => result.OnSuccess(func);

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

        public static Result OnSuccessTry(this Result result, Action action, Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? result
                : Result.Try(action, errorHandler);
        }

        public static Result<T> OnSuccessTry<T>(this Result result, Func<T> func, Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? Result.Fail<T>(result.Error)
                : Result.Try(func, errorHandler);
        }

        public static Result OnSuccessTry<T>(this Result<T> result, Action<T> action, Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? Result.Fail(result.Error)
                : Result.Try(() => action(result.Value), errorHandler);
        }

        public static Result<K> OnSuccessTry<T, K>(this Result<T> result, Func<T, K> func, Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? Result.Fail<K>(result.Error)
                : Result.Try(() => func(result.Value), errorHandler);
        }

        public static T OnBoth<T>(this Result result, Func<Result, T> func)
        {
            return func(result);
        }

        public static K OnBoth<T, K>(this Result<T> result, Func<Result<T>, K> func)
        {
            return func(result);
        }

        public static K OnBoth<T, K, E>(this Result<T, E> result, Func<Result<T, E>, K> func)
        {
            return func(result);
        }

        public static T OnBoth<T, E>(this Result<T, E> result,
            Func<Result<T, E>, T> func)
        {
            return func(result);
        }

        public static Result<T, E> OnFailure<T, E>(this Result<T, E> result,
            Action action)
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

        public static Result<T, E> OnFailure<T, E>(this Result<T, E> result,
            Action<E> action)
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

        public static Result<T, E> OnFailureCompensate<T, E>(this Result<T, E> result,
            Func<Result<T, E>> func)
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

        public static Result<T, E> OnFailureCompensate<T, E>(this Result<T, E> result,
            Func<E, Result<T, E>> func)
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

        public static Result Combine(this IEnumerable<Result> results, string errorMessagesSeparator)
        {
            return Result.Combine(errorMessagesSeparator, results as Result[] ?? results.ToArray());
        }

        public static Result Combine(this IEnumerable<Result> results)
        {
            return Result.Combine(results as Result[] ?? results.ToArray());
        }

        public static Result<IEnumerable<T>> Combine<T>(this IEnumerable<Result<T>> results, string errorMessagesSeparator)
        {
            var data = results as Result<T>[] ?? results.ToArray();

            var result = Result.Combine(errorMessagesSeparator, data);

            return result.IsSuccess
                ? Result.Ok(data.Select(e => e.Value))
                : Result.Fail<IEnumerable<T>>(result.Error);
        }

        public static Result<IEnumerable<T>> Combine<T>(this IEnumerable<Result<T>> results)
        {
            var data = results as Result<T>[] ?? results.ToArray();

            var result = Result.Combine(data);

            return result.IsSuccess
                ? Result.Ok(data.Select(e => e.Value))
                : Result.Fail<IEnumerable<T>>(result.Error);
        }

        public static Result<K> Combine<T, K>(this IEnumerable<Result<T>> results,
            Func<IEnumerable<T>, K> composer,
            string errorMessageSeparator)
        {
            Result<IEnumerable<T>> result = results.Combine(errorMessageSeparator);

            return result.IsSuccess
                ? Result.Ok(composer(result.Value))
                : Result.Fail<K>(result.Error);
        }

        public static Result<K> Combine<T, K>(this IEnumerable<Result<T>> results,
            Func<IEnumerable<T>, K> composer)
        {
            Result<IEnumerable<T>> result = results.Combine();

            return result.IsSuccess
                ? Result.Ok(composer(result.Value))
                : Result.Fail<K>(result.Error);
        }

        public static TOutput Match<TOutput, TError, TValue>(this Result<TValue, TError> result, Func<TValue, TOutput> Ok, Func<TError, TOutput> Failure)
        {
            return result.IsSuccess
                ? Ok(result.Value)
                : Failure(result.Error);
        }

        public static TOutput Match<TOutput, TValue>(this Result<TValue> result, Func<TValue, TOutput> Ok, Func<string, TOutput> Failure)
        {
            return result.IsSuccess
                ? Ok(result.Value)
                : Failure(result.Error);
        }

        public static void Match<T>(this Result<T> result, Action<T> Ok, Action<string> Failure)
        {
            if (result.IsSuccess)
            {
                Ok(result.Value);
            }
            else
            {
                Failure(result.Error);
            }
        }

        public static void Match<TError, TValue>(this Result<TValue, TError> result, Action<TValue> Ok, Action<TError> Failure)
        {
            if (result.IsSuccess)
            {
                Ok(result.Value);
            }
            else
            {
                Failure(result.Error);
            }
        }

        public static T Match<T>(this Result result, Func<T> Ok, Func<string, T> Failure)
        {
            return result.IsSuccess
                ? Ok()
                : Failure(result.Error);
        }

        public static void Match(this Result result, Action Ok, Action<string> Failure)
        {
            if (result.IsSuccess)
            {
                Ok();
            }
            else
            {
                Failure(result.Error);
            }
        }
    }
}
