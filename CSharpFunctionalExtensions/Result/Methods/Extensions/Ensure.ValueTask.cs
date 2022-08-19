#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<bool>> predicate, string errorMessage)
        {
            Result<T> result = await resultTask;

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value))
                return Result.Failure<T>(errorMessage);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T, E>> Ensure<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<bool>> predicate, E error)
        {
            Result<T, E> result = await resultTask;

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value))
                return Result.Failure<T, E>(error);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T, E>> Ensure<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<bool>> predicate, Func<T, E> errorPredicate)
        {
            Result<T, E> result = await resultTask;

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value))
                return Result.Failure<T, E>(errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T, E>> Ensure<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<bool>> predicate, Func<T, ValueTask<E>> errorPredicate)
        {
            Result<T, E> result = await resultTask;

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value))
                return Result.Failure<T, E>(await errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<bool>> predicate, Func<T, string> errorPredicate)
        {
            Result<T> result = await resultTask;

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value))
                return Result.Failure<T>(errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<bool>> predicate, Func<T, ValueTask<string>> errorPredicate)
        {
            Result<T> result = await resultTask;

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value))
                return Result.Failure<T>(await errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result> Ensure(this ValueTask<Result> resultTask, Func<ValueTask<bool>> predicate, string errorMessage)
        {
            Result result = await resultTask;

            if (result.IsFailure)
                return result;

            if (!await predicate())
                return Result.Failure(errorMessage);

            return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result> Ensure(this ValueTask<Result> resultTask, Func<ValueTask<Result>> predicate)
        {
          Result result = await resultTask;
          
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate();
          
          if (predicateResult.IsFailure)
            return Result.Failure(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result>> predicate)
        {
          Result<T> result = await resultTask;
          
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate();
          
          if (predicateResult.IsFailure)
            return Result.Failure<T>(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result> Ensure<T>(this ValueTask<Result> resultTask, Func<ValueTask<Result<T>>> predicate)
        {
          Result result = await resultTask;
          
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate();
          
          if (predicateResult.IsFailure)
            return Result.Failure<T>(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result<T>>> predicate)
        {
          Result<T> result = await resultTask;
          
          if (result.IsFailure)
            return result;
        
          var predicateResult = await predicate();
          
          if (predicateResult.IsFailure)
            return Result.Failure<T>(predicateResult.Error);
        
          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T,ValueTask<Result>> predicate)
        {
          Result<T> result = await resultTask;
          
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate(result.Value);
          
          if (predicateResult.IsFailure)
            return Result.Failure<T>(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T,ValueTask<Result<T>>> predicate)
        {
          Result<T> result = await resultTask;
          
          if (result.IsFailure)
            return result;

          var predicateResult = await predicate(result.Value);
          
          if (predicateResult.IsFailure)
            return Result.Failure<T>(predicateResult.Error);

          return result;
        }
    }
}
#endif