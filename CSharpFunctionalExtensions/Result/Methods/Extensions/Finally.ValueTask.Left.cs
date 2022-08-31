#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Passes the result to the given valueTask action (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<T> Finally<T>(this ValueTask<Result> resultTask, Func<Result, T> valueTask)
        {
            Result result = await resultTask;
            return result.Finally(valueTask);
        }

        /// <summary>
        ///     Passes the result to the given valueTask action (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<K> Finally<T, K>(this ValueTask<Result<T>> resultTask, Func<Result<T>, K> valueTask)
        {
            Result<T> result = await resultTask;
            return result.Finally(valueTask);
        }

        /// <summary>
        ///     Passes the result to the given valueTask action (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<K> Finally<K, E>(this ValueTask<UnitResult<E>> resultTask, Func<UnitResult<E>, K> valueTask)
        {
            UnitResult<E> result = await resultTask;
            return result.Finally(valueTask);
        }

        /// <summary>
        ///     Passes the result to the given valueTask action (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<K> Finally<T, K, E>(this ValueTask<Result<T, E>> resultTask,
            Func<Result<T, E>, K> valueTask)
        {
            Result<T, E> result = await resultTask;
            return result.Finally(valueTask);
        }
    }
}
#endif
