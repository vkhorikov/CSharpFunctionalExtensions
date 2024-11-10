#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        public static async ValueTask<Maybe<K>> Bind<T, K>(this ValueTask<Maybe<T>> maybeTask, Func<T, Maybe<K>> selector)
        {
            Maybe<T> maybe = await maybeTask;
            return maybe.Bind(selector);
        }

        public static async ValueTask<Maybe<K>> Bind<T, K, TContext>(
                this ValueTask<Maybe<T>> maybeTask,
                Func<T, TContext, Maybe<K>> selector,
                TContext context)
        {
            Maybe<T> maybe = await maybeTask;
            return maybe.Bind(selector, context);
        }
    }
}
#endif
