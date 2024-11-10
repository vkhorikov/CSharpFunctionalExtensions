using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static async Task<Result<T>> MapIf<T>(
            this Task<Result<T>> resultTask,
            bool condition,
            Func<T, T> func
        )
        {
            var result = await resultTask.DefaultAwait();
            return result.MapIf(condition, func);
        }

        public static async Task<Result<T>> MapIf<T, TContext>(
            this Task<Result<T>> resultTask,
            bool condition,
            Func<T, TContext, T> func,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            return result.MapIf(condition, func, context);
        }

        public static async Task<Result<T, E>> MapIf<T, E>(
            this Task<Result<T, E>> resultTask,
            bool condition,
            Func<T, T> func
        )
        {
            var result = await resultTask.DefaultAwait();
            return result.MapIf(condition, func);
        }

        public static async Task<Result<T, E>> MapIf<T, E, TContext>(
            this Task<Result<T, E>> resultTask,
            bool condition,
            Func<T, TContext, T> func,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            return result.MapIf(condition, func, context);
        }

        public static async Task<Result<T>> MapIf<T>(
            this Task<Result<T>> resultTask,
            Func<T, bool> predicate,
            Func<T, T> func
        )
        {
            var result = await resultTask.DefaultAwait();
            return result.MapIf(predicate, func);
        }

        public static async Task<Result<T>> MapIf<T, TContext>(
            this Task<Result<T>> resultTask,
            Func<T, TContext, bool> predicate,
            Func<T, TContext, T> func,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            return result.MapIf(predicate, func, context);
        }

        public static async Task<Result<T, E>> MapIf<T, E>(
            this Task<Result<T, E>> resultTask,
            Func<T, bool> predicate,
            Func<T, T> func
        )
        {
            var result = await resultTask.DefaultAwait();
            return result.MapIf(predicate, func);
        }

        public static async Task<Result<T, E>> MapIf<T, E, TContext>(
            this Task<Result<T, E>> resultTask,
            Func<T, TContext, bool> predicate,
            Func<T, TContext, T> func,
            TContext context
        )
        {
            var result = await resultTask.DefaultAwait();
            return result.MapIf(predicate, func, context);
        }
    }
}
