using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> TapError<T>(this Result<T> result, Func<Task> func)
        {
            if (result.IsFailure)
            {
                await func().DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> TapError<T, E>(this Result<T, E> result, Func<Task> func)
        {
            if (result.IsFailure)
            {
                await func().DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Result> TapError(this Result result, Func<Task> func)
        {
            if (result.IsFailure)
            {
                await func().DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Result> TapError(this Result result, Func<string, Task> func)
        {
            if (result.IsFailure)
            {
                await func(result.Error).DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<UnitResult<E>> TapError<E>(this UnitResult<E> result, Func<Task> func)
        {
            if (result.IsFailure)
            {
                await func().DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<UnitResult<E>> TapError<E>(this UnitResult<E> result, Func<E, Task> func)
        {
            if (result.IsFailure)
            {
                await func(result.Error).DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> TapError<T>(this Result<T> result, Func<string, Task> func)
        {
            if (result.IsFailure)
            {
                await func(result.Error).DefaultAwait();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> TapError<T, E>(this Result<T, E> result, Func<E, Task> func)
        {
            if (result.IsFailure)
            {
                await func(result.Error).DefaultAwait();
            }

            return result;
        }
    }
}
