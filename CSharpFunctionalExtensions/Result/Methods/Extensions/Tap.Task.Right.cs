using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result> Tap(this Result result, Func<Task> func)
        {
            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> Tap<T>(this Result<T> result, Func<Task> func)
        {
            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> Tap<T>(this Result<T> result, Func<T, Task> func)
        {
            if (result.IsSuccess)
                await func(result.Value).DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<UnitResult<E>> Tap<E>(this UnitResult<E> result, Func<Task> func)
        {
            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> Tap<T, E>(this Result<T, E> result, Func<Task> func)
        {
            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> Tap<T, E>(this Result<T, E> result, Func<T, Task> func)
        {
            if (result.IsSuccess)
                await func(result.Value).DefaultAwait();

            return result;
        }
    }
}
