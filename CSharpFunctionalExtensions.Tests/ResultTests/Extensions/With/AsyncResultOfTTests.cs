using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions.With
{
    public class AsyncResultOfTTests
    {
        [Fact]
        public async Task Successful_results_are_combined_with_mapping()
        {
            var r1 = Result.Success(1);
            var r2 = Result.Success("hola");

            var actual = await r1
                .WithMap(r2, (a, b) => Task.FromResult(a + b));

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be("1hola");
        }

        [Fact]
        public async Task Successful_results_are_combined_with_binding()
        {
            var r1 = Result.Success(1);
            var r2 = Result.Success("hola");

            var actual = await r1
                .WithBind(r2, (a, b) => Task.FromResult(Result.Success(a + b)));

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be("1hola");
        }

        [Fact]
        public async Task Successful_results_are_combined_into_success()
        {
            var r1 = Result.Success(1);
            var r2 = Result.Success("hola");

            var actual = await r1
                .WithBind(r2, (a, b) => Task.FromResult(Result.Success()));

            actual.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Failures_are_combined_into_failure()
        {
            var r1 = Result.Failure<int>("Failed");
            var r2 = Result.Success("hola");

            var actual = await r1
                .WithBind(r2, (a, b) => Task.FromResult(Result.Success()));

            actual.IsSuccess.Should().BeFalse();
        }
    }
}