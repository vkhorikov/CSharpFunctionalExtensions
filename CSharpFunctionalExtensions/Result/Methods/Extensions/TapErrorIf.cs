using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Result TapErrorIf(this Result result, bool condition, Action action)
        {
            if (condition)
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Result TapErrorIf(this Result result, bool condition, Action<string> action)
        {
            if (condition)
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Result<T> TapErrorIf<T>(this Result<T> result, bool condition, Action action)
        {
            if (condition)
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Result<T> TapErrorIf<T>(this Result<T> result, bool condition, Action<string> action)
        {
            if (condition)
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static UnitResult<E> TapErrorIf<E>(this UnitResult<E> result, bool condition, Action action)
        {
            if (condition)
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static UnitResult<E> TapErrorIf<E>(this UnitResult<E> result, bool condition, Action<E> action)
        {
            if (condition)
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Result<T, E> TapErrorIf<T, E>(this Result<T, E> result, bool condition, Action action)
        {
            if (condition)
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Result<T, E> TapErrorIf<T, E>(this Result<T, E> result, bool condition, Action<E> action)
        {
            if (condition)
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Result TapErrorIf(this Result result, Func<string, bool> predicate, Action action)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Result TapErrorIf(this Result result, Func<string, bool> predicate, Action<string> action)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Result<T> TapErrorIf<T>(this Result<T> result, Func<string, bool> predicate, Action action)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Result<T> TapErrorIf<T>(this Result<T> result, Func<string, bool> predicate, Action<string> action)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Result<T, E> TapErrorIf<T, E>(this Result<T, E> result, Func<E, bool> predicate, Action action)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static Result<T, E> TapErrorIf<T, E>(this Result<T, E> result, Func<E, bool> predicate, Action<E> action)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static UnitResult<E> TapErrorIf<E>(this UnitResult<E> result, Func<E, bool> predicate, Action action)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a failure and condition is true. Returns the calling result.
        /// </summary>
        public static UnitResult<E> TapErrorIf<E>(this UnitResult<E> result, Func<E, bool> predicate, Action<E> action)
        {
            if (result.IsFailure && predicate(result.Error))
            {
                return result.TapError(action);
            }

            return result;
        }
    }
}
