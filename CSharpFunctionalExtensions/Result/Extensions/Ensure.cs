using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static Result<T, E> Ensure<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, E> errorPredicate)
        {
            if (result.IsFailure)
                return result;

            if (!predicate(result.Value))
                return Result.Failure<T, E>(errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static Result<T, E> Ensure<T, E>(this Result<T, E> result, Func<T, bool> predicate, E error)
        {
            if (result.IsFailure)
                return result;

            if (!predicate(result.Value))
                return Result.Failure<T, E>(error);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return result;

            if (!predicate(result.Value))
                return Result.Failure<T>(errorMessage);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, Func<T, string> errorPredicate)
        {
            if (result.IsFailure)
                return result;

            if (!predicate(result.Value))
                return Result.Failure<T>(errorPredicate(result.Value));

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static Result Ensure(this Result result, Func<bool> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return result;

            if (!predicate())
                return Result.Failure(errorMessage);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static Result Ensure(this Result result, Func<Result> predicate)
        {
          if (result.IsFailure)
            return result;

          var predicateResult = predicate();
          
          if (predicateResult.IsFailure)
            return Result.Failure(predicateResult.Error);

          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static Result<T> Ensure<T>(this Result<T> result, Func<Result> predicate)
        {
          if (result.IsFailure)
            return result;
        
          var predicateResult = predicate();
          
          if (predicateResult.IsFailure)
            return Result.Failure<T>(predicateResult.Error);
        
          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static Result Ensure<T>(this Result result, Func<Result<T>> predicate)
        {
          if (result.IsFailure)
            return result;
        
          var predicateResult = predicate();
          
          if (predicateResult.IsFailure)
            return Result.Failure<T>(predicateResult.Error);
        
          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static Result<T> Ensure<T>(this Result<T> result, Func<Result<T>> predicate)
        {
          if (result.IsFailure)
            return result;

          var predicateResult = predicate();
          
          if (predicateResult.IsFailure)
            return Result.Failure<T>(predicateResult.Error);

          return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static Result<T> Ensure<T>(this Result<T> result, Func<T,Result> predicate)
        {
          if (result.IsFailure)
            return result;
        
          var predicateResult = predicate(result.Value);
          
          if (predicateResult.IsFailure)
            return Result.Failure<T>(predicateResult.Error);
        
          return result;
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static Result<T> Ensure<T>(this Result<T> result, Func<T,Result<T>> predicate)
        {
          if (result.IsFailure)
            return result;
        
          var predicateResult = predicate(result.Value);
          
          if (predicateResult.IsFailure)
            return Result.Failure<T>(predicateResult.Error);
        
          return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static IUnitResult<E> Ensure<E>(this IUnitResult<E> result, Func<bool> predicate, Func<E> errorPredicate)
        {
            if (result.IsFailure)
                return result;

            if (!predicate())
                return UnitResult.Failure<E>(errorPredicate());

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static IUnitResult<E> Ensure<E>(this IUnitResult<E> result, Func<bool> predicate, E error)
        {
            if (result.IsFailure)
                return result;

            if (!predicate())
                return UnitResult.Failure<E>(error);

            return result;
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static IUnitResult<E> Ensure<E>(this IUnitResult<E> result, Func<UnitResult<E>> predicate)
        {
            if (result.IsFailure)
                return result;

            var predicateResult = predicate();

            if (predicateResult.IsFailure)
                return UnitResult.Failure<E>(predicateResult.Error);

            return result;
        }
    }
}
