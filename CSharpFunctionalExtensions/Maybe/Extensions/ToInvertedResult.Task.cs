using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static async Task<Result> ToInvertedResult<T>(this Task<Maybe<T>> maybeTask, string errorMessage)
        {
            var maybe = await maybeTask.DefaultAwait();
            return maybe.ToInvertedResult(errorMessage);
        }

        public static async Task<UnitResult<E>> ToInvertedResult<T, E>(this Task<Maybe<T>> maybeTask, E error)
        {
            var maybe = await maybeTask.DefaultAwait();
            return maybe.ToInvertedResult(error);
        }

        public static async Task<UnitResult<E>> ToInvertedResult<T, E>(this Task<Maybe<T>> maybeTask, Func<E> errorFunc)
        {
            var maybe = await maybeTask.DefaultAwait();
            return maybe.ToInvertedResult(errorFunc);
        }
    }
}
