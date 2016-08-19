using System;
using System.Threading.Tasks;


namespace CSharpFunctionalExtensions
{
    /// <summary>
    /// Extentions for async operations where the task appears in the left operand only
    /// </summary>
    public static class AsyncResultExtensionsLeftOperand
    {
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

        public static async Task<Result> Ensure(this Task<Result> resultTask, Func<bool> predicate, string errorMessage)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.Ensure(predicate, errorMessage);
        }

        public static async Task<Result<K>> Map<T, K>(this Task<Result<T>> resultTask, Func<T, K> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(false);
            return result.Map(func);
        }

        public static async Task<Result<T>> Map<T>(this Task<Result> resultTask, Func<T> func)
        {
            Result result = await resultTask.ConfigureAwait(false);
            return result.Map(func);
        }

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
    }
}
