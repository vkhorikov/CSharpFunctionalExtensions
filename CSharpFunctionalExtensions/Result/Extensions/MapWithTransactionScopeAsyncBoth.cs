#if NETSTANDARD2_0
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        // Overloads that construct new results by wrapping a return value from a function
        // 

        public static Task<Result<K>> MapWithTransactionScope<T, K>(this Task<Result<T>> self, Func<T, Task<K>> f)
            => WithTransactionScope(() => self.Map(f));

        public static Task<Result<K>> MapWithTransactionScope<K>(this Task<Result> self, Func<Task<K>> f)
            => WithTransactionScope(() => self.Map(f));

        // Overloads that pass on a new Result returned by a function
        // 

        public static Task<Result<K>> MapWithTransactionScope<T, K>(this Task<Result<T>> self, Func<T, Task<Result<K>>> f)
            => WithTransactionScope(() => self.Map(f));

        public static Task<Result<K>> MapWithTransactionScope<K>(this Task<Result> self, Func<Task<Result<K>>> f)
            => WithTransactionScope(() => self.Map(f));

        public static Task<Result> MapWithTransactionScope<T>(this Task<Result<T>> self, Func<T, Task<Result>> f)
            => WithTransactionScope(() => self.Map(f));

        public static Task<Result> MapWithTransactionScope(this Task<Result> self, Func<Task<Result>> f)
            => WithTransactionScope(() => self.Map(f));
    }
}
#endif
