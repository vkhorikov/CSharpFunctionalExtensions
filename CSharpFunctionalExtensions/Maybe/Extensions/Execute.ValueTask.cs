#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        /// Executes the given <paramref name="valueTask" /> if the <paramref name="maybeTask" /> produces a value
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="valueTask"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task Execute<T>(this ValueTask<Maybe<T>> maybeTask, Func<T, ValueTask> valueTask)
        {
            var maybe = await maybeTask;

            if (maybe.HasNoValue)
                return;

            await valueTask(maybe.GetValueOrThrow());
        }
    }
}
#endif