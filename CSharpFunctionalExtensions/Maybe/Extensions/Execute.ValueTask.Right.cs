#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Executes the given async <paramref name="valueTask" /> if the <paramref name="maybe" /> has a value
        /// </summary>
        /// <param name="maybe"></param>
        /// <param name="valueTask"></param>
        /// <typeparam name="T"></typeparam>
        [Obsolete("Use TapValue instead")]
        public static async Task Execute<T>(this Maybe<T> maybe, Func<T, ValueTask> valueTask)
        {
            if (maybe.HasNoValue)
                return;

            await valueTask(maybe.GetValueOrThrow());
        }
    }
}
#endif
