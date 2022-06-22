using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Check() instead.")]
        public static Task<Result<T>> Tap<T>(this Task<Result<T>> resultTask, Func<T, Task<Result>> func) =>
            Check(resultTask, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Check() instead.")]
        public static Task<Result<T>> Tap<T, K>(this Task<Result<T>> resultTask, Func<T, Task<Result<K>>> func) =>
            Check(resultTask, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Check() instead.")]
        public static Task<Result<T, E>> Tap<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Task<Result<K, E>>> func) => 
            Check(resultTask, func);
    }
}
