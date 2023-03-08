using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static async Task<T> GetValueOrDefault<T>(this Task<Result<T>> resultTask, Func<Task<T>> defaultValue)
        {
            var result = await resultTask.DefaultAwait();
            return await result.GetValueOrDefault(defaultValue).DefaultAwait();
        }

        public static async Task<K> GetValueOrDefault<T, K>(this Task<Result<T>> resultTask, Func<T, Task<K>> selector,
            K defaultValue = default)
        {
            var result = await resultTask.DefaultAwait();
            return await result.GetValueOrDefault(selector, defaultValue).DefaultAwait();
        }

        public static async Task<K> GetValueOrDefault<T, K>(this Task<Result<T>> resultTask, Func<T, Task<K>> selector,
            Func<Task<K>> defaultValue)
        {
            var result = await resultTask.DefaultAwait();
            return await result.GetValueOrDefault(selector, defaultValue).DefaultAwait();
        }
    }
}
