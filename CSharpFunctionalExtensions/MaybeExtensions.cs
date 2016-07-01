using System;


namespace CSharpFunctionalExtensions
{
    public static class MaybeExtensions
    {
        public static Result<T> ToResult<T>(this Maybe<T> maybe, string errorMessage)
            where T : class
        {
            if (maybe.HasNoValue)
                return Result.Fail<T>(errorMessage);

            return Result.Ok(maybe.Value);
        }

        public static T Unwrap<T>(this Maybe<T> maybe)
            where T : class
        {
            return maybe.Unwrap(x => x);
        }

        public static K Unwrap<T, K>(this Maybe<T> maybe, Func<T, K> selector)
            where T : class
        {
            if (maybe.HasValue)
                return selector(maybe.Value);

            return default(K);
        }

        public static Maybe<T> Where<T>(this Maybe<T> maybe, Func<T, bool> predicate)
            where T : class
        {
            if (maybe.HasNoValue)
                return null;

            if (predicate(maybe.Value))
                return maybe;

            return null;
        }

        public static Maybe<K> Map<T, K>(this Maybe<T> maybe, Func<T, K> selector)
            where T : class
            where K : class
        {
            if (maybe.HasNoValue)
                return null;

            return selector(maybe.Value);
        }
    }
}
