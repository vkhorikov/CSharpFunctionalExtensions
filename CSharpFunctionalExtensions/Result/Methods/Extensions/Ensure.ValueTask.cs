#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<bool>> valueTaskPredicate, string errorMessage)
        {
            Result<T> result = await resultTask;

            if (result.IsFailure)
                return result;

            if (!await valueTaskPredicate(result.Value))
                return Result.Failure<T>(errorMessage);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T, E>> Ensure<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<bool>> valueTaskPredicate, E error)
        {
            Result<T, E> result = await resultTask;

            if (result.IsFailure)
                return result;

            if (!await valueTaskPredicate(result.Value))
                return Result.Failure<T, E>(error);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T, E>> Ensure<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<bool>> valueTaskPredicate, Func<T, E> valueTaskErrorPredicate)
        {
            Result<T, E> result = await resultTask;

            if (result.IsFailure)
                return result;

            if (!await valueTaskPredicate(result.Value))
                return Result.Failure<T, E>(valueTaskErrorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T, E>> Ensure<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<bool>> valueTaskPredicate, Func<T, ValueTask<E>> valueTaskErrorPredicate)
        {
            Result<T, E> result = await resultTask;

            if (result.IsFailure)
                return result;

            if (!await valueTaskPredicate(result.Value))
                return Result.Failure<T, E>(await valueTaskErrorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<bool>> predicateValueTask, Func<T, string> valueTaskErrorPredicate)
        {
            Result<T> result = await resultTask;

            if (result.IsFailure)
                return result;

            if (!await predicateValueTask(result.Value))
                return Result.Failure<T>(valueTaskErrorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<bool>> valueTaskPredicate, Func<T, ValueTask<string>> valueTaskErrorPredicate)
        {
            Result<T> result = await resultTask;

            if (result.IsFailure)
                return result;

            if (!await valueTaskPredicate(result.Value))
                return Result.Failure<T>(await valueTaskErrorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result> Ensure(this ValueTask<Result> resultTask, Func<ValueTask<bool>> valueTaskPredicate, string errorMessage)
        {
            Result result = await resultTask;

            if (result.IsFailure)
                return result;

            if (!await valueTaskPredicate())
                return Result.Failure(errorMessage);

            return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result> Ensure(this ValueTask<Result> resultTask, Func<ValueTask<Result>> valueTaskPredicate)
        {
          Result result = await resultTask;
          
          if (result.IsFailure)
            return result;

          var predicateResult = await valueTaskPredicate();
          
          if (predicateResult.IsFailure)
            return Result.Failure(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result>> valueTaskPredicate)
        {
          Result<T> result = await resultTask;
          
          if (result.IsFailure)
            return result;

          var predicateResult = await valueTaskPredicate();
          
          if (predicateResult.IsFailure)
            return Result.Failure<T>(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result> Ensure<T>(this ValueTask<Result> resultTask, Func<ValueTask<Result<T>>> valueTaskPredicate)
        {
          Result result = await resultTask;
          
          if (result.IsFailure)
            return result;

          var predicateResult = await valueTaskPredicate();
          
          if (predicateResult.IsFailure)
            return Result.Failure<T>(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result<T>>> valueTaskPredicate)
        {
          Result<T> result = await resultTask;
          
          if (result.IsFailure)
            return result;
        
          var predicateResult = await valueTaskPredicate();
          
          if (predicateResult.IsFailure)
            return Result.Failure<T>(predicateResult.Error);
        
          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T,ValueTask<Result>> valueTaskPredicate)
        {
          Result<T> result = await resultTask;
          
          if (result.IsFailure)
            return result;

          var predicateResult = await valueTaskPredicate(result.Value);
          
          if (predicateResult.IsFailure)
            return Result.Failure<T>(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T,ValueTask<Result<T>>> valueTaskPredicate)
        {
          Result<T> result = await resultTask;
          
          if (result.IsFailure)
            return result;

          var predicateResult = await valueTaskPredicate(result.Value);
          
          if (predicateResult.IsFailure)
            return Result.Failure<T>(predicateResult.Error);

          return result;
        }
    }
}
#endif