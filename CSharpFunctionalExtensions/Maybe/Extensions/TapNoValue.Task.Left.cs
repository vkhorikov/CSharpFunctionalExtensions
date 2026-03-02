using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Executes the given <paramref name="action" /> if the <paramref name="maybeTask" /> produces no value
        /// Returns the calling maybe.
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The calling maybe</returns>
        public static async Task<Maybe<T>> TapNoValue<T>(
            this Task<Maybe<T>> maybeTask,
            Action action
        )
        {
            var maybe = await maybeTask.DefaultAwait();

            if (maybe.HasNoValue)
            {
                action();
            }
            return maybe;
        }
    }
}
