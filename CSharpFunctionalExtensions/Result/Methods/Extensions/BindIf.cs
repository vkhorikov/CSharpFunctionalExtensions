using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Selects result from the return value of a given function if the condition is true. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result BindIf(this Result result, bool condition, Func<Result> func)
        {
            if (!condition)
            {
                return result;
            }

            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function if the condition is true. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result<T> BindIf<T>(this Result<T> result, bool condition, Func<T, Result<T>> func)
        {
            if (!condition)
            {
                return result;
            }

            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function if the condition is true. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static UnitResult<E> BindIf<E>(this UnitResult<E> result, bool condition, Func<UnitResult<E>> func)
        {
            if (!condition)
            {
                return result;
            }

            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function if the condition is true. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result<T, E> BindIf<T, E>(this Result<T, E> result, bool condition, Func<T, Result<T, E>> func)
        {
            if (!condition)
            {
                return result;
            }

            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function if the predicate is true. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result BindIf(this Result result, Func<bool> predicate, Func<Result> func)
        {
            if (!result.IsSuccess || !predicate())
            {
                return result;
            }

            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function if the predicate is true. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result<T> BindIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Result<T>> func)
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result;
            }

            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function if the predicate is true. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static UnitResult<E> BindIf<E>(this UnitResult<E> result, Func<bool> predicate, Func<UnitResult<E>> func)
        {
            if (!result.IsSuccess || !predicate())
            {
                return result;
            }

            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function if the predicate is true. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result<T, E> BindIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, Result<T, E>> func)
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result;
            }

            return result.Bind(func);
        }
    }
}