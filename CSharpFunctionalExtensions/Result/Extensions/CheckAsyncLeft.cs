using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async Task<Result<T>> Check<T>(this Task<Result<T>> resultTask, Func<T, Result> func)
        {
            Result<T> result = await resultTask.DefaultAwait();
            return result.Check(func);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async Task<Result<T>> Check<T, K>(this Task<Result<T>> resultTask, Func<T, Result<K>> func)
        {
            Result<T> result = await resultTask.DefaultAwait();
            return result.Check(func);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async Task<Result<T, E>> Check<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Result<K, E>> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            return result.Check(func);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async Task<Result<T, E>> Check<T, E>(this Task<Result<T, E>> resultTask, Func<T, UnitResult<E>> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            return result.Check(func);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async Task<UnitResult<E>> Check<E>(this Task<UnitResult<E>> resultTask, Func<UnitResult<E>> func)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();
            return result.Check(func);
        }
    }
}