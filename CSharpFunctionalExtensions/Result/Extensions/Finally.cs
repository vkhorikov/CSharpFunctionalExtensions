using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static T Finally<T>(this Result result, Func<Result, T> func)
            => func(result);

        public static K Finally<T, K>(this Result<T> result, Func<Result<T>, K> func)
            => func(result);

        public static K Finally<T, K, E>(this Result<T, E> result, Func<Result<T, E>, K> func)
            => func(result);
    }
}
