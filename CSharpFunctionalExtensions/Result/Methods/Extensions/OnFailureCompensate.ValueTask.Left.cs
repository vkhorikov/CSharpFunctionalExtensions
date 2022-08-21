#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
      public static async ValueTask<Result<T, E>> OnFailureCompensate<T, E>(this ValueTask<Result<T, E>> resultTask,
            Func<Result<T, E>> func)
        {
            Result<T, E> result = await resultTask;
            return result.OnFailureCompensate(func);
        }
        
        public static async ValueTask<Result<T>> OnFailureCompensate<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>> func)
        {
            Result<T> result = await resultTask;
            return result.OnFailureCompensate(func);
        }

        public static async ValueTask<Result> OnFailureCompensate(this ValueTask<Result> resultTask, Func<Result> func)
        {
            Result result = await resultTask;
            return result.OnFailureCompensate(func);
        }

        public static async ValueTask<Result<T>> OnFailureCompensate<T>(this ValueTask<Result<T>> resultTask, Func<string, Result<T>> func)
        {
            Result<T> result = await resultTask;
            return result.OnFailureCompensate(func);
        }

        public static async ValueTask<Result<T, E>> OnFailureCompensate<T, E>(this ValueTask<Result<T, E>> resultTask,
            Func<E, Result<T, E>> func)
        {
            Result<T, E> result = await resultTask;
            return result.OnFailureCompensate(func);
        }

        public static async ValueTask<Result> OnFailureCompensate(this ValueTask<Result> resultTask, Func<string, Result> func)
        {
            Result result = await resultTask;
            return result.OnFailureCompensate(func);
        }
    }
}
#endif