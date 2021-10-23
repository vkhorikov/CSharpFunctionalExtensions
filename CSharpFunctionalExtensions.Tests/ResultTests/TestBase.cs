namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public abstract class TestBase
    {
        protected const string ErrorMessage = "Error Message";

        protected class T
        {
            public static readonly T Value = new T();
        }

        protected class K
        {
            public static readonly K Value = new K();
        }

        protected class E
        {
            public static readonly E Value = new E();
        }

        protected class E2
        {
            public static readonly E2 Value = new E2();
        }
    }
}
