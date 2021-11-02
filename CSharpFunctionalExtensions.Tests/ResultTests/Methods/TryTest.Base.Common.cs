using System;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Methods.Try
{
    public abstract class TryTestBaseCommon : TestBase
    {
        protected TryTestBaseCommon()
        {
            FuncExecuted = false;
        }

        protected static readonly Exception Exception = new Exception(ErrorMessage);
        protected const string ErrorHandlerMessage = "Error message from error handler";
        protected static readonly Func<Exception, string> ErrorHandler = exc => ErrorHandlerMessage;
        protected static readonly Func<Exception, E> ErrorHandler_E = exc => E.Value;

        protected bool FuncExecuted;
    }
}