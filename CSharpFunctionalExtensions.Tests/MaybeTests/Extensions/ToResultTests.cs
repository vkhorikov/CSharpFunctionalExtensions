using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class ToResultTests : MaybeTestBase
    {
        [Fact]
        public void ToResult_returns_failure_if_has_no_value()
        {
            Maybe<T> maybe = null;

            var result = maybe.ToResult("Error");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Error");
        }

        [Fact]
        public void ToResult_returns_success_if_has_value()
        {
            var maybe = Maybe<T>.From(T.Value);

            var result = maybe.ToResult("Error");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(T.Value);
        }

        [Fact]
        public void ToResult_returns_custom_failure_if_has_no_value()
        {
            Maybe<T> maybe = null;

            var result = maybe.ToResult(E.Value);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value);
        }

        [Fact]
        public void ToResult_custom_failure_returns_success_if_has_value()
        {
            var maybe = Maybe<T>.From(T.Value);

            var result = maybe.ToResult(E.Value);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(T.Value);
        }

        [Fact]
        public void ToResult_returns_custom_failure_via_error_function_if_has_no_value()
        {
            Maybe<T> maybe = null;

            var result = maybe.ToResult(() => E.Value);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value);
        }

        [Fact]
        public void ToResult_custom_failure_with_error_function_returns_success_if_has_value()
        {
            var maybe = Maybe<T>.From(T.Value);

            var result = maybe.ToResult(() => E.Value);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(T.Value);
        }
    }
}
