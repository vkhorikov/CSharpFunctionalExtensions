#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> OnFailure<T>(this Result<T> result, Func<ValueTask> valueTask)
        {
            if (result.IsFailure)
            {
                await valueTask();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> OnFailure<T, E>(this Result<T, E> result, Func<ValueTask> valueTask)
        {
            if (result.IsFailure)
            {
                await valueTask();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result> OnFailure(this Result result, Func<ValueTask> valueTask)
        {
            if (result.IsFailure)
            {
                await valueTask();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result> OnFailure(this Result result, Func<string, ValueTask> valueTask)
        {
            if (result.IsFailure)
            {
                await valueTask(result.Error);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> OnFailure<E>(this UnitResult<E> result, Func<ValueTask> valueTask)
        {
            if (result.IsFailure)
            {
                await valueTask();
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<UnitResult<E>> OnFailure<E>(this UnitResult<E> result, Func<E, ValueTask> valueTask)
        {
            if (result.IsFailure)
            {
                await valueTask(result.Error);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T>> OnFailure<T>(this Result<T> result, Func<string, ValueTask> valueTask)
        {
            if (result.IsFailure)
            {
                await valueTask(result.Error);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure. Returns the calling result.
        /// </summary>
        public static async ValueTask<Result<T, E>> OnFailure<T, E>(this Result<T, E> result, Func<E, ValueTask> valueTask)
        {
            if (result.IsFailure)
            {
                await valueTask(result.Error);
            }

            return result;
        }
    }
}
#endif