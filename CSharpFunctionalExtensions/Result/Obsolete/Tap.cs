using System;
using System.ComponentModel;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Check() instead.")]
        public static Result<T> Tap<T>(this Result<T> result, Func<T, Result> func) 
            => Check(result, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Check() instead.")]
        public static Result<T> Tap<T, K>(this Result<T> result, Func<T, Result<K>> func) 
            => Check(result, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Check() instead.")]
        public static Result<T, E> Tap<T, K, E>(this Result<T, E> result, Func<T, Result<K, E>> func) 
            => Check(result, func);
    }
}