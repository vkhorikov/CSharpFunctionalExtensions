#if NETSTANDARD2_0
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Task<Result<K, E>> BindWithTransactionScope<T, K, E>(this Task<Result<T, E>> self, Func<T, Task<Result<K, E>>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static Task<Result<K>> BindWithTransactionScope<T, K>(this Task<Result<T>> self, Func<T, Task<Result<K>>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static Task<Result<K>> BindWithTransactionScope<K>(this Task<Result> self, Func<Task<Result<K>>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static Task<Result> BindWithTransactionScope<T>(this Task<Result<T>> self, Func<T, Task<Result>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static Task<Result> BindWithTransactionScope(this Task<Result> self, Func<Task<Result>> f)
            => WithTransactionScope(() => self.Bind(f));
    }
}
#endif
