using System;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        public static class Configuration
        {
            public static string ErrorMessagesSeparator = ", ";

            public static bool DefaultConfigureAwait = false;

            public static Func<Exception, string> DefaultTryErrorHandler = exc => exc.Message;    
        }
    }
}