using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static async Task<Maybe<K>> Map<T, K>(this Maybe<T> maybe, Func<T, Task<K>> selector)
        {
            if (maybe.HasNoValue)
                return Maybe<K>.None;

            return await selector(maybe.GetValueOrThrow()).DefaultAwait();
        }

        public static async Task<Maybe<K>> Map<T, K, TContext>(
            this Maybe<T> maybe,
            Func<T, TContext, Task<K>> selector,
            TContext context
        )
        {
            if (maybe.HasNoValue)
                return Maybe<K>.None;

            return await selector(maybe.GetValueOrThrow(), context).DefaultAwait();
        }
    }
}
