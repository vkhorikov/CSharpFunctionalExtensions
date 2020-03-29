using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Result TapIf(this Result result, bool condition, Action action)
        {
            if (condition)
                return result.Tap(action);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Result<T> TapIf<T>(this Result<T> result, bool condition, Action action)
        {
            if (condition)
                return result.Tap(action);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Result<T> TapIf<T>(this Result<T> result, bool condition, Action<T> action)
        {
            if (condition)
                return result.Tap(action);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Result<T, E> TapIf<T, E>(this Result<T, E> result, bool condition, Action action)
        {
            if (condition)
                return result.Tap(action);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Result<T, E> TapIf<T, E>(this Result<T, E> result, bool condition, Action<T> action)
        {
            if (condition)
                return result.Tap(action);
            else
                return result;
        }

        public static Result<T> TapIf<T>(this Result<T> result, bool condition, Func<T, Result> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return result;
        }

        public static Result<T> TapIf<T, K>(this Result<T> result, bool condition, Func<T, Result<K>> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return result;
        }

        public static Result<T, E> TapIf<T, K, E>(this Result<T, E> result, bool condition, Func<T, Result<K, E>> func)
        {
            if (condition)
                return result.Tap(func);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Result<T> TapIf<T>(this Result<T> result, Func<T, bool> predicate, Action action)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(action);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Result<T> TapIf<T>(this Result<T> result, Func<T, bool> predicate, Action<T> action)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(action);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Result<T, E> TapIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Action action)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(action);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Result<T, E> TapIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Action<T> action)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(action);
            else
                return result;
        }

        public static Result<T> TapIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Result> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(func);
            else
                return result;
        }

        public static Result<T> TapIf<T, K>(this Result<T> result, Func<T, bool> predicate, Func<T, Result<K>> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(func);
            else
                return result;
        }

        public static Result<T, E> TapIf<T, K, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, Result<K, E>> func)
        {
            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(func);
            else
                return result;
        }
    }
}
