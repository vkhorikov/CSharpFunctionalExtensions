using System;
using System.Threading.Tasks;


namespace CSharpFunctionalExtensions
{
    /// <summary>
    /// Extentions for async operations where the task appears in the left operand only
    /// </summary>
    public static class AsyncResultExtensionsLeftOperand
    {
        public static async Task<Result<K, TError>> OnSuccess<T, K, TError>(this Task<Result<T, TError>> resultTask,
            Func<T, K> func) where TError : class
        {
            Result<T, TError> result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        public static async Task<Result<K>> OnSuccess<T, K>(this Task<Result<T>> resultTask, Func<T, K> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Task<Result> resultTask, Func<T> func)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        public static async Task<Result<K, TError>> OnSuccess<T, K, TError>(this Task<Result<T, TError>> resultTask,
            Func<T, Result<K, TError>> func) where TError : class
        {
            Result<T, TError> result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        public static async Task<Result<K>> OnSuccess<T, K>(this Task<Result<T>> resultTask, Func<T, Result<K>> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Task<Result> resultTask, Func<Result<T>> func)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        public static async Task<Result<K>> OnSuccess<T, K>(this Task<Result<T>> resultTask, Func<Result<K>> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        public static async Task<Result<K, TError>> OnSuccess<T, K, TError>(this Task<Result<T, TError>> resultTask,
            Func<Result<K, TError>> func) where TError : class
        {
            Result<T, TError> result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        public static async Task<Result> OnSuccess<T>(this Task<Result<T>> resultTask, Func<T, Result> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        public static async Task<Result> OnSuccess(this Task<Result> resultTask, Func<Result> func)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(func);
        }

        public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, string errorMessage)
        {
            Result<T> result = await resultTask.ConfigureAwait(false);
            return result.Ensure(predicate, errorMessage);
        }

        public static async Task<Result<T, TError>> Ensure<T, TError>(this Task<Result<T, TError>> resultTask,
            Func<T, bool> predicate, TError error) where TError : class
        {
            Result<T, TError> result = await resultTask.ConfigureAwait(false);
            return result.Ensure(predicate, error);
        }

        public static async Task<Result> Ensure(this Task<Result> resultTask, Func<bool> predicate, string errorMessage)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.Ensure(predicate, errorMessage);
        }

        public static Task<Result<K>> Map<T, K>(this Task<Result<T>> resultTask, Func<T, K> func)
            => resultTask.OnSuccess(func);

        public static Task<Result<K, TError>> Map<T, K, TError>(this Task<Result<T, TError>> resultTask,
            Func<T, K> func) where TError : class
            => resultTask.OnSuccess(func);

        public static Task<Result<T>> Map<T>(this Task<Result> resultTask, Func<T> func)
            => resultTask.OnSuccess(func);

        public static async Task<Result<T>> OnSuccess<T>(this Task<Result<T>> resultTask, Action<T> action)
        {
            Result<T> result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(action);
        }

        public static async Task<Result> OnSuccess(this Task<Result> resultTask, Action action)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.OnSuccess(action);
        }

        public static async Task<T> OnBoth<T>(this Task<Result> resultTask, Func<Result, T> func)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.OnBoth(func);
        }

        public static async Task<K> OnBoth<T, K>(this Task<Result<T>> resultTask, Func<Result<T>, K> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(false);
            return result.OnBoth(func);
        }

        public static async Task<K> OnBoth<T, K, TError>(this Task<Result<T, TError>> resultTask,
            Func<Result<T, TError>, K> func)
        {
            Result<T, TError> result = await resultTask.ConfigureAwait(false);
            return result.OnBoth(func);
        }

        public static async Task<Result<T>> OnFailure<T>(this Task<Result<T>> resultTask, Action action)
        {
            Result<T> result = await resultTask.ConfigureAwait(false);
            return result.OnFailure(action);
        }

        public static async Task<Result> OnFailure(this Task<Result> resultTask, Action action)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.OnFailure(action);
        }

        public static async Task<Result<T>> OnFailure<T>(this Task<Result<T>> resultTask, Action<string> action)
        {
            Result<T> result = await resultTask.ConfigureAwait(false);
            return result.OnFailure(action);
        }

        public static async Task<Result<T, TError>> OnFailure<T, TError>(this Task<Result<T, TError>> resultTask,
            Action<TError> action) where TError : class
        {
            Result<T, TError> result = await resultTask.ConfigureAwait(false);
            return result.OnFailure(action);
        }

        public static async Task<Result> OnFailure(this Task<Result> resultTask, Action<string> action)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.OnFailure(action);
        }

        public static async Task<Result<T>> OnFailureCompensate<T>(this Task<Result<T>> resultTask, Func<Result<T>> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(false);
            return result.OnFailureCompensate(func);
        }

        public static async Task<Result> OnFailureCompensate(this Task<Result> resultTask, Func<Result> func)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.OnFailureCompensate(func);
        }

        public static async Task<Result<T>> OnFailureCompensate<T>(this Task<Result<T>> resultTask, Func<string, Result<T>> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(false);
            return result.OnFailureCompensate(func);
        }

        public static async Task<Result<T, TError>> OnFailureCompensate<T, TError>(this Task<Result<T, TError>> resultTask,
            Func<TError, Result<T, TError>> func) where TError : class
        {
            Result<T, TError> result = await resultTask.ConfigureAwait(false);
            return result.OnFailureCompensate(func);
        }

        public static async Task<Result> OnFailureCompensate(this Task<Result> resultTask, Func<string, Result> func)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.OnFailureCompensate(func);
        }
    }
}
