#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static async ValueTask<K> Match<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<K>> onSuccess, Func<E, ValueTask<K>> onFailure)
        {
            return await (await resultTask.DefaultAwait())
                .Match(onSuccess, onFailure).DefaultAwait();
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static async ValueTask<K> Match<K, T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<K>> onSuccess, Func<string, ValueTask<K>> onFailure)
        {
            return await (await resultTask.DefaultAwait())
                .Match(onSuccess, onFailure).DefaultAwait();
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static async ValueTask<T> Match<T>(this ValueTask<Result> resultTask, Func<ValueTask<T>> onSuccess, Func<string, ValueTask<T>> onFailure)
        {
            return await (await resultTask.DefaultAwait())
                .Match(onSuccess, onFailure).DefaultAwait();
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async Task Match<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask> onSuccess, Func<E, ValueTask> onFailure)
        {
            await (await resultTask.DefaultAwait())
                .Match(onSuccess, onFailure).DefaultAwait();
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async Task Match<E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask> onSuccess, Func<E, ValueTask> onFailure)
        {
            await (await resultTask.DefaultAwait())
                .Match(onSuccess, onFailure).DefaultAwait();
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async Task Match<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask> onSuccess, Func<string, ValueTask> onFailure)
        {
            await (await resultTask.DefaultAwait())
                .Match(onSuccess, onFailure).DefaultAwait();
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async Task Match(this ValueTask<Result> resultTask, Func<ValueTask> onSuccess, Func<string, ValueTask> onFailure)
        {
            await (await resultTask.DefaultAwait())
                .Match(onSuccess, onFailure).DefaultAwait();
        }
    }
}
#endif