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

        [Fact]
        public async Task TapNoValue_ValueTask_Right_does_not_execute_action_when_has_value()
        {
            var executed = false;

            Maybe<T> maybe = T.Value;

            var returnedMaybe = await maybe.TapNoValue(() =>
            {
                executed = true;
                return ValueTask.CompletedTask;
            });

            executed.Should().BeFalse();
            returnedMaybe.Value.Should().BeSameAs(maybe.Value);
        }
    }
}
