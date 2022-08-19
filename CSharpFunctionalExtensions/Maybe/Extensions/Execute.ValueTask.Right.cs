#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Executes the given async <paramref name="action" /> if the <paramref name="maybe" /> has a value
        /// </summary>
        /// <param name="maybe"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task Execute<T>(this Maybe<T> maybe, Func<T, ValueTask> action)
        {
            if (maybe.HasNoValue)
                return;

            await action(maybe.GetValueOrThrow());
        }
    }
}
#endif