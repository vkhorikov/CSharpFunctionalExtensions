using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class TapNoValueTests_Task_Right : MaybeTestBase
    {
        [Fact]
        public async Task TapNoValue_Task_Right_executes_action_when_no_value()
        {
            string property = null;

            Maybe<T> maybe = null;

            var returnedMaybe = await maybe.TapNoValue(() =>
            {
                property = "Some value";
                return Task.CompletedTask;
            });

            property.Should().Be("Some value");
            returnedMaybe.HasNoValue.Should().BeTrue();
        }
    }
}
