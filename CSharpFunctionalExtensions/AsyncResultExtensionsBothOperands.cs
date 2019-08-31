using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    /// <summary>
    /// Extentions for async operations where the task appears in the both operands
    /// </summary>
    public static class AsyncResultExtensionsBothOperands
    {
        public static async Task<Result<K, E>> OnSuccess<T, K, E>(this Task<Result<T, E>> resultTask,
            Func<T, Task<K>> func)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail<K, E>(result.Error);

            K value = await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);

            return Result.Ok<K, E>(value);
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

        public static async Task<Result<K, E>> OnSuccess<T, K, E>(this Task<Result<T, E>> resultTask,
            Func<T, Task<Result<K, E>>> func)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail<K, E>(result.Error);

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

        public static async Task<Result<K, E>> OnSuccess<T, K, E>(this Task<Result<T, E>> resultTask,
            Func<Task<Result<K, E>>> func)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return Result.Fail<K, E>(result.Error);

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

        public static async Task<Result> Tap(this Task<Result> resultTask, Func<Task> func)
        {
            Result result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsSuccess)
                await func().ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }

        public static async Task<Result<T>> Tap<T>(this Task<Result<T>> resultTask, Func<Task> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsSuccess)
                await func().ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }

        public static async Task<Result<T>> Tap<T>(this Task<Result<T>> resultTask, Func<T, Task> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsSuccess)
                await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }

        public static async Task<Result<T, E>> Tap<T, E>(this Task<Result<T, E>> resultTask, Func<Task> func)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsSuccess)
                await func().ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }

        public static async Task<Result<T, E>> Tap<T, E>(this Task<Result<T, E>> resultTask, Func<T, Task> func)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsSuccess)
                await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
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

        public static async Task<Result<T, E>> Ensure<T, E>(this Task<Result<T, E>> resultTask,
            Func<T, Task<bool>> predicate, E error)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).ConfigureAwait(Result.DefaultConfigureAwait))
                return Result.Fail<T, E>(error);

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

        public static Task<Result<K, E>> Map<T, K, E>(this Task<Result<T, E>> resultTask,
            Func<T, Task<K>> func)
            => resultTask.OnSuccess(func);

        public static Task<Result<K>> Map<T, K>(this Task<Result<T>> resultTask, Func<T, Task<K>> func)
            => resultTask.OnSuccess(func);

        public static Task<Result<T>> Map<T>(this Task<Result> resultTask, Func<Task<T>> func)
            => resultTask.OnSuccess(func);


        public static async Task<Result<T, E>> OnSuccess<T, E>(this Task<Result<T, E>> resultTask,
            Func<T, Task> action)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

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

        public static async Task<K> OnBoth<T, K, E>(this Task<Result<T, E>> resultTask,
            Func<Result<T, E>, Task<K>> func)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return await func(result).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result<T, E>> OnFailure<T, E>(this Task<Result<T, E>> resultTask,
            Func<Task> func)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

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

        public static async Task<Result<T, E>> OnFailure<T, E>(this Task<Result<T, E>> resultTask,
            Func<E, Task> func)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
            {
                await func(result.Error).ConfigureAwait(Result.DefaultConfigureAwait);
            }

            return result;
        }

        public static async Task<Result<T, E>> OnFailureCompensate<T, E>(this Task<Result<T, E>> resultTask,
            Func<Task<Result<T, E>>> func)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

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

        public static async Task<Result<T, E>> OnFailureCompensate<T, E>(this Task<Result<T, E>> resultTask,
            Func<E, Task<Result<T, E>>> func)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);

            if (result.IsFailure)
                return await func(result.Error).ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }
    }
}
