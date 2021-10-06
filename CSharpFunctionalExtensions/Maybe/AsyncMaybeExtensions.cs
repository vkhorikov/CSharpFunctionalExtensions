using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static class AsyncMaybeExtensions
    {
        public static async Task<Result<T>> ToResult<T>(this Task<Maybe<T>> maybeTask, string errorMessage)
        {
            Maybe<T> maybe = await maybeTask.DefaultAwait();
            return maybe.ToResult(errorMessage);
        }

        public static async Task<Result<T, E>> ToResult<T, E>(this Task<Maybe<T>> maybeTask, E error)
        {
            Maybe<T> maybe = await maybeTask.DefaultAwait();
            return maybe.ToResult(error);
        }

        public static async Task<T> GetValueOrThrow<T>(this Task<Maybe<T>> maybeTask)
        {
            var maybe = await maybeTask.DefaultAwait();
            return maybe.GetValueOrThrow();
        }

        public static async Task<T> GetValueOrDefault<T>(this Maybe<T> maybe, Func<Task<T>> defaultValue)
        {
            if (maybe.HasNoValue)
                return await defaultValue().DefaultAwait();

            return maybe.GetValueOrThrow();
        }

        public static async Task<K> GetValueOrDefault<T, K>(this Maybe<T> maybe, Func<T, K> selector, Func<Task<K>> defaultValue)
        {
            if (maybe.HasNoValue)
                return await defaultValue().DefaultAwait();

            return selector(maybe.GetValueOrThrow());
        }

        public static async Task<K> GetValueOrDefault<T, K>(this Maybe<T> maybe, Func<T, Task<K>> selector, K defaultValue = default)
        {
            if (maybe.HasNoValue)
                return defaultValue;

            return await selector(maybe.GetValueOrThrow()).DefaultAwait();
        }

        public static async Task<K> GetValueOrDefault<T, K>(this Maybe<T> maybe, Func<T, Task<K>> selector, Func<Task<K>> defaultValue)
        {
            if (maybe.HasNoValue)
                return await defaultValue().DefaultAwait();

            return await selector(maybe.GetValueOrThrow()).DefaultAwait();
        }

        public static async Task<T> GetValueOrDefault<T>(this Task<Maybe<T>> maybeTask, Func<Task<T>> defaultValue)
        {
            var maybe = await maybeTask.DefaultAwait();
            return await maybe.GetValueOrDefault(defaultValue).DefaultAwait();
        }

        public static async Task<K> GetValueOrDefault<T, K>(this Task<Maybe<T>> maybeTask, Func<T, K> selector, Func<Task<K>> defaultValue)
        {
            var maybe = await maybeTask.DefaultAwait();
            return await maybe.GetValueOrDefault(selector, defaultValue).DefaultAwait();
        }

        public static async Task<K> GetValueOrDefault<T, K>(this Task<Maybe<T>> maybeTask, Func<T, Task<K>> selector, K defaultValue = default)
        {
            var maybe = await maybeTask.DefaultAwait();
            return await maybe.GetValueOrDefault(selector, defaultValue).DefaultAwait();
        }

        public static async Task<K> GetValueOrDefault<T, K>(this Task<Maybe<T>> maybeTask, Func<T, Task<K>> selector, Func<Task<K>> defaultValue)
        {
            var maybe = await maybeTask.DefaultAwait();
            return await maybe.GetValueOrDefault(selector, defaultValue).DefaultAwait();
        }

        public static async Task<T> GetValueOrThrow<T>(this Task<Maybe<T>> maybeTask, string errorMessage)
        {
            var maybe = await maybeTask.DefaultAwait();

            return maybe.GetValueOrThrow(errorMessage);
        }

        public static async Task<Maybe<T>> Where<T>(this Task<Maybe<T>> maybeTask, Func<T, bool> predicate)
        {
            Maybe<T> maybe = await maybeTask.DefaultAwait();
            return maybe.Where(predicate);
        }

        public static async Task<Maybe<T>> Where<T>(this Maybe<T> maybe, Func<T, Task<bool>> predicate)
        {
            if (maybe.HasNoValue)
                return Maybe<T>.None;

            if (await predicate(maybe.GetValueOrThrow()).DefaultAwait())
                return maybe;

            return Maybe<T>.None;
        }

        public static async Task<Maybe<T>> Where<T>(this Task<Maybe<T>> maybeTask, Func<T, Task<bool>> predicate)
        {
            Maybe<T> maybe = await maybeTask.DefaultAwait();
            return await maybe.Where(predicate).DefaultAwait();
        }

        public static async Task<Maybe<K>> Map<T, K>(this Task<Maybe<T>> maybeTask, Func<T, K> selector)
        {
            Maybe<T> maybe = await maybeTask.DefaultAwait();
            return maybe.Map(selector);
        }

        public static async Task<Maybe<K>> Map<T, K>(this Maybe<T> maybe, Func<T, Task<K>> selector)
        {
            if (maybe.HasNoValue)
                return Maybe<K>.None;

            return await selector(maybe.GetValueOrThrow()).DefaultAwait();
        }

        public static async Task<Maybe<K>> Map<T, K>(this Task<Maybe<T>> maybeTask, Func<T, Task<K>> selector)
        {
            Maybe<T> maybe = await maybeTask.DefaultAwait();
            return await maybe.Map(selector).DefaultAwait();
        }

        public static async Task<Maybe<K>> Bind<T, K>(this Task<Maybe<T>> maybeTask, Func<T, Maybe<K>> selector)
        {
            Maybe<T> maybe = await maybeTask.DefaultAwait();
            return maybe.Bind(selector);
        }

        public static Task<Maybe<K>> Bind<T, K>(this Maybe<T> maybe, Func<T, Task<Maybe<K>>> selector)
        {
            if (maybe.HasNoValue)
                return Maybe<K>.None.AsCompletedTask();

            return selector(maybe.GetValueOrThrow());
        }

        public static async Task<Maybe<K>> Bind<T, K>(this Task<Maybe<T>> maybeTask, Func<T, Task<Maybe<K>>> selector)
        {
            Maybe<T> maybe = await maybeTask.DefaultAwait();
            return await maybe.Bind(selector).DefaultAwait();
        }

        /// <summary>
        /// Creates a new <see cref="Maybe{T}" /> if <paramref name="maybeTask" /> is empty, using the supplied <paramref name="fallback" />, otherwise it returns <paramref name="maybeTask" />
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="fallback"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Maybe<T>> Or<T>(this Task<Maybe<T>> maybeTask, T fallback)
        {
            Maybe<T> maybe = await maybeTask.DefaultAwait();

            if (maybe.HasNoValue)
                return Maybe<T>.From(fallback);

            return maybe;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe{T}" /> if <paramref name="maybeTask" /> is empty, using the supplied <paramref name="fallback" />, otherwise it returns <paramref name="maybeTask" />
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="fallback"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Maybe<T>> Or<T>(this Task<Maybe<T>> maybeTask, Task<T> fallback)
        {
            Maybe<T> maybe = await maybeTask.DefaultAwait();

            if (maybe.HasNoValue)
            {
                var value = await fallback.DefaultAwait();
                return Maybe<T>.From(value);
            }

            return maybe;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe{T}" /> if <paramref name="maybeTask" /> is empty, using the result of the supplied <paramref name="fallbackOperation" />, otherwise it returns <paramref name="maybeTask" />
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="fallbackOperation"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Maybe<T>> Or<T>(this Task<Maybe<T>> maybeTask, Func<T> fallbackOperation)
        {
            Maybe<T> maybe = await maybeTask.DefaultAwait();

            if (maybe.HasNoValue)
                return Maybe<T>.From(fallbackOperation());

            return maybe;
        }

        /// <summary>
        /// Creates a new <see cref="Maybe{T}" /> if <paramref name="maybeTask" /> is empty, using the result of the supplied <paramref name="fallbackOperation" />, otherwise it returns <paramref name="maybeTask" />
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="fallbackOperation"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Maybe<T>> Or<T>(this Task<Maybe<T>> maybeTask, Func<Task<T>> fallbackOperation)
        {
            Maybe<T> maybe = await maybeTask.DefaultAwait();

            if (maybe.HasNoValue)
            {
                var value = await fallbackOperation().DefaultAwait();

                return Maybe<T>.From(value);
            }

            return maybe;
        }

        /// <summary>
        /// Returns <paramref name="fallback" /> if <paramref name="maybeTask" /> is empty, otherwise it returns <paramref name="maybeTask" />
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="fallback"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Maybe<T>> Or<T>(this Task<Maybe<T>> maybeTask, Maybe<T> fallback)
        {
            Maybe<T> maybe = await maybeTask.DefaultAwait();

            if (maybe.HasNoValue)
                return fallback;

            return maybe;
        }

        /// <summary>
        /// Returns <paramref name="fallbackOperation" /> if <paramref name="maybeTask" /> is empty, otherwise it returns <paramref name="maybeTask" />
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="fallbackOperation"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Maybe<T>> Or<T>(this Task<Maybe<T>> maybeTask, Func<Maybe<T>> fallbackOperation)
        {
            Maybe<T> maybe = await maybeTask.DefaultAwait();

            if (maybe.HasNoValue)
                return fallbackOperation();

            return maybe;
        }

        /// <summary>
        /// Returns <paramref name="fallbackOperation" /> if <paramref name="maybeTask" /> is empty, otherwise it returns <paramref name="maybeTask" />
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="fallbackOperation"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Maybe<T>> Or<T>(this Task<Maybe<T>> maybeTask, Func<Task<Maybe<T>>> fallbackOperation)
        {
            Maybe<T> maybe = await maybeTask.DefaultAwait();

            if (maybe.HasNoValue)
                return await fallbackOperation().DefaultAwait();

            return maybe;
        }

        /// <summary>
        /// Executes the given <paramref name="action" /> if the <paramref name="maybeTask" /> produces a value
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task Execute<T>(this Task<Maybe<T>> maybeTask, Action<T> action)
        {
            var maybe = await maybeTask.DefaultAwait();

            if (maybe.HasNoValue)
                return;

            action(maybe.GetValueOrThrow());
        }

        /// <summary>
        /// Executes the given <paramref name="action" /> if the <paramref name="maybeTask" /> produces no value
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task ExecuteNoValue<T>(this Task<Maybe<T>> maybeTask, Action action)
        {
            var maybe = await maybeTask.DefaultAwait();

            if (maybe.HasValue)
                return;

            action();
        }

        /// <summary>
        /// Executes the given <paramref name="asyncAction" /> if the <paramref name="maybeTask" /> produces a value
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="asyncAction"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task Execute<T>(this Task<Maybe<T>> maybeTask, Func<T, Task> asyncAction)
        {
            var maybe = await maybeTask.DefaultAwait();

            if (maybe.HasNoValue)
                return;

            await asyncAction(maybe.GetValueOrThrow()).DefaultAwait();
        }

        /// <summary>
        /// Executes the given <paramref name="asyncAction" /> if the <paramref name="maybeTask" /> produces no value
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="asyncAction"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task ExecuteNoValue<T>(this Task<Maybe<T>> maybeTask, Func<Task> asyncAction)
        {
            var maybe = await maybeTask.DefaultAwait();

            if (maybe.HasValue)
                return;

            await asyncAction().DefaultAwait();
        }
    }
}
