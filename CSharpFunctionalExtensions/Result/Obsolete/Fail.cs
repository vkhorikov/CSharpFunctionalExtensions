using System;
using System.ComponentModel;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Failure() instead.")]
        public static Result Fail(string error)
            => Failure(error);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Failure() instead.")]
        public static Result<T> Fail<T>(string error)
            => Failure<T>(error);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Failure() instead.")]
        public static Result<T, E> Fail<T, E>(E error)
            => Failure<T, E>(error);
    }
}
