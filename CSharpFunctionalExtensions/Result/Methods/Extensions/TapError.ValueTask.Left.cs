#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> TapError<T>(this ValueTask<Result<T>> resultTask, Action action)
        {
            Result<T> result = await resultTask;
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result> TapError(this ValueTask<Result> resultTask, Action action)
        {
            Result result = await resultTask;
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> TapError<T, E>(this ValueTask<Result<T, E>> resultTask, Action action)
        {
            Result<T, E> result = await resultTask;
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> TapError<E>(this ValueTask<UnitResult<E>> resultTask, Action action)
        {
            UnitResult<E> result = await resultTask;
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> TapError<E>(this ValueTask<UnitResult<E>> resultTask, Action<E> action)
        {
            UnitResult<E> result = await resultTask;
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> TapError<T>(this ValueTask<Result<T>> resultTask, Action<string> action)
        {
            Result<T> result = await resultTask;
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> TapError<T, E>(this ValueTask<Result<T, E>> resultTask, Action<E> action)
        {
            Result<T, E> result = await resultTask;
            return result.TapError(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result> TapError(this ValueTask<Result> resultTask, Action<string> action)
        {
            Result result = await resultTask;
            return result.TapError(action);
        }
    }
}
#endif
