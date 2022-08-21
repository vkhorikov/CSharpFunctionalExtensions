using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static async Task<Result> FailureIf(Func<Task<bool>> failurePredicate, string error)
        {
            bool isFailure = await failurePredicate().DefaultAwait();
            return SuccessIf(!isFailure, error);
        }
        
        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static async Task<Result<T>> FailureIf<T>(Func<Task<bool>> failurePredicate, T value, string error)
        {
            bool isFailure = await failurePredicate().DefaultAwait();
            return SuccessIf(!isFailure, value, error);
        }
        
        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static async Task<Result<T, E>> FailureIf<T, E>(Func<Task<bool>> failurePredicate, T value, E error)
        {
            bool isFailure = await failurePredicate().DefaultAwait();
            return SuccessIf(!isFailure, value, error);
        }
    }
}
