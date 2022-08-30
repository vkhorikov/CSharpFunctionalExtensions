#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Result> MapError(this ValueTask<Result> resultTask, Func<string, string> errorFactory)
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return Result.Success();
            }

            var error = errorFactory(result.Error);
            return Result.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<UnitResult<E>> MapError<E>(this ValueTask<Result> resultTask, Func<string, E> errorFactory)
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return UnitResult.Success<E>();
            }

            var error = errorFactory(result.Error);
            return UnitResult.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Result<T>> MapError<T>(this ValueTask<Result<T>> resultTask, Func<string, string> errorFactory)
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return Result.Success(result.Value);
            }

            var error = errorFactory(result.Error);
            return Result.Failure<T>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Result<T, E>> MapError<T, E>(this ValueTask<Result<T>> resultTask, Func<string, E> errorFactory)
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return Result.Success<T, E>(result.Value);
            }

            var error = errorFactory(result.Error);
            return Result.Failure<T, E>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Result> MapError<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, string> errorFactory)
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return Result.Success();
            }

            var error = errorFactory(result.Error);
            return Result.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<UnitResult<E2>> MapError<E, E2>(this ValueTask<UnitResult<E>> resultTask, Func<E, E2> errorFactory)
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return UnitResult.Success<E2>();
            }

            var error = errorFactory(result.Error);
            return UnitResult.Failure(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Result<T>> MapError<T, E>(this ValueTask<Result<T, E>> resultTask, Func<E, string> errorFactory)
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return Result.Success(result.Value);
            }

            var error = errorFactory(result.Error);
            return Result.Failure<T>(error);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Result<T, E2>> MapError<T, E, E2>(this ValueTask<Result<T, E>> resultTask, Func<E, E2> errorFactory)
        {
            var result = await resultTask;
            if (result.IsSuccess)
            {
                return Result.Success<T, E2>(result.Value);
            }

            var error = errorFactory(result.Error);
            return Result.Failure<T, E2>(error);
        }
    }
}
#endif