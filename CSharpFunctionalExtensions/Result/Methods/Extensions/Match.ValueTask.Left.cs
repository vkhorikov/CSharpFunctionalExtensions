#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> valueTask action if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> valueTask action.
        /// </summary>
        public static async ValueTask<K> Match<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<T, K> onSuccess, Func<E, K> onFailure)
        {
            return (await resultTask).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> valueTask action if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> valueTask action.
        /// </summary>
        public static async ValueTask<K> Match<K, T>(this ValueTask<Result<T>> resultTask, Func<T, K> onSuccess, Func<string, K> onFailure)
        {
            return (await resultTask).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> valueTask action if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> valueTask action.
        /// </summary>
        public static async ValueTask<T> Match<T>(this ValueTask<Result> resultTask, Func<T> onSuccess, Func<string, T> onFailure)
        {
            return (await resultTask).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Returns the result of the given <paramref name="onSuccess"/> valueTask action if the calling Result is a success. Otherwise, it returns the result of the given <paramref name="onFailure"/> valueTask action.
        /// </summary>
        public static async ValueTask<K> Match<K, E>(this ValueTask<UnitResult<E>> resultTask, Func<K> onSuccess, Func<E, K> onFailure)
        {
            return (await resultTask).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async Task Match<T, E>(this ValueTask<Result<T, E>> resultTask, Action<T> onSuccess, Action<E> onFailure)
        {
            (await resultTask).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async Task Match<T>(this ValueTask<Result<T>> resultTask, Action<T> onSuccess, Action<string> onFailure)
        {
            (await resultTask).Match(onSuccess, onFailure);
        }

        /// <summary>
        ///     Invokes the given <paramref name="onSuccess"/> action if the calling Result is a success. Otherwise, it invokes the given <paramref name="onFailure"/> action.
        /// </summary>
        public static async Task Match(this ValueTask<Result> resultTask, Action onSuccess, Action<string> onFailure)
        {
            (await resultTask).Match(onSuccess, onFailure);
        }
    }
}
#endif