#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, string errorMessage)
        {
            Result<T> result = await resultTask;
            return result.Ensure(predicate, errorMessage);
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T, E>> Ensure<T, E>(this ValueTask<Result<T, E>> resultTask,
            Func<T, bool> predicate, E error)
        {
            Result<T, E> result = await resultTask;
            return result.Ensure(predicate, error);
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T, E>> Ensure<T, E>(this ValueTask<Result<T, E>> resultTask,
            Func<T, bool> predicate, Func<T, E> errorPredicate)
        {
            Result<T, E> result = await resultTask;
            return result.Ensure(predicate, errorPredicate);
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, string> errorPredicate)
        {
            Result<T> result = await resultTask;

            if (result.IsFailure)
                return result;

            return result.Ensure(predicate, errorPredicate);
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, ValueTask<string>> errorPredicate)
        {
            Result<T> result = await resultTask;

            if (result.IsFailure)
                return result;

            if (predicate(result.Value))
                return result;

            return Result.Failure<T>(await errorPredicate(result.Value));
        }

        /// <summary>
        ///     Returns a new failure result if the predicate is false. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result> Ensure(this ValueTask<Result> resultTask, Func<bool> predicate, string errorMessage)
        {
            Result result = await resultTask;
            return result.Ensure(predicate, errorMessage);
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result> Ensure(this ValueTask<Result> resultTask, Func<Result> predicate)
        {
          Result result = await resultTask;
          return result.Ensure(predicate);
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<Result> predicate)
        {
          Result<T> result = await resultTask;
          return result.Ensure(predicate);
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result> Ensure<T>(this ValueTask<Result> resultTask, Func<Result<T>> predicate)
        {
          Result result = await resultTask;
          return result.Ensure(predicate);
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>> predicate)
        {
          Result<T> result = await resultTask;
          return result.Ensure(predicate);
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T,Result> predicate)
        {
          Result<T> result = await resultTask;
          return result.Ensure(predicate);
        }
        
        /// <summary>
        ///     Returns a new failure result if the predicate is a failure result. Otherwise returns the starting result.
        /// </summary>
        public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T,Result<T>> predicate)
        {
          Result<T> result = await resultTask;
          return result.Ensure(predicate);
        }
    }
}
#endif
