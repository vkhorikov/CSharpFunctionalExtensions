using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<Result<T, E>> OnFailure<T, E>(this Task<Result<T, E>> resultTask, Func<Task> func)
            => resultTask.TapError(func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<Result<T>> OnFailure<T>(this Task<Result<T>> resultTask, Func<Task> func)
            => resultTask.TapError(func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<Result> OnFailure(this Task<Result> resultTask, Func<Task> func)
            => resultTask.TapError(func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<Result> OnFailure(this Task<Result> resultTask, Func<string, Task> func)
            => resultTask.TapError(func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<UnitResult<E>> OnFailure<E>(this Task<UnitResult<E>> resultTask, Func<E, Task> func)
            => resultTask.TapError(func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<UnitResult<E>> OnFailure<E>(this Task<UnitResult<E>> resultTask, Func<Task> func)
            => resultTask.TapError(func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<Result<T>> OnFailure<T>(this Task<Result<T>> resultTask, Func<string, Task> func)
            => resultTask.TapError(func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use TapError() instead.")]
        public static Task<Result<T, E>> OnFailure<T, E>(this Task<Result<T, E>> resultTask, Func<E, Task> func)
            => resultTask.TapError(func);
    }
}
