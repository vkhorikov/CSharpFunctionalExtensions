#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static ValueTask<Result> BindIf(this Result result, bool condition, Func<ValueTask<Result>> func)
        {
            if (!condition)
            {
                return result.AsCompletedValueTask();
            }

            return result.Bind(func);
        }

        public static ValueTask<Result<T>> BindIf<T>(this Result<T> result, bool condition, Func<T, ValueTask<Result<T>>> func)
        {
            if (!condition)
            {
                return result.AsCompletedValueTask();
            }

            return result.Bind(func);
        }

        public static ValueTask<UnitResult<E>> BindIf<E>(this UnitResult<E> result, bool condition, Func<ValueTask<UnitResult<E>>> func)
        {
            if (!condition)
            {
                return result.AsCompletedValueTask();
            }

            return result.Bind(func);
        }

        public static ValueTask<Result<T, E>> BindIf<T, E>(this Result<T, E> result, bool condition, Func<T, ValueTask<Result<T, E>>> func)
        {
            if (!condition)
            {
                return result.AsCompletedValueTask();
            }

            return result.Bind(func);
        }

        public static ValueTask<Result> BindIf(this Result result, Func<bool> predicate, Func<ValueTask<Result>> func)
        {
            if (!result.IsSuccess || !predicate())
            {
                return result.AsCompletedValueTask();
            }

            return result.Bind(func);
        }

        public static ValueTask<Result<T>> BindIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, ValueTask<Result<T>>> func)
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result.AsCompletedValueTask();
            }

            return result.Bind(func);
        }

        public static ValueTask<UnitResult<E>> BindIf<E>(this UnitResult<E> result, Func<bool> predicate, Func<ValueTask<UnitResult<E>>> func)
        {
            if (!result.IsSuccess || !predicate())
            {
                return result.AsCompletedValueTask();
            }

            return result.Bind(func);
        }

        public static ValueTask<Result<T, E>> BindIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, ValueTask<Result<T, E>>> func)
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result.AsCompletedValueTask();
            }

            return result.Bind(func);
        }
    }
}
#endif