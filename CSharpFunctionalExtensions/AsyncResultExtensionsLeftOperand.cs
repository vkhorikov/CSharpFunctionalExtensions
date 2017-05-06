using System;
using System.Threading.Tasks;


namespace CSharpFunctionalExtensions
{
    /// <summary>
    /// Extentions for async operations where the task appears in the left operand only
    /// </summary>
    public static class AsyncResultExtensionsLeftOperand
    {
        public static async Task<Result<K>> OnSuccess<T, K>(this Task<Result<T>> resultTask, Func<T, K> func, bool continueOnCapturedContext = false)
        {
            Result<T> result = await resultTask.ConfigureAwait(continueOnCapturedContext);
            return result.OnSuccess(func);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Task<Result> resultTask, Func<T> func, bool continueOnCapturedContext = false)
        {
            Result result = await resultTask.ConfigureAwait(continueOnCapturedContext);
            return result.OnSuccess(func);
        }

        public static async Task<Result<K>> OnSuccess<T, K>(this Task<Result<T>> resultTask, Func<T, Result<K>> func, bool continueOnCapturedContext = false)
        {
            Result<T> result = await resultTask.ConfigureAwait(continueOnCapturedContext);
            return result.OnSuccess(func);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Task<Result> resultTask, Func<Result<T>> func, bool continueOnCapturedContext = false)
        {
            Result result = await resultTask.ConfigureAwait(continueOnCapturedContext);
            return result.OnSuccess(func);
        }

        public static async Task<Result<K>> OnSuccess<T, K>(this Task<Result<T>> resultTask, Func<Result<K>> func, bool continueOnCapturedContext = false)
        {
            Result<T> result = await resultTask.ConfigureAwait(continueOnCapturedContext);
            return result.OnSuccess(func);
        }

        public static async Task<Result> OnSuccess<T>(this Task<Result<T>> resultTask, Func<T, Result> func, bool continueOnCapturedContext = false)
        {
            Result<T> result = await resultTask.ConfigureAwait(continueOnCapturedContext);
            return result.OnSuccess(func);
        }

        public static async Task<Result> OnSuccess(this Task<Result> resultTask, Func<Result> func, bool continueOnCapturedContext = false)
        {
            Result result = await resultTask.ConfigureAwait(continueOnCapturedContext);
            return result.OnSuccess(func);
        }

        public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, string errorMessage, bool continueOnCapturedContext = false)
        {
            Result<T> result = await resultTask.ConfigureAwait(continueOnCapturedContext);
            return result.Ensure(predicate, errorMessage);
        }

        public static async Task<Result> Ensure(this Task<Result> resultTask, Func<bool> predicate, string errorMessage, bool continueOnCapturedContext = false)
        {
            Result result = await resultTask.ConfigureAwait(continueOnCapturedContext);
            return result.Ensure(predicate, errorMessage);
        }

        public static async Task<Result<K>> Map<T, K>(this Task<Result<T>> resultTask, Func<T, K> func, bool continueOnCapturedContext = false)
        {
            Result<T> result = await resultTask.ConfigureAwait(continueOnCapturedContext);
            return result.Map(func);
        }

        public static async Task<Result<T>> Map<T>(this Task<Result> resultTask, Func<T> func, bool continueOnCapturedContext = false)
        {
            Result result = await resultTask.ConfigureAwait(continueOnCapturedContext);
            return result.Map(func);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Task<Result<T>> resultTask, Action<T> action, bool continueOnCapturedContext = false)
        {
            Result<T> result = await resultTask.ConfigureAwait(continueOnCapturedContext);
            return result.OnSuccess(action);
        }

        public static async Task<Result> OnSuccess(this Task<Result> resultTask, Action action, bool continueOnCapturedContext = false)
        {
            Result result = await resultTask.ConfigureAwait(continueOnCapturedContext);
            return result.OnSuccess(action);
        }

        public static async Task<T> OnBoth<T>(this Task<Result> resultTask, Func<Result, T> func, bool continueOnCapturedContext = false)
        {
            Result result = await resultTask.ConfigureAwait(continueOnCapturedContext);
            return result.OnBoth(func);
        }

        public static async Task<K> OnBoth<T, K>(this Task<Result<T>> resultTask, Func<Result<T>, K> func, bool continueOnCapturedContext = false)
        {
            Result<T> result = await resultTask.ConfigureAwait(continueOnCapturedContext);
            return result.OnBoth(func);
        }
        
        public static async Task<Result<T>> OnFailure<T>(this Task<Result<T>> resultTask, Action action, bool continueOnCapturedContext = false)
        {
            Result<T> result = await resultTask.ConfigureAwait(continueOnCapturedContext);
            return result.OnFailure(action);
        }

        public static async Task<Result> OnFailure(this Task<Result> resultTask, Action action, bool continueOnCapturedContext = false)
        {
            Result result = await resultTask.ConfigureAwait(continueOnCapturedContext);
            return result.OnFailure(action);
        }

        public static async Task<Result<T>> OnFailure<T>(this Task<Result<T>> resultTask, Action<string> action, bool continueOnCapturedContext = false)
        {
            Result<T> result = await resultTask.ConfigureAwait(continueOnCapturedContext);
            return result.OnFailure(action);
        }

        public static async Task<Result> OnFailure(this Task<Result> resultTask, Action<string> action, bool continueOnCapturedContext = false)
        {
            Result result = await resultTask.ConfigureAwait(continueOnCapturedContext);
            return result.OnFailure(action);
        }
    }
}
