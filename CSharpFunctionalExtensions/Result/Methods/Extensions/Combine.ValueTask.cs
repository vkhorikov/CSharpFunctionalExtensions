#if NET5_0_OR_GREATER
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
       public static async ValueTask<Result> Combine(this IEnumerable<ValueTask<Result>> tasks, string errorMessageSeparator = null)
        {
            Result[] results = await Task.WhenAll(tasks.Select(x=> x.AsTask())).DefaultAwait();
            return results.Combine(errorMessageSeparator);
        }

        public static async ValueTask<Result<IEnumerable<T>, E>> Combine<T, E>(this IEnumerable<ValueTask<Result<T, E>>> tasks, Func<IEnumerable<E>, E> composerError)
        {
            Result<T, E>[] results = await Task.WhenAll(tasks.Select(x=> x.AsTask())).DefaultAwait();
            return results.Combine(composerError);
        }

        public static async ValueTask<Result<IEnumerable<T>, E>> Combine<T, E>(this IEnumerable<ValueTask<Result<T, E>>> tasks)
            where E : ICombine
        {
            Result<T, E>[] results = await Task.WhenAll(tasks.Select(x=> x.AsTask())).DefaultAwait();
            return results.Combine();
        }

        public static async ValueTask<Result<IEnumerable<T>>> Combine<T>(this IEnumerable<ValueTask<Result<T>>> tasks, string errorMessageSeparator = null)
        {
            Result<T>[] results = await Task.WhenAll(tasks.Select(x=> x.AsTask())).DefaultAwait();
            return results.Combine(errorMessageSeparator);
        }

        public static async ValueTask<Result> Combine(this ValueTask<IEnumerable<Result>> task, string errorMessageSeparator = null)
        {
            IEnumerable<Result> results = await task;
            return results.Combine(errorMessageSeparator);
        }

        public static async ValueTask<Result<IEnumerable<T>, E>> Combine<T, E>(this ValueTask<IEnumerable<Result<T, E>>> task, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<Result<T, E>> results = await task;
            return results.Combine(composerError);
        }

        public static async ValueTask<Result<IEnumerable<T>, E>> Combine<T, E>(this ValueTask<IEnumerable<Result<T, E>>> task)
            where E : ICombine
        {
            IEnumerable<Result<T, E>> results = await task;
            return results.Combine();
        }

        public static async ValueTask<Result<IEnumerable<T>>> Combine<T>(this ValueTask<IEnumerable<Result<T>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<Result<T>> results = await task;
            return results.Combine(errorMessageSeparator);
        }

        public static async ValueTask<Result> Combine(this ValueTask<IEnumerable<ValueTask<Result>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<ValueTask<Result>> tasks = await task;
            return await tasks.Combine(errorMessageSeparator);
        }

        public static async ValueTask<Result<IEnumerable<T>, E>> Combine<T, E>(this ValueTask<IEnumerable<ValueTask<Result<T, E>>>> task, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<ValueTask<Result<T, E>>> tasks = await task;
            return await tasks.Combine(composerError);
        }

        public static async ValueTask<Result<IEnumerable<T>, E>> Combine<T, E>(this ValueTask<IEnumerable<ValueTask<Result<T, E>>>> task)
            where E : ICombine
        {
            IEnumerable<ValueTask<Result<T, E>>> tasks = await task;
            return await tasks.Combine();
        }

        public static async ValueTask<Result<IEnumerable<T>>> Combine<T>(this ValueTask<IEnumerable<ValueTask<Result<T>>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<ValueTask<Result<T>>> tasks = await task;
            return await tasks.Combine(errorMessageSeparator);
        }

        public static async ValueTask<Result<K, E>> Combine<T, K, E>(this IEnumerable<ValueTask<Result<T, E>>> tasks, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<Result<T, E>> results = await Task.WhenAll(tasks.Select(x=> x.AsTask())).DefaultAwait();
            return results.Combine(composer, composerError);
        }

        public static async ValueTask<Result<K, E>> Combine<T, K, E>(this IEnumerable<ValueTask<Result<T, E>>> tasks, Func<IEnumerable<T>, K> composer)
            where E : ICombine
        {
            IEnumerable<Result<T, E>> results = await Task.WhenAll(tasks.Select(x=> x.AsTask())).DefaultAwait();
            return results.Combine(composer);
        }

        public static async ValueTask<Result<K>> Combine<T, K>(this IEnumerable<ValueTask<Result<T>>> tasks, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
        {
            IEnumerable<Result<T>> results = await Task.WhenAll(tasks.Select(x=> x.AsTask())).DefaultAwait();
            return results.Combine(composer, errorMessageSeparator);
        }

        public static async ValueTask<Result<K, E>> Combine<T, K, E>(this ValueTask<IEnumerable<ValueTask<Result<T, E>>>> task, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<ValueTask<Result<T, E>>> tasks = await task;
            return await tasks.Combine(composer, composerError);
        }

        public static async ValueTask<Result<K, E>> Combine<T, K, E>(this ValueTask<IEnumerable<ValueTask<Result<T, E>>>> task, Func<IEnumerable<T>, K> composer)
            where E : ICombine
        {
            IEnumerable<ValueTask<Result<T, E>>> tasks = await task;
            return await tasks.Combine(composer);
        }

        public static async ValueTask<Result<K>> Combine<T, K>(this ValueTask<IEnumerable<ValueTask<Result<T>>>> task, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
        {
            IEnumerable<ValueTask<Result<T>>> tasks = await task;
            return await tasks.Combine(composer, errorMessageSeparator);
        }
    }
}
#endif