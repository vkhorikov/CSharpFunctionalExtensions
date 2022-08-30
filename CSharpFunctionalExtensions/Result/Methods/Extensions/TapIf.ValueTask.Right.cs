#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result> TapIf(this Result result, bool condition, Func<ValueTask> valueTask)
        {
            if (condition)
                return result.Tap(valueTask);
            else
                return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T>> TapIf<T>(this Result<T> result, bool condition, Func<ValueTask> valueTask)
        {
            if (condition)
                return result.Tap(valueTask);
            else
                return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T>> TapIf<T>(this Result<T> result, bool condition, Func<T, ValueTask> valueTask)
        {
            if (condition)
                return result.Tap(valueTask);
            else
                return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T, E>> TapIf<T, E>(this Result<T, E> result, bool condition, Func<ValueTask> valueTask)
        {
            if (condition)
                return result.Tap(valueTask);
            else
                return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T, E>> TapIf<T, E>(this Result<T, E> result, bool condition, Func<T, ValueTask> valueTask)
        {
            if (condition)
                return result.Tap(valueTask);
            else
                return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<UnitResult<E>> TapIf<E>(this UnitResult<E> result, bool condition, Func<ValueTask> valueTask)
        {
            if (condition)
                return result.Tap(valueTask);
            else
                return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T>> TapIf<T>(this Result<T> result, Func<T, bool> predicate, Func<ValueTask> valueTask)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(valueTask);
            else
                return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T>> TapIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, ValueTask> valueTask)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(valueTask);
            else
                return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T, E>> TapIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<ValueTask> valueTask)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(valueTask);
            else
                return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T, E>> TapIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, ValueTask> valueTask)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(valueTask);
            else
                return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<UnitResult<E>> TapIf<E>(this UnitResult<E> result, Func<bool> predicate, Func<ValueTask> valueTask)
        {
            if (result.IsSuccess && predicate())
                return result.Tap(valueTask);
            else
                return result.AsCompletedValueTask();
        }
    }
}
#endif
