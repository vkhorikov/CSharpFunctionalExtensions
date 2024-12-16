using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class ToInvertedResultTests_Task : MaybeTestBase
    {
        [Fact]
        public async Task ToInvertedResult_Task_returns_failure_if_has_value()
        {
            var maybe = Maybe<T>.From(T.Value);

            var result = await maybe.AsTask().ToInvertedResult("Error");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Error");
        }
        
        [Fact]
        public async Task ToInvertedResult_Task_returns_success_if_has_no_value()
        {
            Maybe<T> maybe = null;

            var result = await maybe.AsTask().ToInvertedResult("Error");

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task ToInvertedResult_Task_returns_custom_failure_if_has_value()
        {
            var maybe = Maybe<T>.From(T.Value);

            var result = await maybe.AsTask().ToInvertedResult(E.Value);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value);
        }
        
        [Fact]
        public async Task ToInvertedResult_Task_custom_failure_returns_success_if_has_no_value()
        {
            Maybe<T> maybe = null;

            var result = await maybe.AsTask().ToInvertedResult(E.Value);

            result.IsSuccess.Should().BeTrue();
        }
    }
}
