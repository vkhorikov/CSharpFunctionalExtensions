using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        [Obsolete("Use Map() instead.")]
        public static Task<Result<K, E>> OnSuccess<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Task<K>> func)
            => Map(resultTask, func);

        [Obsolete("Use Map() instead.")]
        public static Task<Result<K>> OnSuccess<T, K>(this Task<Result<T>> resultTask, Func<T, Task<K>> func)
            => Map(resultTask, func);

        [Obsolete("Use Map() instead.")]
        public static Task<Result<K>> OnSuccess<K>(this Task<Result> resultTask, Func<Task<K>> func)
            => Map(resultTask, func);

        [Obsolete("Use Bind() instead.")]
        public static Task<Result<K, E>> OnSuccess<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Task<Result<K, E>>> func)
            => Bind(resultTask, func);

        [Obsolete("Use Bind() instead.")]
        public static Task<Result<K>> OnSuccess<T, K>(this Task<Result<T>> resultTask, Func<T, Task<Result<K>>> func)
            => Bind(resultTask, func);

        [Obsolete("Use Bind() instead.")]
        public static Task<Result<K>> OnSuccess<K>(this Task<Result> resultTask, Func<Task<Result<K>>> func)
            => Bind(resultTask, func);

        [Obsolete("Use Bind() instead.")]
        public static Task<Result> OnSuccess<T>(this Task<Result<T>> resultTask, Func<T, Task<Result>> func)
            => Bind(resultTask, func);

        [Obsolete("Use Bind() instead.")]
        public static Task<Result> OnSuccess(this Task<Result> resultTask, Func<Task<Result>> func)
            => Bind(resultTask, func);

        [Obsolete("Use Tap() instead.")]
        public static Task<Result<T, E>> OnSuccess<T, E>(this Task<Result<T, E>> resultTask, Func<T, Task> action)
            => Tap(resultTask, action);

        [Obsolete("Use Tap() instead.")]
        public static Task<Result<T>> OnSuccess<T>(this Task<Result<T>> resultTask, Func<T, Task> action)
            => Tap(resultTask, action);

        [Obsolete("Use Tap() instead.")]
        public static Task<Result> OnSuccess(this Task<Result> resultTask, Func<Task> action)
            => Tap(resultTask, action);
    }
}
