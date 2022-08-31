#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K, E>> Map<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<T, K> valueTask)
        {
            Result<T, E> result = await resultTask;
            return result.Map(valueTask);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K, E>> Map<K, E>(this ValueTask<UnitResult<E>> resultTask, Func<K> valueTask) 
        {
            UnitResult<E> result = await resultTask;
            return result.Map(valueTask);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K>> Map<T, K>(this ValueTask<Result<T>> resultTask, Func<T, K> valueTask)
        {
            Result<T> result = await resultTask;
            return result.Map(valueTask);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K>> Map<K>(this ValueTask<Result> resultTask, Func<K> valueTask)
        {
            Result result = await resultTask;
            return result.Map(valueTask);
        }
    }
}
#endif