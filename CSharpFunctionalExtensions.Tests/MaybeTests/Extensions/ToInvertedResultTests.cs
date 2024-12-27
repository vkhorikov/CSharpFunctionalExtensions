using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class ToInvertedResultTests : MaybeTestBase
    {
        [Fact]
        public void ToInvertedResult_returns_failure_if_has_value()
        {
            var maybe = Maybe<T>.From(T.Value);

            var result = maybe.ToInvertedResult("Error");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Error");
        }
        
        [Fact]
        public void ToInvertedResult_returns_success_if_has_no_value()
        {
            Maybe<T> maybe = null;

            var result = maybe.ToInvertedResult("Error");

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void ToInvertedResult_returns_custom_failure_if_has_value()
        {
            var maybe = Maybe<T>.From(T.Value);

            var result = maybe.ToInvertedResult(E.Value);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value);
        }
        
        [Fact]
        public void ToInvertedResult_custom_failure_returns_success_if_has_no_value()
        {
            Maybe<T> maybe = null;

            var result = maybe.ToInvertedResult(E.Value);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void ToInvertedResult_returns_custom_failure_via_error_function_if_has_value()
        {
            Maybe<T> maybe = Maybe<T>.From(T.Value);

            var result = maybe.ToInvertedResult(ErrorFunc);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value);
            AssertErrorFuncCalled();
        }

        [Fact]
        public void ToInvertedResult_custom_failure_with_error_function_returns_success_if_has_no_value()
        {
            Maybe<T> maybe = null;

            var result = maybe.ToInvertedResult(ErrorFunc);

            result.IsSuccess.Should().BeTrue();
            AssertErrorFuncNotCalled();
        }
    }
}
