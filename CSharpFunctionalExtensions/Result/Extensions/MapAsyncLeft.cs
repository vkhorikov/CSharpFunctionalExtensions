using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        public static async Task<Result<K, E>> Map<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, K> func)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.Map(func);
        }

        public static async Task<Result<K>> Map<T, K>(this Task<Result<T>> resultTask, Func<T, K> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.Map(func);
        }

        public static async Task<Result<K>> Map<K>(this Task<Result> resultTask, Func<K> func)
        {
            Result result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.Map(func);
        }
    }
}
