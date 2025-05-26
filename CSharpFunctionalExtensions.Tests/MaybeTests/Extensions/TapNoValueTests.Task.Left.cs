using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class TapNoValueTests_Task_Left : MaybeTestBase
    {
        [Fact]
        public async Task TapNoValue_Task_Left_executes_action_when_no_value()
        {
            string property = null;

            Maybe<T> maybe = null;

            var returnedMaybe = await maybe.AsTask().TapNoValue(() => property = "Some value");

            property.Should().Be("Some value");
            returnedMaybe.HasNoValue.Should().BeTrue();
        }
    }
}
