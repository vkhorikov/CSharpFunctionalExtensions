using System;
using System.ComponentModel;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Success() instead.")]
        public static Result Ok()
            => Success();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Success() instead.")]
        public static Result<T> Ok<T>(T value)
            => Success(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Success() instead.")]
        public static Result<T, E> Ok<T, E>(T value)
            => Success<T, E>(value);
    }
}
