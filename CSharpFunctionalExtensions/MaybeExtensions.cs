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

        public static Result<T, E> ToResult<T, E>(this Maybe<T> maybe, E error) where E : class
        {
            if (maybe.HasNoValue)
                return Result.Fail<T, E>(error);

            return Result.Ok<T, E>(maybe.Value);
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
                return Maybe<T>.None;

            if (predicate(maybe.Value))
                return maybe;

            return Maybe<T>.None;
        }

        public static Maybe<K> Select<T, K>(this Maybe<T> maybe, Func<T, K> selector)
        {
            if (maybe.HasNoValue)
                return Maybe<K>.None;

            return selector(maybe.Value);
        }

        public static Maybe<K> Select<T, K>(this Maybe<T> maybe, Func<T, Maybe<K>> selector)
        {
            if (maybe.HasNoValue)
                return Maybe<K>.None;

            return selector(maybe.Value);
        }

        public static void Execute<T>(this Maybe<T> maybe, Action<T> action)
        {
            if (maybe.HasNoValue)
                return;

            action(maybe.Value);
        }
    }
}