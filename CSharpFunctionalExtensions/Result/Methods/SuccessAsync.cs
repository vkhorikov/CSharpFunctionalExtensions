using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        /// <summary>
        ///     Creates a success async result.
        /// </summary>
        public static Task<Result> SuccessAsync()
        {
            return new Task<Result>(() => Success());
        }

        /// <summary>
        ///     Creates a success async result containing the given value.
        /// </summary>
        public static Task<Result<T>> SuccessAsync<T>(T value)
        {
            return new Task<Result<T>>(() => Success<T>(value));
        }
        
        /// <summary>
        ///     Creates a success async result containing the given value.
        /// </summary>
        public static Task<Result<T, E>> SuccessAsync<T, E>(T value)
        {
            return new Task<Result<T,E>>(() => Success<T, E>(value));
        }
    }
}
