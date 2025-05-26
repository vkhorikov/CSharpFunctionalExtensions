using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class TapTests_ValueTask_Left : MaybeTestBase
    {
        [Fact]
        public async Task Tap_ValueTask_Lef_does_not_execute_action_if_no_value()
        {
            Maybe<T> maybe = null;
            var executed = false;

            var returnedMaybe = await maybe.AsValueTask().Tap(value => executed = true);

            executed.Should().BeFalse();
            returnedMaybe.HasNoValue.Should().BeTrue();
        }

        [Fact]
        public async Task Tap_ValueTask_Lef_executes_action_if_value()
        {
            Maybe<T> maybe = T.Value;

            var returnedMaybe = await maybe.AsValueTask().Tap(value => value.Should().Be(T.Value));

            maybe.Value.Should().Be(T.Value);
            returnedMaybe.Value.Should().BeSameAs(maybe.Value);
        }
    }
}
