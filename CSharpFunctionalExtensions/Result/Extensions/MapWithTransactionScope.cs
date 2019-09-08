#if NETSTANDARD2_0
using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        // Overloads that construct new results by wrapping a return value from a function
        // 

        public static Result<K> MapWithTransactionScope<T, K>(this Result<T> self, Func<T, K> f)
            => WithTransactionScope(() => self.Map(f));

        public static Result<K> MapWithTransactionScope<K>(this Result self, Func<K> f)
            => WithTransactionScope(() => self.Map(f));

        // Overloads that pass on a new Result returned by a function
        // 

        public static Result<K> MapWithTransactionScope<T, K>(this Result<T> self, Func<T, Result<K>> f)
            => WithTransactionScope(() => self.Map(f));

        public static Result<K> MapWithTransactionScope<K>(this Result self, Func<Result<K>> f)
            => WithTransactionScope(() => self.Map(f));

        public static Result MapWithTransactionScope<T>(this Result<T> self, Func<T, Result> f)
            => WithTransactionScope(() => self.Map(f));

        public static Result MapWithTransactionScope(this Result self, Func<Result> f)
            => WithTransactionScope(() => self.Map(f));
    }
}
#endif
