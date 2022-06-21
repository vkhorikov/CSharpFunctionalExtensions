using System;
using System.ComponentModel;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Finally() instead.")]
        public static T OnBoth<T>(this Result result, Func<Result, T> func)
            => Finally(result, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Finally() instead.")]
        public static K OnBoth<T, K>(this Result<T> result, Func<Result<T>, K> func)
            => Finally(result, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Finally() instead.")]
        public static K OnBoth<T, K, E>(this Result<T, E> result, Func<Result<T, E>, K> func)
            => Finally(result, func);
    }
}
