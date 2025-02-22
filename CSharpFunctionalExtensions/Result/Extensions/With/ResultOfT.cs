using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Result<(T1, T2)> With<T1, T2>(this Result<T1> a, Result<T2> b)
        {
            return a.WithMap(b, (x, y) => (x, y));
        }

        public static Result<TResult> WithMap<T, K, TResult>(
            this Result<T> a,
            Result<K> b,
            Func<T, K, TResult> func)
        {
            return a
                .BindError(e1 => b
                    .MapError(e2 => Errors.Join(e1, e2))
                    .Bind(_ => Result.Failure<T>(e1))
                ).Bind(x => b
                    .Map(y => func(x, y))
                    .MapError(e => e));
        }

        public static Result<TResult> WithBind<T, K, TResult>(
            this Result<T> a,
            Result<K> b,
            Func<T, K, Result<TResult>> func)
        {
            return a
                .BindError(e1 => b
                    .MapError(e2 => Errors.Join(e1, e2))
                    .Bind(_ => Result.Failure<T>(e1))
                ).Bind(x => b
                    .Bind(y => func(x, y))
                    .MapError(e => e));
        }
    }
}