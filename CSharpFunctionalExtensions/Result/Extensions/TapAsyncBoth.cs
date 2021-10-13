using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result> Tap(this Task<Result> resultTask, Func<Task> func)
        {
            Result result = await resultTask.DefaultAwait();

            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> Tap<T>(this Task<Result<T>> resultTask, Func<Task> func)
        {
            Result<T> result = await resultTask.DefaultAwait();

            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> Tap<T>(this Task<Result<T>> resultTask, Func<T, Task> func)
        {
            Result<T> result = await resultTask.DefaultAwait();

            if (result.IsSuccess)
                await func(result.Value).DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<UnitResult<E>> Tap<E>(this Task<UnitResult<E>> resultTask, Func<Task> func)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> Tap<T, E>(this Task<Result<T, E>> resultTask, Func<Task> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess)
                await func().DefaultAwait();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> Tap<T, E>(this Task<Result<T, E>> resultTask, Func<T, Task> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess)
                await func(result.Value).DefaultAwait();

            return result;
        }
    }
}
