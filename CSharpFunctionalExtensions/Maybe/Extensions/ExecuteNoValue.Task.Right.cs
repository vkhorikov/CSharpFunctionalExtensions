using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Executes the given async <paramref name="action" /> if the <paramref name="maybe" /> has no value
        /// </summary>
        /// <param name="maybe"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task ExecuteNoValue<T>(this Maybe<T> maybe, Func<Task> action)
        {
            if (maybe.HasValue)
                return;

            await action().DefaultAwait();
        }
    }
}