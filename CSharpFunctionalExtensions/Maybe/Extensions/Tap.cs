using System;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Executes the given <paramref name="action" /> if the <paramref name="maybe" /> has a value
        /// Returns the calling maybe.
        /// </summary>
        /// <param name="maybe"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The calling maybe</returns>
        public static Maybe<T> Tap<T>(in this Maybe<T> maybe, Action<T> action)
        {
            if (maybe.HasValue)
            {
                action(maybe.GetValueOrThrow());
            }

            return maybe;
        }
    }
}
