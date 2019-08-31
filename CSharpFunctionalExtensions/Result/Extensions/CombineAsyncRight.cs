using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        public static async Task<Result> Combine(this IEnumerable<Task<Result>> tasks, string errorMessageSeparator)
        {
#if NET40
            Result[] results = await TaskEx.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
#else
            Result[] results = await Task.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
#endif
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result<IEnumerable<T>>> Combine<T>(this IEnumerable<Task<Result<T>>> tasks,
            string errorMessageSeparator)
        {
#if NET40
            Result<T>[] results = await TaskEx.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
#else
            Result<T>[] results = await Task.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
#endif
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result> Combine(this Task<IEnumerable<Result>> task, string errorMessageSeparator)
        {
            IEnumerable<Result> results = await task.ConfigureAwait(Result.DefaultConfigureAwait);
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result<IEnumerable<T>>> Combine<T>(this Task<IEnumerable<Result<T>>> task,
            string errorMessageSeparator)
        {
            IEnumerable<Result<T>> results = await task.ConfigureAwait(Result.DefaultConfigureAwait);
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result> Combine(this Task<IEnumerable<Task<Result>>> task,
            string errorMessageSeparator)
        {
            var tasks = await task.ConfigureAwait(Result.DefaultConfigureAwait);

#if NET40
            var results = await TaskEx.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
#else
            var results = await Task.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
#endif

            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result<IEnumerable<T>>> Combine<T>(this Task<IEnumerable<Task<Result<T>>>> task,
            string errorMessageSeparator)
        {
            var tasks = await task.ConfigureAwait(Result.DefaultConfigureAwait);
#if NET40
            var results = await TaskEx.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
#else
            var results = await Task.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
#endif

            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result<K>> Combine<T, K>(this IEnumerable<Task<Result<T>>> tasks,
            Func<IEnumerable<T>, K> composer,
            string errorMessageSeparator)
        {
#if NET40
            IEnumerable<Result<T>> results = await TaskEx.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
#else
            IEnumerable<Result<T>> results = await Task.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
#endif

            return results.Combine(composer, errorMessageSeparator);
        }

        public static async Task<Result<K>> Combine<T, K>(this Task<IEnumerable<Task<Result<T>>>> task,
            Func<IEnumerable<T>, K> composer,
            string errorMessageSeparator)
        {
            IEnumerable<Task<Result<T>>> tasks = await task.ConfigureAwait(Result.DefaultConfigureAwait);
            return await tasks.Combine(composer, errorMessageSeparator).ConfigureAwait(Result.DefaultConfigureAwait);
        }
    }
}
