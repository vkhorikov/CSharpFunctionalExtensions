using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static Result TapAndCheck(this Result result, Func<Result> func)
        {
            if (result.IsFailure)
                return result;

            var funcResult = func();
            return funcResult.IsSuccess
                ? result
                : Result.Failure(funcResult.Error);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static Result TapAndCheck<K>(this Result result, Func<Result<K>> func)
        {
            if (result.IsFailure)
                return result;

            var funcResult = func();
            return funcResult.IsSuccess
                ? result
                : Result.Failure(funcResult.Error);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static Result<T> TapAndCheck<T>(this Result<T> result, Func<Result> func)
        {
            if (result.IsFailure)
                return result;

            return func().Map(() => result.Value);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static Result<T> TapAndCheck<T, K>(this Result<T> result, Func<Result<K>> func)
        {
            if (result.IsFailure)
                return result;

            return func().Map(_ => result.Value);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static Result TapAndCheck<T>(this Result<T> result, Func<T, Result> func)
        {
            if (result.IsFailure)
                return result;

            return func(result.Value).Map(() => result.Value);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static Result<T> TapAndCheck<T, K>(this Result<T> result, Func<T, Result<K>> func)
        {
            if (result.IsFailure)
                return result;

            return func(result.Value).Map(_ => result.Value);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static Result<T, E> TapAndCheck<T, K, E>(this Result<T, E> result, Func<Result<K, E>> func)
        {
            if (result.IsFailure)
                return result;

            return func().Map(_ => result.Value);
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success. Returns the calling result on success.
        /// </summary>
        public static Result<T, E> TapAndCheck<T, K, E>(this Result<T, E> result, Func<T, Result<K, E>> func)
        {
            if (result.IsFailure)
                return result;

            return func(result.Value).Map(_ => result.Value);
        }
    }
}
