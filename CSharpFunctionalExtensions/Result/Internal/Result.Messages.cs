namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        internal static class Messages
        {
            public static readonly string ErrorIsInaccessibleForSuccess =
                "You attempted to access the Error property for a successful result. A successful result has no Error.";

            public static readonly string ValueIsInaccessibleForFailure =
                "You attempted to access the Value property for a failed result. A failed result has no Value.";

            public static readonly string ErrorObjectIsNotProvidedForFailure =
                "You attempted to create a failure result, which must have an error, but a null error object (or empty string) was passed to the constructor.";

            public static readonly string ErrorObjectIsProvidedForSuccess =
                "You attempted to create a success result, which cannot have an error, but a non-null error object was passed to the constructor.";

            public static readonly string ConvertFailureExceptionOnSuccess =
                $"{nameof(ConvertFailure)} failed because the Result is in a success state.";
        }
    }
}
