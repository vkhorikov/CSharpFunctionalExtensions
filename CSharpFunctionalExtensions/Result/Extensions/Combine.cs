using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Result Combine(this IEnumerable<Result> results, string errorMessageSeparator = null)
            => Result.Combine(results, errorMessageSeparator);

        public static Result<IEnumerable<T>, E> Combine<T, E>(this IEnumerable<Result<T, E>> results)
            where E : ICombine
        {
            Result<bool, E> result = Result.Combine(results);

            return result.IsSuccess
                ? Result.Success<IEnumerable<T>, E>(results.Select(e => e.Value))
                : Result.Failure<IEnumerable<T>, E>(result.Error);
        }


        public static Result<IEnumerable<T>, E> Combine<T, E>(this IEnumerable<Result<T, E>> results, Func<IEnumerable<E>, E> composerError)
        {
            Result<bool, E> result = Result.Combine(results, composerError);

            return result.IsSuccess
                ? Result.Success<IEnumerable<T>, E>(results.Select(e => e.Value))
                : Result.Failure<IEnumerable<T>, E>(result.Error);
        }

        public static Result<IEnumerable<T>> Combine<T>(this IEnumerable<Result<T>> results, string errorMessageSeparator = null)
        {
            Result result = Result.Combine(results, errorMessageSeparator);

            return result.IsSuccess
                ? Result.Success(results.Select(e => e.Value))
                : Result.Failure<IEnumerable<T>>(result.Error);
        }

        public static Result<K, E> Combine<T, K, E>(this IEnumerable<Result<T, E>> results, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
        {
            Result<IEnumerable<T>, E> result = results.Combine(composerError);

            return result.IsSuccess
                ? Result.Success<K, E>(composer(result.Value))
                : Result.Failure<K, E>(result.Error);
        }

        public static Result<K, E> Combine<T, K, E>(this IEnumerable<Result<T, E>> results, Func<IEnumerable<T>, K> composer)
            where E : ICombine
        {
            Result<IEnumerable<T>, E> result = results.Combine<T, E>();

            return result.IsSuccess
                ? Result.Success<K, E>(composer(result.Value))
                : Result.Failure<K, E>(result.Error);
        }

        public static Result<K> Combine<T, K>(this IEnumerable<Result<T>> results, Func<IEnumerable<T>, K> composer,
            string errorMessageSeparator = null)
        {
            Result<IEnumerable<T>> result = results.Combine(errorMessageSeparator);

            return result.IsSuccess
                ? Result.Success(composer(result.Value))
                : Result.Failure<K>(result.Error);
        }
    }
}
