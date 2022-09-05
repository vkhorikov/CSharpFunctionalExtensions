using System.Collections.Generic;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
#if !NET45_OR_GREATER && !NETSTANDARD && !NETCORE && !NET
        public static Maybe<V> TryFind<K, V>(this IDictionary<K, V> dict, K key)
        {
            if (dict.ContainsKey(key)) return dict[key];

            return Maybe<V>.None;
        }
#else
        public static Maybe<V> TryFind<K, V>(this IReadOnlyDictionary<K, V> dict, K key)
        {
            if (dict.ContainsKey(key))
            {
                return dict[key];
            }
            return Maybe<V>.None;
        }
#endif
    }
}