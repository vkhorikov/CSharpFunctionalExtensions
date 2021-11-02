using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static Result<T> Check<T>(this Result<T> result, Func<T, Result> func)
        {
            return result.Bind(func).Map(() => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static Result<T> Check<T, K>(this Result<T> result, Func<T, Result<K>> func)
        {
            return result.Bind(func).Map(_ => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static Result<T, E> Check<T, K, E>(this Result<T, E> result, Func<T, Result<K, E>> func)
        {
            return result.Bind(func).Map(_ => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static Result<T, E> Check<T, E>(this Result<T, E> result, Func<T, UnitResult<E>> func)
        {
            return result.Bind(func).Map(() => result.Value);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static UnitResult<E> Check<E>(this UnitResult<E> result, Func<UnitResult<E>> func)
        {
            return result.Bind(func).Map(() => result);
        }
    }
}