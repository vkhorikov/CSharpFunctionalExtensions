#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
        /// </summary>
        public static async ValueTask<Result> SuccessIf(Func<ValueTask<bool>> predicate, string error)
        {
            bool isSuccess = await predicate();
            return SuccessIf(isSuccess, error);
        }
        
        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
        /// </summary>
        public static async ValueTask<Result<T>> SuccessIf<T>(Func<ValueTask<bool>> predicate, T value, string error)
        {
            bool isSuccess = await predicate();
            return SuccessIf(isSuccess, value, error);
        }

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of FailureIf().
        /// </summary>
        public static async ValueTask<Result<T, E>> SuccessIf<T, E>(Func<ValueTask<bool>> predicate, T value, E error)
        {
            bool isSuccess = await predicate();
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
        public static async ValueTask<UnitResult<E>> SuccessIf<E>(Func<ValueTask<bool>> predicate, E error)
        {
            bool isSuccess = await predicate();
            return SuccessIf(isSuccess, error);
        }
    }
}
#endif
