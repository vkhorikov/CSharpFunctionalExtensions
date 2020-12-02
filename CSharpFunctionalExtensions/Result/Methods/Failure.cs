namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        /// <summary>
        ///     Creates a failure result with the given error message.
        /// </summary>
        public static Result Failure(string error)
        {
            return new Result(true, error);
        }

        /// <summary>
        ///     Creates a failure result with the given error message.
        /// </summary>
        public static Result<T> Failure<T>(string error)
        {
            return new Result<T>(true, error, default);
        }

        /// <summary>
        ///     Creates a failure result with the given error.
        /// </summary>
        public static Result<T, E> Failure<T, E>(E error)
        {
            return new Result<T, E>(true, error, default);
        }

        /// <summary>
        ///     Creates a failure result with the given error.
        /// </summary>
        public static UnitResult<E> Failure<E>(E error)
        {
            return new UnitResult<E>(true, error);
        }
    }
}
