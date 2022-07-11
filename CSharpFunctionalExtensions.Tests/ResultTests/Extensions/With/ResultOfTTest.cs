using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions.With
{
    public class ResultOfTTest
    {
        [Fact]
        public void Results_of_same_type_are_combined_correctly()
        {
            var r1 = Result.Success("Hello");
            var r2 = Result.Success("world");

            var actual = r1.With(r2);
            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(("Hello", "world"));
        }

        [Fact]
        public void Results_of_different_type_are_mapped_correctly()
        {
            var r1 = Result.Success("Hello");
            var r2 = Result.Success("world");

            var actual = r1.WithMap(r2, (a, b) => a + b);
            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be("Helloworld");
        }

        [Fact]
        public void Results_of_different_type_are_bound_correctly()
        {
            var r1 = Result.Success("Hello");
            var r2 = Result.Success("world");

            var actual = r1.WithBind(r2, (a, b) => Result.Success(a + b));
            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be("Helloworld");
        }
    }
}