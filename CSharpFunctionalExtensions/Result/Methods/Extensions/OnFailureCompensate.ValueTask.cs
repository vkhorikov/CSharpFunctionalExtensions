#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsBothOperands
    {
       public static async ValueTask<Result<T, E>> OnFailureCompensate<T, E>(this ValueTask<Result<T, E>> resultTask,
            Func<ValueTask<Result<T, E>>> valueTask)
        {
            Result<T, E> result = await resultTask;

            if (result.IsFailure)
                return await valueTask();

            return result;
        }

        public static async ValueTask<Result<T>> OnFailureCompensate<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result<T>>> valueTask)
        {
            Result<T> result = await resultTask;

            if (result.IsFailure)
                return await valueTask();

            return result;
        }

        public static async ValueTask<Result> OnFailureCompensate(this ValueTask<Result> resultTask, Func<ValueTask<Result>> valueTask)
        {
            Result result = await resultTask;

            if (result.IsFailure)
                return await valueTask();

            return result;
        }
        
        
        public static async ValueTask<Result<T>> OnFailureCompensate<T>(this ValueTask<Result<T>> resultTask, Func<string, ValueTask<Result<T>>> valueTask)
        {
            Result<T> result = await resultTask;

            if (result.IsFailure)
                return await valueTask(result.Error);

            return result;
        }

        public static async ValueTask<Result<T, E>> OnFailureCompensate<T, E>(this ValueTask<Result<T, E>> resultTask,
            Func<E, ValueTask<Result<T, E>>> valueTask)
        {
            Result<T, E> result = await resultTask;

            if (result.IsFailure)
                return await valueTask(result.Error);

            return result;
        }

        public static async ValueTask<Result> OnFailureCompensate(this ValueTask<Result> resultTask, Func<string, ValueTask<Result>> valueTask)
        {
            Result result = await resultTask;
            
            if (result.IsFailure)
                return await valueTask(result.Error);

            return result;
        }
    }
}
#endif