#if NETSTANDARD2_0
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Task<Result<K>> MapWithTransactionScope<T, K>(this Task<Result<T>> self, Func<T, K> f)
            => WithTransactionScope(() => self.Map(f));

        public static Task<Result<K>> MapWithTransactionScope<K>(this Task<Result> self, Func<K> f)
            => WithTransactionScope(() => self.Map(f));
    }
}
#endif
