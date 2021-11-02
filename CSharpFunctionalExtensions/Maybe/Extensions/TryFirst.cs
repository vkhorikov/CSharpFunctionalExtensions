using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static Maybe<T> TryFirst<T>(this IEnumerable<T> source)
        {
            source = source as ICollection<T> ?? source.ToList();

            if (source.Any()) return Maybe<T>.From(source.First());

            return Maybe<T>.None;
        }

        public static Maybe<T> TryFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var firstOrEmpty = source.Where(predicate).Take(1).ToList();
            if (firstOrEmpty.Any()) return Maybe<T>.From(firstOrEmpty[0]);

            return Maybe<T>.None;
        }
    }
}