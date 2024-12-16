using System;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static Result ToInvertedResult<T>(in this Maybe<T> maybe, string errorMessage)
        {
            if (maybe.HasValue)
                return Result.Failure<T>(errorMessage);

            return Result.Success();
        }
        
        public static UnitResult<E> ToInvertedResult<T, E>(in this Maybe<T> maybe, E error)
        {
            if (maybe.HasValue)
                return UnitResult.Failure(error);
        
            return UnitResult.Success<E>();
        }
    }
}
