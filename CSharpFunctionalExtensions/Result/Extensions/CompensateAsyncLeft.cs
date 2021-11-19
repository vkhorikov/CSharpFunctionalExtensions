using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static async Task<Result> Compensate(this Task<Result> resultTask, Func<string, Result> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.Compensate(func);
        }

        public static async Task<UnitResult<E>> Compensate<E>(this Task<Result> resultTask, Func<string, UnitResult<E>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.Compensate(func);
        }

        public static async Task<Result> Compensate<T>(this Task<Result<T>> resultTask, Func<string, Result> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.Compensate(func);
        }

        public static async Task<Result<T>> Compensate<T>(this Task<Result<T>> resultTask, Func<string, Result<T>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.Compensate(func);
        }

        public static async Task<Result<T, E>> Compensate<T, E>(this Task<Result<T>> resultTask, Func<string, Result<T, E>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.Compensate(func);
        }

        public static async Task<Result> Compensate<E>(this Task<UnitResult<E>> resultTask, Func<E, Result> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.Compensate(func);
        }

        public static async Task<UnitResult<E2>> Compensate<E, E2>(this Task<UnitResult<E>> resultTask, Func<E, UnitResult<E2>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.Compensate(func);
        }

        public static async Task<Result> Compensate<T, E>(this Task<Result<T, E>> resultTask, Func<E, Result> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.Compensate(func);
        }

        public static async Task<UnitResult<E2>> Compensate<T, E, E2>(this Task<Result<T, E>> resultTask, Func<E, UnitResult<E2>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.Compensate(func);
        }

        public static async Task<Result<T, E2>> Compensate<T, E, E2>(this Task<Result<T, E>> resultTask, Func<E, Result<T, E2>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.Compensate(func);
        }
    }
}