#nullable enable

using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Returns a new failure result if the result is null. Otherwise returns the starting result.
        /// </summary>
        public static Result<T> EnsureNotNull<T>(this Result<T?> result, string error)
            where T : class
        {
            return result.Ensure(value => value != null, error).Map(value => value!);
        }

        /// <summary>
        ///     Returns a new failure result if the result is null. Otherwise returns the starting result.
        /// </summary>
        public static Result<T> EnsureNotNull<T>(this Result<T?> result, string error)
            where T : struct
        {
            return result.Ensure(value => value != null, error).Map(value => value!.Value);
        }

        /// <summary>
        ///     Returns a new failure result if the result is null. Otherwise returns the starting result.
        /// </summary>
        public static Result<T> EnsureNotNull<T>(this Result<T?> result, Func<string> errorFactory)
            where T : class
        {
            return result.Ensure(value => value != null, _ => errorFactory()).Map(value => value!);
        }

        /// <summary>
        ///     Returns a new failure result if the result is null. Otherwise returns the starting result.
        /// </summary>
        public static Result<T> EnsureNotNull<T>(this Result<T?> result, Func<string> errorFactory)
            where T : struct
        {
            return result.Ensure(value => value != null, _ => errorFactory()).Map(value => value!.Value);
        }

        /// <summary>
        ///     Returns a new failure result if the result is null. Otherwise returns the starting result.
        /// </summary>
        public static Result<T, E> EnsureNotNull<T, E>(this Result<T?, E> result, E error)
            where T : class
        {
            return result.Ensure(value => value != null, error).Map(value => value!);
        }

        /// <summary>
        ///     Returns a new failure result if the result is null. Otherwise returns the starting result.
        /// </summary>
        public static Result<T, E> EnsureNotNull<T, E>(this Result<T?, E> result, E error)
            where T : struct
        {
            return result.Ensure(value => value != null, error).Map(value => value!.Value);
        }

        /// <summary>
        ///     Returns a new failure result if the result is null. Otherwise returns the starting result.
        /// </summary>
        public static Result<T, E> EnsureNotNull<T, E>(this Result<T?, E> result, Func<E> errorFactory)
            where T : class
        {
            return result.Ensure(value => value != null, _ => errorFactory()).Map(value => value!);
        }

        /// <summary>
        ///     Returns a new failure result if the result is null. Otherwise returns the starting result.
        /// </summary>
        public static Result<T, E> EnsureNotNull<T, E>(this Result<T?, E> result, Func<E> errorFactory)
            where T : struct
        {
            return result.Ensure(value => value != null, _ => errorFactory()).Map(value => value!.Value);
        }
    }
}
