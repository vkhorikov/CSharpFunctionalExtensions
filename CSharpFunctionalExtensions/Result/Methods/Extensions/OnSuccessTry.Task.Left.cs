using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static async Task<Result> OnSuccessTry(this Task<Result> task, Action action,
            Func<Exception, string> errorHandler = null)
        {
            var result = await task.DefaultAwait();
            return result.OnSuccessTry(action, errorHandler);
        }

        public static async Task<Result> OnSuccessTry<T>(this Task<Result<T>> task, Action<T> action,
            Func<Exception, string> errorHandler = null)
        {
            var result = await task.DefaultAwait();
            return result.OnSuccessTry(action, errorHandler);
        }
    }
}
