using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Task<Result> BindIf(this Result result, bool condition, Func<Task<Result>> func)
        {
            if (!condition)
            {
                return result.AsCompletedTask();
            }

            return result.Bind(func);
        }

        public static Task<Result<T>> BindIf<T>(this Result<T> result, bool condition, Func<T, Task<Result<T>>> func)
        {
            if (!condition)
            {
                return result.AsCompletedTask();
            }

            return result.Bind(func);
        }

        public static Task<UnitResult<E>> BindIf<E>(this UnitResult<E> result, bool condition, Func<Task<UnitResult<E>>> func)
        {
            if (!condition)
            {
                return result.AsCompletedTask();
            }

            return result.Bind(func);
        }

        public static Task<Result<T, E>> BindIf<T, E>(this Result<T, E> result, bool condition, Func<T, Task<Result<T, E>>> func)
        {
            if (!condition)
            {
                return result.AsCompletedTask();
            }

            return result.Bind(func);
        }

        public static Task<Result> BindIf(this Result result, Func<bool> predicate, Func<Task<Result>> func)
        {
            if (!result.IsSuccess || !predicate())
            {
                return result.AsCompletedTask();
            }

            return result.Bind(func);
        }

        public static Task<Result<T>> BindIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Task<Result<T>>> func)
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result.AsCompletedTask();
            }

            return result.Bind(func);
        }

        public static Task<UnitResult<E>> BindIf<E>(this UnitResult<E> result, Func<bool> predicate, Func<Task<UnitResult<E>>> func)
        {
            if (!result.IsSuccess || !predicate())
            {
                return result.AsCompletedTask();
            }

            return result.Bind(func);
        }

        public static Task<Result<T, E>> BindIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, Task<Result<T, E>>> func)
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result.AsCompletedTask();
            }

            return result.Bind(func);
        }
    }
}