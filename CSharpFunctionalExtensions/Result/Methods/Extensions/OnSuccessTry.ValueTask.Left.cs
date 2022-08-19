#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static async ValueTask<Result> OnSuccessTry(this ValueTask<Result> task, Action action,
            Func<Exception, string> errorHandler = null)
        {
            var result = await task;
            return result.OnSuccessTry(action, errorHandler);
        }

        public static async ValueTask<Result<T>> OnSuccessTry<T>(this ValueTask<Result> task, Func<T> func,
            Func<Exception, string> errorHandler = null)
        {
            var result = await task;
            return result.OnSuccessTry(func, errorHandler);
        }

        public static async ValueTask<Result<T, E>> OnSuccessTry<T, E>(this ValueTask<Result<T, E>> task, Func<T> func,
            Func<Exception, E> errorHandler = null)
        {
            var result = await task;
            return result.OnSuccessTry(func, errorHandler);
        }
        
        public static async ValueTask<Result> OnSuccessTry<T>(this ValueTask<Result<T>> task, Action<T> action,
            Func<Exception, string> errorHandler = null)
        {
            var result = await task;
            return result.OnSuccessTry(action, errorHandler);
        }

        public static async ValueTask<Result<K>> OnSuccessTry<T, K>(this ValueTask<Result<T>> task, Func<T, K> action,
            Func<Exception, string> errorHandler = null)
        {
            var result = await task;
            return result.OnSuccessTry(action, errorHandler);
        }
        
        public static async ValueTask<Result<K, E>> OnSuccessTry<T, K, E>(this ValueTask<Result<T, E>> task, Func<T, K> action,
            Func<Exception, E> errorHandler = null)
        {
            var result = await task;
            return result.OnSuccessTry(action, errorHandler);
        }
    }
}
#endif