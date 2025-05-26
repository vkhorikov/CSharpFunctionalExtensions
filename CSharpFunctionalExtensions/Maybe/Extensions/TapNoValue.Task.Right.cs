using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Executes the given async <paramref name="action" /> if the <paramref name="maybe" /> has no value
        /// Returns the calling maybe.
        /// </summary>
        /// <param name="maybe"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The calling maybe</returns>
        public static async Task<Maybe<T>> TapNoValue<T>(this Maybe<T> maybe, Func<Task> action)
        {
            if (maybe.HasNoValue)
            {
                await action().DefaultAwait();
            }

            return maybe;
        }
    }
}
