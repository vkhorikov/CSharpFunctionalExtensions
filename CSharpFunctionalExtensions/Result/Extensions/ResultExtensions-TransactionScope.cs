#if NETSTANDARD2_0
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Transactions;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        // Non-async extensions
        [DebuggerStepThrough]
        public static Result<K> OnSuccessWithTransactionScope<T, K>(this Result<T> self, Func<T, K> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Result<T> OnSuccessWithTransactionScope<T>(this Result self, Func<T> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Result<K> OnSuccessWithTransactionScope<T, K>(this Result<T> self, Func<T, Result<K>> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Result<T> OnSuccessWithTransactionScope<T>(this Result self, Func<Result<T>> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Result<K> OnSuccessWithTransactionScope<T, K>(this Result<T> self, Func<Result<K>> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Result OnSuccessWithTransactionScope<T>(this Result<T> self, Func<T, Result> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Result OnSuccessWithTransactionScope(this Result self, Func<Result> f) =>
            WithTransactionScope(() => self.OnSuccess(f));


        // Async - Both Operands
        [DebuggerStepThrough]
        public static Task<Result<K>> OnSuccessWithTransactionScope<T, K>(this Task<Result<T>> self, Func<T, Task<K>> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Task<Result<T>> OnSuccessWithTransactionScope<T>(this Task<Result> self, Func<Task<T>> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Task<Result<K>> OnSuccessWithTransactionScope<T, K>(this Task<Result<T>> self, Func<T, Task<Result<K>>> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Task<Result<T>> OnSuccessWithTransactionScope<T>(this Task<Result> self, Func<Task<Result<T>>> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Task<Result<K>> OnSuccessWithTransactionScope<T, K>(this Task<Result<T>> self, Func<Task<Result<K>>> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Task<Result> OnSuccessWithTransactionScope<T>(this Task<Result<T>> self, Func<T, Task<Result>> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Task<Result> OnSuccessWithTransactionScope(this Task<Result> self, Func<Task<Result>> f) =>
            WithTransactionScope(() => self.OnSuccess(f));


        // Async - Left Operands
        [DebuggerStepThrough]
        public static Task<Result<K>> OnSuccessWithTransactionScope<T, K>(this Task<Result<T>> self, Func<T, K> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Task<Result<T>> OnSuccessWithTransactionScope<T>(this Task<Result> self, Func<T> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Task<Result<K>> OnSuccessWithTransactionScope<T, K>(this Task<Result<T>> self, Func<T, Result<K>> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Task<Result<T>> OnSuccessWithTransactionScope<T>(this Task<Result> self, Func<Result<T>> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Task<Result<K>> OnSuccessWithTransactionScope<T, K>(this Task<Result<T>> self, Func<Result<K>> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Task<Result> OnSuccessWithTransactionScope<T>(this Task<Result<T>> self, Func<T, Result> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Task<Result> OnSuccessWithTransactionScope(this Task<Result> self, Func<Result> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Task<Result<K>> MapWithTransactionScope<T, K>(this Task<Result<T>> self, Func<T, K> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Task<Result<T>> MapWithTransactionScope<T>(this Task<Result> self, Func<T> f) =>
            WithTransactionScope(() => self.OnSuccess(f));


        // Async - Right Operands
        [DebuggerStepThrough]
        public static Task<Result<K>> OnSuccessWithTransactionScope<T, K>(this Result<T> self, Func<T, Task<K>> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Task<Result<T>> OnSuccessWithTransactionScope<T>(this Result self, Func<Task<T>> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Task<Result<K>> OnSuccessWithTransactionScope<T, K>(this Result<T> self, Func<T, Task<Result<K>>> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Task<Result<T>> OnSuccessWithTransactionScope<T>(this Result self, Func<Task<Result<T>>> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Task<Result<K>> OnSuccessWithTransactionScope<T, K>(this Result<T> self, Func<Task<Result<K>>> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Task<Result> OnSuccessWithTransactionScope<T>(this Result<T> self, Func<T, Task<Result>> f) =>
            WithTransactionScope(() => self.OnSuccess(f));

        [DebuggerStepThrough]
        public static Task<Result> OnSuccessWithTransactionScope(this Result self, Func<Task<Result>> f) =>
            WithTransactionScope(() => self.OnSuccess(f));


        private static T WithTransactionScope<T>(Func<T> f)
            where T : IResult
        {
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = f();
                if (result.IsSuccess)
                {
                    trans.Complete();
                }
                return result;
            }
        }

        private async static Task<T> WithTransactionScope<T>(Func<Task<T>> f)
            where T : IResult
        {
            using (var trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = await f().ConfigureAwait(Result.DefaultConfigureAwait);
                if (result.IsSuccess)
                {
                    trans.Complete();
                }
                return result;
            }
        }
    }
}
#endif
