#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        public static async ValueTask<Maybe<T>> Where<T>(this Maybe<T> maybe, Func<T, ValueTask<bool>> predicate)
        {
            if (maybe.HasNoValue)
                return Maybe<T>.None;

            if (await predicate(maybe.GetValueOrThrow()))
                return maybe;

            return Maybe<T>.None;
        }
    }
}
#endif