#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccessValueTask"/> valueTask action if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailureValueTask"/> valueTask action.
        /// </summary>
        public static async ValueTask<K> Match<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<K>> onSuccessValueTask, Func<E, ValueTask<K>> onFailureValueTask)
        {
            return await (await resultTask)
                .Match(onSuccessValueTask, onFailureValueTask);
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccessValueTask"/> valueTask action if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailureValueTask"/> valueTask action.
        /// </summary>
        public static async ValueTask<K> Match<K, T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<K>> onSuccessValueTask, Func<string, ValueTask<K>> onFailureValueTask)
        {
            return await (await resultTask)
                .Match(onSuccessValueTask, onFailureValueTask);
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccessValueTask"/> valueTask action if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailureValueTask"/> valueTask action.
        /// </summary>
        public static async ValueTask<T> Match<T>(this ValueTask<Result> resultTask, Func<ValueTask<T>> onSuccessValueTask, Func<string, ValueTask<T>> onFailureValueTask)
        {
            return await (await resultTask)
                .Match(onSuccessValueTask, onFailureValueTask);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccessValueTask"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailureValueTask"/> action.
        /// </summary>
        public static async Task Match<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask> onSuccessValueTask, Func<E, ValueTask> onFailureValueTask)
        {
            await (await resultTask)
                .Match(onSuccessValueTask, onFailureValueTask);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccessValueTask"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailureValueTask"/> action.
        /// </summary>
        public static async Task Match<E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask> onSuccessValueTask, Func<E, ValueTask> onFailureValueTask)
        {
            await (await resultTask)
                .Match(onSuccessValueTask, onFailureValueTask);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccessValueTask"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailureValueTask"/> action.
        /// </summary>
        public static async Task Match<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask> onSuccessValueTask, Func<string, ValueTask> onFailureValueTask)
        {
            await (await resultTask)
                .Match(onSuccessValueTask, onFailureValueTask);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccessValueTask"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailureValueTask"/> action.
        /// </summary>
        public static async Task Match(this ValueTask<Result> resultTask, Func<ValueTask> onSuccessValueTask, Func<string, ValueTask> onFailureValueTask)
        {
            await (await resultTask)
                .Match(onSuccessValueTask, onFailureValueTask);
        }
    }
}
#endif