using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Result Combine(this IEnumerable<Result> results, string errorMessageSeparator = null)
            => Result.Combine(results, errorMessageSeparator);

        public static Result<IEnumerable<T>> Combine<T>(this IEnumerable<Result<T>> results, string errorMessageSeparator = null)
        {
            Result result = Result.Combine(results, errorMessageSeparator);

            return result.IsSuccess
                ? Result.Success(results.Select(e => e.Value))
                : Result.Fail<IEnumerable<T>>(result.Error);
        }

        public static Result<K> Combine<T, K>(this IEnumerable<Result<T>> results, Func<IEnumerable<T>, K> composer,
            string errorMessageSeparator = null)
        {
            Result<IEnumerable<T>> result = results.Combine(errorMessageSeparator);

            return result.IsSuccess
                ? Result.Success(composer(result.Value))
                : Result.Fail<K>(result.Error);
        }
    }
}
