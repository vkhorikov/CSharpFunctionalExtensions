using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class TapTests_ValueTask : MaybeTestBase
    {
        [Fact]
        public async Task Tap_ValueTask_does_not_execute_action_if_no_value()
        {
            Maybe<T> maybe = null;

            var returnedMaybe = await maybe
                .AsValueTask()
                .Tap(value =>
                {
                    maybe = T.Value;
                    return ValueTask.CompletedTask;
                });

            maybe.HasNoValue.Should().BeTrue();
            returnedMaybe.Should().BeSameAs(maybe);
        }

        [Fact]
        public async Task Tap_ValueTask_executes_action_if_value()
        {
            Maybe<T> maybe = T.Value;

            var returnedMaybe = await maybe
                .AsValueTask()
                .Tap(value =>
                {
                    value.Should().Be(T.Value);
                    return ValueTask.CompletedTask;
                });

            maybe.Value.Should().Be(T.Value);
            returnedMaybe.Should().BeSameAs(maybe);
        }
    }
}
