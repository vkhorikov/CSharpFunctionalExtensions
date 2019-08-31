using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Result Combine(this IEnumerable<Result> results, string errorMessageSeparator = null)
            => Result.Combine(results, errorMessageSeparator);

        //public static Result Combine(this IEnumerable<Result> results)
        //{
        //    return Result.Combine(results as Result[] ?? results.ToArray());
        //}

        public static Result<IEnumerable<T>> Combine<T>(this IEnumerable<Result<T>> results, string errorMessageSeparator = null)
        {
            Result result = Result.Combine(results, errorMessageSeparator);

            return result.IsSuccess
                ? Result.Ok(results.Select(e => e.Value))
                : Result.Fail<IEnumerable<T>>(result.Error);
        }

        //public static Result<IEnumerable<T>> Combine<T>(this IEnumerable<Result<T>> results)
        //{
        //    var data = results as Result<T>[] ?? results.ToArray();

        //    var result = Result.Combine(data);

        //    return result.IsSuccess
        //        ? Result.Ok(data.Select(e => e.Value))
        //        : Result.Fail<IEnumerable<T>>(result.Error);
        //}

        public static Result<K> Combine<T, K>(this IEnumerable<Result<T>> results, Func<IEnumerable<T>, K> composer,
            string errorMessageSeparator = null)
        {
            Result<IEnumerable<T>> result = results.Combine(errorMessageSeparator);

            return result.IsSuccess
                ? Result.Ok(composer(result.Value))
                : Result.Fail<K>(result.Error);
        }

        //public static Result<K> Combine<T, K>(this IEnumerable<Result<T>> results, Func<IEnumerable<T>, K> composer)
        //{
        //    Result<IEnumerable<T>> result = results.Combine();

        //    return result.IsSuccess
        //        ? Result.Ok(composer(result.Value))
        //        : Result.Fail<K>(result.Error);
        //}
    }
}
