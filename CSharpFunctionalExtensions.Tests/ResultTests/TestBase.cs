using System;
using System.Collections.Generic;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public abstract class TestBase
    {
        protected const string ErrorMessage = "Error Message";

        protected const string ErrorMessage2 = "Error Message2";

        protected class T
        {
            public static readonly T Value = new T();

            public static readonly T Value2 = new T();
        }

        protected class K
        {
            public static readonly K Value = new K();
        }

        protected class E : Error
        {
            public static readonly E Value = new E();

            public static readonly E Value2 = new E();
        }

        protected class E2 : Error
        {
            public static readonly E2 Value = new E2();
        }

        protected class Error : ICombine
        {
            private readonly List<string> _errors = new List<string>();

            public Error()
            {
            }

            public Error(string error)
                : this(new List<string> { error })
            {
            }

            public Error(List<string> errors)
            {
                _errors = errors ?? throw new ArgumentNullException(nameof(errors));
            }

            public IReadOnlyCollection<string> Errors => _errors;

            public ICombine Combine(ICombine value)
            {
                var errorMsg = value as Error;
                var errorList = new List<string>(errorMsg._errors);
                errorList.AddRange(_errors);
                return new Error(errorList);
            }
        }
    }
}
