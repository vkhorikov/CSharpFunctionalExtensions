namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public abstract class TestBase
    {
        protected class T
        {
            public static readonly T Value = new T();
        }

        protected class E
        {
            public static readonly E Value = new E();
        }

        protected class Discard
        {
            public static readonly Discard Value = new Discard();
        }
    }
}
