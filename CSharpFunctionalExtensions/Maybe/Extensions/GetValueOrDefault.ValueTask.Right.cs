#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static async ValueTask<T> GetValueOrDefault<T>(this Maybe<T> maybe, Func<ValueTask<T>> defaultValue)
        {
            if (maybe.HasNoValue)
                return await defaultValue();

            return maybe.GetValueOrThrow();
        }

        public static async ValueTask<K> GetValueOrDefault<T, K>(this Maybe<T> maybe, Func<T, K> selector,
            Func<ValueTask<K>> defaultValue)
        {
            if (maybe.HasNoValue)
                return await defaultValue();

            return selector(maybe.GetValueOrThrow());
        }

        public static async ValueTask<K> GetValueOrDefault<T, K>(this Maybe<T> maybe, Func<T, ValueTask<K>> selector,
            K defaultValue = default)
        {
            if (maybe.HasNoValue)
                return defaultValue;

            return await selector(maybe.GetValueOrThrow());
        }

        public static async ValueTask<K> GetValueOrDefault<T, K>(this Maybe<T> maybe, Func<T, ValueTask<K>> selector,
            Func<ValueTask<K>> defaultValue)
        {
            if (maybe.HasNoValue)
                return await defaultValue();

            return await selector(maybe.GetValueOrThrow());
        }
    }
}
#endif