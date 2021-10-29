using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result<K, E>> Bind<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Result<K, E>> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result<K>> Bind<T, K>(this Task<Result<T>> resultTask, Func<T, Result<K>> func)
        {
            Result<T> result = await resultTask.DefaultAwait();
            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result<K>> Bind<K>(this Task<Result> resultTask, Func<Result<K>> func)
        {
            Result result = await resultTask.DefaultAwait();
            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result> Bind<T>(this Task<Result<T>> resultTask, Func<T, Result> func)
        {
            Result<T> result = await resultTask.DefaultAwait();
            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result> Bind(this Task<Result> resultTask, Func<Result> func)
        {
            Result result = await resultTask.DefaultAwait();
            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<UnitResult<E>> Bind<E>(this Task<UnitResult<E>> resultTask, Func<UnitResult<E>> func)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();
            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<Result<T, E>> Bind<T, E>(this Task<UnitResult<E>> resultTask, Func<Result<T, E>> func)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();
            return result.Bind(func);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async Task<UnitResult<E>> Bind<T, E>(this Task<Result<T, E>> resultTask, Func<T, UnitResult<E>> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            return result.Bind(func);
        }
    }
}