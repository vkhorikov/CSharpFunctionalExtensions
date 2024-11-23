#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K, E>> Map<T, K, E>(
            this ValueTask<Result<T, E>> resultTask,
            Func<T, ValueTask<K>> valueTask
        )
        {
            Result<T, E> result = await resultTask;

            if (result.IsFailure)
                return Result.Failure<K, E>(result.Error);

            K value = await valueTask(result.Value);

            return Result.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K, E>> Map<T, K, E, TContext>(
            this ValueTask<Result<T, E>> resultTask,
            Func<T, TContext, ValueTask<K>> valueTask,
            TContext context
        )
        {
            Result<T, E> result = await resultTask;

            if (result.IsFailure)
                return Result.Failure<K, E>(result.Error);

            K value = await valueTask(result.Value, context);

            return Result.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K, E>> Map<K, E>(
            this ValueTask<UnitResult<E>> resultTask,
            Func<ValueTask<K>> valueTask
        )
        {
            UnitResult<E> result = await resultTask;

            if (result.IsFailure)
                return Result.Failure<K, E>(result.Error);

            K value = await valueTask();

            return Result.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K, E>> Map<K, E, TContext>(
            this ValueTask<UnitResult<E>> resultTask,
            Func<TContext, ValueTask<K>> valueTask,
            TContext context
        )
        {
            UnitResult<E> result = await resultTask;

            if (result.IsFailure)
                return Result.Failure<K, E>(result.Error);

            K value = await valueTask(context);

            return Result.Success<K, E>(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K>> Map<T, K>(
            this ValueTask<Result<T>> resultTask,
            Func<T, ValueTask<K>> valueTask
        )
        {
            Result<T> result = await resultTask;

            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            K value = await valueTask(result.Value);

            return Result.Success(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K>> Map<T, K, TContext>(
            this ValueTask<Result<T>> resultTask,
            Func<T, TContext, ValueTask<K>> valueTask,
            TContext context
        )
        {
            Result<T> result = await resultTask;

            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            K value = await valueTask(result.Value, context);

            return Result.Success(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K>> Map<K>(
            this ValueTask<Result> resultTask,
            Func<ValueTask<K>> valueTask
        )
        {
            Result result = await resultTask;

            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            K value = await valueTask();

            return Result.Success(value);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Result<K>> Map<K, TContext>(
            this ValueTask<Result> resultTask,
            Func<TContext, ValueTask<K>> valueTask,
            TContext context
        )
        {
            Result result = await resultTask;

            if (result.IsFailure)
                return Result.Failure<K>(result.Error);

            K value = await valueTask(context);

            return Result.Success(value);
        }
    }
}
#endif
