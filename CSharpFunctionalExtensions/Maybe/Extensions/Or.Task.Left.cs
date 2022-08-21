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
        public static async Task<Maybe<T>> Or<T>(this Task<Maybe<T>> maybeTask, T fallback)
        {
            var maybe = await maybeTask.DefaultAwait();

            if (maybe.HasNoValue)
                return Maybe<T>.From(fallback);

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
        public static async Task<Maybe<T>> Or<T>(this Task<Maybe<T>> maybeTask, Func<T> fallbackOperation)
        {
            var maybe = await maybeTask.DefaultAwait();

            if (maybe.HasNoValue)
                return Maybe<T>.From(fallbackOperation());

            return maybe;
        }

        /// <summary>
        ///     Returns <paramref name="fallback" /> if <paramref name="maybeTask" /> is empty, otherwise it returns
        ///     <paramref name="maybeTask" />
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="fallback"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<Maybe<T>> Or<T>(this Task<Maybe<T>> maybeTask, Maybe<T> fallback)
        {
            var maybe = await maybeTask.DefaultAwait();

            if (maybe.HasNoValue)
                return fallback;

            return maybe;
        }
    }
}