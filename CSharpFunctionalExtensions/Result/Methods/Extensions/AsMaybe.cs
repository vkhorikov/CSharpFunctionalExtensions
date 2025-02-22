namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        /// <para>Converts a <see cref="Result{T}"/> to a <see cref="Maybe{T}"/>:</para>
        /// <para>Returns <see cref="Maybe{T}.Value"/> if the result is <c>Success</c>.</para>
        /// Returns <see cref="Maybe{T}.None"/> if the result is <c>Error</c>.
        /// </summary>

        public static Maybe<T> AsMaybe<T>(this Result<T> result)
        {
            return result.IsSuccess 
                ? Maybe<T>.From(result.Value) 
                : Maybe<T>.None;
        }
    }
}
