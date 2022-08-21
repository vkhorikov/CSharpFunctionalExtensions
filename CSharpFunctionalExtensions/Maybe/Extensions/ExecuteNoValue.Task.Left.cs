using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Executes the given <paramref name="action" /> if the <paramref name="maybeTask" /> produces no value
        /// </summary>
        /// <param name="maybeTask"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task ExecuteNoValue<T>(this Task<Maybe<T>> maybeTask, Action action)
        {
            var maybe = await maybeTask.DefaultAwait();

            if (maybe.HasValue)
                return;

            action();
        }
    }
}