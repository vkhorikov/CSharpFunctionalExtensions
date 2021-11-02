using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static async Task<T> GetValueOrDefault<T>(this Maybe<T> maybe, Func<Task<T>> defaultValue)
        {
            if (maybe.HasNoValue)
                return await defaultValue().DefaultAwait();

            return maybe.GetValueOrThrow();
        }

        public static async Task<K> GetValueOrDefault<T, K>(this Maybe<T> maybe, Func<T, K> selector,
            Func<Task<K>> defaultValue)
        {
            if (maybe.HasNoValue)
                return await defaultValue().DefaultAwait();

            return selector(maybe.GetValueOrThrow());
        }

        public static async Task<K> GetValueOrDefault<T, K>(this Maybe<T> maybe, Func<T, Task<K>> selector,
            K defaultValue = default)
        {
            if (maybe.HasNoValue)
                return defaultValue;

            return await selector(maybe.GetValueOrThrow()).DefaultAwait();
        }

        public static async Task<K> GetValueOrDefault<T, K>(this Maybe<T> maybe, Func<T, Task<K>> selector,
            Func<Task<K>> defaultValue)
        {
            if (maybe.HasNoValue)
                return await defaultValue().DefaultAwait();

            return await selector(maybe.GetValueOrThrow()).DefaultAwait();
        }
    }
}