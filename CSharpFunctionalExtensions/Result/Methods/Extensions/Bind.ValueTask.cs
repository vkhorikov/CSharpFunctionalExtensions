#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K, E>> Bind<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<Result<K, E>>> valueTask)
        {
            Result<T, E> result = await resultTask;
            return await result.Bind(valueTask);
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K>> Bind<T, K>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<K>>> valueTask)
        {
            Result<T> result = await resultTask;
            return await result.Bind(valueTask);
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K>> Bind<K>(this ValueTask<Result> resultTask, Func<ValueTask<Result<K>>> valueTask)
        {
            Result result = await resultTask;
            return await result.Bind(valueTask);
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result> Bind<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result>> valueTask)
        {
            Result<T> result = await resultTask;
            return await result.Bind(valueTask);
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result> Bind(this ValueTask<Result> resultTask, Func<ValueTask<Result>> valueTask)
        {
            Result result = await resultTask;
            return await result.Bind(valueTask);
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<T, E>> Bind<T, E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask<Result<T, E>>> valueTask)
        {
            UnitResult<E> result = await resultTask;
            return await result.Bind(valueTask);
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<UnitResult<E>> Bind<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<UnitResult<E>>> valueTask)
        {
            Result<T, E> result = await resultTask;
            return await result.Bind(valueTask);
        }
        
        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<UnitResult<E>> Bind<E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask<UnitResult<E>>> valueTask)
        {
            UnitResult<E> result = await resultTask;
            return await result.Bind(valueTask);
        }
    }
}
#endif