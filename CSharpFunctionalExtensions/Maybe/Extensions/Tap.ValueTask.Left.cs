#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        /// Executes the given <paramref name="action" /> if the <paramref name="maybeTask" /> produces a value
        /// Returns the calling maybe.
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The calling maybe</returns>
        public static async ValueTask<Maybe<T>> Tap<T>(
            this ValueTask<Maybe<T>> maybeTask,
            Action<T> action
        )
        {
            var maybe = await maybeTask;

            if (maybe.HasValue)
            {
                action(maybe.GetValueOrThrow());
            }

            return maybe;
        }
    }
}
#endif
