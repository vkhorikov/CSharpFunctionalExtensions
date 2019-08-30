#if NETSTANDARD2_0
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        // Async - Left Operands
        [DebuggerStepThrough]
        public static Task<Result<K>> MapWithTransactionScope<T, K>(this Task<Result<T>> self, Func<T, K> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Task<Result<T>> MapWithTransactionScope<T>(this Task<Result> self, Func<T> f) =>
            WithTransactionScope(() => self.OnSuccess(f));
    }
}
#endif
