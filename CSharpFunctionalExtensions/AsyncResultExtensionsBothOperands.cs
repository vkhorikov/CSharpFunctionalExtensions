using System;
using System.Threading.Tasks;


namespace CSharpFunctionalExtensions
{
    /// <summary>
    /// Extentions for async operations where the task appears in the both operands
    /// </summary>
    public static class AsyncResultExtensionsBothOperands
    {
        public static async Task<Result<K, TError>> OnSuccess<T, K, TError>(this Task<Result<T, TError>> resultTask,
            Func<T, Task<K>> func) where TError : class
        {
            Result<T, TError> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail<K, TError>(result.Error);

            K value = await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);

            return Result.Ok<K, TError>(value);
        }

        public static async Task<Result<K>> OnSuccess<T, K>(this Task<Result<T>> resultTask, Func<T, Task<K>> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            K value = await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);

            return Result.Ok(value);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Task<Result> resultTask, Func<Task<T>> func)
        {
            Result result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            T value = await func().ConfigureAwait(Result.DefaultConfigureAwait);

            return Result.Ok(value);
        }

        public static async Task<Result<K, TError>> OnSuccess<T, K, TError>(this Task<Result<T, TError>> resultTask,
            Func<T, Task<Result<K, TError>>> func) where TError : class
        {
            Result<T, TError> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail<K, TError>(result.Error);

            return await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result<K>> OnSuccess<T, K>(this Task<Result<T>> resultTask, Func<T, Task<Result<K>>> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Task<Result> resultTask, Func<Task<Result<T>>> func)
        {
            Result result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            return await func().ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result<K, TError>> OnSuccess<T, K, TError>(this Task<Result<T, TError>> resultTask,
            Func<Task<Result<K, TError>>> func) where TError : class
        {
            Result<T, TError> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail<K, TError>(result.Error);

            return await func().ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result<K>> OnSuccess<T, K>(this Task<Result<T>> resultTask, Func<Task<Result<K>>> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return await func().ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result> OnSuccess<T>(this Task<Result<T>> resultTask, Func<T, Task<Result>> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail(result.Error);

            return await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result> OnSuccess(this Task<Result> resultTask, Func<Task<Result>> func)
        {
            Result result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return result;

            return await func().ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Func<T, Task<bool>> predicate, string errorMessage)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).ConfigureAwait(Result.DefaultConfigureAwait))
                return Result.Fail<T>(errorMessage);

            return result;
        }

        public static async Task<Result<T, TError>> Ensure<T, TError>(this Task<Result<T, TError>> resultTask,
            Func<T, Task<bool>> predicate, TError error) where TError : class
        {
            Result<T, TError> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).ConfigureAwait(Result.DefaultConfigureAwait))
                return Result.Fail<T, TError>(error);

            return result;
        }

        public static async Task<Result> Ensure(this Task<Result> resultTask, Func<Task<bool>> predicate, string errorMessage)
        {
            Result result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return result;

            if (!await predicate().ConfigureAwait(Result.DefaultConfigureAwait))
                return Result.Fail(errorMessage);

            return result;
        }

        public static Task<Result<K, TError>> Map<T, K, TError>(this Task<Result<T, TError>> resultTask,
            Func<T, Task<K>> func) where TError : class
            => resultTask.OnSuccess(func);

        public static Task<Result<K>> Map<T, K>(this Task<Result<T>> resultTask, Func<T, Task<K>> func)
            => resultTask.OnSuccess(func);

        public static Task<Result<T>> Map<T>(this Task<Result> resultTask, Func<Task<T>> func)
            => resultTask.OnSuccess(func);


        public static async Task<Result<T, TError>> OnSuccess<T, TError>(this Task<Result<T, TError>> resultTask,
            Func<T, Task> action)
        {
            Result<T, TError> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsSuccess)
            {
                await action(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);
            }

            return result;
        }

        public static async Task<Result<T>> OnSuccess<T>(this Task<Result<T>> resultTask, Func<T, Task> action)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsSuccess)
            {
                await action(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);
            }

            return result;
        }

        public static async Task<Result> OnSuccess(this Task<Result> resultTask, Func<Task> action)
        {
            Result result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsSuccess)
            {
                await action().ConfigureAwait(Result.DefaultConfigureAwait);
            }

            return result;
        }

        public static async Task<T> OnBoth<T>(this Task<Result> resultTask, Func<Result, Task<T>> func)
        {
            Result result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return await func(result).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<K> OnBoth<T, K>(this Task<Result<T>> resultTask, Func<Result<T>, Task<K>> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return await func(result).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<K> OnBoth<T, K, TError>(this Task<Result<T, TError>> resultTask,
            Func<Result<T, TError>, Task<K>> func)
        {
            Result<T, TError> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return await func(result).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result<T, TError>> OnFailure<T, TError>(this Task<Result<T, TError>> resultTask,
            Func<Task> func)
        {
            Result<T, TError> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
            {
                await func().ConfigureAwait(Result.DefaultConfigureAwait);
            }

            return result;
        }

        public static async Task<Result<T>> OnFailure<T>(this Task<Result<T>> resultTask, Func<Task> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
            {
                await func().ConfigureAwait(Result.DefaultConfigureAwait);
            }

            return result;
        }

        public static async Task<Result> OnFailure(this Task<Result> resultTask, Func<Task> func)
        {
            Result result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
            {
                await func().ConfigureAwait(Result.DefaultConfigureAwait);
            }

            return result;
        }

        public static async Task<Result<T>> OnFailure<T>(this Task<Result<T>> resultTask, Func<string, Task> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
            {
                await func(result.Error).ConfigureAwait(Result.DefaultConfigureAwait);
            }

            return result;
        }

        public static async Task<Result<T, TError>> OnFailure<T, TError>(this Task<Result<T, TError>> resultTask,
            Func<TError, Task> func)
        {
            Result<T, TError> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
            {
                await func(result.Error).ConfigureAwait(Result.DefaultConfigureAwait);
            }

            return result;
        }

        public static async Task<Result<T, TError>> OnFailureCompensate<T, TError>(this Task<Result<T, TError>> resultTask,
            Func<Task<Result<T, TError>>> func)
        {
            Result<T, TError> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return await func().ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }

        public static async Task<Result<T>> OnFailureCompensate<T>(this Task<Result<T>> resultTask, Func<Task<Result<T>>> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return await func().ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }

        public static async Task<Result> OnFailureCompensate(this Task<Result> resultTask, Func<Task<Result>> func)
        {
            Result result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return await func().ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }

        public static async Task<Result<T>> OnFailureCompensate<T>(this Task<Result<T>> resultTask, Func<string, Task<Result<T>>> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return await func(result.Error).ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }

        public static async Task<Result<T, TError>> OnFailureCompensate<T, TError>(this Task<Result<T, TError>> resultTask,
            Func<TError, Task<Result<T, TError>>> func)
        {
            Result<T, TError> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return await func(result.Error).ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }
    }
}
