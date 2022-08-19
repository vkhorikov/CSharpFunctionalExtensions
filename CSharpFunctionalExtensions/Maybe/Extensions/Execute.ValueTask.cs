#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        /// Executes the given <paramref name="asyncAction" /> if the <paramref name="maybeTask" /> produces a value
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="asyncAction"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task Execute<T>(this ValueTask<Maybe<T>> maybeTask, Func<T, ValueTask> asyncAction)
        {
            var maybe = await maybeTask;

            if (maybe.HasNoValue)
                return;

            await asyncAction(maybe.GetValueOrThrow());
        }
    }
}
#endif