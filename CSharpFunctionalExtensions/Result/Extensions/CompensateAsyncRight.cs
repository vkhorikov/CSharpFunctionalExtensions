using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Task<Result> Compensate(this Result result, Func<string, Task<Result>> func)
        {
            if (result.IsSuccess)
            {
                return Result.Success().AsCompletedTask();
            }

            return func(result.Error);
        }

        public static Task<UnitResult<E>> Compensate<E>(this Result result, Func<string, Task<UnitResult<E>>> func)
        {
            if (result.IsSuccess)
            {
                return UnitResult.Success<E>().AsCompletedTask();
            }

            return func(result.Error);
        }

        public static Task<Result> Compensate<T>(this Result<T> result, Func<string, Task<Result>> func)
        {
            if (result.IsSuccess)
            {
                return Result.Success().AsCompletedTask();
            }

            return func(result.Error);
        }

        public static Task<Result<T>> Compensate<T>(this Result<T> result, Func<string, Task<Result<T>>> func)
        {
            if (result.IsSuccess)
            {
                return Result.Success(result.Value).AsCompletedTask();
            }

            return func(result.Error);
        }

        public static Task<Result<T, E>> Compensate<T, E>(this Result<T> result, Func<string, Task<Result<T, E>>> func)
        {
            if (result.IsSuccess)
            {
                return Result.Success<T, E>(result.Value).AsCompletedTask();
            }

            return func(result.Error);
        }

        public static Task<Result> Compensate<E>(this UnitResult<E> result, Func<E, Task<Result>> func)
        {
            if (result.IsSuccess)
            {
                return Result.Success().AsCompletedTask();
            }

            return func(result.Error);
        }

        public static Task<UnitResult<E2>> Compensate<E, E2>(this UnitResult<E> result, Func<E, Task<UnitResult<E2>>> func)
        {
            if (result.IsSuccess)
            {
                return UnitResult.Success<E2>().AsCompletedTask();
            }

            return func(result.Error);
        }

        public static Task<Result> Compensate<T, E>(this Result<T, E> result, Func<E, Task<Result>> func)
        {
            if (result.IsSuccess)
            {
                return Result.Success().AsCompletedTask();
            }

            return func(result.Error);
        }

        public static Task<UnitResult<E2>> Compensate<T, E, E2>(this Result<T, E> result, Func<E, Task<UnitResult<E2>>> func)
        {
            if (result.IsSuccess)
            {
                return UnitResult.Success<E2>().AsCompletedTask();
            }

            return func(result.Error);
        }

        public static Task<Result<T, E2>> Compensate<T, E, E2>(this Result<T, E> result, Func<E, Task<Result<T, E2>>> func)
        {
            if (result.IsSuccess)
            {
                return Result.Success<T, E2>(result.Value).AsCompletedTask();
            }

            return func(result.Error);
        }
    }
}