using System;
using System.ComponentModel;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Result<T, E> OnFailure<T, E>(this Result<T, E> result, Action action)
            => result.TapError(action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Result<T> OnFailure<T>(this Result<T> result, Action action)
            => result.TapError(action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Result OnFailure(this Result result, Action action)
            => result.TapError(action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static UnitResult<E> OnFailure<E>(this UnitResult<E> result, Action<E> action)
            => result.TapError(action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static UnitResult<E> OnFailure<E>(this UnitResult<E> result, Action action)
            => result.TapError(action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Result<T, E> OnFailure<T, E>(this Result<T, E> result, Action<E> action)
            => result.TapError(action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Result<T> OnFailure<T>(this Result<T> result, Action<string> action)
            => result.TapError(action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Result OnFailure(this Result result, Action<string> action)
            => result.TapError(action);
    }
}
