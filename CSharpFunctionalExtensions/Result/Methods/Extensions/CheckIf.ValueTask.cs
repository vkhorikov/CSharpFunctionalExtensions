#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        public static ValueTask<Result<T>> CheckIf<T>(this ValueTask<Result<T>> resultTask, bool condition,
            Func<T, ValueTask<Result>> valueTask)
        {
            if (condition)
                return resultTask.Check(valueTask);
            else
                return resultTask;
        }

        public static ValueTask<Result<T>> CheckIf<T, K>(this ValueTask<Result<T>> resultTask, bool condition,
            Func<T, ValueTask<Result<K>>> valueTask)
        {
            if (condition)
                return resultTask.Check(valueTask);
            else
                return resultTask;
        }

        public static ValueTask<Result<T, E>> CheckIf<T, K, E>(this ValueTask<Result<T, E>> resultTask, bool condition,
            Func<T, ValueTask<Result<K, E>>> valueTask)
        {
            if (condition)
                return resultTask.Check(valueTask);
            else
                return resultTask;
        }

        public static ValueTask<Result<T, E>> CheckIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition,
            Func<T, ValueTask<UnitResult<E>>> valueTask)
        {
            if (condition)
                return resultTask.Check(valueTask);
            else
                return resultTask;
        }

        public static ValueTask<UnitResult<E>> CheckIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition,
            Func<ValueTask<UnitResult<E>>> valueTask)
        {
            if (condition)
                return resultTask.Check(valueTask);
            else
                return resultTask;
        }

        public static async ValueTask<Result<T>> CheckIf<T>(this ValueTask<Result<T>> resultTask,
            Func<T, bool> predicate, Func<T, ValueTask<Result>> valueTask)
        {
            Result<T> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return await result.Check(valueTask);
            else
                return result;
        }

        public static async ValueTask<Result<T>> CheckIf<T, K>(this ValueTask<Result<T>> resultTask,
            Func<T, bool> predicate, Func<T, ValueTask<Result<K>>> valueTask)
        {
            Result<T> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return await result.Check(valueTask);
            else
                return result;
        }

        public static async ValueTask<Result<T, E>> CheckIf<T, K, E>(this ValueTask<Result<T, E>> resultTask,
            Func<T, bool> predicate, Func<T, ValueTask<Result<K, E>>> valueTask)
        {
            Result<T, E> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return await result.Check(valueTask);
            else
                return result;
        }

        public static async ValueTask<Result<T, E>> CheckIf<T, E>(this ValueTask<Result<T, E>> resultTask,
            Func<T, bool> predicate, Func<T, ValueTask<UnitResult<E>>> valueTask)
        {
            Result<T, E> result = await resultTask;

            if (result.IsSuccess && predicate(result.Value))
                return await result.Check(valueTask);
            else
                return result;
        }

        public static async ValueTask<UnitResult<E>> CheckIf<E>(this ValueTask<UnitResult<E>> resultTask,
            Func<bool> predicate, Func<ValueTask<UnitResult<E>>> valueTask)
        {
            UnitResult<E> result = await resultTask;

            if (result.IsSuccess && predicate())
                return await result.Check(valueTask);
            else
                return result;
        }
    }
}
#endif
