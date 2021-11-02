using System;
using System.Collections.Generic;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static IEnumerable<U> Choose<T, U>(this IEnumerable<Maybe<T>> source, Func<T, U> selector)
        {
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var item = enumerator.Current;
                    if (item.HasValue) yield return selector(item.GetValueOrThrow());
                }
            }
        }

        public static IEnumerable<T> Choose<T>(this IEnumerable<Maybe<T>> source)
        {
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var item = enumerator.Current;
                    if (item.HasValue) yield return item.GetValueOrThrow();
                }
            }
        }
    }
}