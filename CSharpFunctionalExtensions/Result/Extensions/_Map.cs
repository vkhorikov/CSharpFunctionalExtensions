using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Result<K, E> Map<T, K, E>(this Result<T, E> result,
            Func<T, K> func)
            => result.OnSuccess(func);

        public static Result<K> Map<T, K>(this Result<T> result, Func<T, K> func)
            => result.OnSuccess(func);

        public static Result<T> Map<T>(this Result result, Func<T> func)
            => result.OnSuccess(func);
    }
}
