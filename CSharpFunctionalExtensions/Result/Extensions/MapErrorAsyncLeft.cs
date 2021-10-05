using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Result> MapError(this Task<Result> resultTask, Func<string, string> errorFactory)
        {
            var result = await resultTask.DefaultAwait();

            return result.MapError(errorFactory);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<UnitResult<E>> MapError<E>(this Task<Result> resultTask, Func<string, E> errorFactory)
        {
            var result = await resultTask.DefaultAwait();

            return result.MapError(errorFactory);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Result<T>> MapError<T>(this Task<Result<T>> resultTask, Func<string, string> errorFactory)
        {
            var result = await resultTask.DefaultAwait();

            return result.MapError(errorFactory);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Result<T, E>> MapError<T, E>(this Task<Result<T>> resultTask, Func<string, E> errorFactory)
        {
            var result = await resultTask.DefaultAwait();

            return result.MapError(errorFactory);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Result> MapError<E>(this Task<UnitResult<E>> resultTask, Func<E, string> errorFactory) 
        {
            var result = await resultTask.DefaultAwait();

            return result.MapError(errorFactory);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Result<T>> MapError<T, E>(this Task<Result<T, E>> resultTask, Func<E, string> errorFactory)
        {
            var result = await resultTask.DefaultAwait();

            return result.MapError(errorFactory);
        }

        /// <summary>
        ///     If the calling Result is a success, a new success result is returned. Otherwise, creates a new failure result from the return value of a given function.
        /// </summary>
        public static async Task<Result<T, E2>> MapError<T, E, E2>(this Task<Result<T, E>> resultTask, Func<E, E2> errorFactory)
        {
            var result = await resultTask.DefaultAwait();

            return result.MapError(errorFactory);
        }
    }
}