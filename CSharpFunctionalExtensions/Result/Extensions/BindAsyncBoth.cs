using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result<K, E>> Bind<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Task<Result<K, E>>> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            return await result.Bind(func).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result<K>> Bind<T, K>(this Task<Result<T>> resultTask, Func<T, Task<Result<K>>> func)
        {
            Result<T> result = await resultTask.DefaultAwait();
            return await result.Bind(func).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result<K>> Bind<K>(this Task<Result> resultTask, Func<Task<Result<K>>> func)
        {
            Result result = await resultTask.DefaultAwait();
            return await result.Bind(func).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result> Bind<T>(this Task<Result<T>> resultTask, Func<T, Task<Result>> func)
        {
            Result<T> result = await resultTask.DefaultAwait();
            return await result.Bind(func).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result> Bind(this Task<Result> resultTask, Func<Task<Result>> func)
        {
            Result result = await resultTask.DefaultAwait();
            return await result.Bind(func).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<UnitResult<E>> Bind<E>(this Task<UnitResult<E>> resultTask, Func<Task<UnitResult<E>>> func)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();
            return await result.Bind(func).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result<T, E>> Bind<T, E>(this Task<UnitResult<E>> resultTask, Func<Task<Result<T, E>>> func)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();
            return await result.Bind(func).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<UnitResult<E>> Bind<T, E>(this Task<Result<T, E>> resultTask, Func<T, Task<UnitResult<E>>> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            return await result.Bind(func).DefaultAwait();
        }
    }
}