#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        public static async ValueTask<T> GetValueOrDefault<T>(this ValueTask<Result<T>> resultTask, Func<T> defaultValue)
        {
            var result = await resultTask;
            return result.GetValueOrDefault(defaultValue);
        }

        public static async ValueTask<K> GetValueOrDefault<T, K>(this ValueTask<Result<T>> resultTask, Func<T, K> selector,
            K defaultValue = default)
        {
            var result = await resultTask;
            return result.GetValueOrDefault(selector, defaultValue);
        }

        public static async ValueTask<K> GetValueOrDefault<T, K>(this ValueTask<Result<T>> resultTask, Func<T, K> selector,
            Func<K> defaultValue)
        {
            var result = await resultTask;
            return result.GetValueOrDefault(selector, defaultValue);
        }
    }
}
#endif
