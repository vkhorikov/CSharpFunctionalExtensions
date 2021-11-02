using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class BindTests : MaybeTestBase
    {
        [Fact]
        public void Bind_returns_no_value_if_initial_maybe_is_null()
        {
            Maybe<T> maybe = null;

            var maybe2 = maybe.Bind(ExpectAndReturnMaybe(null, T.Value));

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public void Bind_returns_no_value_if_selector_returns_null()
        {
            Maybe<T> maybe = T.Value;

            var maybe2 = maybe.Bind(ExpectAndReturn(T.Value, Maybe<T>.None));

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public void Bind_returns_value_if_selector_returns_value()
        {
            Maybe<T> maybe = T.Value;

            var maybe2 = maybe.Bind(ExpectAndReturnMaybe<T>(T.Value, T.Value));

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be(T.Value);
        }
    }
}