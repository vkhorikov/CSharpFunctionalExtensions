using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class TapNoValueTests : MaybeTestBase
    {
        [Fact]
        public void TapNoValue_executes_action_when_no_value()
        {
            string property = null;

            Maybe<T> maybe = null;

            var returnedMaybe = maybe.TapNoValue(() => property = "Some value");

            property.Should().Be("Some value");
            returnedMaybe.HasNoValue.Should().BeTrue();
        }
    }
}
