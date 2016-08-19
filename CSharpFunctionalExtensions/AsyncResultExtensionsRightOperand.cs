using System;
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
                return Result.Fail<T>(result.Error);

            if (!await predicate(result.Value).ConfigureAwait(false))
                return Result.Fail<T>(errorMessage);

            return Result.Ok(result.Value);
        }

        public static async Task<Result> Ensure(this Result result, Func<Task<bool>> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return Result.Fail(result.Error);

            if (!await predicate().ConfigureAwait(false))
                return Result.Fail(errorMessage);

            return Result.Ok();
        }

        public static async Task<Result<K>> Map<T, K>(this Result<T> result, Func<T, Task<K>> func)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            K value = await func(result.Value).ConfigureAwait(false);

            return Result.Ok(value);
        }

        public static async Task<Result<T>> Map<T>(this Result result, Func<Task<T>> func)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            T value = await func().ConfigureAwait(false);

            return Result.Ok(value);
        }

        public static async Task<Result<T>> OnSuccess<T>(this Result<T> result, Func<T, Task> action)
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

        public static async Task<Result<T>> OnFailure<T>(this Result<T> result, Func<Task> func)
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
    }
}
