using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions.With
{
    public class ResultOfTETests
    {
        [Fact]
        public async void Successful_results_are_combined_with_map()
        {
            var r1 = Result.Success<int, string>(1);
            var r2 = Result.Success<int, string>(2);

            var actual = r1.WithMap(r2, (a, b) => a + b, (e1, e2) => "");

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(3);
        }

        [Fact]
        public async void Successful_results_are_combined_with_binding()
        {
            var r1 = Result.Success<int, string>(1);
            var r2 = Result.Success<int, string>(2);

            var actual = r1.WithBind<int, string>(r2, (a, b) => Result.Success<int, string>(a + b), (e1, e2) => "");

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(3);
        }

        [Fact]
        public async void Successful_results_are_combined_with_binding_different_types()
        {
            var r1 = Result.Success<string, string>("Hi");
            var r2 = Result.Success<int, string>(2);

            var actual = r1.WithBind(r2, (a, b) => Result.Success<string, string>(a + b), (e1, e2) => "");

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be("Hi2");
        }
    }
}