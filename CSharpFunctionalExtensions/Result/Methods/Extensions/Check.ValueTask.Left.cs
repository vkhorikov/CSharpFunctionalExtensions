#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     If the calling result is a success, the given valueTask action is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Result<T>> Check<T>(this ValueTask<Result<T>> resultTask, Func<T, Result> valueTask)
        {
            Result<T> result = await resultTask;
            return result.Check(valueTask);
        }

        /// <summary>
        ///     If the calling result is a success, the given valueTask action is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Result<T>> Check<T, K>(this ValueTask<Result<T>> resultTask,
            Func<T, Result<K>> valueTask)
        {
            Result<T> result = await resultTask;
            return result.Check(valueTask);
        }

        /// <summary>
        ///     If the calling result is a success, the given valueTask action is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Result<T, E>> Check<T, K, E>(this ValueTask<Result<T, E>> resultTask,
            Func<T, Result<K, E>> valueTask)
        {
            Result<T, E> result = await resultTask;
            return result.Check(valueTask);
        }

        /// <summary>
        ///     If the calling result is a success, the given valueTask action is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Result<T, E>> Check<T, E>(this ValueTask<Result<T, E>> resultTask,
            Func<T, UnitResult<E>> valueTask)
        {
            Result<T, E> result = await resultTask;
            return result.Check(valueTask);
        }

        /// <summary>
        ///     If the calling result is a success, the given valueTask action is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<UnitResult<E>> Check<E>(this ValueTask<UnitResult<E>> resultTask,
            Func<UnitResult<E>> valueTask)
        {
            UnitResult<E> result = await resultTask;
            return result.Check(valueTask);
        }
    }
}
#endif