#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> OnFailure<T>(this Result<T> result, Func<ValueTask> func)
        {
            if (result.IsFailure)
            {
                await func();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> OnFailure<T, E>(this Result<T, E> result, Func<ValueTask> func)
        {
            if (result.IsFailure)
            {
                await func();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result> OnFailure(this Result result, Func<ValueTask> func)
        {
            if (result.IsFailure)
            {
                await func();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result> OnFailure(this Result result, Func<string, ValueTask> func)
        {
            if (result.IsFailure)
            {
                await func(result.Error);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> OnFailure<E>(this UnitResult<E> result, Func<ValueTask> func)
        {
            if (result.IsFailure)
            {
                await func();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> OnFailure<E>(this UnitResult<E> result, Func<E, ValueTask> func)
        {
            if (result.IsFailure)
            {
                await func(result.Error);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> OnFailure<T>(this Result<T> result, Func<string, ValueTask> func)
        {
            if (result.IsFailure)
            {
                await func(result.Error);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> OnFailure<T, E>(this Result<T, E> result, Func<E, ValueTask> func)
        {
            if (result.IsFailure)
            {
                await func(result.Error);
            }

            return result;
        }
    }
}
#endif