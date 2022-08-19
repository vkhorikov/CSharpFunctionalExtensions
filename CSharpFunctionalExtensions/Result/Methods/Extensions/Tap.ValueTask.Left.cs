#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result> Tap(this ValueTask<Result> resultTask, Action action)
        {
            Result result = await resultTask;
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> Tap<T>(this ValueTask<Result<T>> resultTask, Action action)
        {
            Result<T> result = await resultTask;
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> Tap<T>(this ValueTask<Result<T>> resultTask, Action<T> action)
        {
            Result<T> result = await resultTask;
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> Tap<E>(this ValueTask<UnitResult<E>> resultTask, Action action)
        {
            UnitResult<E> result = await resultTask;
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> Tap<T, E>(this ValueTask<Result<T, E>> resultTask, Action action)
        {
            Result<T, E> result = await resultTask;
            return result.Tap(action);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> Tap<T, E>(this ValueTask<Result<T, E>> resultTask, Action<T> action)
        {
            Result<T, E> result = await resultTask;
            return result.Tap(action);
        }
    }
}
#endif
