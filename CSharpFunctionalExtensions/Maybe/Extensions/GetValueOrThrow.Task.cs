using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static async Task<T> GetValueOrThrow<T>(this Task<Maybe<T>> maybeTask)
        {
            var maybe = await maybeTask.DefaultAwait();
            return maybe.GetValueOrThrow();
        }

        /// <summary>
        ///     Returns <paramref name="maybeTask" />'s inner value if it has one, otherwise throws an InvalidOperationException
        ///     with <paramref name="errorMessage" />
        /// </summary>
        /// <exception cref="InvalidOperationException">Maybe has no value.</exception>
        public static async Task<T> GetValueOrThrow<T>(this Task<Maybe<T>> maybeTask, string errorMessage)
        {
            var maybe = await maybeTask.DefaultAwait();
            return maybe.GetValueOrThrow(errorMessage);
        }
    }
}