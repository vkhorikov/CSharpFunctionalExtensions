#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<T> Finally<T>(this Result result, Func<Result, ValueTask<T>> func)
        {
            return await func(result);
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<K> Finally<T, K>(this Result<T> result, Func<Result<T>, ValueTask<K>> func)
        {
            return await func(result);
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<K> Finally<K, E>(this UnitResult<E> result, Func<UnitResult<E>, ValueTask<K>> func)
        {
            return await func(result);
        }

        /// <summary>
        ///     Passes the result to the given function (regardless of success/failure state) to yield a final output value.
        /// </summary>
        public static async ValueTask<K> Finally<T, K, E>(this Result<T, E> result, Func<Result<T, E>, ValueTask<K>> func)
        {
            return await func(result);
        }
    }
}
#endif
