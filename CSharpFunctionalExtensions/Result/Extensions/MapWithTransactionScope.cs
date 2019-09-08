#if NETSTANDARD2_0
using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Result<K> MapWithTransactionScope<T, K>(this Result<T> self, Func<T, K> f)
            => WithTransactionScope(() => self.Map(f));

        public static Result<K> MapWithTransactionScope<K>(this Result self, Func<K> f)
            => WithTransactionScope(() => self.Map(f));
    }
}
#endif
