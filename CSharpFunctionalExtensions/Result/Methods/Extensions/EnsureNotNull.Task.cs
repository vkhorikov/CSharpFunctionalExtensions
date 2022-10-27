#nullable enable

using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Task<Result<T>> EnsureNotNull<T>(this Task<Result<T?>> resultTask, string error)
            where T : class
        {
            return resultTask.Ensure(value => value != null, error).Map(value => value!);
        }

        public static Task<Result<T>> EnsureNotNull<T>(this Task<Result<T?>> resultTask, string error)
            where T : struct
        {
            return resultTask.Ensure(value => value != null, error).Map(value => value!.Value);
        }

        public static Task<Result<T>> EnsureNotNull<T>(this Task<Result<T?>> resultTask, Func<Task<string>> errorFactory)
            where T : class
        {
            return resultTask.Ensure(value => value != null, _ => errorFactory()).Map(value => value!);
        }

        public static Task<Result<T>> EnsureNotNull<T>(this Task<Result<T?>> resultTask, Func<Task<string>> errorFactory)
            where T : struct
        {
            return resultTask.Ensure(value => value != null, _ => errorFactory()).Map(value => value!.Value);
        }

        public static Task<Result<T, E>> EnsureNotNull<T, E>(this Task<Result<T?, E>> resultTask, E error)
            where T : class
        {
            return resultTask.Ensure(value => value != null, error).Map(value => value!);
        }

        public static Task<Result<T, E>> EnsureNotNull<T, E>(this Task<Result<T?, E>> resultTask, E error)
            where T : struct
        {
            return resultTask.Ensure(value => value != null, error).Map(value => value!.Value);
        }

        public static Task<Result<T, E>> EnsureNotNull<T, E>(this Task<Result<T?, E>> resultTask, Func<Task<E>> errorFactory)
            where T : class
        {
            return resultTask.Ensure(value => Task.FromResult(value != null), _ => errorFactory()).Map(value => value!);
        }

        public static Task<Result<T, E>> EnsureNotNull<T, E>(this Task<Result<T?, E>> resultTask, Func<Task<E>> errorFactory)
            where T : struct
        {
            return resultTask.Ensure(value => Task.FromResult(value != null), _ => errorFactory()).Map(value => value!.Value);
        }
    }
}
