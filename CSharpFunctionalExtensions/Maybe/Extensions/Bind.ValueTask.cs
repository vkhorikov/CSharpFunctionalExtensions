#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static async ValueTask<Maybe<K>> Bind<T, K>(this ValueTask<Maybe<T>> maybeTask, Func<T, ValueTask<Maybe<K>>> selector)
        {
            Maybe<T> maybe = await maybeTask;
            return await maybe.Bind(selector);
        }
    }
}
#endif