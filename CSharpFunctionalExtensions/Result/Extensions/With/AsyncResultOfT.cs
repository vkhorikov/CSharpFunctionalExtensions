using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Task<Result<TResult>> WithMap<T1, T2, TResult>(this Result<T1> a,
            Result<T2> b,
            Func<T1, T2, Task<TResult>> func)
        {
            var mapSuccess =
                a.BindError(e1 => b
                        .MapError(e2 => Errors.Join(e1, e2))
                        .Bind(_ => Result.Failure<T1>(e1)))
                    .Bind(x => b
                        .Map(y => func(x, y))
                        .MapError(el => el));

            return mapSuccess;
        }

        public static Task<Result<TResult>> WithBind<T1, T2, TResult>(this Result<T1> a,
            Result<T2> b,
            Func<T1, T2, Task<Result<TResult>>> func)
        {
            var mapSuccess =
                a.BindError(e1 => b
                        .MapError(e2 => Errors.Join(e1, e2))
                        .Bind(_ => Result.Failure<T1>(e1)))
                    .Bind(x => b
                        .Bind(y => func(x, y))
                        .MapError(el => el));

            return mapSuccess;
        }

        public static Task<Result> WithBind<T1, T2>(this Result<T1> a,
            Result<T2> b,
            Func<T1, T2, Task<Result>> map)
        {
            var mapSuccess =
                a.BindError(el1 => b
                        .MapError(el2 => string.Join(Result.ErrorMessagesSeparator, el1, el2))
                        .Bind(_ => Result.Failure<T1>(el1)))
                    .Bind(x => b
                        .Bind(y => map(x, y))
                        .MapError(el => el));

            return mapSuccess;
        }
    }
}