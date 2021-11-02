using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
        /// </summary>
        public static async Task<Result> SuccessIf(Func<Task<bool>> predicate, string error)
        {
            bool isSuccess = await predicate().DefaultAwait();
            return SuccessIf(isSuccess, error);
        }
        
        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
        /// </summary>
        public static async Task<Result<T>> SuccessIf<T>(Func<Task<bool>> predicate, T value, string error)
        {
            bool isSuccess = await predicate().DefaultAwait();
            return SuccessIf(isSuccess, value, error);
        }

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
        /// </summary>
        public static async Task<Result<T, E>> SuccessIf<T, E>(Func<Task<bool>> predicate, T value, E error)
        {
            bool isSuccess = await predicate().DefaultAwait();
            return SuccessIf(isSuccess, value, error);
        }
    }

    /// <summary>
    /// Alternative entrypoint for <see cref="UnitResult{E}" /> to avoid ambiguous calls
    /// </summary>
    public static partial class UnitResult
    {
        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
        /// </summary>
        public static async Task<UnitResult<E>> SuccessIf<E>(Func<Task<bool>> predicate, E error)
        {
            bool isSuccess = await predicate().DefaultAwait();
            return SuccessIf(isSuccess, error);
        }
    }
}
