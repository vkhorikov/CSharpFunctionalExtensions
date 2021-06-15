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

        public static async Task<Maybe<T>> Where<T>(this Task<Maybe<T>> maybeTask, Func<T, bool> predicate)
        {
            Maybe<T> maybe = await maybeTask.DefaultAwait();
            return maybe.Where(predicate);
        }

        public static async Task<Maybe<T>> Where<T>(this Maybe<T> maybe, Func<T, Task<bool>> predicate)
        {
            if (maybe.HasNoValue)
                return Maybe<T>.None;

            if (await predicate(maybe.Value).DefaultAwait())
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

            return await selector(maybe.Value).DefaultAwait();
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

            return selector(maybe.Value);
        }

        public static async Task<Maybe<K>> Bind<T, K>(this Task<Maybe<T>> maybeTask, Func<T, Task<Maybe<K>>> selector)
        {
            Maybe<T> maybe = await maybeTask.DefaultAwait();
            return await maybe.Bind(selector).DefaultAwait();
        }

        /// <summary>
        /// Creates a new <see cref="Maybe{T}" /> if <paramref name="maybeTask" /> is empty, using the supplied <paramref name="value" />, otherwise it returns <paramref name="maybeTask" />
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Maybe<T>> Or<T>(this Task<Maybe<T>> maybeTask, T value)
        {
            Maybe<T> maybe = await maybeTask.DefaultAwait();

            if (maybe.HasNoValue)
                return Maybe<T>.From(value);

            return maybe;
        }
    }
}
