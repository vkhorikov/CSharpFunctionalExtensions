using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Result<T>> Ensure<T>(this Result<T> result, Func<T, Task<bool>> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).ConfigureAwait(Result.DefaultConfigureAwait))
                return Result.Failure<T>(errorMessage);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Result<T, E>> Ensure<T, E>(this Result<T, E> result,
            Func<T, Task<bool>> predicate, E error)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).ConfigureAwait(Result.DefaultConfigureAwait))
                return Result.Failure<T, E>(error);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async Task<Result> Ensure(this Result result, Func<Task<bool>> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate().ConfigureAwait(Result.DefaultConfigureAwait))
                return Result.Failure(errorMessage);

            return result;
        }
    }
}
