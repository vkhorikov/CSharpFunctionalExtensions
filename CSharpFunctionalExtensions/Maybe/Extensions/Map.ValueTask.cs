#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static async ValueTask<Maybe<K>> Map<T, K>(this ValueTask<Maybe<T>> maybeTask, Func<T, ValueTask<K>> selector)
        {
            Maybe<T> maybe = await maybeTask.DefaultAwait();
            return await maybe.Map(selector).DefaultAwait();
        }
    }
}
#endif