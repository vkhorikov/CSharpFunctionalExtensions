using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result<K, E> Bind<T, K, E>(this Result<T, E> result, Func<T, Result<K, E>> func)
        {
            if (result.IsFailure)
                return Result.Failure<K, E>(result.Error);

            return func(result.Value);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result<K> Bind<T, K>(this Result<T> result, Func<T, Result<K>> func)
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            return func(result.Value);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result<K> Bind<K>(this Result result, Func<Result<K>> func)
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            return func();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result Bind<T>(this Result<T> result, Func<T, Result> func)
        {
            if (result.IsFailure)
                return result;

            return func(result.Value);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result Bind(this Result result, Func<Result> func)
        {
            if (result.IsFailure)
                return result;

            return func();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static UnitResult<E> Bind<E>(this UnitResult<E> result, Func<UnitResult<E>> func)
        {
            if (result.IsFailure)
                return result.Error;
            
            return func();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result<T, E> Bind<T, E>(this UnitResult<E> result, Func<Result<T, E>> func)
        {
            if (result.IsFailure)
                return result.Error;
            
            return func();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static UnitResult<E> Bind<T, E>(this Result<T, E> result, Func<T, UnitResult<E>> func)
        {
            if (result.IsFailure) 
                return result.Error;

            return func(result.Value);
        }
    }
}
