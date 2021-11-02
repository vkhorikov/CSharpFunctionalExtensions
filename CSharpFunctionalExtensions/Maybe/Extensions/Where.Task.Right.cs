using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static async Task<Maybe<T>> Where<T>(this Maybe<T> maybe, Func<T, Task<bool>> predicate)
        {
            if (maybe.HasNoValue)
                return Maybe<T>.None;

            if (await predicate(maybe.GetValueOrThrow()).DefaultAwait())
                return maybe;

            return Maybe<T>.None;
        }
    }
}