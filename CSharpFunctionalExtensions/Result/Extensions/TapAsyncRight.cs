using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        public static async Task<Result> Tap(this Result result, Func<Task> func)
        {
            if (result.IsSuccess)
                await func().ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }

        public static async Task<Result> Tap<_>(this Result result, Func<Task<_>> func)
        {
            if (result.IsSuccess)
                await func().ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }

        public static async Task<Result<T>> Tap<T>(this Result<T> result, Func<Task> func)
        {
            if (result.IsSuccess)
                await func().ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }

        public static async Task<Result<T>> Tap<T, _>(this Result<T> result, Func<Task<_>> func)
        {
            if (result.IsSuccess)
                await func().ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }

        public static async Task<Result<T>> Tap<T, _>(this Result<T> result, Func<T, Task<_>> func)
        {
            if (result.IsSuccess)
                await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }

        public static async Task<Result<T, E>> Tap<T, E>(this Result<T, E> result, Func<Task> func)
        {
            if (result.IsSuccess)
                await func().ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }

        public static async Task<Result<T, E>> Tap<T, E, _>(this Result<T, E> result, Func<Task<_>> func)
        {
            if (result.IsSuccess)
                await func().ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }

        public static async Task<Result<T>> Tap<T>(this Result<T> result, Func<T, Task> func)
        {
            if (result.IsSuccess)
                await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }

        public static async Task<Result<T, E>> Tap<T, E>(this Result<T, E> result, Func<T, Task> func)
        {
            if (result.IsSuccess)
                await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }

        public static async Task<Result<T, E>> Tap<T, E, _>(this Result<T, E> result, Func<T, Task<_>> func)
        {
            if (result.IsSuccess)
                await func(result.Value).ConfigureAwait(Result.DefaultConfigureAwait);

            return result;
        }
    }
}
