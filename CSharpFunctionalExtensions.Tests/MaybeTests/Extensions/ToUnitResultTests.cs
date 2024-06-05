using System;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class ToUnitResultTests : MaybeTestBase
    {
        [Fact]
        public void ToUnitResult_returns_failure_if_has_error_value()
        {
            var maybe = Maybe<E>.From(E.Value);

            var result = maybe.ToUnitResult();

            result.IsFailure.Should().BeTrue();
        }

        [Fact]
        public void ToUnitResult_returns_success_if_has_no_error_value()
        {
            Maybe<E> maybe = null;

            var result = maybe.ToUnitResult();

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void ToUnitResult_returns_failure_if_has_no_value()
        {
            Maybe<T> maybe = null;

            var result = maybe.ToUnitResult("Error");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Error");
        }

        [Fact]
        public void ToUnitResult_returns_success_if_has_value()
        {
            var maybe = Maybe<T>.From(T.Value);

            var result = maybe.ToUnitResult("Error");

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void ToUnitResult_returns_custom_failure_if_has_no_value()
        {
            Maybe<T> maybe = null;

            var result = maybe.ToUnitResult(E.Value);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value);
        }

        [Fact]
        public void ToUnitResult_custom_failure_returns_success_if_has_value()
        {
            var maybe = Maybe<T>.From(T.Value);

            var result = maybe.ToUnitResult(E.Value);

            result.IsSuccess.Should().BeTrue();
        }
    }
}
