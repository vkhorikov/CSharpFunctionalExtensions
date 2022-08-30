#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
      public static async ValueTask<Result<T, E>> OnFailureCompensate<T, E>(this ValueTask<Result<T, E>> resultTask,
            Func<Result<T, E>> valueTask)
        {
            Result<T, E> result = await resultTask;
            return result.OnFailureCompensate(valueTask);
        }
        
        public static async ValueTask<Result<T>> OnFailureCompensate<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>> valueTask)
        {
            Result<T> result = await resultTask;
            return result.OnFailureCompensate(valueTask);
        }

        public static async ValueTask<Result> OnFailureCompensate(this ValueTask<Result> resultTask, Func<Result> valueTask)
        {
            Result result = await resultTask;
            return result.OnFailureCompensate(valueTask);
        }

        public static async ValueTask<Result<T>> OnFailureCompensate<T>(this ValueTask<Result<T>> resultTask, Func<string, Result<T>> valueTask)
        {
            Result<T> result = await resultTask;
            return result.OnFailureCompensate(valueTask);
        }

        public static async ValueTask<Result<T, E>> OnFailureCompensate<T, E>(this ValueTask<Result<T, E>> resultTask,
            Func<E, Result<T, E>> valueTask)
        {
            Result<T, E> result = await resultTask;
            return result.OnFailureCompensate(valueTask);
        }

        public static async ValueTask<Result> OnFailureCompensate(this ValueTask<Result> resultTask, Func<string, Result> valueTask)
        {
            Result result = await resultTask;
            return result.OnFailureCompensate(valueTask);
        }
    }
}
#endif