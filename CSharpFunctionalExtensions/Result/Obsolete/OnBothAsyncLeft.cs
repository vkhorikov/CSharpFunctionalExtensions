using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Finally() instead.")]
        public static Task<T> OnBoth<T>(this Task<Result> resultTask, Func<Result, T> func)
            => Finally(resultTask, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Finally() instead.")]
        public static Task<K> OnBoth<T, K>(this Task<Result<T>> resultTask, Func<Result<T>, K> func)
            => Finally(resultTask, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Finally() instead.")]
        public static Task<K> OnBoth<T, K, E>(this Task<Result<T, E>> resultTask, Func<Result<T, E>, K> func)
            => Finally(resultTask, func);
    }
}
