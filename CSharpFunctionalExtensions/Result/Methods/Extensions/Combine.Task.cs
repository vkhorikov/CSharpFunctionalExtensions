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
            Result[] results = await Task.WhenAll(tasks).DefaultAwait();
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result<IEnumerable<T>, E>> Combine<T, E>(this IEnumerable<Task<Result<T, E>>> tasks, Func<IEnumerable<E>, E> composerError)
        {
            Result<T, E>[] results = await Task.WhenAll(tasks).DefaultAwait();
            return results.Combine(composerError);
        }

        public static async Task<Result<IEnumerable<T>, E>> Combine<T, E>(this IEnumerable<Task<Result<T, E>>> tasks)
            where E : ICombine
        {
            Result<T, E>[] results = await Task.WhenAll(tasks).DefaultAwait();
            return results.Combine();
        }

        public static async Task<Result<IEnumerable<T>>> Combine<T>(this IEnumerable<Task<Result<T>>> tasks, string errorMessageSeparator = null)
        {
            Result<T>[] results = await Task.WhenAll(tasks).DefaultAwait();
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result> Combine(this Task<IEnumerable<Result>> task, string errorMessageSeparator = null)
        {
            IEnumerable<Result> results = await task.DefaultAwait();
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result<IEnumerable<T>, E>> Combine<T, E>(this Task<IEnumerable<Result<T, E>>> task, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<Result<T, E>> results = await task.DefaultAwait();
            return results.Combine(composerError);
        }

        public static async Task<Result<IEnumerable<T>, E>> Combine<T, E>(this Task<IEnumerable<Result<T, E>>> task)
            where E : ICombine
        {
            IEnumerable<Result<T, E>> results = await task.DefaultAwait();
            return results.Combine();
        }

        public static async Task<Result<IEnumerable<T>>> Combine<T>(this Task<IEnumerable<Result<T>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<Result<T>> results = await task.DefaultAwait();
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result> Combine(this Task<IEnumerable<Task<Result>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<Task<Result>> tasks = await task.DefaultAwait();
            return await tasks.Combine(errorMessageSeparator).DefaultAwait();
        }

        public static async Task<Result<IEnumerable<T>, E>> Combine<T, E>(this Task<IEnumerable<Task<Result<T, E>>>> task, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<Task<Result<T, E>>> tasks = await task.DefaultAwait();
            return await tasks.Combine(composerError).DefaultAwait();
        }

        public static async Task<Result<IEnumerable<T>, E>> Combine<T, E>(this Task<IEnumerable<Task<Result<T, E>>>> task)
            where E : ICombine
        {
            IEnumerable<Task<Result<T, E>>> tasks = await task.DefaultAwait();
            return await tasks.Combine().DefaultAwait();
        }

        public static async Task<Result<IEnumerable<T>>> Combine<T>(this Task<IEnumerable<Task<Result<T>>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<Task<Result<T>>> tasks = await task.DefaultAwait();
            return await tasks.Combine(errorMessageSeparator).DefaultAwait();
        }

        public static async Task<Result<K, E>> Combine<T, K, E>(this IEnumerable<Task<Result<T, E>>> tasks, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<Result<T, E>> results = await Task.WhenAll(tasks).DefaultAwait();
            return results.Combine(composer, composerError);
        }

        public static async Task<Result<K, E>> Combine<T, K, E>(this IEnumerable<Task<Result<T, E>>> tasks, Func<IEnumerable<T>, K> composer)
            where E : ICombine
        {
            IEnumerable<Result<T, E>> results = await Task.WhenAll(tasks).DefaultAwait();
            return results.Combine(composer);
        }

        public static async Task<Result<K>> Combine<T, K>(this IEnumerable<Task<Result<T>>> tasks, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
        {
            IEnumerable<Result<T>> results = await Task.WhenAll(tasks).DefaultAwait();
            return results.Combine(composer, errorMessageSeparator);
        }

        public static async Task<Result<K, E>> Combine<T, K, E>(this Task<IEnumerable<Task<Result<T, E>>>> task, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<Task<Result<T, E>>> tasks = await task.DefaultAwait();
            return await tasks.Combine(composer, composerError).DefaultAwait();
        }

        public static async Task<Result<K, E>> Combine<T, K, E>(this Task<IEnumerable<Task<Result<T, E>>>> task, Func<IEnumerable<T>, K> composer)
            where E : ICombine
        {
            IEnumerable<Task<Result<T, E>>> tasks = await task.DefaultAwait();
            return await tasks.Combine(composer).DefaultAwait();
        }

        public static async Task<Result<K>> Combine<T, K>(this Task<IEnumerable<Task<Result<T>>>> task, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
        {
            IEnumerable<Task<Result<T>>> tasks = await task.DefaultAwait();
            return await tasks.Combine(composer, errorMessageSeparator).DefaultAwait();
        }
    }
}
