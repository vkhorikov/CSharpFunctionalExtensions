using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        [Obsolete("Use Map() instead.")]
        public static Result<K, E> OnSuccess<T, K, E>(this Result<T, E> result, Func<T, K> func)
            => Map(result, func);

        [Obsolete("Use Map() instead.")]
        public static Result<K> OnSuccess<T, K>(this Result<T> result, Func<T, K> func)
            => Map(result, func);

        [Obsolete("Use Map() instead.")]
        public static Result<K> OnSuccess<K>(this Result result, Func<K> func)
            => Map(result, func);

        [Obsolete("Use Bind() instead.")]
        public static Result<K, E> OnSuccess<T, K, E>(this Result<T, E> result, Func<T, Result<K, E>> func)
            => Bind(result, func);

        [Obsolete("Use Bind() instead.")]
        public static Result<K> OnSuccess<T, K>(this Result<T> result, Func<T, Result<K>> func)
            => Bind(result, func);

        [Obsolete("Use Bind() instead.")]
        public static Result<K> OnSuccess<K>(this Result result, Func<Result<K>> func)
            => Bind(result, func);

        [Obsolete("Use Bind() instead.")]
        public static Result OnSuccess<T>(this Result<T> result, Func<T, Result> func)
            => Bind(result, func);

        [Obsolete("Use Bind() instead.")]
        public static Result OnSuccess(this Result result, Func<Result> func)
            => Bind(result, func);

        [Obsolete("Use Tap() instead.")]
        public static Result<T, E> OnSuccess<T, E>(this Result<T, E> result, Action<T> action)
            => Tap(result, action);

        [Obsolete("Use Tap() instead.")]
        public static Result<T> OnSuccess<T>(this Result<T> result, Action<T> action)
            => Tap(result, action);

        [Obsolete("Use Tap() instead.")]
        public static Result OnSuccess(this Result result, Action action)
            => Tap(result, action);
    }
}
