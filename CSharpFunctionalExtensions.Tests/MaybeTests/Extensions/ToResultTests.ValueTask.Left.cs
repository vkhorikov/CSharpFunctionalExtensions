using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class ToResultTests_ValueTask_Left : MaybeTestBase
    {
        [Fact]
        public async Task ToResult_ValueTask_Left_returns_failure_if_has_no_value()
        {
            Maybe<T> maybe = null;

            var result = await maybe.AsValueTask().ToResult("Error");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Error");
        }

        [Fact]
        public async Task ToResult_ValueTask_Left_returns_success_if_has_value()
        {
            var maybe = Maybe<T>.From(T.Value);

            var result = await maybe.AsValueTask().ToResult("Error");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(T.Value);
        }

        [Fact]
        public async Task ToResult_ValueTask_Left_returns_custom_failure_if_has_no_value()
        {
            Maybe<T> maybe = null;

            var result = await maybe.AsValueTask().ToResult(E.Value);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value);
        }

        [Fact]
        public async Task ToResult_ValueTask_Left_custom_failure_returns_success_if_has_value()
        {
            var maybe = Maybe<T>.From(T.Value);

            var result = await maybe.AsValueTask().ToResult(E.Value);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(T.Value);
        }
    }
}