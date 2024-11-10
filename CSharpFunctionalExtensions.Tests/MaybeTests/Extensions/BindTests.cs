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

        [Fact]
        public void Bind_provides_context_to_selector()
        {
            Maybe<T> maybe = T.Value;
            var context = 5;

            var maybe2 = maybe.Bind(
                (value, ctx) =>
                {
                    ctx.Should().Be(context);
                    return Maybe.From(value);
                },
                context
            );

            maybe2.HasValue.Should().BeTrue();
        }

        [Fact]
        public void Bind_with_context_returns_no_value_if_initial_maybe_is_null()
        {
            Maybe<T> maybe = null;

            var maybe2 = maybe.Bind(
                (value, _) => ExpectAndReturnMaybe(null, T.Value)(value),
                context: 5
            );

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public void Bind_with_context_returns_no_value_if_selector_returns_null()
        {
            Maybe<T> maybe = T.Value;

            var maybe2 = maybe.Bind(
                (value, _) => ExpectAndReturn(T.Value, Maybe<T>.None)(value),
                context: 5
            );

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public void Bind_with_context_returns_value_if_selector_returns_value()
        {
            Maybe<T> maybe = T.Value;

            var maybe2 = maybe.Bind(
                (value, _) => ExpectAndReturnMaybe<T>(T.Value, T.Value)(value),
                5
            );

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be(T.Value);
        }
    }
}
