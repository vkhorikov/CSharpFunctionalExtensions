using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static async Task<Maybe<K>> Map<T, K>(
            this Task<Maybe<T>> maybeTask,
            Func<T, Task<K>> selector
        )
        {
            var maybe = await maybeTask.DefaultAwait();
            return await maybe.Map(selector).DefaultAwait();
        }

        public static async Task<Maybe<K>> Map<T, K, TContext>(
            this Task<Maybe<T>> maybeTask,
            Func<T, TContext, Task<K>> selector,
            TContext context
        )
        {
            var maybe = await maybeTask.DefaultAwait();
            return await maybe.Map(selector, context).DefaultAwait();
        }
    }
}
