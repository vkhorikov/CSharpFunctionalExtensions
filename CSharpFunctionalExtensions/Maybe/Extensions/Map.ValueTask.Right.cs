#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static async ValueTask<Maybe<K>> Map<T, K>(this Maybe<T> maybe, Func<T, ValueTask<K>> selector)
        {
            if (maybe.HasNoValue)
                return Maybe<K>.None;

            return await selector(maybe.GetValueOrThrow()).DefaultAwait();
        }
    }
}
#endif