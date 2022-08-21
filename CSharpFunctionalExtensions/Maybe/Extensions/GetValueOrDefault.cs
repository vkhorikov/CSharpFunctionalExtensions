using System;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static T GetValueOrDefault<T>(in this Maybe<T> maybe, Func<T> defaultValue)
        {
            if (maybe.HasNoValue)
                return defaultValue();

            return maybe.GetValueOrThrow();
        }

        public static K GetValueOrDefault<T, K>(in this Maybe<T> maybe, Func<T, K> selector, K defaultValue = default)
        {
            if (maybe.HasNoValue)
                return defaultValue;

            return selector(maybe.GetValueOrThrow());
        }

        public static K GetValueOrDefault<T, K>(in this Maybe<T> maybe, Func<T, K> selector, Func<K> defaultValue)
        {
            if (maybe.HasNoValue)
                return defaultValue();

            return selector(maybe.GetValueOrThrow());
        }
    }
}