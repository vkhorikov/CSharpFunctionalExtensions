using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<Result<T>> OnFailure<T>(this Task<Result<T>> resultTask, Action action)
            => resultTask.TapError(action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<Result> OnFailure(this Task<Result> resultTask, Action action)
            => resultTask.TapError(action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<Result<T, E>> OnFailure<T, E>(this Task<Result<T, E>> resultTask, Action action)
            => resultTask.TapError(action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<UnitResult<E>> OnFailure<E>(this Task<UnitResult<E>> resultTask, Action action)
            => resultTask.TapError(action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<UnitResult<E>> OnFailure<E>(this Task<UnitResult<E>> resultTask, Action<E> action)
            => resultTask.TapError(action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<Result<T>> OnFailure<T>(this Task<Result<T>> resultTask, Action<string> action)
            => resultTask.TapError(action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<Result<T, E>> OnFailure<T, E>(this Task<Result<T, E>> resultTask, Action<E> action)
            => resultTask.TapError(action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<Result> OnFailure(this Task<Result> resultTask, Action<string> action)
            => resultTask.TapError(action);
    }
}
