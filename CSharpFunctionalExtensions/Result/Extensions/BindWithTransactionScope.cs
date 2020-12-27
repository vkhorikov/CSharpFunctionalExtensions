#if NETSTANDARD2_0 || NET50
using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Result<K> BindWithTransactionScope<T, K>(this Result<T> self, Func<T, Result<K>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static Result<K> BindWithTransactionScope<K>(this Result self, Func<Result<K>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static Result BindWithTransactionScope<T>(this Result<T> self, Func<T, Result> f)
            => WithTransactionScope(() => self.Bind(f));

        public static Result BindWithTransactionScope(this Result self, Func<Result> f)
            => WithTransactionScope(() => self.Bind(f));

        public static Result<K, E> BindWithTransactionScope<T, K, E>(this Result<T, E> self, Func<T, Result<K, E>> f)
            => WithTransactionScope(() => self.Bind(f));
    }
}
#endif
