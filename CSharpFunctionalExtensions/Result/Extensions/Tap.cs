using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static Result Tap(this Result result, Action action)
        {
            if (result.IsSuccess)
                action();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static Result<T> Tap<T>(this Result<T> result, Action action)
        {
            if (result.IsSuccess)
                action();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static Result<T> Tap<T>(this Result<T> result, Action<T> action)
        {
            if (result.IsSuccess)
                action(result.Value);

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static Result<T, E> Tap<T, E>(this Result<T, E> result, Action action)
        {
            if (result.IsSuccess)
                action();

            return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result.
        /// </summary>
        public static Result<T, E> Tap<T, E>(this Result<T, E> result, Action<T> action)
        {
            if (result.IsSuccess)
                action(result.Value);

            return result;
        }
    }
}
