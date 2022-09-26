using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {        
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use MapTry() instead.")]
        public static async Task<Result<T>> OnSuccessTry<T>(this Task<Result> task, Func<T> func,
            Func<Exception, string> errorHandler = null)
        {
            return await task.MapTry(func, errorHandler).DefaultAwait();
        }        

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use MapTry() instead.")]
        public static async Task<Result<K>> OnSuccessTry<T, K>(this Task<Result<T>> task, Func<T, K> action,
            Func<Exception, string> errorHandler = null)
        {
            return await task.MapTry(action, errorHandler).DefaultAwait();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use MapTry() instead.")]
        public static async Task<Result<K, E>> OnSuccessTry<T, K, E>(this Task<Result<T, E>> task, Func<T, K> action,
            Func<Exception, E> errorHandler = null)
        {
            return await task.MapTry(action, errorHandler).DefaultAwait();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Explicitly cast to UnitResult<E> and use MapTry() instead.")]
        public static async Task<Result<T, E>> OnSuccessTry<T, E>(this Task<Result<T, E>> task, Func<T> func,
            Func<Exception, E> errorHandler = null)
        {            
            UnitResult<E> unitResult = await task.DefaultAwait();
            return unitResult.MapTry(func, errorHandler);            
        }
    }
}
