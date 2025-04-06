using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        /// Change from one result type to another, while staying optional (the return type still contains <see cref="Maybe"/>)
        /// Even though it's a Result&lt;Maybe&gt;, the mapping function only has to
        /// operate on the innermost value, and is only called if it's present.
        /// </summary>
        public static Result<Maybe<K>, E> BindOptional<T, K, E>(
            this Result<Maybe<T>, E> result,
            Func<T, Result<K, E>> bind)
        {
            if (result.IsFailure)
                return Result.Failure<Maybe<K>, E>(result.Error);

            if (result.Value.HasNoValue)
                return Result.Success<Maybe<K>, E>(Maybe.None);
            
            return bind(result.Value.Value).Map(Maybe.From);
        }
    }
}
