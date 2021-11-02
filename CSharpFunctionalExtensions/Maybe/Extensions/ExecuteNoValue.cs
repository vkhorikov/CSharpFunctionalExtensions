using System;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Executes the given <paramref name="action" /> if the <paramref name="maybe" /> has no value
        /// </summary>
        /// <param name="maybe"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        public static void ExecuteNoValue<T>(in this Maybe<T> maybe, Action action)
        {
            if (maybe.HasValue)
                return;

            action();
        }
    }
}