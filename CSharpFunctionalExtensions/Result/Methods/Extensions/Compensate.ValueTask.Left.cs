#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        public static async ValueTask<Result> Compensate(this ValueTask<Result> resultTask, Func<string, Result> valueTask)
        {
            var result = await resultTask;
            return result.Compensate(valueTask);
        }

        public static async ValueTask<UnitResult<E>> Compensate<E>(this ValueTask<Result> resultTask, Func<string, UnitResult<E>> valueTask)
        {
            var result = await resultTask;
            return result.Compensate(valueTask);
        }

        public static async ValueTask<Result> Compensate<T>(this ValueTask<Result<T>> resultTask, Func<string, Result> valueTask)
        {
            var result = await resultTask;
            return result.Compensate(valueTask);
        }

        public static async ValueTask<Result<T>> Compensate<T>(this ValueTask<Result<T>> resultTask, Func<string, Result<T>> valueTask)
        {
            var result = await resultTask;
            return result.Compensate(valueTask);
        }

        public static async ValueTask<Result<T, E>> Compensate<T, E>(this ValueTask<Result<T>> resultTask, Func<string, Result<T, E>> valueTask)
        {
            var result = await resultTask;
            return result.Compensate(valueTask);
        }

        public static async ValueTask<Result> Compensate<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, Result> valueTask)
        {
            var result = await resultTask;
            return result.Compensate(valueTask);
        }

        public static async ValueTask<UnitResult<E2>> Compensate<E, E2>(this ValueTask<UnitResult<E>> resultTask, Func<E, UnitResult<E2>> valueTask)
        {
            var result = await resultTask;
            return result.Compensate(valueTask);
        }

        public static async ValueTask<Result> Compensate<T, E>(this ValueTask<Result<T, E>> resultTask, Func<E, Result> valueTask)
        {
            var result = await resultTask;
            return result.Compensate(valueTask);
        }

        public static async ValueTask<UnitResult<E2>> Compensate<T, E, E2>(this ValueTask<Result<T, E>> resultTask, Func<E, UnitResult<E2>> valueTask)
        {
            var result = await resultTask;
            return result.Compensate(valueTask);
        }

        public static async ValueTask<Result<T, E2>> Compensate<T, E, E2>(this ValueTask<Result<T, E>> resultTask, Func<E, Result<T, E2>> valueTask)
        {
            var result = await resultTask;
            return result.Compensate(valueTask);
        }
    }
}
#endif