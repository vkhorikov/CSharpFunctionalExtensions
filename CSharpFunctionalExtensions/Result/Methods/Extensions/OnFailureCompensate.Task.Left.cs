using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        public static async Task<Result<T, E>> OnFailureCompensate<T, E>(this Task<Result<T, E>> resultTask,
            Func<Result<T, E>> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            return result.OnFailureCompensate(func);
        }
        
        public static async Task<Result<T>> OnFailureCompensate<T>(this Task<Result<T>> resultTask, Func<Result<T>> func)
        {
            Result<T> result = await resultTask.DefaultAwait();
            return result.OnFailureCompensate(func);
        }

        public static async Task<Result> OnFailureCompensate(this Task<Result> resultTask, Func<Result> func)
        {
            Result result = await resultTask.DefaultAwait();
            return result.OnFailureCompensate(func);
        }

        public static async Task<Result<T>> OnFailureCompensate<T>(this Task<Result<T>> resultTask, Func<string, Result<T>> func)
        {
            Result<T> result = await resultTask.DefaultAwait();
            return result.OnFailureCompensate(func);
        }

        public static async Task<Result<T, E>> OnFailureCompensate<T, E>(this Task<Result<T, E>> resultTask,
            Func<E, Result<T, E>> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            return result.OnFailureCompensate(func);
        }

        public static async Task<Result> OnFailureCompensate(this Task<Result> resultTask, Func<string, Result> func)
        {
            Result result = await resultTask.DefaultAwait();
            return result.OnFailureCompensate(func);
        }
    }
}
