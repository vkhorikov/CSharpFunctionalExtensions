using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class TapTests : MaybeTestBase
    {
        [Fact]
        public void Tap_does_not_execute_action_if_no_value()
        {
            Maybe<T> maybe = null;
            var executed = false;

            var returnedMaybe = maybe.Tap(value => executed = true);

            executed.Should().BeFalse();
            returnedMaybe.HasNoValue.Should().BeTrue();
        }

        [Fact]
        public void Tap_executes_action_if_value()
        {
            Maybe<T> maybe = T.Value;

            var returnedMaybe = maybe.Tap(value => value.Should().Be(T.Value));

            maybe.Value.Should().Be(T.Value);
            returnedMaybe.Value.Should().BeSameAs(maybe.Value);
        }
    }
}
