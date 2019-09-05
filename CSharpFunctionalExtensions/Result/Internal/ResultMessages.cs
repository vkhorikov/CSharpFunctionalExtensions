namespace CSharpFunctionalExtensions.Internal
{
    internal static class ResultMessages
    {
        public static readonly string ErrorIsInaccessibleForSuccess = "You attempted to access the Error property for a successful result. A successful result has no Error.";

        public static readonly string ValueIsInaccessibleForFailure = "You attempted to access the Value property for a failed result. A failed result has no Value.";

        public static readonly string ErrorObjectIsNotProvidedForFailure =
            "You attempted to create a failure result, which must have an error, but a null error object was passed to the constructor.";

        public static readonly string ErrorObjectIsProvidedForSuccess =
            "You attempted to create a success result, which cannot have an error, but a non-null error object was passed to the constructor.";

        public static readonly string ErrorMessageIsNotProvidedForFailure = "You attempted to create a failure result, which must have an error, but a null or empty string was passed to the constructor.";

        public static readonly string ErrorMessageIsProvidedForSuccess = "You attempted to create a success result, which cannot have an error, but a non-null string was passed to the constructor.";
    }
}