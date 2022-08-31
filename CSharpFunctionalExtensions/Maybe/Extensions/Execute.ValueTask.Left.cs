#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        /// Executes the given <paramref name="action" /> if the <paramref name="maybeTask" /> produces a value
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task Execute<T>(this ValueTask<Maybe<T>> maybeTask, Action<T> action)
        {
            var maybe = await maybeTask;

            if (maybe.HasNoValue)
                return;

            action(maybe.GetValueOrThrow());
        }
    }
}
#endif