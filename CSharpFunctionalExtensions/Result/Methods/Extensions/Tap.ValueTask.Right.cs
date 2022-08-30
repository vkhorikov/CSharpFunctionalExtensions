#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result> Tap(this Result result, Func<ValueTask> valueTask)
        {
            if (result.IsSuccess)
                await valueTask();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> Tap<T>(this Result<T> result, Func<ValueTask> valueTask)
        {
            if (result.IsSuccess)
                await valueTask();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> Tap<T>(this Result<T> result, Func<T, ValueTask> valueTask)
        {
            if (result.IsSuccess)
                await valueTask(result.Value);

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> Tap<E>(this UnitResult<E> result, Func<ValueTask> valueTask)
        {
            if (result.IsSuccess)
                await valueTask();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> Tap<T, E>(this Result<T, E> result, Func<ValueTask> valueTask)
        {
            if (result.IsSuccess)
                await valueTask();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> Tap<T, E>(this Result<T, E> result, Func<T, ValueTask> valueTask)
        {
            if (result.IsSuccess)
                await valueTask(result.Value);

            return result;
        }
    }
}
#endif