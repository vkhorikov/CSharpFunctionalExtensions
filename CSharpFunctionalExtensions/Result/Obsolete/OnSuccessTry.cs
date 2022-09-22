using System;
using System.ComponentModel;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use MapTry() instead.")]
        public static Result<T> OnSuccessTry<T>(this Result result, Func<T> func, Func<Exception, string> errorHandler = null)
        {
            return result.MapTry(func, errorHandler);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use MapTry() instead.")]
        public static Result<K> OnSuccessTry<T, K>(this Result<T> result, Func<T, K> func, Func<Exception, string> errorHandler = null)
        {
            return result.MapTry(func, errorHandler);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use MapTry() instead.")]
        public static Result<K, E> OnSuccessTry<T, K, E>(this Result<T, E> result, Func<T, K> func, Func<Exception, E> errorHandler)
        {
            return result.MapTry(func, errorHandler);
        }
    }
}
