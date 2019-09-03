using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        public static Task<Result> TapIf(this Result result, bool condition, Func<Task> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Result> TapIf<K>(this Result result, bool condition, Func<Task<K>> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Result<T>> TapIf<T>(this Result<T> result, bool condition, Func<Task> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Result<T>> TapIf<T, _>(this Result<T> result, bool condition, Func<Task<_>> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Result<T>> TapIf<T, _>(this Result<T> result, bool condition, Func<T, Task<_>> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Result<T, E>> TapIf<T, E>(this Result<T, E> result, bool condition, Func<Task> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Result<T, E>> TapIf<T, E, _>(this Result<T, E> result, bool condition, Func<Task<_>> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Result<T>> TapIf<T>(this Result<T> result, bool condition, Func<T, Task> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Result<T, E>> TapIf<T, E>(this Result<T, E> result, bool condition, Func<T, Task> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        public static Task<Result<T, E>> TapIf<T, E, _>(this Result<T, E> result, bool condition, Func<T, Task<_>> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }
    }
}
