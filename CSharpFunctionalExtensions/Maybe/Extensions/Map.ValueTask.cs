#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        public static async ValueTask<Maybe<K>> Map<T, K>(
            this ValueTask<Maybe<T>> maybeTask,
            Func<T, ValueTask<K>> valueTask
        )
        {
            Maybe<T> maybe = await maybeTask;
            return await maybe.Map(valueTask);
        }

        public static async ValueTask<Maybe<K>> Map<T, K, TContext>(
            this ValueTask<Maybe<T>> maybeTask,
            Func<T, TContext, ValueTask<K>> valueTask,
            TContext context
        )
        {
            Maybe<T> maybe = await maybeTask;
            return await maybe.Map(valueTask, context);
        }
    }
}
#endif
