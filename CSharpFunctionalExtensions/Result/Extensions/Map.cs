using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Result<K, E> Map<T, K, E>(this Result<T, E> result, Func<T, K> func)
        {
            if (result.IsFailure)
                return Result.Fail<K, E>(result.Error);

            return Result.Ok<K, E>(func(result.Value));
        }

        public static Result<K> Map<T, K>(this Result<T> result, Func<T, K> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return Result.Ok(func(result.Value));
        }

        public static Result<K> Map<K>(this Result result, Func<K> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return Result.Ok(func());
        }
    }
}
