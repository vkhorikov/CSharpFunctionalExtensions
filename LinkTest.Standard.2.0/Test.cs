using CSharpFunctionalExtensions;

namespace LinkTest
{
    class Test
    {
        static void ForceLink() // If the library isn't referenced, it doesn't actually get linked
        {
            Maybe<Test> maybe = null;

            System.Diagnostics.Debug.WriteLine(string.Format("maybe HasValue: {0} hasNoValue {1}", maybe.HasValue, maybe.HasNoValue));
        }
    }
}
