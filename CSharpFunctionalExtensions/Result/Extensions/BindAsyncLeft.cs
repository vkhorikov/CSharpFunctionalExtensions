using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        public static async Task<Result<K, E>> Bind<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Result<K, E>> func)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.Bind(func);
        }

        public static async Task<Result<K>> Bind<T, K>(this Task<Result<T>> resultTask, Func<T, Result<K>> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.Bind(func);
        }

        public static async Task<Result<K>> Bind<K>(this Task<Result> resultTask, Func<Result<K>> func)
        {
            Result result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.Bind(func);
        }

        public static async Task<Result> Bind<T>(this Task<Result<T>> resultTask, Func<T, Result> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.Bind(func);
        }

        public static async Task<Result> Bind(this Task<Result> resultTask, Func<Result> func)
        {
            Result result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.Bind(func);
        }
    }
}
