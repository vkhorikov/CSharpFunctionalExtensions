using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static Maybe<T> TryLast<T>(this IEnumerable<T> source)
        {
            source = source as ICollection<T> ?? source.ToList();

            if (source.Any()) return Maybe<T>.From(source.Last());

            return Maybe<T>.None;
        }

        public static Maybe<T> TryLast<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var last = source.LastOrDefault(predicate);
            if (last != null) return Maybe<T>.From(last);

            return Maybe<T>.None;
        }
    }
}