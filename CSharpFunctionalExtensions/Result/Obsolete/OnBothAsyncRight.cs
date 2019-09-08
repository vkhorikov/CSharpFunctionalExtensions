using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        [Obsolete("Use Finally() instead.")]
        public static Task<T> OnBoth<T>(this Result result, Func<Result, Task<T>> func)
            => Finally(result, func);

        [Obsolete("Use Finally() instead.")]
        public static Task<K> OnBoth<T, K>(this Result<T> result, Func<Result<T>, Task<K>> func)
            => Finally(result, func);

        [Obsolete("Use Finally() instead.")]
        public static Task<K> OnBoth<T, K, E>(this Result<T, E> result, Func<Result<T>, Task<K>> func)
            => Finally(result, func);
    }
}
