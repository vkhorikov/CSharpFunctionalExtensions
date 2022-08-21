using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async Task<T> Finally<T>(this Task<Result> resultTask, Func<Result, Task<T>> func)
        {
            Result result = await resultTask.DefaultAwait();
            return await func(result).DefaultAwait();
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async Task<K> Finally<T, K>(this Task<Result<T>> resultTask, Func<Result<T>, Task<K>> func)
        {
            Result<T> result = await resultTask.DefaultAwait();
            return await func(result).DefaultAwait();
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async Task<K> Finally<K, E>(this Task<UnitResult<E>> resultTask, Func<UnitResult<E>, Task<K>> func) 
        {
            UnitResult<E> result = await resultTask.DefaultAwait();
            return await func(result).DefaultAwait();
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async Task<K> Finally<T, K, E>(this Task<Result<T, E>> resultTask,
            Func<Result<T, E>, Task<K>> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            return await func(result).DefaultAwait();
        }
    }
}
