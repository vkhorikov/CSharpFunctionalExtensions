#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        /// Executes the given <paramref name="action" /> if the <paramref name="maybeTask" /> produces no value
        /// Returns the calling maybe.
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The calling maybe</returns>
        public static async ValueTask<Maybe<T>> TapNoValue<T>(
            this ValueTask<Maybe<T>> maybeTask,
            Action action
        )
        {
            var maybe = await maybeTask;

            if (maybe.HasNoValue)
            {
                action();
            }

            return maybe;
        }
    }
}
#endif
