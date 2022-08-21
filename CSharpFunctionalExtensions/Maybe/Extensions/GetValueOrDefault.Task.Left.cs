using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static async Task<T> GetValueOrDefault<T>(this Task<Maybe<T>> maybeTask, Func<T> defaultValue)
        {
            var maybe = await maybeTask.DefaultAwait();
            return maybe.GetValueOrDefault(defaultValue);
        }
        
        public static async Task<K> GetValueOrDefault<T, K>(this Task<Maybe<T>> maybeTask, Func<T, K> selector,
            K defaultValue = default)
        {
            var maybe = await maybeTask.DefaultAwait();
            return maybe.GetValueOrDefault(selector, defaultValue);
        }

        public static async Task<K> GetValueOrDefault<T, K>(this Task<Maybe<T>> maybeTask, Func<T, K> selector,
            Func<K> defaultValue)
        {
            var maybe = await maybeTask.DefaultAwait();
            return maybe.GetValueOrDefault(selector, defaultValue);
        }
    }
}