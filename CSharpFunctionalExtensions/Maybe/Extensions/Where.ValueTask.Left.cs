#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static async ValueTask<Maybe<T>> Where<T>(this ValueTask<Maybe<T>> maybeTask, Func<T, bool> predicate)
        {
            Maybe<T> maybe = await maybeTask;
            return maybe.Where(predicate);
        }
    }
}
#endif