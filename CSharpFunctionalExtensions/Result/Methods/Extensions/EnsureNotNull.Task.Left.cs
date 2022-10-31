#nullable enable

using System;
using System.Threading.Tasks;

#if NET40
using Task = System.Threading.Tasks.TaskEx;
#else
using Task = System.Threading.Tasks.Task;
#endif

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Task<Result<T>> EnsureNotNull<T>(this Task<Result<T?>> resultTask, Func<string> errorFactory)
            where T : class
        {
            return resultTask.Ensure(value => value != null, _ => errorFactory()).Map(value => value!);
        }

        public static Task<Result<T>> EnsureNotNull<T>(this Task<Result<T?>> resultTask, Func<string> errorFactory)
            where T : struct
        {
            return resultTask.Ensure(value => value != null, _ => errorFactory()).Map(value => value!.Value);
        }

        public static Task<Result<T, E>> EnsureNotNull<T, E>(this Task<Result<T?, E>> resultTask, Func<E> errorFactory)
            where T : class
        {
            return resultTask.Ensure(value => Task.FromResult(value != null), _ => errorFactory()).Map(value => value!);
        }

        public static Task<Result<T, E>> EnsureNotNull<T, E>(this Task<Result<T?, E>> resultTask, Func<E> errorFactory)
            where T : struct
        {
            return resultTask.Ensure(value => Task.FromResult(value != null), _ => errorFactory()).Map(value => value!.Value);
        }
    }
}
