using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static async Task<T> GetValueOrDefault<T>(this Task<Maybe<T>> maybeTask, Func<Task<T>> defaultValue)
        {
            var maybe = await maybeTask.DefaultAwait();
            return await maybe.GetValueOrDefault(defaultValue).DefaultAwait();
        }
        
        public static async Task<K> GetValueOrDefault<T, K>(this Task<Maybe<T>> maybeTask, Func<T, Task<K>> selector,
            K defaultValue = default)
        {
            var maybe = await maybeTask.DefaultAwait();
            return await maybe.GetValueOrDefault(selector, defaultValue).DefaultAwait();
        }

        public static async Task<K> GetValueOrDefault<T, K>(this Task<Maybe<T>> maybeTask, Func<T, Task<K>> selector,
            Func<Task<K>> defaultValue)
        {
            var maybe = await maybeTask.DefaultAwait();
            return await maybe.GetValueOrDefault(selector, defaultValue).DefaultAwait();
        }
    }
}