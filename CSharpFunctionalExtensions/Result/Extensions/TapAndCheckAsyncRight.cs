using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static async Task<Result> TapAndCheck(this Result result, Func<Task<Result>> func)
        {
            if (result.IsFailure)
                return result;

            var funcResult = await func();
            return funcResult.IsSuccess
                ? result
                : Result.Failure(funcResult.Error);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static async Task<Result> TapAndCheck<K>(this Result result, Func<Task<Result<K>>> func)
        {
            if (result.IsFailure)
                return result;

            var funcResult = await func();
            return funcResult.IsSuccess
                ? result
                : Result.Failure(funcResult.Error);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static async Task<Result<T>> TapAndCheck<T>(this Result<T> result, Func<Task<Result>> func)
        {
            if (result.IsFailure)
                return result;

            return await func().Map(() => result.Value);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static async Task<Result<T>> TapAndCheck<T, K>(this Result<T> result, Func<Task<Result<K>>> func)
        {
            if (result.IsFailure)
                return result;

            return await func().Map(_ => result.Value);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static async Task<Result> TapAndCheck<T>(this Result<T> result, Func<T, Task<Result>> func)
        {
            if (result.IsFailure)
                return result;

            return await func(result.Value).Map(() => result.Value);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static async Task<Result<T>> TapAndCheck<T, K>(this Result<T> result, Func<T, Task<Result<K>>> func)
        {
            if (result.IsFailure)
                return result;

            return await func(result.Value).Map(_ => result.Value);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static async Task<Result<T, E>> TapAndCheck<T, K, E>(this Result<T, E> result, Func<Task<Result<K, E>>> func)
        {
            if (result.IsFailure)
                return result;

            return await func().Map(_ => result.Value);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static async Task<Result<T, E>> TapAndCheck<T, K, E>(this Result<T, E> result, Func<T, Task<Result<K, E>>> func)
        {
            if (result.IsFailure)
                return result;

            return await func(result.Value).Map(_ => result.Value);
        }
    }
}