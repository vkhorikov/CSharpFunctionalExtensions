using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static async Task<T> GetValueOrDefault<T>(this Result<T> result, Func<Task<T>> defaultValue)
        {
            if (result.IsFailure)
                return await defaultValue().DefaultAwait();

            return result.Value;
        }

        public static async Task<K> GetValueOrDefault<T, K>(this Result<T> result, Func<T, K> selector,
            Func<Task<K>> defaultValue)
        {
            if (result.IsFailure)
                return await defaultValue().DefaultAwait();

            return selector(result.Value);
        }

        public static async Task<K> GetValueOrDefault<T, K>(this Result<T> result, Func<T, Task<K>> selector,
            K defaultValue = default)
        {
            if (result.IsFailure)
                return defaultValue;

            return await selector(result.Value).DefaultAwait();
        }

        public static async Task<K> GetValueOrDefault<T, K>(this Result<T> result, Func<T, Task<K>> selector,
            Func<Task<K>> defaultValue)
        {
            if (result.IsFailure)
                return await defaultValue().DefaultAwait();

            return await selector(result.Value).DefaultAwait();
        }
    }
}
