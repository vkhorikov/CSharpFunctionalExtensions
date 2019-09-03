using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#if NET40
using Task = System.Threading.Tasks.TaskEx;
#else
using Task = System.Threading.Tasks.Task;
#endif

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        public static async Task<Result> Combine(this IEnumerable<Task<Result>> tasks, string errorMessageSeparator = null)
        {
            Result[] results = await Task.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result<IEnumerable<T>>> Combine<T>(this IEnumerable<Task<Result<T>>> tasks, string errorMessageSeparator = null)
        {
            Result<T>[] results = await Task.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result> Combine(this Task<IEnumerable<Result>> task, string errorMessageSeparator = null)
        {
            IEnumerable<Result> results = await task.ConfigureAwait(Result.DefaultConfigureAwait);
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result<IEnumerable<T>>> Combine<T>(this Task<IEnumerable<Result<T>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<Result<T>> results = await task.ConfigureAwait(Result.DefaultConfigureAwait);
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result> Combine(this Task<IEnumerable<Task<Result>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<Task<Result>> tasks = await task.ConfigureAwait(Result.DefaultConfigureAwait);
            return await tasks.Combine(errorMessageSeparator).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result<IEnumerable<T>>> Combine<T>(this Task<IEnumerable<Task<Result<T>>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<Task<Result<T>>> tasks = await task.ConfigureAwait(Result.DefaultConfigureAwait);
            return await tasks.Combine(errorMessageSeparator).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result<K>> Combine<T, K>(this IEnumerable<Task<Result<T>>> tasks, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
        {
            IEnumerable<Result<T>> results = await Task.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
            return results.Combine(composer, errorMessageSeparator);
        }

        public static async Task<Result<K>> Combine<T, K>(this Task<IEnumerable<Task<Result<T>>>> task, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
        {
            IEnumerable<Task<Result<T>>> tasks = await task.ConfigureAwait(Result.DefaultConfigureAwait);
            return await tasks.Combine(composer, errorMessageSeparator).ConfigureAwait(Result.DefaultConfigureAwait);
        }
    }
}
