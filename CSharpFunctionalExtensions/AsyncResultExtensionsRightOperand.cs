using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    /// <summary>
    /// Extentions for async operations where the task appears in the right operand only
    /// </summary>
    public static class AsyncResultExtensionsRightOperand
    {
        public static async Task<Result<K>> OnSuccess<T, K>(this Result<T> result, Func<T, Task<K>> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            K value = await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);

            return Result.Ok(value);
        }

        public static async Task<Result<K, E>> OnSuccess<T, K, E>(this Result<T, E> result,
            Func<T, Task<K>> func) where E : class
        {
            if (result.IsFailure)
                return Result.Fail<K, E>(result.Error);

            K value = await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);

            return Result.Ok<K, E>(value);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Result result, Func<Task<T>> func)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            T value = await func().ConfigureAwait(Result.DefaultConfigureAwait);

            return Result.Ok(value);
        }

        public static async Task<Result<K>> OnSuccess<T, K>(this Result<T> result, Func<T, Task<Result<K>>> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result<K, E>> OnSuccess<T, K, E>(this Result<T, E> result,
            Func<T, Task<Result<K, E>>> func) where E : class
        {
            if (result.IsFailure)
                return Result.Fail<K, E>(result.Error);

            return await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Result result, Func<Task<Result<T>>> func)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            return await func().ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result<K>> OnSuccess<T, K>(this Result<T> result, Func<Task<Result<K>>> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return await func().ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result<K, E>> OnSuccess<T, K, E>(this Result<T, E> result,
            Func<Task<Result<K, E>>> func) where E : class
        {
            if (result.IsFailure)
                return Result.Fail<K, E>(result.Error);

            return await func().ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result> OnSuccess<T>(this Result<T> result, Func<T, Task<Result>> func)
        {
            if (result.IsFailure)
                return Result.Fail(result.Error);

            return await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result> OnSuccess(this Result result, Func<Task<Result>> func)
        {
            if (result.IsFailure)
                return result;

            return await func().ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result<T>> Ensure<T>(this Result<T> result, Func<T, Task<bool>> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).ConfigureAwait(Result.DefaultConfigureAwait))
                return Result.Fail<T>(errorMessage);

            return result;
        }

        public static async Task<Result<T, E>> Ensure<T, E>(this Result<T, E> result,
            Func<T, Task<bool>> predicate, E error) where E : class
        {
            if (result.IsFailure)
                return result;

            if (!await predicate(result.Value).ConfigureAwait(Result.DefaultConfigureAwait))
                return Result.Fail<T, E>(error);

            return result;
        }

        public static async Task<Result> Ensure(this Result result, Func<Task<bool>> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return result;

            if (!await predicate().ConfigureAwait(Result.DefaultConfigureAwait))
                return Result.Fail(errorMessage);

            return result;
        }

        public static Task<Result<K>> Map<T, K>(this Result<T> result, Func<T, Task<K>> func)
            => result.OnSuccess(func);

        public static Task<Result<K, E>> Map<T, K, E>(this Result<T, E> result,
            Func<T, Task<K>> func) where E : class
            => result.OnSuccess(func);

        public static Task<Result<T>> Map<T>(this Result result, Func<Task<T>> func)
            => result.OnSuccess(func);

        public static async Task<Result<T>> OnSuccess<T>(this Result<T> result, Func<T, Task> action)
        {
            if (result.IsSuccess)
            {
                await action(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);
            }

            return result;
        }

        public static async Task<Result<T, E>> OnSuccess<T, E>(this Result<T, E> result,
            Func<T, Task> action)
        {
            if (result.IsSuccess)
            {
                await action(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);
            }

            return result;
        }

        public static async Task<Result> OnSuccess(this Result result, Func<Task> action)
        {
            if (result.IsSuccess)
            {
                await action().ConfigureAwait(Result.DefaultConfigureAwait);
            }

            return result;
        }

        public static async Task<T> OnBoth<T>(this Result result, Func<Result, Task<T>> func)
        {
            return await func(result).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<K> OnBoth<T, K>(this Result<T> result, Func<Result<T>, Task<K>> func)
        {
            return await func(result).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<K> OnBoth<T, K, E>(this Result<T, E> result, Func<Result<T>, Task<K>> func)
        {
            return await func(result).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result<T>> OnFailure<T>(this Result<T> result, Func<Task> func)
        {
            if (result.IsFailure)
            {
                await func().ConfigureAwait(Result.DefaultConfigureAwait);
            }

            return result;
        }

        public static async Task<Result<T, E>> OnFailure<T, E>(this Result<T, E> result, Func<Task> func)
        {
            if (result.IsFailure)
            {
                await func().ConfigureAwait(Result.DefaultConfigureAwait);
            }

            return result;
        }

        public static async Task<Result> OnFailure(this Result result, Func<Task> func)
        {
            if (result.IsFailure)
            {
                await func().ConfigureAwait(Result.DefaultConfigureAwait);
            }

            return result;
        }

        public static async Task<Result<T>> OnFailure<T>(this Result<T> result, Func<string, Task> func)
        {
            if (result.IsFailure)
            {
                await func(result.Error).ConfigureAwait(Result.DefaultConfigureAwait);
            }

            return result;
        }

        public static async Task<Result<T, E>> OnFailure<T, E>(this Result<T, E> result,
            Func<E, Task> func)
        {
            if (result.IsFailure)
            {
                await func(result.Error).ConfigureAwait(Result.DefaultConfigureAwait);
            }

            return result;
        }

        public static async Task<Result<T>> OnFailureCompensate<T>(this Result<T> result, Func<Task<Result<T>>> func)
        {
            if (result.IsFailure)
                return await func().ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }

        public static async Task<Result<T, E>> OnFailureCompensate<T, E>(this Result<T, E> result, Func<Task<Result<T, E>>> func)
        {
            if (result.IsFailure)
                return await func().ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }

        public static async Task<Result> OnFailureCompensate(this Result result, Func<Task<Result>> func)
        {
            if (result.IsFailure)
                return await func().ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }

        public static async Task<Result<T>> OnFailureCompensate<T>(this Result<T> result, Func<string, Task<Result<T>>> func)
        {
            if (result.IsFailure)
                return await func(result.Error).ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }

        public static async Task<Result<T, E>> OnFailureCompensate<T, E>(this Result<T, E> result,
            Func<E, Task<Result<T, E>>> func)
        {
            if (result.IsFailure)
                return await func(result.Error).ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }

        public static async Task<Result> Combine(this IEnumerable<Task<Result>> tasks, string errorMessageSeparator)
        {
#if NET40
            Result[] results = await TaskEx.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
#else
            Result[] results = await Task.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
#endif
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result<IEnumerable<T>>> Combine<T>(this IEnumerable<Task<Result<T>>> tasks,
            string errorMessageSeparator)
        {
#if NET40
            Result<T>[] results = await TaskEx.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
#else
            Result<T>[] results = await Task.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
#endif
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result> Combine(this Task<IEnumerable<Result>> task, string errorMessageSeparator)
        {
            IEnumerable<Result> results = await task.ConfigureAwait(Result.DefaultConfigureAwait);
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result<IEnumerable<T>>> Combine<T>(this Task<IEnumerable<Result<T>>> task,
            string errorMessageSeparator)
        {
            IEnumerable<Result<T>> results = await task.ConfigureAwait(Result.DefaultConfigureAwait);
            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result> Combine(this Task<IEnumerable<Task<Result>>> task,
            string errorMessageSeparator)
        {
            var tasks = await task.ConfigureAwait(Result.DefaultConfigureAwait);

#if NET40
            var results = await TaskEx.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
#else
            var results = await Task.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
#endif

            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result<IEnumerable<T>>> Combine<T>(this Task<IEnumerable<Task<Result<T>>>> task,
            string errorMessageSeparator)
        {
            var tasks = await task.ConfigureAwait(Result.DefaultConfigureAwait);
#if NET40
            var results = await TaskEx.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
#else
            var results = await Task.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
#endif

            return results.Combine(errorMessageSeparator);
        }

        public static async Task<Result<K>> Combine<T, K>(this IEnumerable<Task<Result<T>>> tasks,
            Func<IEnumerable<T>, K> composer,
            string errorMessageSeparator)
        {
#if NET40
            IEnumerable<Result<T>> results = await TaskEx.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
#else
            IEnumerable<Result<T>> results = await Task.WhenAll(tasks).ConfigureAwait(Result.DefaultConfigureAwait);
#endif

            return results.Combine(composer, errorMessageSeparator);
        }

        public static async Task<Result<K>> Combine<T, K>(this Task<IEnumerable<Task<Result<T>>>> task,
            Func<IEnumerable<T>, K> composer,
            string errorMessageSeparator)
        {
            IEnumerable<Task<Result<T>>> tasks = await task.ConfigureAwait(Result.DefaultConfigureAwait);
            return await tasks.Combine(composer, errorMessageSeparator).ConfigureAwait(Result.DefaultConfigureAwait);
        }

        public static async Task<Result> OnSuccessTry(this Task<Result> task, Action action,
            Func<Exception, string> errorHandler = null)
        {
            var result = await task.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.OnSuccessTry(action, errorHandler);
        }

        public static async Task<Result<T>> OnSuccessTry<T>(this Task<Result> task, Func<T> func,
            Func<Exception, string> errorHandler = null)
        {
            var result = await task.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.OnSuccessTry(func, errorHandler);
        }

        public static async Task<Result> OnSuccessTry<T>(this Task<Result<T>> task, Action<T> action,
            Func<Exception, string> errorHandler = null)
        {
            var result = await task.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.OnSuccessTry(action, errorHandler);
        }

        public static async Task<Result<K>> OnSuccessTry<T, K>(this Task<Result<T>> task, Func<T, K> action,
            Func<Exception, string> errorHandler = null)
        {
            var result = await task.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.OnSuccessTry(action, errorHandler);
        }
    }
}
