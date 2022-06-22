using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Finally() instead.")]
        public static Task<T> OnBoth<T>(this Task<Result> resultTask, Func<Result, Task<T>> func)
            => Finally(resultTask, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Finally() instead.")]
        public static Task<K> OnBoth<T, K>(this Task<Result<T>> resultTask, Func<Result<T>, Task<K>> func)
            => Finally(resultTask, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Finally() instead.")]
        public static Task<K> OnBoth<T, K, E>(this Task<Result<T, E>> resultTask, Func<Result<T, E>, Task<K>> func)
            => Finally(resultTask, func);
    }
}
