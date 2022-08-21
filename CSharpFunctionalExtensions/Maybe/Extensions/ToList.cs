using System.Collections.Generic;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static List<T> ToList<T>(in this Maybe<T> maybe)
        {
            return maybe.GetValueOrDefault(value => new List<T> { value }, new List<T>());
        }
    }
}