using System;
using System.ComponentModel;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static Maybe<K> Select<T, K>(in this Maybe<T> maybe, Func<T, K> selector)
        {
            return maybe.Map(selector);
        }
    }
}
