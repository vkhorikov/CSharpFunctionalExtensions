using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Executes the given <paramref name="action" /> if the <paramref name="maybeTask" /> produces a value
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task Execute<T>(this Task<Maybe<T>> maybeTask, Action<T> action)
        {
            var maybe = await maybeTask.DefaultAwait();

            if (maybe.HasNoValue)
                return;

            action(maybe.GetValueOrThrow());
        }
    }
}