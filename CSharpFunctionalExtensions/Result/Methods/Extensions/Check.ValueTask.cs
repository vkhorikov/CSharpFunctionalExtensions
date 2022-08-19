#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Result<T>> Check<T>(this ValueTask<Result<T>> resultTask,
            Func<T, ValueTask<Result>> func)
        {
            Result<T> result = await resultTask;
            return await result.Bind(func).Map(() => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Result<T>> Check<T, K>(this ValueTask<Result<T>> resultTask,
            Func<T, ValueTask<Result<K>>> func)
        {
            Result<T> result = await resultTask;
            return await result.Bind(func).Map(_ => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Result<T, E>> Check<T, K, E>(this ValueTask<Result<T, E>> resultTask,
            Func<T, ValueTask<Result<K, E>>> func)
        {
            Result<T, E> result = await resultTask;
            return await result.Bind(func).Map(_ => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Result<T, E>> Check<T, E>(this ValueTask<Result<T, E>> resultTask,
            Func<T, ValueTask<UnitResult<E>>> func)
        {
            Result<T, E> result = await resultTask;
            return await result.Bind(func).Map(() => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<UnitResult<E>> Check<E>(this ValueTask<UnitResult<E>> resultTask,
            Func<ValueTask<UnitResult<E>>> func)
        {
            UnitResult<E> result = await resultTask;
            return await result.Bind(func).Map(() => result);
        }
    }
}
#endif