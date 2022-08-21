#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static async ValueTask<T> GetValueOrThrow<T>(this ValueTask<Maybe<T>> maybeTask)
        {
            var maybe = await maybeTask;
            return maybe.GetValueOrThrow();
        }

        /// <summary>
        ///     Returns <paramref name="maybeTask" />'s inner value if it has one, otherwise throws an InvalidOperationException
        ///     with <paramref name="errorMessage" />
        /// </summary>
        /// <exception cref="InvalidOperationException">Maybe has no value.</exception>
        public static async ValueTask<T> GetValueOrThrow<T>(this ValueTask<Maybe<T>> maybeTask, string errorMessage)
        {
            var maybe = await maybeTask;
            return maybe.GetValueOrThrow(errorMessage);
        }
    }
}
#endif