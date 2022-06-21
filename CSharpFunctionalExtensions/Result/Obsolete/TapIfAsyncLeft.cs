using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use CheckIf() instead.")]
        public static Task<Result<T>> TapIf<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Result> func) =>
            CheckIf(resultTask, condition, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use CheckIf() instead.")]
        public static Task<Result<T>> TapIf<T, K>(this Task<Result<T>> resultTask, bool condition, Func<T, Result<K>> func) =>
            CheckIf(resultTask, condition, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use CheckIf() instead.")]
        public static Task<Result<T, E>> TapIf<T, K, E>(this Task<Result<T, E>> resultTask, bool condition, Func<T, Result<K, E>> func) =>
            CheckIf(resultTask, condition, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use CheckIf() instead.")]
        public static Task<Result<T>> TapIf<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result> func) =>
            CheckIf(resultTask, predicate, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use CheckIf() instead.")]
        public static Task<Result<T>> TapIf<T, K>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result<K>> func) =>
            CheckIf(resultTask, predicate, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use CheckIf() instead.")]
        public static Task<Result<T, E>> TapIf<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, Result<K, E>> func) =>
            CheckIf(resultTask, predicate, func);
    }
}
