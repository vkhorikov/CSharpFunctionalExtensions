using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Executes the given async <paramref name="action" /> if the <paramref name="maybe" /> has a value
        /// Returns the calling maybe.
        /// </summary>
        /// <param name="maybe"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The calling maybe</returns>
        public static async Task<Maybe<T>> Tap<T>(this Maybe<T> maybe, Func<T, Task> action)
        {
            if (maybe.HasValue)
            {
                await action(maybe.GetValueOrThrow()).DefaultAwait();
            }

            return maybe;
        }
    }
}
