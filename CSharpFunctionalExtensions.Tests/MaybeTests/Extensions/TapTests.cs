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

            var returnedMaybe = maybe.Tap(value => maybe = T.Value);

            maybe.HasNoValue.Should().BeTrue();
            returnedMaybe.Should().BeSameAs(maybe);
        }

        [Fact]
        public void Tap_executes_action_if_value()
        {
            Maybe<T> maybe = T.Value;

            var returnedMaybe = maybe.Tap(value => value.Should().Be(T.Value));

            maybe.Value.Should().Be(T.Value);
            returnedMaybe.Should().BeSameAs(maybe);
        }
    }
}
