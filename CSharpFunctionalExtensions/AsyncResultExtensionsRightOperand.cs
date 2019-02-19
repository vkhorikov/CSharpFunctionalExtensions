using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    /// <summary>
    ///     Extentions for async operations where the task appears in the right operand only
    /// </summary>
    public static class AsyncResultExtensionsRightOperand
    {
        public static async Task<Result<K>> OnSuccess<T, K>(this Result<T> result, Func<T, Task<K>> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            K value = await func(result.Value).ConfigureAwait(false);

            return Result.Ok(value);
        }

        public static async Task<Result<K, TError>> OnSuccess<T, K, TError>(this Result<T, TError> result,
            Func<T, Task<K>> func) where TError : class
        {
            if (result.IsFailure)
                return Result.Fail<K, TError>(result.Error);

            K value = await func(result.Value).ConfigureAwait(false);

            return Result.Ok<K, TError>(value);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Result result, Func<Task<T>> func)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            T value = await func().ConfigureAwait(false);

            return Result.Ok(value);
        }

        public static async Task<Result<K>> OnSuccess<T, K>(this Result<T> result, Func<T, Task<Result<K>>> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return await func(result.Value).ConfigureAwait(false);
        }

        public static async Task<Result<K, TError>> OnSuccess<T, K, TError>(this Result<T, TError> result,
            Func<T, Task<Result<K, TError>>> func) where TError : class
        {
            if (result.IsFailure)
                return Result.Fail<K, TError>(result.Error);

            return await func(result.Value).ConfigureAwait(false);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Result result, Func<Task<Result<T>>> func)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            return await func().ConfigureAwait(false);
        }

        public static async Task<Result<K>> OnSuccess<T, K>(this Result<T> result, Func<Task<Result<K>>> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return await func().ConfigureAwait(false);
        }

        public static async Task<Result<K, TError>> OnSuccess<T, K, TError>(this Result<T, TError> result,
            Func<Task<Result<K, TError>>> func) where TError : class
        {
            if (result.IsFailure)
                return Result.Fail<K, TError>(result.Error);

            return await func().ConfigureAwait(false);
        }

        public static async Task<Result> OnSuccess<T>(this Result<T> result, Func<T, Task<Result>> func)
        {
            if (result.IsFailure)
                return Result.Fail(result.Error);

            return await func(result.Value).ConfigureAwait(false);
        }

        public static async Task<Result> OnSuccess(this Result result, Func<Task<Result>> func)
        {
            if (result.IsFailure)
                return result;

            return await func().ConfigureAwait(false);
        }

        public static async Task<Result<T>> Ensure<T>(this Result<T> result, Func<T, Task<bool>> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).ConfigureAwait(false))
                return Result.Fail<T>(errorMessage);

            return result;
        }

        public static async Task<Result<T, TError>> Ensure<T, TError>(this Result<T, TError> result,
            Func<T, Task<bool>> predicate, TError error) where TError : class
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).ConfigureAwait(false))
                return Result.Fail<T, TError>(error);

            return result;
        }

        public static async Task<Result> Ensure(this Result result, Func<Task<bool>> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate().ConfigureAwait(false))
                return Result.Fail(errorMessage);

            return result;
        }

        public static Task<Result<K>> Map<T, K>(this Result<T> result, Func<T, Task<K>> func)
            => result.OnSuccess(func);

        public static Task<Result<K, TError>> Map<T, K, TError>(this Result<T, TError> result,
            Func<T, Task<K>> func) where TError : class
            => result.OnSuccess(func);

        public static Task<Result<T>> Map<T>(this Result result, Func<Task<T>> func)
            => result.OnSuccess(func);

        public static async Task<Result<T>> OnSuccess<T>(this Result<T> result, Func<T, Task> action)
        {
            if (result.IsSuccess)
            {
                await action(result.Value).ConfigureAwait(false);
            }

            return result;
        }

        public static async Task<Result<T, TError>> OnSuccess<T, TError>(this Result<T, TError> result,
            Func<T, Task> action)
        {
            if (result.IsSuccess)
            {
                await action(result.Value).ConfigureAwait(false);
            }

            return result;
        }

        public static async Task<Result> OnSuccess(this Result result, Func<Task> action)
        {
            if (result.IsSuccess)
            {
                await action().ConfigureAwait(false);
            }

            return result;
        }

        public static async Task<T> OnBoth<T>(this Result result, Func<Result, Task<T>> func)
        {
            return await func(result).ConfigureAwait(false);
        }

        public static async Task<K> OnBoth<T, K>(this Result<T> result, Func<Result<T>, Task<K>> func)
        {
            return await func(result).ConfigureAwait(false);
        }

        public static async Task<K> OnBoth<T, K, TError>(this Result<T, TError> result, Func<Result<T>, Task<K>> func)
        {
            return await func(result).ConfigureAwait(false);
        }

        public static async Task<Result<T>> OnFailure<T>(this Result<T> result, Func<Task> func)
        {
            if (result.IsFailure)
            {
                await func().ConfigureAwait(false);
            }

            return result;
        }

        public static async Task<Result<T, TError>> OnFailure<T, TError>(this Result<T, TError> result, Func<Task> func)
        {
            if (result.IsFailure)
            {
                await func().ConfigureAwait(false);
            }

            return result;
        }

        public static async Task<Result> OnFailure(this Result result, Func<Task> func)
        {
            if (result.IsFailure)
            {
                await func().ConfigureAwait(false);
            }

            return result;
        }

        public static async Task<Result<T>> OnFailure<T>(this Result<T> result, Func<string, Task> func)
        {
            if (result.IsFailure)
            {
                await func(result.Error).ConfigureAwait(false);
            }

            return result;
        }

        public static async Task<Result<T, TError>> OnFailure<T, TError>(this Result<T, TError> result,
            Func<TError, Task> func)
        {
            if (result.IsFailure)
            {
                await func(result.Error).ConfigureAwait(false);
            }

            return result;
        }

        public static async Task<Result<T>> OnFailureCompensate<T>(this Result<T> result, Func<Task<Result<T>>> func)
        {
            if (result.IsFailure)
                return await func().ConfigureAwait(false);

            return result;
        }

        public static async Task<Result<T, TError>> OnFailureCompensate<T, TError>(this Result<T, TError> result, Func<Task<Result<T, TError>>> func)
        {
            if (result.IsFailure)
                return await func().ConfigureAwait(false);

            return result;
        }

        public static async Task<Result> OnFailureCompensate(this Result result, Func<Task<Result>> func)
        {
            if (result.IsFailure)
                return await func().ConfigureAwait(false);

            return result;
        }

        public static async Task<Result<T>> OnFailureCompensate<T>(this Result<T> result, Func<string, Task<Result<T>>> func)
        {
            if (result.IsFailure)
                return await func(result.Error).ConfigureAwait(false);

            return result;
        }

        public static async Task<Result<T, TError>> OnFailureCompensate<T, TError>(this Result<T, TError> result,
            Func<TError, Task<Result<T, TError>>> func)
        {
            if (result.IsFailure)
                return await func(result.Error).ConfigureAwait(false);

            return result;
        }

        public static async Task<Result> Combine(this IEnumerable<Task<Result>> tasks, string errorMessageSeparator)
        {
#if NET40
            Result[] results = await TaskEx.WhenAll(tasks).ConfigureAwait(false);
#else
            Result[] results = await Task.WhenAll(tasks).ConfigureAwait(false);
#endif
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result<IEnumerable<T>>> Combine<T>(this IEnumerable<Task<Result<T>>> tasks,
            string errorMessageSeparator)
        {
#if NET40
            Result<T>[] results = await TaskEx.WhenAll(tasks).ConfigureAwait(false);
#else
            Result<T>[] results = await Task.WhenAll(tasks).ConfigureAwait(false);
#endif
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result> Combine(this Task<IEnumerable<Result>> task, string errorMessageSeparator)
        {
            IEnumerable<Result> results = await task.ConfigureAwait(false);
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result<IEnumerable<T>>> Combine<T>(this Task<IEnumerable<Result<T>>> task,
            string errorMessageSeparator)
        {
            IEnumerable<Result<T>> results = await task.ConfigureAwait(false);
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result> Combine(this Task<IEnumerable<Task<Result>>> task,
            string errorMessageSeparator)
        {
            var tasks = await task.ConfigureAwait(false);

#if NET40
            var results = await TaskEx.WhenAll(tasks).ConfigureAwait(false);
#else
            var results = await Task.WhenAll(tasks).ConfigureAwait(false);
#endif

            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result<IEnumerable<T>>> Combine<T>(this Task<IEnumerable<Task<Result<T>>>> task,
            string errorMessageSeparator)
        {
            var tasks = await task.ConfigureAwait(false);
#if NET40
            var results = await TaskEx.WhenAll(tasks).ConfigureAwait(false);
#else
            var results = await Task.WhenAll(tasks).ConfigureAwait(false);
#endif

            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result<TNew>> Combine<T, TNew>(this IEnumerable<Task<Result<T>>> tasks,
            Func<IEnumerable<T>, TNew> composer,
            string errorMessageSeparator)
        {
#if NET40
            IEnumerable<Result<T>> results = await TaskEx.WhenAll(tasks).ConfigureAwait(false);
#else
            IEnumerable<Result<T>> results = await Task.WhenAll(tasks).ConfigureAwait(false);
#endif

            return results.Combine(composer, errorMessageSeparator);
        }

        public static async Task<Result<TNew>> Combine<T, TNew>(this Task<IEnumerable<Task<Result<T>>>> task,
            Func<IEnumerable<T>, TNew> composer,
            string errorMessageSeparator)
        {
            IEnumerable<Task<Result<T>>> tasks = await task.ConfigureAwait(false);
            return await tasks.Combine(composer, errorMessageSeparator);
        }

        public static async Task<Result> OnSuccessTry(this Task<Result> task, Action action,
            Func<Exception, string> errorHandler = null)
        {
            var result = await task.ConfigureAwait(false);
            return result.OnSuccessTry(action, errorHandler);
        }

        public static async Task<Result<T>> OnSuccessTry<T>(this Task<Result> task, Func<T> func,
            Func<Exception, string> errorHandler = null)
        {
            var result = await task.ConfigureAwait(false);
            return result.OnSuccessTry(func, errorHandler);
        }

        public static async Task<Result> OnSuccessTry<T>(this Task<Result<T>> task, Action<T> action,
            Func<Exception, string> errorHandler = null)
        {
            var result = await task.ConfigureAwait(false);
            return result.OnSuccessTry(action, errorHandler);
        }

        public static async Task<Result<R>> OnSuccessTry<T, R>(this Task<Result<T>> task, Func<T, R> action,
            Func<Exception, string> errorHandler = null)
        {
            var result = await task.ConfigureAwait(false);
            return result.OnSuccessTry(action, errorHandler);
        }
    }
}
