using System;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Creates a new <see cref="Maybe{T}" /> if <paramref name="maybe" /> is empty, using the result of the supplied
        ///     <paramref name="fallbackOperation" />, otherwise it returns <paramref name="maybe" />
        /// </summary>
        /// <param name="maybe"></param>
        /// <param name="fallbackOperation"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Maybe<T> Or<T>(in this Maybe<T> maybe, Func<T> fallbackOperation)
        {
            if (maybe.HasNoValue)
                return fallbackOperation();

            return maybe;
        }

        /// <summary>
        ///     Returns <paramref name="fallback" /> if <paramref name="maybe" /> is empty, otherwise it returns
        ///     <paramref name="maybe" />
        /// </summary>
        /// <param name="maybe"></param>
        /// <param name="fallback"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Maybe<T> Or<T>(in this Maybe<T> maybe, Maybe<T> fallback)
        {
            if (maybe.HasNoValue)
                return fallback;

            return maybe;
        }

        /// <summary>
        ///     Returns the result of <paramref name="fallbackOperation" /> if <paramref name="maybe" /> is empty, otherwise it
        ///     returns <paramref name="maybe" />
        /// </summary>
        /// <param name="maybe"></param>
        /// <param name="fallbackOperation"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Maybe<T> Or<T>(in this Maybe<T> maybe, Func<Maybe<T>> fallbackOperation)
        {
            if (maybe.HasNoValue)
                return fallbackOperation();

            return maybe;
        }
    }
}