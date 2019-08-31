using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        public static Task<Result<K>> Map<T, K>(this Task<Result<T>> resultTask, Func<T, K> func)
            => resultTask.OnSuccess(func);

        public static Task<Result<K, E>> Map<T, K, E>(this Task<Result<T, E>> resultTask,
            Func<T, K> func)
            => resultTask.OnSuccess(func);

        public static Task<Result<T>> Map<T>(this Task<Result> resultTask, Func<T> func)
            => resultTask.OnSuccess(func);
    }
}
