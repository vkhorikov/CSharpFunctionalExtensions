using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        public static Task<Result<K, E>> Map<T, K, E>(this Task<Result<T, E>> resultTask,
            Func<T, Task<K>> func)
            => resultTask.OnSuccess(func);

        public static Task<Result<K>> Map<T, K>(this Task<Result<T>> resultTask, Func<T, Task<K>> func)
            => resultTask.OnSuccess(func);

        public static Task<Result<T>> Map<T>(this Task<Result> resultTask, Func<Task<T>> func)
            => resultTask.OnSuccess(func);
    }
}
