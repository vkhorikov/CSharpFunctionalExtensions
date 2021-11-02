using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Creates a new <see cref="Maybe{T}" /> if <paramref name="maybeTask" /> is empty, using the supplied
        ///     <paramref name="fallback" />, otherwise it returns <paramref name="maybeTask" />
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="fallback"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Maybe<T>> Or<T>(this Task<Maybe<T>> maybeTask, Task<T> fallback)
        {
            var maybe = await maybeTask.DefaultAwait();

            if (maybe.HasNoValue)
            {
                var value = await fallback.DefaultAwait();
                return Maybe<T>.From(value);
            }

            return maybe;
        }

        /// <summary>
        ///     Creates a new <see cref="Maybe{T}" /> if <paramref name="maybeTask" /> is empty, using the result of the supplied
        ///     <paramref name="fallbackOperation" />, otherwise it returns <paramref name="maybeTask" />
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="fallbackOperation"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Maybe<T>> Or<T>(this Task<Maybe<T>> maybeTask, Func<Task<T>> fallbackOperation)
        {
            var maybe = await maybeTask.DefaultAwait();

            if (maybe.HasNoValue)
            {
                var value = await fallbackOperation().DefaultAwait();

                return Maybe<T>.From(value);
            }

            return maybe;
        }

        /// <summary>
        ///     Returns <paramref name="fallbackOperation" /> if <paramref name="maybeTask" /> is empty, otherwise it returns
        ///     <paramref name="maybeTask" />
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="fallbackOperation"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Maybe<T>> Or<T>(this Task<Maybe<T>> maybeTask, Func<Maybe<T>> fallbackOperation)
        {
            var maybe = await maybeTask.DefaultAwait();

            if (maybe.HasNoValue)
                return fallbackOperation();

            return maybe;
        }

        /// <summary>
        ///     Returns <paramref name="fallbackOperation" /> if <paramref name="maybeTask" /> is empty, otherwise it returns
        ///     <paramref name="maybeTask" />
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="fallbackOperation"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Maybe<T>> Or<T>(this Task<Maybe<T>> maybeTask, Func<Task<Maybe<T>>> fallbackOperation)
        {
            var maybe = await maybeTask.DefaultAwait();

            if (maybe.HasNoValue)
                return await fallbackOperation().DefaultAwait();

            return maybe;
        }
    }
}