#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static async ValueTask<Result> Compensate(this ValueTask<Result> resultTask, Func<string, ValueTask<Result>> func)
        {
            var result = await resultTask;
            return await result.Compensate(func);
        }

        public static async ValueTask<UnitResult<E>> Compensate<E>(this ValueTask<Result> resultTask, Func<string, ValueTask<UnitResult<E>>> func)
        {
            var result = await resultTask;
            return await result.Compensate(func);
        }

        public static async ValueTask<Result> Compensate<T>(this ValueTask<Result<T>> resultTask, Func<string, ValueTask<Result>> func)
        {
            var result = await resultTask;
            return await result.Compensate(func);
        }

        public static async ValueTask<Result<T>> Compensate<T>(this ValueTask<Result<T>> resultTask, Func<string, ValueTask<Result<T>>> func)
        {
            var result = await resultTask;
            return await result.Compensate(func);
        }

        public static async ValueTask<Result<T, E>> Compensate<T, E>(this ValueTask<Result<T>> resultTask, Func<string, ValueTask<Result<T, E>>> func)
        {
            var result = await resultTask;
            return await result.Compensate(func);
        }

        public static async ValueTask<Result> Compensate<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, ValueTask<Result>> func)
        {
            var result = await resultTask;
            return await result.Compensate(func);
        }

        public static async ValueTask<UnitResult<E2>> Compensate<E, E2>(this ValueTask<UnitResult<E>> resultTask, Func<E, ValueTask<UnitResult<E2>>> func)
        {
            var result = await resultTask;
            return await result.Compensate(func);
        }

        public static async ValueTask<Result> Compensate<T, E>(this ValueTask<Result<T, E>> resultTask, Func<E, ValueTask<Result>> func)
        {
            var result = await resultTask;
            return await result.Compensate(func);
        }

        public static async ValueTask<UnitResult<E2>> Compensate<T, E, E2>(this ValueTask<Result<T, E>> resultTask, Func<E, ValueTask<UnitResult<E2>>> func)
        {
            var result = await resultTask;
            return await result.Compensate(func);
        }

        public static async ValueTask<Result<T, E2>> Compensate<T, E, E2>(this ValueTask<Result<T, E>> resultTask, Func<E, ValueTask<Result<T, E2>>> func)
        {
            var result = await resultTask;
            return await result.Compensate(func);
        }
    }
}
#endif