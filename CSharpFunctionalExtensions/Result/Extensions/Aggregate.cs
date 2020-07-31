using System.Collections.Generic;
using System.Linq;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Creates a new result from a enumeration of results. If one fails the new result will have the combined result
        /// </summary>
        public static Result<IEnumerable<TValue>> Aggregate<TValue>(this IEnumerable<Result<TValue>> results, string errorMessagesSeparator = null)
        {
            Result<TValue>[] resultsArray = results.ToArray();
            Result combined = Result.Combine(resultsArray, errorMessagesSeparator);
            if (combined.IsFailure)
            {
                return Result.Failure<IEnumerable<TValue>>(combined.Error);
            }

            return Result.Success<IEnumerable<TValue>>(resultsArray.Select(result => result.Value).ToList());
        }

        /// <summary>
        ///     Creates a new result from a enumeration of results. If one fails the new result will have the combined result
        /// </summary>
        public static Result Aggregate(this IEnumerable<Result> results, string errorMessagesSeparator = null)
        {
            Result[] resultsArray = results.ToArray();
            Result combined = Result.Combine(resultsArray, errorMessagesSeparator);
            if (combined.IsFailure)
            {
                return Result.Failure(combined.Error);
            }

            return Result.Success();
        }
    }
}