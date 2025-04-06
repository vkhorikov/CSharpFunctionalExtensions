namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        /// Mark the possibly null value as optional. Null is not an error, it's just null.
        /// </summary>
        public static Result<Maybe<T>, E> Optional<T, E>(this Maybe<Result<T, E>> maybe)
        {
            if (maybe.HasNoValue)
                return Result.Success<Maybe<T>, E>(Maybe<T>.None);

            if (maybe.Value.IsFailure)
                return Result.Failure<Maybe<T>, E>(maybe.Value.Error);

            return Result.Success<Maybe<T>, E>(Maybe.From(maybe.Value.Value));
        }
        
        /// <summary>
        /// Mark the possibly null value as optional. Null is not an error, it's just null.
        /// </summary>
        public static Result<Maybe<T>> Optional<T>(this Maybe<Result<T>> maybe)
        {
            if (maybe.HasNoValue)
                return Result.Success<Maybe<T>>(Maybe<T>.None);

            if (maybe.Value.IsFailure)
                return Result.Failure<Maybe<T>>(maybe.Value.Error);

            return Result.Success<Maybe<T>>(Maybe.From(maybe.Value.Value));
        }
    }
}
