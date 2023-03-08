#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        public static async ValueTask<T> GetValueOrDefault<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<T>> defaultValue)
        {
            var result = await resultTask;
            return await result.GetValueOrDefault(defaultValue);
        }

        public static async ValueTask<K> GetValueOrDefault<T, K>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<K>> selector,
            K defaultValue = default)
        {
            var result = await resultTask;
            return await result.GetValueOrDefault(selector, defaultValue);
        }

        public static async ValueTask<K> GetValueOrDefault<T, K>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<K>> selector,
            Func<ValueTask<K>> defaultValue)
        {
            var result = await resultTask;
            return await result.GetValueOrDefault(selector, defaultValue);
        }
    }
}
#endif
