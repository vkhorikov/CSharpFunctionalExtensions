#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        public static async ValueTask<UnitResult<E>> ToUnitResult<E>(this ValueTask<Maybe<E>> maybeTask)
        {
            Maybe<E> maybe = await maybeTask;
            return maybe.ToUnitResult();
        }

        public static async ValueTask<UnitResult<E>> ToUnitResult<T, E>(this ValueTask<Maybe<T>> maybeTask, E error)
        {
            Maybe<T> maybe = await maybeTask;
            return maybe.ToUnitResult(error);
        }

        public static async ValueTask<UnitResult<E>> ToUnitResult<T, E>(this ValueTask<Maybe<T>> maybeTask, Func<E> errorFunc)
        {
            Maybe<T> maybe = await maybeTask;
            return maybe.ToUnitResult(errorFunc);
        }
    }
}
#endif
