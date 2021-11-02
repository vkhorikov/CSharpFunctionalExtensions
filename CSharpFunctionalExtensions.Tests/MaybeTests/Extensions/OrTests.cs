using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class OrTests : MaybeTestBase
    {
        [Fact]
        public void Or_fallback_value_returns_source_if_source_has_value()
        {
            Maybe<T> maybe = T.Value;

            var orMaybe = maybe.Or(T.Value2);

            orMaybe.HasValue.Should().BeTrue();
            orMaybe.Should().Be(T.Value);
        }

        [Fact]
        public void Or_fallback_value_returns_a_new_instance_with_value_when_source_is_empty()
        {
            var maybeTask = Maybe<T>.None;

            var orMaybe = maybeTask.Or(T.Value2);

            orMaybe.HasValue.Should().BeTrue();
            orMaybe.Should().Be(T.Value2);
        }
        
                [Fact]
        public void Or_fallback_value_returns_none_if_source_and_fallback_are_none()
        {
            string value = null;

            Maybe<string> maybe = Maybe<string>.None;

            var orMaybe = maybe.Or(value);

            orMaybe.HasValue.Should().BeFalse();
        }

        [Fact]
        public void Or_fallback_value_creates_a_new_instance_with_fallback_when_source_is_empty()
        {
            Maybe<string> maybe = Maybe<string>.None;

            var orMaybe = maybe.Or("other");

            orMaybe.HasValue.Should().BeTrue();
            orMaybe.Should().NotBe(maybe);
        }



        [Fact]
        public void Or_fallback_operation_returns_source_if_source_has_value()
        {
            Maybe<string> maybe = "value";

            var orMaybe = maybe.Or(() => "other");

            orMaybe.HasValue.Should().BeTrue();
            orMaybe.Should().Be(maybe);
        }

        [Fact]
        public void Or_fallback_operation_creates_a_new_instance_with_fallback_operation_when_source_is_empty()
        {
            Maybe<string> maybe = Maybe<string>.None;

            var orMaybe = maybe.Or(() => "other");

            orMaybe.HasValue.Should().BeTrue();
            orMaybe.Should().NotBe(maybe);
        }


        [Fact]
        public void Or_fallback_maybe_returns_source_if_source_has_value()
        {
            Maybe<string> maybe = "value";

            var orMaybe = maybe.Or(Maybe.From("other"));

            orMaybe.HasValue.Should().BeTrue();
            orMaybe.Should().Be(maybe);
        }

        [Fact]
        public void Or_fallback_maybe_returns_fallback_when_source_is_empty()
        {
            Maybe<string> maybe = Maybe<string>.None;

            var orMaybe = maybe.Or(Maybe.From("other"));

            orMaybe.HasValue.Should().BeTrue();
            orMaybe.Should().NotBe(maybe);
        }

        [Fact]
        public void Or_fallback_maybe_operation_returns_source_if_source_has_value()
        {
            Maybe<string> maybe = "value";

            var orMaybe = maybe.Or(() => Maybe.From("other"));

            orMaybe.HasValue.Should().BeTrue();
            orMaybe.Should().Be(maybe);
        }

        [Fact]
        public void Or_fallback_maybe_operation_returns_fallback_when_source_is_empty()
        {
            Maybe<string> maybe = Maybe<string>.None;

            var orMaybe = maybe.Or(() => Maybe.From("other"));

            orMaybe.HasValue.Should().BeTrue();
            orMaybe.Should().NotBe(maybe);
        }
    }
}