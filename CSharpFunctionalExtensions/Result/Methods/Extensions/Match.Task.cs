using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static async Task<K> Match<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Task<K>> onSuccess, Func<E, Task<K>> onFailure)
        {
            return await (await resultTask.DefaultAwait())
                .Match(onSuccess, onFailure).DefaultAwait();
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static async Task<K> Match<K, T>(this Task<Result<T>> resultTask, Func<T, Task<K>> onSuccess, Func<string, Task<K>> onFailure)
        {
            return await (await resultTask.DefaultAwait())
                .Match(onSuccess, onFailure).DefaultAwait();
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static async Task<T> Match<T>(this Task<Result> resultTask, Func<Task<T>> onSuccess, Func<string, Task<T>> onFailure)
        {
            return await (await resultTask.DefaultAwait())
                .Match(onSuccess, onFailure).DefaultAwait();
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async Task Match<T, E>(this Task<Result<T, E>> resultTask, Func<T, Task> onSuccess, Func<E, Task> onFailure)
        {
            await (await resultTask.DefaultAwait())
                .Match(onSuccess, onFailure).DefaultAwait();
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async Task Match<E>(this Task<UnitResult<E>> resultTask, Func<Task> onSuccess, Func<E, Task> onFailure)
        {
            await (await resultTask.DefaultAwait())
                .Match(onSuccess, onFailure).DefaultAwait();
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async Task Match<T>(this Task<Result<T>> resultTask, Func<T, Task> onSuccess, Func<string, Task> onFailure)
        {
            await (await resultTask.DefaultAwait())
                .Match(onSuccess, onFailure).DefaultAwait();
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async Task Match(this Task<Result> resultTask, Func<Task> onSuccess, Func<string, Task> onFailure)
        {
            await (await resultTask.DefaultAwait())
                .Match(onSuccess, onFailure).DefaultAwait();
        }
    }
}
