#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<T> Finally<T>(this ValueTask<Result> resultTask, Func<Result, ValueTask<T>> func)
        {
            Result result = await resultTask;
            return await func(result);
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<K> Finally<T, K>(this ValueTask<Result<T>> resultTask, Func<Result<T>, ValueTask<K>> func)
        {
            Result<T> result = await resultTask;
            return await func(result);
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<K> Finally<K, E>(this ValueTask<UnitResult<E>> resultTask, Func<UnitResult<E>, ValueTask<K>> func) 
        {
            UnitResult<E> result = await resultTask;
            return await func(result);
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<K> Finally<T, K, E>(this ValueTask<Result<T, E>> resultTask,
            Func<Result<T, E>, ValueTask<K>> func)
        {
            Result<T, E> result = await resultTask;
            return await func(result);
        }
    }
}
#endif
