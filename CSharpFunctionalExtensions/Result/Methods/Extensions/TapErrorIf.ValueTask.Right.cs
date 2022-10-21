#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result> TapErrorIf(this Result result, bool condition, Func<ValueTask> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result> TapErrorIf(this Result result, bool condition, Func<string, ValueTask> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T>> TapErrorIf<T>(this Result<T> result, bool condition, Func<ValueTask> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T>> TapErrorIf<T>(this Result<T> result, bool condition, Func<string, ValueTask> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T, E>> TapErrorIf<T, E>(this Result<T, E> result, bool condition, Func<ValueTask> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T, E>> TapErrorIf<T, E>(this Result<T, E> result, bool condition, Func<E, ValueTask> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<UnitResult<E>> TapErrorIf<E>(this UnitResult<E> result, bool condition, Func<ValueTask> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<UnitResult<E>> TapErrorIf<E>(this UnitResult<E> result, bool condition, Func<E, ValueTask> func)
        {
            if (condition)
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result> TapErrorIf(this Result result, Func<string, bool> predicate, Func<ValueTask> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result> TapErrorIf(this Result result, Func<string, bool> predicate, Func<string, ValueTask> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T>> TapErrorIf<T>(this Result<T> result, Func<string, bool> predicate, Func<ValueTask> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T>> TapErrorIf<T>(this Result<T> result, Func<string, bool> predicate, Func<string, ValueTask> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T, E>> TapErrorIf<T, E>(this Result<T, E> result, Func<E, bool> predicate, Func<ValueTask> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<Result<T, E>> TapErrorIf<T, E>(this Result<T, E> result, Func<E, bool> predicate, Func<E, ValueTask> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<UnitResult<E>> TapErrorIf<E>(this UnitResult<E> result, Func<E, bool> predicate, Func<ValueTask> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static ValueTask<UnitResult<E>> TapErrorIf<E>(this UnitResult<E> result, Func<E, bool> predicate, Func<E, ValueTask> func)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(func);
            }

            return result.AsCompletedValueTask();
        }
    }
}
#endif
