using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result<K, E>> Map<T, K, E>(
            this Task<Result<T, E>> resultTask,
            Func<T, K> func
        )
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            return result.Map(func);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result<K, E>> Map<T, K, E, TContext>(
            this Task<Result<T, E>> resultTask,
            Func<T, TContext, K> func,
            TContext context
        )
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            return result.Map(func, context);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result<K, E>> Map<K, E>(
            this Task<UnitResult<E>> resultTask,
            Func<K> func
        )
        {
            UnitResult<E> result = await resultTask.DefaultAwait();
            return result.Map(func);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result<K, E>> Map<K, E, TContext>(
            this Task<UnitResult<E>> resultTask,
            Func<TContext, K> func,
            TContext context
        )
        {
            UnitResult<E> result = await resultTask.DefaultAwait();
            return result.Map(func, context);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result<K>> Map<T, K>(
            this Task<Result<T>> resultTask,
            Func<T, K> func
        )
        {
            Result<T> result = await resultTask.DefaultAwait();
            return result.Map(func);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result<K>> Map<T, K, TContext>(
            this Task<Result<T>> resultTask,
            Func<T, TContext, K> func,
            TContext context
        )
        {
            Result<T> result = await resultTask.DefaultAwait();
            return result.Map(func, context);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result<K>> Map<K>(this Task<Result> resultTask, Func<K> func)
        {
            Result result = await resultTask.DefaultAwait();
            return result.Map(func);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result<K>> Map<K, TContext>(
            this Task<Result> resultTask,
            Func<TContext, K> func,
            TContext context
        )
        {
            Result result = await resultTask.DefaultAwait();
            return result.Map(func, context);
        }
    }
}
