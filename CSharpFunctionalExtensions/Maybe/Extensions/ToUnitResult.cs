namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static UnitResult<E> ToUnitResult<E>(in this Maybe<E> maybe)
        {
            if (maybe.HasValue)
                return UnitResult.Failure(maybe.Value);

            return UnitResult.Success<E>();
        }

        public static UnitResult<E> ToUnitResult<T, E>(in this Maybe<T> maybe, E error)
        {
            if (maybe.HasNoValue)
                return UnitResult.Failure(error);

            return UnitResult.Success<E>();
        }
    }
}
