using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        public static Task<Result<T>> CheckIf<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<Result>> func)
        {
            if (condition)
                return resultTask.Check(func);
            else
                return resultTask;
        }

        public static Task<Result<T>> CheckIf<T, K>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<Result<K>>> func)
        {
            if (condition)
                return resultTask.Check(func);
            else
                return resultTask;
        }

        public static Task<Result<T, E>> CheckIf<T, K, E>(this Task<Result<T, E>> resultTask, bool condition, Func<T, Task<Result<K, E>>> func)
        {
            if (condition)
                return resultTask.Check(func);
            else
                return resultTask;
        }

        public static Task<Result<T, E>> CheckIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Func<T, Task<UnitResult<E>>> func)
        {
            if (condition)
                return resultTask.Check(func);
            else
                return resultTask;
        }

        public static Task<UnitResult<E>> CheckIf<E>(this Task<UnitResult<E>> resultTask, bool condition, Func<Task<UnitResult<E>>> func)
        {
            if (condition)
                return resultTask.Check(func);
            else
                return resultTask;
        }
        
        public static async Task<Result<T>> CheckIf<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Task<Result>> func)
        {
            Result<T> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate(result.Value))
                return await result.Check(func).DefaultAwait();
            else
                return result;
        }

        public static async Task<Result<T>> CheckIf<T, K>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Task<Result<K>>> func)
        {
            Result<T> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate(result.Value))
                return await result.Check(func).DefaultAwait();
            else
                return result;
        }

        public static async Task<Result<T, E>> CheckIf<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, Task<Result<K, E>>> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate(result.Value))
                return await result.Check(func).DefaultAwait();
            else
                return result;
        }

        public static async Task<Result<T, E>> CheckIf<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, Task<UnitResult<E>>> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate(result.Value))
                return await result.Check(func).DefaultAwait();
            else
                return result;
        }

        public static async Task<UnitResult<E>> CheckIf<E>(this Task<UnitResult<E>> resultTask, Func<bool> predicate, Func<Task<UnitResult<E>>> func)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate())
                return await result.Check(func).DefaultAwait();
            else
                return result;
        }
    }
}
