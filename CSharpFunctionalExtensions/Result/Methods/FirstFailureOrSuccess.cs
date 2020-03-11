namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        /// <summary>
        ///     Returns the first failure from the supplied <paramref name="results"/>.
        ///     If there is no failure, a success result is returned.
        /// </summary>
        public static Result FirstFailureOrSuccess(params Result[] results)
        {
            foreach (Result result in results)
            {
                if (result.IsFailure)
                    return Failure(result.Error);
            }

            return Success();
        }
    }
}
