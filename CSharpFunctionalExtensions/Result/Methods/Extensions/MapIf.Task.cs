using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static async Task<Result<T>> MapIf<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<T>> func)
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapIf(condition, func).DefaultAwait();
        }

        public static async Task<Result<T, E>> MapIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Func<T, Task<T>> func)
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapIf(condition, func).DefaultAwait();
        }

        public static async Task<Result<T>> MapIf<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Task<T>> func)
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapIf(predicate, func).DefaultAwait();
        }

        public static async Task<Result<T, E>> MapIf<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, Task<T>> func)
        {
            var result = await resultTask.DefaultAwait();
            return await result.MapIf(predicate, func).DefaultAwait();
        }
    }
}