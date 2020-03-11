namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        /// <summary>
        ///     Creates a success result.
        /// </summary>
        public static Result Success()
        {
            return new Result(false, default);
        }

        /// <summary>
        ///     Creates a success result containing the given value.
        /// </summary>
        public static Result<T> Success<T>(T value)
        {
            return new Result<T>(false, default, value);
        }

        /// <summary>
        ///     Creates a success result containing the given value.
        /// </summary>
        public static Result<T, E> Success<T, E>(T value)
        {
            return new Result<T, E>(false, default, value);
        }
    }
}
