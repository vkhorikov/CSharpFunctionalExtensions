#if NET5_0_OR_GREATER
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        public static async ValueTask<Result> CombineInOrder(this IEnumerable<ValueTask<Result>> tasks, string errorMessageSeparator = null)
        {
            Result[] results = await CompleteInOrder(tasks);
            return results.Combine(errorMessageSeparator);
        }

        public static async ValueTask<Result<IEnumerable<T>, E>> CombineInOrder<T, E>(this IEnumerable<ValueTask<Result<T, E>>> tasks, Func<IEnumerable<E>, E> composerError)
        {
            Result<T, E>[] results = await CompleteInOrder(tasks);
            return results.Combine(composerError);
        }

        public static async ValueTask<Result<IEnumerable<T>, E>> CombineInOrder<T, E>(this IEnumerable<ValueTask<Result<T, E>>> tasks)
            where E : ICombine
        {
            Result<T, E>[] results = await CompleteInOrder(tasks);
            return results.Combine();
        }

        public static async ValueTask<Result<IEnumerable<T>>> CombineInOrder<T>(this IEnumerable<ValueTask<Result<T>>> tasks, string errorMessageSeparator = null)
        {
            Result<T>[] results = await CompleteInOrder(tasks);
            return results.Combine(errorMessageSeparator);
        }

        public static async ValueTask<Result> CombineInOrder(this ValueTask<IEnumerable<ValueTask<Result>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<ValueTask<Result>> tasks = await task;
            return await tasks.CombineInOrder(errorMessageSeparator);
        }

        public static async ValueTask<Result<IEnumerable<T>, E>> CombineInOrder<T, E>(this ValueTask<IEnumerable<ValueTask<Result<T, E>>>> task, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<ValueTask<Result<T, E>>> tasks = await task;
            return await tasks.CombineInOrder(composerError);
        }

        public static async ValueTask<Result<IEnumerable<T>, E>> CombineInOrder<T, E>(this ValueTask<IEnumerable<ValueTask<Result<T, E>>>> task)
            where E : ICombine
        {
            IEnumerable<ValueTask<Result<T, E>>> tasks = await task;
            return await tasks.CombineInOrder();
        }

        public static async ValueTask<Result<IEnumerable<T>>> CombineInOrder<T>(this ValueTask<IEnumerable<ValueTask<Result<T>>>> task, string errorMessageSeparator = null)
        {
            IEnumerable<ValueTask<Result<T>>> tasks = await task;
            return await tasks.CombineInOrder(errorMessageSeparator);
        }

        public static async ValueTask<Result<K, E>> CombineInOrder<T, K, E>(this IEnumerable<ValueTask<Result<T, E>>> tasks, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<Result<T, E>> results = await CompleteInOrder(tasks);
            return results.Combine(composer, composerError);
        }

        public static async ValueTask<Result<K, E>> CombineInOrder<T, K, E>(this IEnumerable<ValueTask<Result<T, E>>> tasks, Func<IEnumerable<T>, K> composer)
            where E : ICombine
        {
            IEnumerable<Result<T, E>> results = await CompleteInOrder(tasks);
            return results.Combine(composer);
        }

        public static async ValueTask<Result<K>> CombineInOrder<T, K>(this IEnumerable<ValueTask<Result<T>>> tasks, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
        {
            IEnumerable<Result<T>> results = await CompleteInOrder(tasks);
            return results.Combine(composer, errorMessageSeparator);
        }

        public static async ValueTask<Result<K, E>> CombineInOrder<T, K, E>(this ValueTask<IEnumerable<ValueTask<Result<T, E>>>> task, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
        {
            IEnumerable<ValueTask<Result<T, E>>> tasks = await task;
            return await tasks.CombineInOrder(composer, composerError);
        }

        public static async ValueTask<Result<K, E>> CombineInOrder<T, K, E>(this ValueTask<IEnumerable<ValueTask<Result<T, E>>>> task, Func<IEnumerable<T>, K> composer)
            where E : ICombine
        {
            IEnumerable<ValueTask<Result<T, E>>> tasks = await task;
            return await tasks.CombineInOrder(composer);
        }

        public static async ValueTask<Result<K>> CombineInOrder<T, K>(this ValueTask<IEnumerable<ValueTask<Result<T>>>> task, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
        {
            IEnumerable<ValueTask<Result<T>>> tasks = await task;
            return await tasks.CombineInOrder(composer, errorMessageSeparator);
        }

        public static async ValueTask<T[]> CompleteInOrder<T>(IEnumerable<ValueTask<T>> tasks)
        {
            List<T> results = new List<T>();
            foreach (var task in tasks)
            {
                results.Add(await task);
            }
            return results.ToArray();
        }
    }
}
#endif
