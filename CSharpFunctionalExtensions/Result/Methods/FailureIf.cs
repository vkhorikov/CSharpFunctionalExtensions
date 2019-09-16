using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        public static Result FailureIf(bool isFailure, string error)
            => SuccessIf(!isFailure, error);

        public static Result FailureIf(Func<bool> failurePredicate, string error)
            => SuccessIf(!failurePredicate(), error);

        public static async Task<Result> FailureIf(Func<Task<bool>> failurePredicate, string error)
        {
            bool isFailure = await failurePredicate().ConfigureAwait(DefaultConfigureAwait);
            return SuccessIf(!isFailure, error);
        }

        public static Result<T> FailureIf<T>(bool isFailure, T value, string error)
            => SuccessIf(!isFailure, value, error);

        public static Result<T> FailureIf<T>(Func<bool> failurePredicate, T value, string error)
            => SuccessIf(!failurePredicate(), value, error);

        public static async Task<Result<T>> FailureIf<T>(Func<Task<bool>> failurePredicate, T value, string error)
        {
            bool isFailure = await failurePredicate().ConfigureAwait(DefaultConfigureAwait);
            return SuccessIf(!isFailure, value, error);
        }

        public static Result<T, E> FailureIf<T, E>(bool isFailure, T value, E error)
            => SuccessIf(!isFailure, value, error);

        public static Result<T, E> FailureIf<T, E>(Func<bool> failurePredicate, T value, E error)
            => SuccessIf(!failurePredicate(), value, error);

        public static async Task<Result<T, E>> FailureIf<T, E>(Func<Task<bool>> failurePredicate, T value, E error)
        {
            bool isFailure = await failurePredicate().ConfigureAwait(DefaultConfigureAwait);
            return SuccessIf(!isFailure, value, error);
        }
    }
}
