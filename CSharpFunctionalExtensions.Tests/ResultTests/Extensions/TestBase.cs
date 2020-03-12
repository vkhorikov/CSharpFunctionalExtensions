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

        protected class K
        {
            public bool Value { get; }

            private K(bool condition)
            {
                Value = condition;
            }

            public static K FromBool(bool b)
            {
                return new K(b);
            }
        }
    }
}
