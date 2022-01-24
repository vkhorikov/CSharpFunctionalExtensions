using System;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        public static string ErrorMessagesSeparator = ", ";

        public static bool DefaultConfigureAwait = false;

        public static string DefaultNoValueExceptionMessage = "Maybe has no value.";

        public static Func<Exception, string> DefaultTryErrorHandler = exc => exc.Message;
    }
}