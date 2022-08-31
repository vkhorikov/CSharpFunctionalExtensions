#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        /// Creates a new <see cref="Maybe{T}" /> if <paramref name="maybe" /> is empty, using the result of the supplied <paramref name="valueTaskFallbackOperation" />, otherwise it returns <paramref name="maybe" />
        /// </summary>
        /// <param name="maybe"></param>
        /// <param name="valueTaskFallbackOperation"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async ValueTask<Maybe<T>> Or<T>(this Maybe<T> maybe, Func<ValueTask<T>> valueTaskFallbackOperation)
        {
            if (maybe.HasNoValue)
                return await valueTaskFallbackOperation();

            return maybe;
        }

        /// <summary>
        /// Returns <paramref name="valueTaskFallback" /> if <paramref name="maybe" /> is empty, otherwise it returns <paramref name="maybe" />
        /// </summary>
        /// <param name="maybe"></param>
        /// <param name="valueTaskFallback"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async ValueTask<Maybe<T>> Or<T>(this Maybe<T> maybe, ValueTask<Maybe<T>> valueTaskFallback)
        {
            if (maybe.HasNoValue)
                return await valueTaskFallback;

            return maybe;
        }

        /// <summary>
        /// Returns the result of <paramref name="valueTaskFallbackOperation" /> if <paramref name="maybe" /> is empty, otherwise it returns <paramref name="maybe" />
        /// </summary>
        /// <param name="maybe"></param>
        /// <param name="valueTaskFallbackOperation"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async ValueTask<Maybe<T>> Or<T>(this Maybe<T> maybe, Func<ValueTask<Maybe<T>>> valueTaskFallbackOperation)
        {
            if (maybe.HasNoValue)
                return await valueTaskFallbackOperation();

            return maybe;
        }
    }
}
#endif