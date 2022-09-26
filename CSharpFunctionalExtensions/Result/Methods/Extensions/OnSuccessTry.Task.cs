using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static async Task<Result> OnSuccessTry(this Task<Result> task, Func<Task> func,
            Func<Exception, string> errorHandler = null)
        {
            var result = await task.DefaultAwait();
            return await result.OnSuccessTry(func, errorHandler).DefaultAwait();
        }

        public static async Task<Result> OnSuccessTry<T>(this Task<Result<T>> task, Func<T, Task> func,
            Func<Exception, string> errorHandler = null)
        {
            var result = await task.DefaultAwait();
            return await result.OnSuccessTry(func, errorHandler).DefaultAwait();
        }
    }
}
