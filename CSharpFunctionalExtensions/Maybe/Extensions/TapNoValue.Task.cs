using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Executes the given <paramref name="asyncAction" /> if the <paramref name="maybeTask" /> produces no value
        /// Returns the calling maybe.
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="asyncAction"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task<Maybe<T>> TapNoValue<T>(
            this Task<Maybe<T>> maybeTask,
            Func<Task> asyncAction
        )
        {
            var maybe = await maybeTask.DefaultAwait();

            if (maybe.HasNoValue)
            {
                await asyncAction().DefaultAwait();
            }

            return maybe;
        }
    }
}
