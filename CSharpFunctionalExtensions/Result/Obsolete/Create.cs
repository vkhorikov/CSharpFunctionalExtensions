using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use SuccessIf() instead.")]
        public static Result Create(bool isSuccess, string error)
            => SuccessIf(isSuccess, error);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use SuccessIf() instead.")]
        public static Result Create(Func<bool> predicate, string error)
            => SuccessIf(predicate, error);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use SuccessIf() instead.")]
        public static Task<Result> Create(Func<Task<bool>> predicate, string error)
            => SuccessIf(predicate, error);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use SuccessIf() instead.")]
        public static Result<T> Create<T>(bool isSuccess, T value, string error)
            => SuccessIf(isSuccess, value, error);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use SuccessIf() instead.")]
        public static Result<T> Create<T>(Func<bool> predicate, T value, string error)
            => SuccessIf(predicate, value, error);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use SuccessIf() instead.")]
        public static Task<Result<T>> Create<T>(Func<Task<bool>> predicate, T value, string error)
            => SuccessIf(predicate, value, error);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use SuccessIf() instead.")]
        public static Result<T, E> Create<T, E>(bool isSuccess, T value, E error)
            => SuccessIf(isSuccess, value, error);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use SuccessIf() instead.")]
        public static Result<T, E> Create<T, E>(Func<bool> predicate, T value, E error)
            => SuccessIf(predicate, value, error);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use SuccessIf() instead.")]
        public static Task<Result<T, E>> Create<T, E>(Func<Task<bool>> predicate, T value, E error)
            => SuccessIf(predicate, value, error);
    }
}
