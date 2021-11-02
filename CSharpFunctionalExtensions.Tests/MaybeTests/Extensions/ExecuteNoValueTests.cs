using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class ExecuteNoValueTests : MaybeTestBase
    {
        [Fact]
        public void ExecuteNoValue_executes_action_when_no_value()
        {
            string property = null;

            Maybe<T> maybe = null;

            maybe.ExecuteNoValue(() => property = "Some value");

            property.Should().Be("Some value");
        }
    }
}