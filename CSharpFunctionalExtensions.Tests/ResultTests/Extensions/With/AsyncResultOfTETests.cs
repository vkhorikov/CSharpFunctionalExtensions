using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions.With
{
    public class AsyncResultOfTETests
    {
        [Fact]
        public async Task Combining_successful()
        {
            var r1 = Result.Success<int, string>(1);
            var r2 = Result.Success<int, string>(2);
            var actual = await r1.WithMap(r2, (a, b) => Task.FromResult(a + b), (e1, e2) => "failure");

            actual.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Successful_results_are_combined_with_binding()
        {
            var r1 = Result.Success<int, string>(1);
            var r2 = Result.Success<int, string>(2);

            var actual = await r1
                .WithBind(r2, (a, b) => Task.FromResult(Result.Success<int, string>(a + b)), (e1, e2) => "error");

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(3);
        }
    }
}