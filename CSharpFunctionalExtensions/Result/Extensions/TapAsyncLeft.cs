using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        public static async Task<Result> Tap(this Task<Result> resultTask, Action action)
        {
            Result result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.Tap(action);
        }

        public static async Task<Result<T>> Tap<T>(this Task<Result<T>> resultTask, Action action)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.Tap(action);
        }

        public static async Task<Result<T>> Tap<T>(this Task<Result<T>> resultTask, Action<T> action)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.Tap(action);
        }

        public static async Task<Result<T, E>> Tap<T, E>(this Task<Result<T, E>> resultTask, Action action)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.Tap(action);
        }

        public static async Task<Result<T, E>> Tap<T, E>(this Task<Result<T, E>> resultTask, Action<T> action)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.Tap(action);
        }

        public static async Task<Result> Tap<K>(this Task<Result> resultTask, Func<K> func)
        {
            Result result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.Tap(func);
        }

        public static async Task<Result<T>> Tap<T, K>(this Task<Result<T>> resultTask, Func<K> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.Tap(func);
        }

        public static async Task<Result<T>> Tap<T, K>(this Task<Result<T>> resultTask, Func<T, K> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.Tap(func);
        }

        public static async Task<Result<T, E>> Tap<T, K, E>(this Task<Result<T, E>> resultTask, Func<K> func)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.Tap(func);
        }

        public static async Task<Result<T, E>> Tap<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, K> func)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.Tap(func);
        }
    }
}
