using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        public static async Task<Result> OnSuccessTry(this Task<Result> task, Action action,
            Func<Exception, string> errorHandler = null)
        {
            var result = await task.DefaultAwait();
            return result.OnSuccessTry(action, errorHandler);
        }

        public static async Task<Result<T>> OnSuccessTry<T>(this Task<Result> task, Func<T> func,
            Func<Exception, string> errorHandler = null)
        {
            var result = await task.DefaultAwait();
            return result.OnSuccessTry(func, errorHandler);
        }

        public static async Task<Result> OnSuccessTry<T>(this Task<Result<T>> task, Action<T> action,
            Func<Exception, string> errorHandler = null)
        {
            var result = await task.DefaultAwait();
            return result.OnSuccessTry(action, errorHandler);
        }

        public static async Task<Result<K>> OnSuccessTry<T, K>(this Task<Result<T>> task, Func<T, K> action,
            Func<Exception, string> errorHandler = null)
        {
            var result = await task.DefaultAwait();
            return result.OnSuccessTry(action, errorHandler);
        }

        public static async Task OnSuccessTry<T>(this Result<T> result, Func<T, Task> func)
        {
            if (result.IsSuccess)
            {
                await func(result.Value);
            }
        }

        public static async Task OnSuccessTry<T, E>(this Result<T, E> result, Func<T, Task> func)
        {
            if (result.IsSuccess)
            {
                await func(result.Value);
            }
        }
    }
}
