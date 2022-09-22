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
                : await Result.Try(func, errorHandler).DefaultAwait();
        }

        public static async Task<Result<T, E>> OnSuccessTry<T, E>(this Result<T, E> result, Func<Task<T>> func,
            Func<Exception, E> errorHandler = null)
        {
            return result.IsFailure
                ? Result.Failure<T, E>(result.Error)
                : await Result.Try(func, errorHandler).DefaultAwait();
        }

        public static async Task<Result> OnSuccessTry<T>(this Result<T> result, Func<T, Task> func,
            Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? Result.Failure(result.Error)
                : await Result.Try(() => func.Invoke(result.Value), errorHandler).DefaultAwait();
        }
    }
}
