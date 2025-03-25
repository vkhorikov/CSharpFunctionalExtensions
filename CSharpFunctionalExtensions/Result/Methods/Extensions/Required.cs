namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        /// The optional value is required, so convert to a failed result if there's no value.
        /// </summary>
        public static Result<T, E> Required<T, E>(this Result<Maybe<T>, E> result, E error) =>
            result.Bind(value => value.ToResult(error));
        
        /// <summary>
        /// The optional value is required, so convert to a failed result if there's no value.
        /// </summary>
        public static Result<T> Required<T>(this Result<Maybe<T>> result, string error) =>
            result.Bind(value => value.ToResult(error));
    }
}
