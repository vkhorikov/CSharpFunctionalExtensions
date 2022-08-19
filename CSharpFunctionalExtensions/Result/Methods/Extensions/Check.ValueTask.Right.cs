#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
   public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Result<T>> Check<T>(this Result<T> result, Func<T, ValueTask<Result>> func)
        {
            return await result.Bind(func).Map(() => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Result<T>> Check<T, K>(this Result<T> result, Func<T, ValueTask<Result<K>>> func)
        {
            return await result.Bind(func).Map(_ => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Result<T, E>> Check<T, K, E>(this Result<T, E> result, Func<T, ValueTask<Result<K, E>>> func)
        {
            return await result.Bind(func).Map(_ => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Result<T, E>> Check<T, E>(this Result<T, E> result, Func<T, ValueTask<UnitResult<E>>> func)
        {
            return await result.Bind(func).Map(() => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<UnitResult<E>> Check<E>(this UnitResult<E> result, Func<ValueTask<UnitResult<E>>> func)
        {
            return await result.Bind(func).Map(() => result);
        }
    }
}
#endif