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
        public static async ValueTask<Result> MapError(this ValueTask<Result> resultTask, Func<string, ValueTask<string>> errorFactory)
        {
            var result = await resultTask;
            return await result.MapError(errorFactory);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<UnitResult<E>> MapError<E>(this ValueTask<Result> resultTask, Func<string, ValueTask<E>> errorFactory)
        {
            var result = await resultTask;
            return await result.MapError(errorFactory);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Result<T>> MapError<T>(this ValueTask<Result<T>> resultTask, Func<string, ValueTask<string>> errorFactory)
        {
            var result = await resultTask;
            return await result.MapError(errorFactory);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Result<T, E>> MapError<T, E>(this ValueTask<Result<T>> resultTask, Func<string, ValueTask<E>> errorFactory)
        {
            var result = await resultTask;
            return await result.MapError(errorFactory);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Result> MapError<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, ValueTask<string>> errorFactory)
        {
            var result = await resultTask;
            return await result.MapError(errorFactory);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<UnitResult<E2>> MapError<E, E2>(this ValueTask<UnitResult<E>> resultTask, Func<E, ValueTask<E2>> errorFactory)
        {
            var result = await resultTask;
            return await result.MapError(errorFactory);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Result<T>> MapError<T, E>(this ValueTask<Result<T, E>> resultTask, Func<E, ValueTask<string>> errorFactory)
        {
            var result = await resultTask;
            return await result.MapError(errorFactory);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given valueTask action.
        /// </summary>
        public static async ValueTask<Result<T, E2>> MapError<T, E, E2>(this ValueTask<Result<T, E>> resultTask, Func<E, ValueTask<E2>> errorFactory)
        {
            var result = await resultTask;
            return await result.MapError(errorFactory);
        }
    }
}
#endif