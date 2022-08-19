#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
   public static partial class AsyncResultExtensionsLeftOperand
    {
        public static ValueTask<Result<T>> CheckIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, Result> func)
        {
            if (condition)
                return resultTask.Check(func);
            else
                return resultTask;
        }

        public static ValueTask<Result<T>> CheckIf<T, K>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, Result<K>> func)
        {
            if (condition)
                return resultTask.Check(func);
            else
                return resultTask;
        }

        public static ValueTask<Result<T, E>> CheckIf<T, K, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<T, Result<K, E>> func)
        {
            if (condition)
                return resultTask.Check(func);
            else
                return resultTask;
        }

        public static ValueTask<Result<T, E>> CheckIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<T, UnitResult<E>> func)
        {
            if (condition)
                return resultTask.Check(func);
            else
                return resultTask;
        }

        public static ValueTask<UnitResult<E>> CheckIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Func<UnitResult<E>> func)
        {
            if (condition)
                return resultTask.Check(func);
            else
                return resultTask;
        }

        public static async ValueTask<Result<T>> CheckIf<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result> func)
        {
            Result<T> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return result;
        }

        public static async ValueTask<Result<T>> CheckIf<T, K>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result<K>> func)
        {
            Result<T> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return result;
        }

        public static async ValueTask<Result<T, E>> CheckIf<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, Result<K, E>> func)
        {
            Result<T, E> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return result;
        }

        public static async ValueTask<Result<T, E>> CheckIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, UnitResult<E>> func)
        {
            Result<T, E> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return result;
        }

        public static async ValueTask<UnitResult<E>> CheckIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<bool> predicate, Func<UnitResult<E>> func)
        {
            UnitResult<E> result = await resultTask;

            if (result.IsSuccess && predicate())
                return result.Check(func);
            else
                return result;
        }
    }
}
#endif