#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K, E>> Map<T, K, E>(
            this Result<T, E> result,
            Func<T, ValueTask<K>> valueTask
        )
        {
            if (result.IsFailure)
                return Result.Failure<K, E>(result.Error);

            K value = await valueTask(result.Value);

            return Result.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K, E>> Map<T, K, E, TContext>(
            this Result<T, E> result,
            Func<T, TContext, ValueTask<K>> valueTask,
            TContext context
        )
        {
            if (result.IsFailure)
                return Result.Failure<K, E>(result.Error);

            K value = await valueTask(result.Value, context);

            return Result.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K, E>> Map<K, E>(
            this UnitResult<E> result,
            Func<ValueTask<K>> valueTask
        )
        {
            if (result.IsFailure)
                return Result.Failure<K, E>(result.Error);

            K value = await valueTask();

            return Result.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K, E>> Map<K, E, TContext>(
            this UnitResult<E> result,
            Func<TContext, ValueTask<K>> valueTask,
            TContext context
        )
        {
            if (result.IsFailure)
                return Result.Failure<K, E>(result.Error);

            K value = await valueTask(context);

            return Result.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K>> Map<T, K>(
            this Result<T> result,
            Func<T, ValueTask<K>> valueTask
        )
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            K value = await valueTask(result.Value);

            return Result.Success(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K>> Map<T, K, TContext>(
            this Result<T> result,
            Func<T, TContext, ValueTask<K>> valueTask,
            TContext context
        )
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            K value = await valueTask(result.Value, context);

            return Result.Success(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K>> Map<T, K>(
            this Result<T> result,
            Func<T, ValueTask<Result<K>>> valueTask
        )
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            Result<K> value = await valueTask(result.Value);
            return value;
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K>> Map<T, K, TContext>(
            this Result<T> result,
            Func<T, TContext, ValueTask<Result<K>>> valueTask,
            TContext context
        )
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            Result<K> value = await valueTask(result.Value, context);
            return value;
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K>> Map<K>(
            this Result result,
            Func<ValueTask<K>> valueTask
        )
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            K value = await valueTask();

            return Result.Success(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K>> Map<K, TContext>(
            this Result result,
            Func<TContext, ValueTask<K>> valueTask,
            TContext context
        )
        {
            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            K value = await valueTask(context);

            return Result.Success(value);
        }
    }
}
#endif
