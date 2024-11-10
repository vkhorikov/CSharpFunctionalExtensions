using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static async Task<Maybe<K>> Bind<T, K>(this Task<Maybe<T>> maybeTask, Func<T, Task<Maybe<K>>> selector)
        {
            var maybe = await maybeTask.DefaultAwait();
            return await maybe.Bind(selector).DefaultAwait();
        }

        public static async Task<Maybe<K>> Bind<T, K, TContext>(this Task<Maybe<T>> maybeTask, Func<T, TContext, Task<Maybe<K>>> selector, TContext context)
        {
            var maybe = await maybeTask.DefaultAwait();
            return await maybe.Bind(selector, context).DefaultAwait();
        }
    }
}
