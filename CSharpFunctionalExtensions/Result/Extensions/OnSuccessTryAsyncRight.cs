using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static async Task<Result> OnSuccessTry(this Result result, Func<Task> func,
            Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
               ? result
               : await Result.Try(func, errorHandler);
        }

        public static async Task OnSuccessTry<T>(this Result<T> result, Func<T, Task> func)
        {
            if (result.IsSuccess)
            {
                await func(result.Value);
            }
        }

        public static async Task OnSuccessTry<T, E>(this Result<T, E> result, Func<T, Task> func)
        {
            if (result.IsSuccess)
            {
                await func(result.Value);
            }
        }

        public static async Task<Result<T>> OnSuccessTry<T>(this Result result, Func<Task<T>> func,
            Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
               ? Result.Failure<T>(result.Error)
               : await Result.Try(func, errorHandler);
        }

        public static async Task<Result> OnSuccessTry<T>(this Result<T> result, Func<T, Task> func,
            Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
               ? Result.Failure(result.Error)
               : await Result.Try(async () => await func(result.Value), errorHandler);
        }

        public static async Task<Result<K>> OnSuccessTry<T, K>(this Result<T> result, Func<T, Task<K>> func,
            Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
               ? Result.Failure<K>(result.Error)
               : await Result.Try(async () => await func(result.Value), errorHandler);
        }
    }
}
