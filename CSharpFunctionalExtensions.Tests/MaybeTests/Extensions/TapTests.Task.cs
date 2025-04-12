using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class TapTests_Task : MaybeTestBase
    {
        [Fact]
        public async Task Tap_Task_does_not_execute_action_if_no_value()
        {
            Maybe<T> maybe = null;

            var returnedMaybe = await maybe
                .AsTask()
                .Tap(value =>
                {
                    maybe = T.Value;
                    return Task.CompletedTask;
                });

            maybe.HasNoValue.Should().BeTrue();
            returnedMaybe.Should().BeSameAs(maybe);
        }

        [Fact]
        public async Task Tap_Task_executes_action_if_value()
        {
            Maybe<T> maybe = T.Value;

            var returnedMaybe = await maybe
                .AsTask()
                .Tap(value =>
                {
                    value.Should().Be(T.Value);
                    return Task.CompletedTask;
                });

            maybe.Value.Should().Be(T.Value);
            returnedMaybe.Should().BeSameAs(maybe);
        }
    }
}
