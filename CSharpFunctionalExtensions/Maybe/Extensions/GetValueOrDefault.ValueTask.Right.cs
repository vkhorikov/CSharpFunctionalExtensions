#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        public static async ValueTask<T> GetValueOrDefault<T>(this Maybe<T> maybe, Func<ValueTask<T>> valueTask)
        {
            if (maybe.HasNoValue)
                return await valueTask();

            return maybe.GetValueOrThrow();
        }

        public static async ValueTask<K> GetValueOrDefault<T, K>(this Maybe<T> maybe, Func<T, K> selector,
            Func<ValueTask<K>> valueTask)
        {
            if (maybe.HasNoValue)
                return await valueTask();

            return selector(maybe.GetValueOrThrow());
        }

        public static async ValueTask<K> GetValueOrDefault<T, K>(this Maybe<T> maybe, Func<T, ValueTask<K>> valueTask,
            K defaultValue = default)
        {
            if (maybe.HasNoValue)
                return defaultValue;

            return await valueTask(maybe.GetValueOrThrow());
        }

        public static async ValueTask<K> GetValueOrDefault<T, K>(this Maybe<T> maybe, Func<T, ValueTask<K>> valueTask,
            Func<ValueTask<K>> defaultValue)
        {
            if (maybe.HasNoValue)
                return await defaultValue();

            return await valueTask(maybe.GetValueOrThrow());
        }
    }
}
#endif