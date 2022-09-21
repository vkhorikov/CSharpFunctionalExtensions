using Xunit;

namespace CSharpFunctionalExtensions.Tests
{
    [CollectionDefinition(Name, DisableParallelization = true)]
    public sealed class NonParallelTestCollectionDefinition
    {
        internal const string Name = "Non-Parallel Collection";
    }
}
