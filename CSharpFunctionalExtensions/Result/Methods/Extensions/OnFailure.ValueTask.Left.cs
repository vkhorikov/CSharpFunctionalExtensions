#if NET5_0_OR_GREATER
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static ValueTask<Result<T>> OnFailure<T>(this ValueTask<Result<T>> resultTask, Action action)
            => resultTask.TapError(action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static ValueTask<Result> OnFailure(this ValueTask<Result> resultTask, Action action)
            => resultTask.TapError(action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static ValueTask<Result<T, E>> OnFailure<T, E>(this ValueTask<Result<T, E>> resultTask, Action action)
            => resultTask.TapError(action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static ValueTask<UnitResult<E>> OnFailure<E>(this ValueTask<UnitResult<E>> resultTask, Action action)
            => resultTask.TapError(action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static ValueTask<UnitResult<E>> OnFailure<E>(this ValueTask<UnitResult<E>> resultTask, Action<E> action)
            => resultTask.TapError(action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static ValueTask<Result<T>> OnFailure<T>(this ValueTask<Result<T>> resultTask, Action<string> action)
            => resultTask.TapError(action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static ValueTask<Result<T, E>> OnFailure<T, E>(this ValueTask<Result<T, E>> resultTask, Action<E> action)
            => resultTask.TapError(action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static ValueTask<Result> OnFailure(this ValueTask<Result> resultTask, Action<string> action)
            => resultTask.TapError(action);
    }
}
#endif