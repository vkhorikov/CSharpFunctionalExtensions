using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static async Task<Result> BindIf(this Task<Result> resultTask, bool condition, Func<Result> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindIf(condition, func);
        }

        public static async Task<Result<T>> BindIf<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Result<T>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindIf(condition, func);
        }

        public static async Task<UnitResult<E>> BindIf<E>(this Task<UnitResult<E>> resultTask, bool condition, Func<UnitResult<E>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindIf(condition, func);
        }

        public static async Task<Result<T, E>> BindIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Func<T, Result<T, E>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindIf(condition, func);
        }

        public static async Task<Result> BindIf(this Task<Result> resultTask, Func<bool> predicate, Func<Result> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindIf(predicate, func);
        }

        public static async Task<Result<T>> BindIf<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result<T>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindIf(predicate, func);
        }

        public static async Task<UnitResult<E>> BindIf<E>(this Task<UnitResult<E>> resultTask, Func<bool> predicate, Func<UnitResult<E>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindIf(predicate, func);
        }

        public static async Task<Result<T, E>> BindIf<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, Result<T, E>> func)
        {
            var result = await resultTask.DefaultAwait();
            return result.BindIf(predicate, func);
        }
    }
}