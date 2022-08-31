#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        /// Creates a new <see cref="Maybe{T}" /> if <paramref name="maybeTask" /> is empty, using the supplied <paramref name="fallback" />, otherwise it returns <paramref name="maybeTask" />
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="fallback"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async ValueTask<Maybe<T>> Or<T>(this ValueTask<Maybe<T>> maybeTask, ValueTask<T> fallback)
        {
            Maybe<T> maybe = await maybeTask;

            if (maybe.HasNoValue)
            {
                var value = await fallback;
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
        public static async ValueTask<Maybe<T>> Or<T>(this ValueTask<Maybe<T>> maybeTask, Func<ValueTask<T>> fallbackOperation)
        {
            Maybe<T> maybe = await maybeTask;

            if (maybe.HasNoValue)
            {
                var value = await fallbackOperation();

                return Maybe<T>.From(value);
            }

            return maybe;
        }

        /// <summary>
        /// Returns <paramref name="fallbackOperation" /> if <paramref name="maybeTask" /> is empty, otherwise it returns <paramref name="maybeTask" />
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="fallbackOperation"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async ValueTask<Maybe<T>> Or<T>(this ValueTask<Maybe<T>> maybeTask, Func<ValueTask<Maybe<T>>> fallbackOperation)
        {
            Maybe<T> maybe = await maybeTask;

            if (maybe.HasNoValue)
                return await fallbackOperation();

            return maybe;
        }
    }
}
#endif