using System;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        [Obsolete("Use Failure() instead.")]
        public static Result Fail(string error)
            => Failure(error);

        [Obsolete("Use Failure() instead.")]
        public static Result<T> Fail<T>(string error)
            => Failure<T>(error);

        [Obsolete("Use Failure() instead.")]
        public static Result<T, E> Fail<T, E>(E error)
            => Failure<T, E>(error);
    }
}
