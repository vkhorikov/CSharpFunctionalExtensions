#if NETSTANDARD2_0 || NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Task<Result<K>> MapWithTransactionScope<T, K>(this Result<T> self, Func<T, Task<K>> f)
            => WithTransactionScope(() => self.Map(f));

        public static Task<Result<K>> MapWithTransactionScope<K>(this Result self, Func<Task<K>> f)
            => WithTransactionScope(() => self.Map(f));
    }
}
#endif
