#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Executes the given async <paramref name="valueTask" /> if the <paramref name="maybe" /> has no value
        /// Returns the calling maybe.
        /// </summary>
        /// <param name="maybe"></param>
        /// <param name="valueTask"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The calling maybe</returns>
        public static async ValueTask<Maybe<T>> TapNoValue<T>(
            this Maybe<T> maybe,
            Func<ValueTask> valueTask
        )
        {
            if (maybe.HasNoValue)
            {
                await valueTask();
            }

            return maybe;
        }
    }
}
#endif
