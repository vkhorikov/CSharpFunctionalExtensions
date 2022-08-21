#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        /// Executes the given <paramref name="asyncAction" /> if the <paramref name="maybeTask" /> produces no value
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="asyncAction"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task ExecuteNoValue<T>(this ValueTask<Maybe<T>> maybeTask, Func<ValueTask> asyncAction)
        {
            var maybe = await maybeTask;

            if (maybe.HasValue)
                return;

            await asyncAction();
        }

    }
}
#endif