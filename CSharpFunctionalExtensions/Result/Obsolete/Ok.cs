using System;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        [Obsolete("Use Success() instead.")]
        public static Result Ok()
            => Success();

        [Obsolete("Use Success() instead.")]
        public static Result<T> Ok<T>(T value)
            => Success(value);

        [Obsolete("Use Success() instead.")]
        public static Result<T, E> Ok<T, E>(T value)
            => Success<T, E>(value);
    }
}
