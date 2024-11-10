using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Task<Result<T>> MapIf<T>(
            this Result<T> result,
            bool condition,
            Func<T, Task<T>> func
        )
        {
            if (!condition)
            {
                return result.AsCompletedTask();
            }

            return result.Map(func);
        }

        public static Task<Result<T>> MapIf<T, TContext>(
            this Result<T> result,
            bool condition,
            Func<T, TContext, Task<T>> func,
            TContext context
        )
        {
            if (!condition)
            {
                return result.AsCompletedTask();
            }

            return result.Map(func, context);
        }

        public static Task<Result<T, E>> MapIf<T, E>(
            this Result<T, E> result,
            bool condition,
            Func<T, Task<T>> func
        )
        {
            if (!condition)
            {
                return result.AsCompletedTask();
            }

            return result.Map(func);
        }

        public static Task<Result<T, E>> MapIf<T, E, TContext>(
            this Result<T, E> result,
            bool condition,
            Func<T, TContext, Task<T>> func,
            TContext context
        )
        {
            if (!condition)
            {
                return result.AsCompletedTask();
            }

            return result.Map(func, context);
        }

        public static Task<Result<T>> MapIf<T>(
            this Result<T> result,
            Func<T, bool> predicate,
            Func<T, Task<T>> func
        )
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result.AsCompletedTask();
            }

            return result.Map(func);
        }

        public static Task<Result<T>> MapIf<T, TContext>(
            this Result<T> result,
            Func<T, TContext, bool> predicate,
            Func<T, TContext, Task<T>> func,
            TContext context
        )
        {
            if (!result.IsSuccess || !predicate(result.Value, context))
            {
                return result.AsCompletedTask();
            }

            return result.Map(func, context);
        }

        public static Task<Result<T, E>> MapIf<T, E>(
            this Result<T, E> result,
            Func<T, bool> predicate,
            Func<T, Task<T>> func
        )
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result.AsCompletedTask();
            }

            return result.Map(func);
        }

        public static Task<Result<T, E>> MapIf<T, E, TContext>(
            this Result<T, E> result,
            Func<T, TContext, bool> predicate,
            Func<T, TContext, Task<T>> func,
            TContext context
        )
        {
            if (!result.IsSuccess || !predicate(result.Value, context))
            {
                return result.AsCompletedTask();
            }

            return result.Map(func, context);
        }
    }
}
