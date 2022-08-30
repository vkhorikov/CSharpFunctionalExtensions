#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        public static async ValueTask<T> GetValueOrDefault<T>(this ValueTask<Maybe<T>> maybeTask, Func<T> defaultValue)
        {
            var maybe = await maybeTask;
            return maybe.GetValueOrDefault(defaultValue);
        }
        
        public static async ValueTask<K> GetValueOrDefault<T, K>(this ValueTask<Maybe<T>> maybeTask, Func<T, K> selector,
            K defaultValue = default)
        {
            var maybe = await maybeTask;
            return maybe.GetValueOrDefault(selector, defaultValue);
        }

        public static async ValueTask<K> GetValueOrDefault<T, K>(this ValueTask<Maybe<T>> maybeTask, Func<T, K> selector,
            Func<K> defaultValue)
        {
            var maybe = await maybeTask;
            return maybe.GetValueOrDefault(selector, defaultValue);
        }
    }
}
#endif