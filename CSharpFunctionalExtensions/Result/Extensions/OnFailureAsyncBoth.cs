using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> OnFailure<T, E>(this Task<Result<T, E>> resultTask, Func<Task> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                await func().DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> OnFailure<T>(this Task<Result<T>> resultTask, Func<Task> func)
        {
            Result<T> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                await func().DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Result> OnFailure(this Task<Result> resultTask, Func<Task> func)
        {
            Result result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                await func().DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> OnFailure<T>(this Task<Result<T>> resultTask, Func<string, Task> func)
        {
            Result<T> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                await func(result.Error).DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> OnFailure<T, E>(this Task<Result<T, E>> resultTask, Func<E, Task> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
            {
                await func(result.Error).DefaultAwait();
            }

            return result;
        }
    }
}
