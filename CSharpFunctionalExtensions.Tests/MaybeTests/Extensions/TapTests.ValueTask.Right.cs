using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class TapTests_ValueTask_Right : MaybeTestBase
    {
        [Fact]
        public async Task Tap_ValueTask_Right_does_not_execute_action_if_no_value()
        {
            Maybe<T> maybe = null;
            var executed = false;

            var returnedMaybe = await maybe.Tap(value =>
            {
                executed = true;
                return ValueTask.CompletedTask;
            });

            executed.Should().BeFalse();
            returnedMaybe.HasNoValue.Should().BeTrue();
        }

        [Fact]
        public async Task Tap_ValueTask_Right_executes_action_if_value()
        {
            Maybe<T> maybe = T.Value;

            var returnedMaybe = await maybe.Tap(value =>
            {
                value.Should().Be(T.Value);
                return ValueTask.CompletedTask;
            });

            maybe.Value.Should().Be(T.Value);
            returnedMaybe.Value.Should().BeSameAs(maybe.Value);
        }
    }
}
