using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> TapError<T>(this Task<Result<T>> resultTask, Action action)
        {
            Result<T> result = await resultTask.DefaultAwait();
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Result> TapError(this Task<Result> resultTask, Action action)
        {
            Result result = await resultTask.DefaultAwait();
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> TapError<T, E>(this Task<Result<T, E>> resultTask, Action action)
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<UnitResult<E>> TapError<E>(this Task<UnitResult<E>> resultTask, Action action)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<UnitResult<E>> TapError<E>(this Task<UnitResult<E>> resultTask, Action<E> action)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> TapError<T>(this Task<Result<T>> resultTask, Action<string> action)
        {
            Result<T> result = await resultTask.DefaultAwait();
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> TapError<T, E>(this Task<Result<T, E>> resultTask, Action<E> action)
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Result> TapError(this Task<Result> resultTask, Action<string> action)
        {
            Result result = await resultTask.DefaultAwait();
            return result.TapError(action);
        }
    }
}
