using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<Result<T>> OnFailure<T>(this Result<T> result, Func<Task> func)
            => result.TapError(func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<Result<T, E>> OnFailure<T, E>(this Result<T, E> result, Func<Task> func)
            => result.TapError(func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<Result> OnFailure(this Result result, Func<Task> func)
            => result.TapError(func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<Result> OnFailure(this Result result, Func<string, Task> func)
            => result.TapError(func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<UnitResult<E>> OnFailure<E>(this UnitResult<E> result, Func<Task> func)
            => result.TapError(func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<UnitResult<E>> OnFailure<E>(this UnitResult<E> result, Func<E, Task> func)
            => result.TapError(func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<Result<T>> OnFailure<T>(this Result<T> result, Func<string, Task> func)
            => result.TapError(func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<Result<T, E>> OnFailure<T, E>(this Result<T, E> result, Func<E, Task> func)
            => result.TapError(func);
    }
}
