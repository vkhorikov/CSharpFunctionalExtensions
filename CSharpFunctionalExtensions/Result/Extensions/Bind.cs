using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Result<K, E> Bind<T, K, E>(this Result<T, E> result, Func<T, Result<K, E>> func)
        {
            if (result.IsFailure)
                return Result.Fail<K, E>(result.Error);

            return func(result.Value);
        }

        public static Result<K> Bind<T, K>(this Result<T> result, Func<T, Result<K>> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return func(result.Value);
        }

        public static Result<K> Bind<K>(this Result result, Func<Result<K>> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return func();
        }

        // Potential loss of E fidelity. Not present in Async overloads
        public static Result<K> Bind<T, K, E>(this Result<T, E> result, Func<T, Result<K>> func)
        {
            if (result.IsFailure)
                return Result.Fail<K, E>(result.Error);

            return func(result.Value);
        }

        public static Result Bind<T>(this Result<T> result, Func<T, Result> func)
        {
            if (result.IsFailure)
                return Result.Fail(result.Error);

            return func(result.Value);
        }

        public static Result Bind(this Result result, Func<Result> func)
        {
            if (result.IsFailure)
                return result;

            return func();
        }
    }
}
