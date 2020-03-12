using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static async Task<Result> TapAndCheck(this Task<Result> resultTask, Func<Task<Result>> func)
        {
            Result result = await resultTask.DefaultAwait();
            var funcResult = await result.Bind(func).DefaultAwait();
            return funcResult.IsSuccess
                ? result
                : Result.Failure(funcResult.Error);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static async Task<Result> TapAndCheck<K>(this Task<Result> resultTask, Func<Task<Result<K>>> func)
        {
            Result result = await resultTask.DefaultAwait();
            var funcResult = await result.Bind(func).DefaultAwait();
            return funcResult.IsSuccess
                ? result
                : Result.Failure(funcResult.Error);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static async Task<Result<T>> TapAndCheck<T>(this Task<Result<T>> resultTask, Func<Task<Result>> func)
        {
            Result<T> result = await resultTask.DefaultAwait();
            var funcResult = await result.Bind(_ => func()).DefaultAwait();
            return funcResult.Map(() => result.Value);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static async Task<Result<T>> TapAndCheck<T, K>(this Task<Result<T>> resultTask, Func<Task<Result<K>>> func)
        {
            Result<T> result = await resultTask.DefaultAwait();
            var funcResult = await result.Bind(_ => func()).DefaultAwait();
            return funcResult.Map(_ => result.Value);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static async Task<Result> TapAndCheck<T>(this Task<Result<T>> resultTask, Func<T, Task<Result>> func)
        {
            Result<T> result = await resultTask.DefaultAwait();
            var funcResult = await result.Bind(func).DefaultAwait();
            return funcResult.Map(() => result.Value);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static async Task<Result<T>> TapAndCheck<T, K>(this Task<Result<T>> resultTask, Func<T, Task<Result<K>>> func)
        {
            Result<T> result = await resultTask.DefaultAwait();
            var funcResult = await result.Bind(func).DefaultAwait();
            return funcResult.Map(_ => result.Value);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static async Task<Result<T, E>> TapAndCheck<T, K, E>(this Task<Result<T, E>> resultTask, Func<Task<Result<K, E>>> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            var funcResult = await result.Bind(_ => func()).DefaultAwait();
            return funcResult.Map(_ => result.Value);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static async Task<Result<T, E>> TapAndCheck<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Task<Result<K, E>>> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            var funcResult = await result.Bind(func).DefaultAwait();
            return funcResult.Map(_ => result.Value);
        }
    }
}
