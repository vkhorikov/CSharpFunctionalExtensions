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

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static async Task<Result<T>> Tap<T>(this Result<T> result, Func<T, Task<Result>> func)
        {
            return await result.Bind(func).Map(() => result.Value).DefaultAwait();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static async Task<Result<T>> Tap<T, K>(this Result<T> result, Func<T, Task<Result<K>>> func)
        {
            return await result.Bind(func).Map(_ => result.Value).DefaultAwait();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static async Task<Result<T, E>> Tap<T, K, E>(this Result<T, E> result, Func<T, Task<Result<K, E>>> func)
        {
            return await result.Bind(func).Map(_ => result.Value).DefaultAwait();
        }
    }
}
