#if NETSTANDARD2_0
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        // Non-async extensions
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use MapWithTransactionScope() instead.")]
        public static Result<K> OnSuccessWithTransactionScope<T, K>(this Result<T> self, Func<T, K> f)
            => self.MapWithTransactionScope(f);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use MapWithTransactionScope() instead.")]
        public static Result<K> OnSuccessWithTransactionScope<K>(this Result self, Func<K> f)
            => self.MapWithTransactionScope(f);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use BindWithTransactionScope() instead.")]
        public static Result<K> OnSuccessWithTransactionScope<T, K>(this Result<T> self, Func<T, Result<K>> f)
            => self.BindWithTransactionScope(f);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use BindWithTransactionScope() instead.")]
        public static Result<K> OnSuccessWithTransactionScope<K>(this Result self, Func<Result<K>> f)
            => self.BindWithTransactionScope(f);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use BindWithTransactionScope() instead.")]
        public static Result OnSuccessWithTransactionScope<T>(this Result<T> self, Func<T, Result> f)
            => self.BindWithTransactionScope(f);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use BindWithTransactionScope() instead.")]
        public static Result OnSuccessWithTransactionScope(this Result self, Func<Result> f)
            => self.BindWithTransactionScope(f);


        // Async - both operands
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use MapWithTransactionScope() instead.")]
        public static Task<Result<K>> OnSuccessWithTransactionScope<T, K>(this Task<Result<T>> self, Func<T, Task<K>> f)
            => self.MapWithTransactionScope(f);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use MapWithTransactionScope() instead.")]
        public static Task<Result<K>> OnSuccessWithTransactionScope<K>(this Task<Result> self, Func<Task<K>> f)
            => self.MapWithTransactionScope(f);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use BindWithTransactionScope() instead.")]
        public static Task<Result<K>> OnSuccessWithTransactionScope<T, K>(this Task<Result<T>> self, Func<T, Task<Result<K>>> f)
            => self.BindWithTransactionScope(f);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use BindWithTransactionScope() instead.")]
        public static Task<Result<K>> OnSuccessWithTransactionScope<K>(this Task<Result> self, Func<Task<Result<K>>> f)
            => self.BindWithTransactionScope(f);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use BindWithTransactionScope() instead.")]
        public static Task<Result> OnSuccessWithTransactionScope<T>(this Task<Result<T>> self, Func<T, Task<Result>> f)
            => self.BindWithTransactionScope(f);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use BindWithTransactionScope() instead.")]
        public static Task<Result> OnSuccessWithTransactionScope(this Task<Result> self, Func<Task<Result>> f)
            => self.BindWithTransactionScope(f);


        // Async - left operands
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use MapWithTransactionScope() instead.")]
        public static Task<Result<K>> OnSuccessWithTransactionScope<T, K>(this Task<Result<T>> self, Func<T, K> f)
            => self.MapWithTransactionScope(f);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use MapWithTransactionScope() instead.")]
        public static Task<Result<K>> OnSuccessWithTransactionScope<K>(this Task<Result> self, Func<K> f)
            => self.MapWithTransactionScope(f);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use BindWithTransactionScope() instead.")]
        public static Task<Result<K>> OnSuccessWithTransactionScope<T, K>(this Task<Result<T>> self, Func<T, Result<K>> f)
            => self.BindWithTransactionScope(f);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use BindWithTransactionScope() instead.")]
        public static Task<Result<K>> OnSuccessWithTransactionScope<K>(this Task<Result> self, Func<Result<K>> f)
            => self.BindWithTransactionScope(f);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use BindWithTransactionScope() instead.")]
        public static Task<Result> OnSuccessWithTransactionScope<T>(this Task<Result<T>> self, Func<T, Result> f)
            => self.BindWithTransactionScope(f);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use BindWithTransactionScope() instead.")]
        public static Task<Result> OnSuccessWithTransactionScope(this Task<Result> self, Func<Result> f)
            => self.BindWithTransactionScope(f);


        // Async - right operands
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use MapWithTransactionScope() instead.")]
        public static Task<Result<K>> OnSuccessWithTransactionScope<T, K>(this Result<T> self, Func<T, Task<K>> f)
            => self.MapWithTransactionScope(f);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use MapWithTransactionScope() instead.")]
        public static Task<Result<K>> OnSuccessWithTransactionScope<K>(this Result self, Func<Task<K>> f)
            => self.MapWithTransactionScope(f);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use BindWithTransactionScope() instead.")]
        public static Task<Result<K>> OnSuccessWithTransactionScope<T, K>(this Result<T> self, Func<T, Task<Result<K>>> f)
            => self.BindWithTransactionScope(f);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use BindWithTransactionScope() instead.")]
        public static Task<Result<K>> OnSuccessWithTransactionScope<K>(this Result self, Func<Task<Result<K>>> f)
            => self.BindWithTransactionScope(f);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use BindWithTransactionScope() instead.")]
        public static Task<Result> OnSuccessWithTransactionScope<T>(this Result<T> self, Func<T, Task<Result>> f)
            => self.BindWithTransactionScope(f);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use BindWithTransactionScope() instead.")]
        public static Task<Result> OnSuccessWithTransactionScope(this Result self, Func<Task<Result>> f)
            => self.BindWithTransactionScope(f);
    }
}
#endif
