using System;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static Maybe<K> Bind<T, K>(in this Maybe<T> maybe, Func<T, Maybe<K>> selector)
        {
            if (maybe.HasNoValue)
                return Maybe<K>.None;

            return selector(maybe.GetValueOrThrow());
        }
    }
}