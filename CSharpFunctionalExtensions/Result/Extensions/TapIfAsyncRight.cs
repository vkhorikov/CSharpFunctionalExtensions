using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result> TapIf(this Result result, bool condition, Func<Task> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result<T>> TapIf<T>(this Result<T> result, bool condition, Func<Task> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result<T>> TapIf<T>(this Result<T> result, bool condition, Func<T, Task> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result<T, E>> TapIf<T, E>(this Result<T, E> result, bool condition, Func<Task> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result<T, E>> TapIf<T, E>(this Result<T, E> result, bool condition, Func<T, Task> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result<T>> TapIf<T>(this Result<T> result, Func<T, bool> condition, Func<Task> func)
        {
            if (result.IsSuccess && condition(result.Value))
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result<T>> TapIf<T>(this Result<T> result, Func<T, bool> condition, Func<T, Task> func)
        {
            if (result.IsSuccess && condition(result.Value))
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result<T, E>> TapIf<T, E>(this Result<T, E> result, Func<T, bool> condition, Func<Task> func)
        {
            if (result.IsSuccess && condition(result.Value))
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result<T, E>> TapIf<T, E>(this Result<T, E> result, Func<T, bool> condition, Func<T, Task> func)
        {
            if (result.IsSuccess && condition(result.Value))
                return result.Tap(func);
            else
                return Task.FromResult(result);
        }
    }
}
