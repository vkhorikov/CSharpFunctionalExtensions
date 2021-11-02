#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
       public static async ValueTask<Result<T, E>> OnFailureCompensate<T, E>(this ValueTask<Result<T, E>> resultTask,
            Func<ValueTask<Result<T, E>>> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return await func().DefaultAwait();

            return result;
        }

        public static async ValueTask<Result<T>> OnFailureCompensate<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result<T>>> func)
        {
            Result<T> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return await func().DefaultAwait();

            return result;
        }

        public static async ValueTask<Result> OnFailureCompensate(this ValueTask<Result> resultTask, Func<ValueTask<Result>> func)
        {
            Result result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return await func().DefaultAwait();

            return result;
        }
        
        
        public static async ValueTask<Result<T>> OnFailureCompensate<T>(this ValueTask<Result<T>> resultTask, Func<string, ValueTask<Result<T>>> func)
        {
            Result<T> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return await func(result.Error).DefaultAwait();

            return result;
        }

        public static async ValueTask<Result<T, E>> OnFailureCompensate<T, E>(this ValueTask<Result<T, E>> resultTask,
            Func<E, ValueTask<Result<T, E>>> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();

            if (result.IsFailure)
                return await func(result.Error).DefaultAwait();

            return result;
        }

        public static async ValueTask<Result> OnFailureCompensate(this ValueTask<Result> resultTask, Func<string, ValueTask<Result>> func)
        {
            Result result = await resultTask.DefaultAwait();
            
            if (result.IsFailure)
                return await func(result.Error).DefaultAwait();

            return result;
        }
    }
}
#endif