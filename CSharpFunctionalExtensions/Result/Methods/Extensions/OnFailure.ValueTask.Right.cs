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
        public static ValueTask<Result<T>> OnFailure<T>(this Result<T> result, Func<ValueTask> valueTask)
            => result.TapError(valueTask);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static ValueTask<Result<T, E>> OnFailure<T, E>(this Result<T, E> result, Func<ValueTask> valueTask)
            => result.TapError(valueTask);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static ValueTask<Result> OnFailure(this Result result, Func<ValueTask> valueTask)
            => result.TapError(valueTask);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static ValueTask<Result> OnFailure(this Result result, Func<string, ValueTask> valueTask)
            => result.TapError(valueTask);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static ValueTask<UnitResult<E>> OnFailure<E>(this UnitResult<E> result, Func<ValueTask> valueTask)
            => result.TapError(valueTask);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static ValueTask<UnitResult<E>> OnFailure<E>(this UnitResult<E> result, Func<E, ValueTask> valueTask)
            => result.TapError(valueTask);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static ValueTask<Result<T>> OnFailure<T>(this Result<T> result, Func<string, ValueTask> valueTask)
            => result.TapError(valueTask);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static ValueTask<Result<T, E>> OnFailure<T, E>(this Result<T, E> result, Func<E, ValueTask> valueTask)
            => result.TapError(valueTask);
    }
}
#endif