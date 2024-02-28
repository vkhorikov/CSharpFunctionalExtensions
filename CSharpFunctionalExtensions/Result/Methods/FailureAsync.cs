using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        /// <summary>
        ///     Creates a failure async result with the given error message.
        /// </summary>
        public static Task<Result> FailureAsync(string error)
        {
            return new Task<Result>(() => Failure(error));
        }

        /// <summary>
        ///     Creates a failure async result with the given error message.
        /// </summary>
        public static Task<Result<T>> FailureAsync<T>(string error)
        {
            return new Task<Result<T>>(() => Failure<T>(error));
        }

        /// <summary>
        ///     Creates a failure async result with the given error.
        /// </summary>
        public static Task<Result<T, E>> FailureAsync<T, E>(E error)
        {
            return new Task<Result<T, E>>(() => Failure<T, E>(error));
        }
    }
}
