using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        /// <summary>
        ///     Creates a result whose success/failure reflects the supplied condition. Opposite of SuccessIf().
        /// </summary>
        public static Result FailureIf(bool isFailure, string error)
            => SuccessIf(!isFailure, error);

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static Result FailureIf(Func<bool> failurePredicate, string error)
            => SuccessIf(!failurePredicate(), error);

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static async Task<Result> FailureIf(Func<Task<bool>> failurePredicate, string error)
        {
            bool isFailure = await failurePredicate().DefaultAwait();
            return SuccessIf(!isFailure, error);
        }

        /// <summary>
        ///     Creates a result whose success/failure reflects the supplied condition. Opposite of SuccessIf().
        /// </summary>
        public static Result<T> FailureIf<T>(bool isFailure, T value, string error)
            => SuccessIf(!isFailure, value, error);

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static Result<T> FailureIf<T>(Func<bool> failurePredicate, T value, string error)
            => SuccessIf(!failurePredicate(), value, error);

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static async Task<Result<T>> FailureIf<T>(Func<Task<bool>> failurePredicate, T value, string error)
        {
            bool isFailure = await failurePredicate().DefaultAwait();
            return SuccessIf(!isFailure, value, error);
        }

        /// <summary>
        ///     Creates a result whose success/failure reflects the supplied condition. Opposite of SuccessIf().
        /// </summary>
        public static Result<T, E> FailureIf<T, E>(bool isFailure, T value, E error)
            => SuccessIf(!isFailure, value, error);

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static Result<T, E> FailureIf<T, E>(Func<bool> failurePredicate, T value, E error)
            => SuccessIf(!failurePredicate(), value, error);

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static async Task<Result<T, E>> FailureIf<T, E>(Func<Task<bool>> failurePredicate, T value, E error)
        {
            bool isFailure = await failurePredicate().DefaultAwait();
            return SuccessIf(!isFailure, value, error);
        }
    }

    public static partial class UnitResult
    {
        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static UnitResult<E> FailureIf<E>(bool isFailure, E error)
            => SuccessIf(!isFailure, error);

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static UnitResult<E> FailureIf<E>(Func<bool> failurePredicate, E error)
            => SuccessIf(!failurePredicate(), error);

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static async Task<UnitResult<E>> FailureIf<E>(Func<Task<bool>> failurePredicate, E error)
        {
            bool isFailure = await failurePredicate().DefaultAwait();
            return SuccessIf(!isFailure, error);
        }
    }
}
