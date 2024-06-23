using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class ToUnitResultTests_Task : MaybeTestBase
    {
        [Fact]
        public async Task ToUnitResult_Task_returns_failure_if_has_error_value()
        {
            var maybe = Maybe<E>.From(E.Value);

            var result = await maybe.AsTask().ToUnitResult();

            result.IsFailure.Should().BeTrue();
        }

        [Fact]
        public async Task ToUnitResult_Task_returns_success_if_has_no_error_value()
        {
            Maybe<E> maybe = null;

            var result = await maybe.AsTask().ToUnitResult();

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task ToUnitResult_Task_returns_failure_if_has_no_value()
        {
            Maybe<T> maybe = null;

            var result = await maybe.AsTask().ToUnitResult("Error");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Error");
        }

        [Fact]
        public async Task ToUnitResult_Task_returns_success_if_has_value()
        {
            var maybe = Maybe<T>.From(T.Value);

            var result = await maybe.AsTask().ToUnitResult("Error".AsTask());

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task ToUnitResult_Task_returns_custom_failure_if_has_no_value()
        {
            Maybe<T> maybe = null;

            var result = await maybe.AsTask().ToUnitResult(E.Value);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value);
        }

        [Fact]
        public async Task ToUnitResult_Task_custom_failure_returns_success_if_has_value()
        {
            var maybe = Maybe<T>.From(T.Value);

            var result = await maybe.AsTask().ToUnitResult(E.Value.AsTask());

            result.IsSuccess.Should().BeTrue();
        }
    }
}
