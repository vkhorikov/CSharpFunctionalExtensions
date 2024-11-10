#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        public static async ValueTask<Maybe<K>> Map<T, K>(
            this Maybe<T> maybe,
            Func<T, ValueTask<K>> valueTask
        )
        {
            if (maybe.HasNoValue)
                return Maybe<K>.None;

            return await valueTask(maybe.GetValueOrThrow());
        }

        public static async ValueTask<Maybe<K>> Map<T, K, TContext>(
            this Maybe<T> maybe,
            Func<T, TContext, ValueTask<K>> valueTask,
            TContext context
        )
        {
            if (maybe.HasNoValue)
                return Maybe<K>.None;

            return await valueTask(maybe.GetValueOrThrow(), context);
        }
    }
}
#endif
