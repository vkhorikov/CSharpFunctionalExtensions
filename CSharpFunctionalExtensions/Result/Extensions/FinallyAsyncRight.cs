using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        public static async Task<T> Finally<T>(this Result result, Func<Result, Task<T>> func)
        {
            return await func(result).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<K> Finally<T, K>(this Result<T> result, Func<Result<T>, Task<K>> func)
        {
            return await func(result).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<K> Finally<T, K, E>(this Result<T, E> result, Func<Result<T>, Task<K>> func)
        {
            return await func(result).ConfigureAwait(Result.DefaultConfigureAwait);
        }
    }
}
