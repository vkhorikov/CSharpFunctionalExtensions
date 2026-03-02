using System;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static Maybe<K> SelectMany<T, K>(in this Maybe<T> maybe, Func<T, Maybe<K>> selector)
        {
            return maybe.Bind(selector);
        }

        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static Maybe<V> SelectMany<T, U, V>(in this Maybe<T> maybe,
            Func<T, Maybe<U>> selector,
            Func<T, U, V> project)
        {
            return maybe.GetValueOrDefault(
                x => selector(x).GetValueOrDefault(u => project(x, u), Maybe<V>.None),
                Maybe<V>.None);
        }
    }
}
