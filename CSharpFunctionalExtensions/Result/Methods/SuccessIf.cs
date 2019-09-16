using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        public static Result SuccessIf(bool isSuccess, string error)
        {
            return isSuccess
                ? Ok()
                : Fail(error);
        }

        public static Result SuccessIf(Func<bool> predicate, string error)
        {
            return SuccessIf(predicate(), error);
        }

        public static async Task<Result> SuccessIf(Func<Task<bool>> predicate, string error)
        {
            bool isSuccess = await predicate().ConfigureAwait(DefaultConfigureAwait);
            return SuccessIf(isSuccess, error);
        }

        public static Result<T> SuccessIf<T>(bool isSuccess, T value, string error)
        {
            return isSuccess
                ? Ok(value)
                : Fail<T>(error);
        }

        public static Result<T> SuccessIf<T>(Func<bool> predicate, T value, string error)
        {
            return SuccessIf(predicate(), value, error);
        }

        public static async Task<Result<T>> SuccessIf<T>(Func<Task<bool>> predicate, T value, string error)
        {
            bool isSuccess = await predicate().ConfigureAwait(DefaultConfigureAwait);
            return SuccessIf(isSuccess, value, error);
        }

        public static Result<T, E> SuccessIf<T, E>(bool isSuccess, T value, E error)
        {
            return isSuccess
                ? Ok<T, E>(value)
                : Fail<T, E>(error);
        }

        public static Result<T, E> SuccessIf<T, E>(Func<bool> predicate, T value, E error)
        {
            return SuccessIf(predicate(), value, error);
        }

        public static async Task<Result<T, E>> SuccessIf<T, E>(Func<Task<bool>> predicate, T value, E error)
        {
            bool isSuccess = await predicate().ConfigureAwait(DefaultConfigureAwait);
            return SuccessIf(isSuccess, value, error);
        }
    }
}
