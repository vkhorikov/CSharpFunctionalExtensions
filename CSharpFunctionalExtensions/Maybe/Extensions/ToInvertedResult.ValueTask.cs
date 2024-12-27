#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static async ValueTask<Result> ToInvertedResult<T>(this ValueTask<Maybe<T>> maybeTask, string errorMessage)
        {
            Maybe<T> maybe = await maybeTask;
            return maybe.ToInvertedResult(errorMessage);
        }

        public static async ValueTask<UnitResult<E>> ToInvertedResult<T, E>(this ValueTask<Maybe<T>> maybeTask, E error)
        {
            Maybe<T> maybe = await maybeTask;
            return maybe.ToInvertedResult(error);
        }

        public static async ValueTask<UnitResult<E>> ToInvertedResult<T, E>(this ValueTask<Maybe<T>> maybeTask, Func<E> errorFunc)
        {
            Maybe<T> maybe = await maybeTask;
            return maybe.ToInvertedResult(errorFunc);
        }
    }
}
#endif
