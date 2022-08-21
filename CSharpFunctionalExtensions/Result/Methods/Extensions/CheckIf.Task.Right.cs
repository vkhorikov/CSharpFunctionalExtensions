using System;
using System.Threading.Tasks;

#if NET40
using Task = System.Threading.Tasks.TaskEx;
#else
using Task = System.Threading.Tasks.Task;
#endif

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        public static Task<Result<T>> CheckIf<T>(this Result<T> result, bool condition, Func<T, Task<Result>> func)
        {
            if (condition)
                return result.Check(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Result<T>> CheckIf<T, K>(this Result<T> result, bool condition, Func<T, Task<Result<K>>> func)
        {
            if (condition)
                return result.Check(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Result<T, E>> CheckIf<T, K, E>(this Result<T, E> result, bool condition, Func<T, Task<Result<K, E>>> func)
        {
            if (condition)
                return result.Check(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Result<T, E>> CheckIf<T, E>(this Result<T, E> result, bool condition, Func<T, Task<UnitResult<E>>> func)
        {
            if (condition)
                return result.Check(func);
            else
                return Task.FromResult(result);
        }

        public static Task<UnitResult<E>> CheckIf<E>(this UnitResult<E> result, bool condition, Func<Task<UnitResult<E>>> func)
        {
            if (condition)
                return result.Check(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Result<T>> CheckIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Task<Result>> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Result<T>> CheckIf<T, K>(this Result<T> result, Func<T, bool> predicate, Func<T, Task<Result<K>>> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Result<T, E>> CheckIf<T, K, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, Task<Result<K, E>>> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Result<T, E>> CheckIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, Task<UnitResult<E>>> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return Task.FromResult(result);
        }

        public static async Task<UnitResult<E>> CheckIf<E>(this UnitResult<E> result, Func<bool> predicate, Func<Task<UnitResult<E>>> func)
        {
            if (result.IsSuccess && predicate())
                return await result.Check(func).DefaultAwait();
            else
                return result;
        }
    }
}
