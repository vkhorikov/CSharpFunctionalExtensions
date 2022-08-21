using System;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Executes the given <paramref name="action" /> if the <paramref name="maybe" /> has a value
        /// </summary>
        /// <param name="maybe"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        public static void Execute<T>(in this Maybe<T> maybe, Action<T> action)
        {
            if (maybe.HasNoValue)
                return;

            action(maybe.GetValueOrThrow());
        }
    }
}