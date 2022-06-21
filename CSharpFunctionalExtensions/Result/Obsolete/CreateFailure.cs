using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use FailureIf() instead.")]
        public static Result CreateFailure(bool isFailure, string error)
            => FailureIf(isFailure, error);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use FailureIf() instead.")]
        public static Result CreateFailure(Func<bool> failurePredicate, string error)
            => FailureIf(failurePredicate, error);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use FailureIf() instead.")]
        public static Task<Result> CreateFailure(Func<Task<bool>> failurePredicate, string error)
            => FailureIf(failurePredicate, error);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use FailureIf() instead.")]
        public static Result<T> CreateFailure<T>(bool isFailure, T value, string error)
            => FailureIf(isFailure, value, error);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use FailureIf() instead.")]
        public static Result<T> CreateFailure<T>(Func<bool> failurePredicate, T value, string error)
            => FailureIf(failurePredicate, value, error);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use FailureIf() instead.")]
        public static Task<Result<T>> CreateFailure<T>(Func<Task<bool>> failurePredicate, T value, string error)
            => FailureIf(failurePredicate, value, error);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use FailureIf() instead.")]
        public static Result<T, E> CreateFailure<T, E>(bool isFailure, T value, E error)
            => FailureIf(isFailure, value, error);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use FailureIf() instead.")]
        public static Result<T, E> CreateFailure<T, E>(Func<bool> failurePredicate, T value, E error)
            => FailureIf(failurePredicate, value, error);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use FailureIf() instead.")]
        public static Task<Result<T, E>> CreateFailure<T, E>(Func<Task<bool>> failurePredicate, T value, E error)
            => FailureIf(failurePredicate, value, error);
    }
}
