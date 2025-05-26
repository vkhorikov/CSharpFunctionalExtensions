using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class TapNoValueTests_ValueTask_Right : MaybeTestBase
    {
        [Fact]
        public async Task TapNoValue_ValueTask_Right_executes_action_when_no_value()
        {
            string property = null;

            Maybe<T> maybe = null;

            var returnedMaybe = await maybe.TapNoValue(() =>
            {
                property = "Some value";
                return ValueTask.CompletedTask;
            });

            property.Should().Be("Some value");
            returnedMaybe.HasNoValue.Should().BeTrue();
        }
    }
}
