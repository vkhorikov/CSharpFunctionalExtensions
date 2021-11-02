using System;
using System.ComponentModel;

namespace CSharpFunctionalExtensions.Obsolete
{
    public static partial class MaybeExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use GetValueOrDefault() instead.")]
        public static T Unwrap<T>(in this Maybe<T> maybe, T defaultValue = default)
        {
            return maybe.GetValueOrDefault(defaultValue);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use GetValueOrDefault() instead.")]
        public static K Unwrap<T, K>(in this Maybe<T> maybe, Func<T, K> selector, K defaultValue = default(K))
        {
            return maybe.GetValueOrDefault(selector, defaultValue);
        }
    }
}