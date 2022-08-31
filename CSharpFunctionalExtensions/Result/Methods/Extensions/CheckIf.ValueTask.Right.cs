#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        public static ValueTask<Result<T>> CheckIf<T>(this Result<T> result, bool condition, Func<T, ValueTask<Result>> valueTask)
        {
            if (condition)
                return result.Check(valueTask);
            else
                return result.AsCompletedValueTask();
        }

        public static ValueTask<Result<T>> CheckIf<T, K>(this Result<T> result, bool condition, Func<T, ValueTask<Result<K>>> valueTask)
        {
            if (condition)
                return result.Check(valueTask);
            else
                return result.AsCompletedValueTask();
        }

        public static ValueTask<Result<T, E>> CheckIf<T, K, E>(this Result<T, E> result, bool condition, Func<T, ValueTask<Result<K, E>>> valueTask)
        {
            if (condition)
                return result.Check(valueTask);
            else
                return result.AsCompletedValueTask();
        }

        public static ValueTask<Result<T, E>> CheckIf<T, E>(this Result<T, E> result, bool condition, Func<T, ValueTask<UnitResult<E>>> valueTask)
        {
            if (condition)
                return result.Check(valueTask);
            else
                return result.AsCompletedValueTask();
        }

        public static ValueTask<UnitResult<E>> CheckIf<E>(this UnitResult<E> result, bool condition, Func<ValueTask<UnitResult<E>>> valueTask)
        {
            if (condition)
                return result.Check(valueTask);
            else
                return result.AsCompletedValueTask();
        }

        public static ValueTask<Result<T>> CheckIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, ValueTask<Result>> valueTask)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(valueTask);
            else
                return result.AsCompletedValueTask();
        }

        public static ValueTask<Result<T>> CheckIf<T, K>(this Result<T> result, Func<T, bool> predicate, Func<T, ValueTask<Result<K>>> valueTask)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(valueTask);
            else
                return result.AsCompletedValueTask();
        }

        public static ValueTask<Result<T, E>> CheckIf<T, K, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, ValueTask<Result<K, E>>> valueTask)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(valueTask);
            else
                return result.AsCompletedValueTask();
        }

        public static ValueTask<Result<T, E>> CheckIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, ValueTask<UnitResult<E>>> valueTask)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(valueTask);
            else
                return result.AsCompletedValueTask();
        }

        public static async ValueTask<UnitResult<E>> CheckIf<E>(this UnitResult<E> result, Func<bool> predicate, Func<ValueTask<UnitResult<E>>> valueTask)
        {
            if (result.IsSuccess && predicate())
                return await result.Check(valueTask);
            else
                return result;
        }
    }
}
#endif
