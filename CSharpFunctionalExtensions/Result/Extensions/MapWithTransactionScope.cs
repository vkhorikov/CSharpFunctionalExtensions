#if NETSTANDARD2_0
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        // Non-async extensions
        [DebuggerStepThrough]
        public static Result<K> MapWithTransactionScope<T, K>(this Result<T> self, Func<T, K> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Result<T> MapWithTransactionScope<T>(this Result self, Func<T> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Result<K> MapWithTransactionScope<T, K>(this Result<T> self, Func<T, Result<K>> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Result<T> MapWithTransactionScope<T>(this Result self, Func<Result<T>> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Result<K> MapWithTransactionScope<T, K>(this Result<T> self, Func<Result<K>> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Result MapWithTransactionScope<T>(this Result<T> self, Func<T, Result> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Result MapWithTransactionScope(this Result self, Func<Result> f)
            => WithTransactionScope(() => self.Map(f));


        // Async - both operands
        [DebuggerStepThrough]
        public static Task<Result<K>> MapWithTransactionScope<T, K>(this Task<Result<T>> self, Func<T, Task<K>> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Task<Result<T>> MapWithTransactionScope<T>(this Task<Result> self, Func<Task<T>> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Task<Result<K>> MapWithTransactionScope<T, K>(this Task<Result<T>> self, Func<T, Task<Result<K>>> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Task<Result<T>> MapWithTransactionScope<T>(this Task<Result> self, Func<Task<Result<T>>> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Task<Result<K>> MapWithTransactionScope<T, K>(this Task<Result<T>> self, Func<Task<Result<K>>> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Task<Result> MapWithTransactionScope<T>(this Task<Result<T>> self, Func<T, Task<Result>> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Task<Result> MapWithTransactionScope(this Task<Result> self, Func<Task<Result>> f)
            => WithTransactionScope(() => self.Map(f));


        // Async - left operands
        [DebuggerStepThrough]
        public static Task<Result<K>> MapWithTransactionScope<T, K>(this Task<Result<T>> self, Func<T, K> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Task<Result<T>> MapWithTransactionScope<T>(this Task<Result> self, Func<T> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Task<Result<K>> MapWithTransactionScope<T, K>(this Task<Result<T>> self, Func<T, Result<K>> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Task<Result<T>> MapWithTransactionScope<T>(this Task<Result> self, Func<Result<T>> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Task<Result<K>> MapWithTransactionScope<T, K>(this Task<Result<T>> self, Func<Result<K>> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Task<Result> MapWithTransactionScope<T>(this Task<Result<T>> self, Func<T, Result> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Task<Result> MapWithTransactionScope(this Task<Result> self, Func<Result> f)
            => WithTransactionScope(() => self.Map(f));


        // Async - right operands
        [DebuggerStepThrough]
        public static Task<Result<K>> MapWithTransactionScope<T, K>(this Result<T> self, Func<T, Task<K>> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Task<Result<T>> MapWithTransactionScope<T>(this Result self, Func<Task<T>> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Task<Result<K>> MapWithTransactionScope<T, K>(this Result<T> self, Func<T, Task<Result<K>>> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Task<Result<T>> MapWithTransactionScope<T>(this Result self, Func<Task<Result<T>>> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Task<Result<K>> MapWithTransactionScope<T, K>(this Result<T> self, Func<Task<Result<K>>> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Task<Result> MapWithTransactionScope<T>(this Result<T> self, Func<T, Task<Result>> f)
            => WithTransactionScope(() => self.Map(f));

        [DebuggerStepThrough]
        public static Task<Result> MapWithTransactionScope(this Result self, Func<Task<Result>> f)
            => WithTransactionScope(() => self.Map(f));
    }
}
#endif
