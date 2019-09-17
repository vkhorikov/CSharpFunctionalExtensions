namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        /// <summary>
        /// Deprecated. Use Success() instead.
        /// </summary>
        public static Result Ok()
            => Success();

        /// <summary>
        /// Deprecated. Use Success() instead.
        /// </summary>
        public static Result<T> Ok<T>(T value)
            => Success(value);

        /// <summary>
        /// Deprecated. Use Success() instead.
        /// </summary>
        public static Result<T, E> Ok<T, E>(T value)
            => Success<T, E>(value);
    }
}
