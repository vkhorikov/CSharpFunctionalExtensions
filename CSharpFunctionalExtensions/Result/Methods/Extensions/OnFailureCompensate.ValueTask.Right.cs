#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        public static async ValueTask<Result<T>> OnFailureCompensate<T>(this Result<T> result, Func<ValueTask<Result<T>>> valueTask)
        {
            if (result.IsFailure)
                return await valueTask();

            return result;
        }

        public static async ValueTask<Result<T, E>> OnFailureCompensate<T, E>(this Result<T, E> result, Func<ValueTask<Result<T, E>>> valueTask)
        {
            if (result.IsFailure)
                return await valueTask();

            return result;
        }

        public static async ValueTask<Result> OnFailureCompensate(this Result result, Func<ValueTask<Result>> valueTask)
        {
            if (result.IsFailure)
                return await valueTask();

            return result;
        }

        public static async ValueTask<Result<T>> OnFailureCompensate<T>(this Result<T> result, Func<string, ValueTask<Result<T>>> valueTask)
        {
            if (result.IsFailure)
                return await valueTask(result.Error);

            return result;
        }

        public static async ValueTask<Result<T, E>> OnFailureCompensate<T, E>(this Result<T, E> result,
            Func<E, ValueTask<Result<T, E>>> valueTask)
        {
            if (result.IsFailure)
                return await valueTask(result.Error);

            return result;
        }
        
        public static async ValueTask<Result> OnFailureCompensate(this Result result, Func<string, ValueTask<Result>> valueTask)
        {
            if (result.IsFailure)
                return await valueTask(result.Error);

            return result;
        }
    }
}
#endif
