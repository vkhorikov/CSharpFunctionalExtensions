#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Executes the given async <paramref name="valueTask" /> if the <paramref name="maybe" /> has a value
        /// Returns the calling maybe.
        /// </summary>
        /// <param name="maybe"></param>
        /// <param name="valueTask"></param>
        /// <typeparam name="T"></typeparam>
        public static async ValueTask<Maybe<T>> Tap<T>(
            this Maybe<T> maybe,
            Func<T, ValueTask> valueTask
        )
        {
            if (maybe.HasValue)
            {
                await valueTask(maybe.GetValueOrThrow());
            }

            return maybe;
        }
    }
}
#endif
