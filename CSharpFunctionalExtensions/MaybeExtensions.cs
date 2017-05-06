using System;

namespace CSharpFunctionalExtensions
{
    public static class MaybeExtensions
    {
        public static Result<T> ToResult<T>(this Maybe<T> maybe, string errorMessage)
        {
            if (maybe.HasNoValue)
                return Result.Fail<T>(errorMessage);

            return Result.Ok(maybe.Value);
        }

        public static T Unwrap<T>(this Maybe<T> maybe, T defaultValue = default(T))
        {
            return maybe.Unwrap(x => x, defaultValue);
        }

        public static K Unwrap<T, K>(this Maybe<T> maybe, Func<T, K> selector, K defaultValue = default(K))
        {
            if (maybe.HasValue)
                return selector(maybe.Value);

            return defaultValue;
        }

        public static Maybe<T> Where<T>(this Maybe<T> maybe, Func<T, bool> predicate)
        {
            if (maybe.HasNoValue)
                return default(T);

            if (predicate(maybe.Value))
                return maybe;

            return default(T);
        }

        public static Maybe<K> Select<T, K>(this Maybe<T> maybe, Func<T, K> selector)
        {
            if (maybe.HasNoValue)
                return default(K);

            return selector(maybe.Value);
        }

        public static Maybe<K> Select<T, K>(this Maybe<T> maybe, Func<T, Maybe<K>> selector)
        {
            if (maybe.HasNoValue)
                return default(K);

            return selector(maybe.Value);
        }

        public static void Execute<T>(this Maybe<T> maybe, Action<T> action)
        {
            if (maybe.HasNoValue)
                return;

            action(maybe.Value);
        }

        public static TOut Execute<T, TOut>(this Maybe<T> maybe, Func<T, TOut> func)
            where T : class
        {
            if (maybe.HasNoValue)
                return default(TOut);

            return func(maybe.Value);
        }
    }
}
