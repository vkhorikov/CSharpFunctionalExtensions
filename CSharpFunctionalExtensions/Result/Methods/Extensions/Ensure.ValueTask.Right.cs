#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this Result<T> result, Func<T, ValueTask<bool>> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).DefaultAwait())
                return Result.Failure<T>(errorMessage);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T, E>> Ensure<T, E>(this Result<T, E> result,
            Func<T, ValueTask<bool>> predicate, E error)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).DefaultAwait())
                return Result.Failure<T, E>(error);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T, E>> Ensure<T, E>(this Result<T, E> result,
            Func<T, ValueTask<bool>> predicate, Func<T, E> errorPredicate)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).DefaultAwait())
                return Result.Failure<T, E>(errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T, E>> Ensure<T, E>(this Result<T, E> result,
            Func<T, ValueTask<bool>> predicate, Func<T, ValueTask<E>> errorPredicate)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).DefaultAwait())
                return Result.Failure<T, E>(await errorPredicate(result.Value).DefaultAwait());

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this Result<T> result, Func<T, ValueTask<bool>> predicate, Func<T, string> errorPredicate)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).DefaultAwait())
                return Result.Failure<T>(errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this Result<T> result, Func<T, ValueTask<bool>> predicate, Func<T, ValueTask<string>> errorPredicate)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).DefaultAwait())
                return Result.Failure<T>(await errorPredicate(result.Value).DefaultAwait());

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result> Ensure(this Result result, Func<ValueTask<bool>> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate().DefaultAwait())
                return Result.Failure(errorMessage);

            return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result> Ensure(this Result result, Func<ValueTask<Result>> predicate)
        {
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate().DefaultAwait();
          
          if (predicateResult.IsFailure)
            return Result.Failure(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this Result<T> result, Func<ValueTask<Result>> predicate)
        {
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate().DefaultAwait();
          
          if (predicateResult.IsFailure)
            return Result.Failure<T>(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result> Ensure<T>(this Result result, Func<ValueTask<Result<T>>> predicate)
        {
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate().DefaultAwait();
          
          if (predicateResult.IsFailure)
            return Result.Failure<T>(predicateResult.Error);

          return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this Result<T> result, Func<ValueTask<Result<T>>> predicate)
        {
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate().DefaultAwait();
          
          if (predicateResult.IsFailure)
            return Result.Failure<T>(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this Result<T> result, Func<T,ValueTask<Result>> predicate)
        {
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate(result.Value).DefaultAwait();
          
          if (predicateResult.IsFailure)
            return Result.Failure<T>(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this Result<T> result, Func<T,ValueTask<Result<T>>> predicate)
        {
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate(result.Value).DefaultAwait();
          
          if (predicateResult.IsFailure)
            return Result.Failure<T>(predicateResult.Error);

          return result;
        }
    }
}
#endif