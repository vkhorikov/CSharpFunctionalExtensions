#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static async ValueTask<Result> OnSuccessTry(this Result result, Func<ValueTask> func,
            Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? result
                : await Result.Try(func, errorHandler);
        }

        public static async ValueTask<Result<T>> OnSuccessTry<T>(this Result result, Func<ValueTask<T>> func,
            Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? Result.Failure<T>(result.Error)
                : await Result.Try(func, errorHandler);
        }

        public static async ValueTask<Result<T, E>> OnSuccessTry<T, E>(this Result<T, E> result, Func<ValueTask<T>> func,
            Func<Exception, E> errorHandler = null)
        {
            return result.IsFailure
                ? Result.Failure<T, E>(result.Error)
                : await Result.Try(func, errorHandler);
        }

        public static async ValueTask<Result> OnSuccessTry<T>(this Result<T> result, Func<T, ValueTask> func,
            Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? Result.Failure(result.Error)
                : await Result.Try(() => func.Invoke(result.Value), errorHandler);
        }

        public static async ValueTask<Result<K>> OnSuccessTry<T, K>(this Result<T> result, Func<T, ValueTask<K>> func,
            Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? Result.Failure<K>(result.Error)
                : await Result.Try(() => func.Invoke(result.Value), errorHandler);
        }

        public static async ValueTask<Result<K, E>> OnSuccessTry<T, K, E>(this Result<T, E> result, Func<T, ValueTask<K>> func,
            Func<Exception, E> errorHandler = null)
        {
            return result.IsFailure
                ? Result.Failure<K, E>(result.Error)
                : await Result.Try(() => func.Invoke(result.Value), errorHandler);
        }
    }
}

#endif
