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
        public static ValueTask<Result<T, E>> OnFailure<T, E>(this ValueTask<Result<T, E>> resultTask, Func<ValueTask> valueTask)
            => resultTask.TapError(valueTask);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static ValueTask<Result<T>> OnFailure<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask> valueTask)
            => resultTask.TapError(valueTask);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static ValueTask<Result> OnFailure(this ValueTask<Result> resultTask, Func<ValueTask> valueTask)
            => resultTask.TapError(valueTask);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static ValueTask<Result> OnFailure(this ValueTask<Result> resultTask, Func<string, ValueTask> valueTask)
            => resultTask.TapError(valueTask);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static ValueTask<UnitResult<E>> OnFailure<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, ValueTask> valueTask)
            => resultTask.TapError(valueTask);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static ValueTask<UnitResult<E>> OnFailure<E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask> valueTask)
            => resultTask.TapError(valueTask);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static ValueTask<Result<T>> OnFailure<T>(this ValueTask<Result<T>> resultTask, Func<string, ValueTask> valueTask)
            => resultTask.TapError(valueTask);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static ValueTask<Result<T, E>> OnFailure<T, E>(this ValueTask<Result<T, E>> resultTask, Func<E, ValueTask> valueTask)
            => resultTask.TapError(valueTask);
    }
}
#endif