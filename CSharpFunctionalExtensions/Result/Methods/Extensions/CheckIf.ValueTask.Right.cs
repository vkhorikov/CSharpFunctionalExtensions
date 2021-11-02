#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        public static ValueTask<Result<T>> CheckIf<T>(this Result<T> result, bool condition, Func<T, ValueTask<Result>> func)
        {
            if (condition)
                return result.Check(func);
            else
                return ValueTask.FromResult(result);
        }

        public static ValueTask<Result<T>> CheckIf<T, K>(this Result<T> result, bool condition, Func<T, ValueTask<Result<K>>> func)
        {
            if (condition)
                return result.Check(func);
            else
                return ValueTask.FromResult(result);
        }

        public static ValueTask<Result<T, E>> CheckIf<T, K, E>(this Result<T, E> result, bool condition, Func<T, ValueTask<Result<K, E>>> func)
        {
            if (condition)
                return result.Check(func);
            else
                return ValueTask.FromResult(result);
        }

        public static ValueTask<Result<T, E>> CheckIf<T, E>(this Result<T, E> result, bool condition, Func<T, ValueTask<UnitResult<E>>> func)
        {
            if (condition)
                return result.Check(func);
            else
                return ValueTask.FromResult(result);
        }

        public static ValueTask<UnitResult<E>> CheckIf<E>(this UnitResult<E> result, bool condition, Func<ValueTask<UnitResult<E>>> func)
        {
            if (condition)
                return result.Check(func);
            else
                return ValueTask.FromResult(result);
        }

        public static ValueTask<Result<T>> CheckIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, ValueTask<Result>> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return ValueTask.FromResult(result);
        }

        public static ValueTask<Result<T>> CheckIf<T, K>(this Result<T> result, Func<T, bool> predicate, Func<T, ValueTask<Result<K>>> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return ValueTask.FromResult(result);
        }

        public static ValueTask<Result<T, E>> CheckIf<T, K, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, ValueTask<Result<K, E>>> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return ValueTask.FromResult(result);
        }

        public static ValueTask<Result<T, E>> CheckIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, ValueTask<UnitResult<E>>> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return ValueTask.FromResult(result);
        }

        public static async ValueTask<UnitResult<E>> CheckIf<E>(this UnitResult<E> result, Func<bool> predicate, Func<ValueTask<UnitResult<E>>> func)
        {
            if (result.IsSuccess && predicate())
                return await result.Check(func).DefaultAwait();
            else
                return result;
        }
    }
}
#endif
