#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        /// Executes the given <paramref name="valueTask" /> if the <paramref name="maybeTask" /> produces no value
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="valueTask"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task ExecuteNoValue<T>(this ValueTask<Maybe<T>> maybeTask, Func<ValueTask> valueTask)
        {
            var maybe = await maybeTask;

            if (maybe.HasValue)
                return;

            await valueTask();
        }

    }
}
#endif