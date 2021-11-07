using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static Result OnSuccessTry(this Result result, Action action, Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? result
                : Result.Try(action, errorHandler);
        }

        public static Result<T> OnSuccessTry<T>(this Result result, Func<T> func, Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? Result.Failure<T>(result.Error)
                : Result.Try(func, errorHandler);
        }

        public static Result OnSuccessTry<T>(this Result<T> result, Action<T> action, Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? Result.Failure(result.Error)
                : Result.Try(() => action(result.Value), errorHandler);
        }
        
        public static Result<T, E> OnSuccessTry<T, E>(this Result<T, E> result, Func<T> func, Func<Exception, E> errorHandler)
        {
            return result.IsFailure
                ? Result.Failure<T, E>(result.Error)
                : Result.Try(func, errorHandler);
        }

        public static Result<K> OnSuccessTry<T, K>(this Result<T> result, Func<T, K> func, Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? Result.Failure<K>(result.Error)
                : Result.Try(() => func(result.Value), errorHandler);
        }
        
        public static Result<K, E> OnSuccessTry<T, K, E>(this Result<T, E> result, Func<T, K> func, Func<Exception, E> errorHandler)
        {
            return result.IsFailure
                ? Result.Failure<K, E>(result.Error)
                : Result.Try(() => func(result.Value), errorHandler);
        }
    }
}
