#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        /// Executes the given <paramref name="action" /> if the <paramref name="maybeTask" /> produces no value
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        [Obsolete("Use TapNoValue instead")]
        public static async Task ExecuteNoValue<T>(this ValueTask<Maybe<T>> maybeTask, Action action)
        {
            var maybe = await maybeTask;

            if (maybe.HasValue)
                return;

            action();
        }
    }
}
#endif
