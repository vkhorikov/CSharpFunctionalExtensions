#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result> Tap(this Result result, Func<ValueTask> func)
        {
            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> Tap<T>(this Result<T> result, Func<ValueTask> func)
        {
            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> Tap<T>(this Result<T> result, Func<T, ValueTask> func)
        {
            if (result.IsSuccess)
                await func(result.Value).DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> Tap<E>(this UnitResult<E> result, Func<ValueTask> func)
        {
            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> Tap<T, E>(this Result<T, E> result, Func<ValueTask> func)
        {
            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> Tap<T, E>(this Result<T, E> result, Func<T, ValueTask> func)
        {
            if (result.IsSuccess)
                await func(result.Value).DefaultAwait();

            return result;
        }
    }
}
#endif