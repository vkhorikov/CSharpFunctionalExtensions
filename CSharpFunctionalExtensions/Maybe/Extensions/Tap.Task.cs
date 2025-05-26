using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Executes the given <paramref name="asyncAction" /> if the <paramref name="maybeTask" /> produces a value
        /// Returns the calling maybe.
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="asyncAction"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The calling maybe</returns>
        public static async Task<Maybe<T>> Tap<T>(
            this Task<Maybe<T>> maybeTask,
            Func<T, Task> asyncAction
        )
        {
            var maybe = await maybeTask.DefaultAwait();

            if (maybe.HasValue)
            {
                await asyncAction(maybe.GetValueOrThrow()).DefaultAwait();
            }

            return maybe;
        }
    }
}
