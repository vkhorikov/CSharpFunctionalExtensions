using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static async Task<UnitResult<E>> ToUnitResult<E>(this Task<Maybe<E>> maybeTask)
        {
            var maybe = await maybeTask.DefaultAwait();
            return maybe.ToUnitResult();
        }

        public static async Task<UnitResult<E>> ToUnitResult<T, E>(this Task<Maybe<T>> maybeTask, E error)
        {
            var maybe = await maybeTask.DefaultAwait();
            return maybe.ToUnitResult(error);
        }
    }
}
