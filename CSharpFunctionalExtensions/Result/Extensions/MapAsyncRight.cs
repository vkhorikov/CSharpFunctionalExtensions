using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        public static Task<Result<K>> Map<T, K>(this Result<T> result, Func<T, Task<K>> func)
            => result.OnSuccess(func);

        public static Task<Result<K, E>> Map<T, K, E>(this Result<T, E> result,
            Func<T, Task<K>> func)
            => result.OnSuccess(func);

        public static Task<Result<T>> Map<T>(this Result result, Func<Task<T>> func)
            => result.OnSuccess(func);
    }
}
