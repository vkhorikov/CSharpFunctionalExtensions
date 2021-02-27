using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static async Task<K> Match<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, K> onSuccess, Func<E, K> onFailure)
        {
            return (await resultTask.DefaultAwait()).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static async Task<K> Match<K, T>(this Task<Result<T>> resultTask, Func<T, K> onSuccess, Func<string, K> onFailure)
        {
            return (await resultTask.DefaultAwait()).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> function if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> function.
        /// </summary>
        public static async Task<T> Match<T>(this Task<Result> resultTask, Func<T> onSuccess, Func<string, T> onFailure)
        {
            return (await resultTask.DefaultAwait()).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async Task Match<T, E>(this Task<Result<T, E>> resultTask, Action<T> onSuccess, Action<E> onFailure)
        {
            (await resultTask.DefaultAwait()).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async Task Match<T>(this Task<Result<T>> resultTask, Action<T> onSuccess, Action<string> onFailure)
        {
            (await resultTask.DefaultAwait()).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async Task Match(this Task<Result> resultTask, Action onSuccess, Action<string> onFailure)
        {
            (await resultTask.DefaultAwait()).Match(onSuccess, onFailure);
        }
    }
}
