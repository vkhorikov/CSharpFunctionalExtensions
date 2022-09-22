using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use MapTry() instead.")]
        public static async Task<Result<T>> OnSuccessTry<T>(this Result result, Func<Task<T>> func,
            Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? Result.Failure<T>(result.Error)
                : await Result.Try(func, errorHandler).DefaultAwait();
        }       

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use MapTry() instead.")]
        public static async Task<Result<K>> OnSuccessTry<T, K>(this Result<T> result, Func<T, Task<K>> func,
            Func<Exception, string> errorHandler = null)
        {
            return await result.MapTry(func, errorHandler);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use MapTry() instead.")]
        public static async Task<Result<K, E>> OnSuccessTry<T, K, E>(this Result<T, E> result, Func<T, Task<K>> func,
            Func<Exception, E> errorHandler = null)
        {
            return await result.MapTry(func, errorHandler);
        }
    }
}
