using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class SelectTests_Task
    {
        [Fact]
        public async Task Select_Task_returns_new_result()
        {
            Task<Result<MyClass>> result = Task.FromResult(Result.Success(new MyClass { Property = "Some value" }));

            Result<string> result2 = await result.Select(x => x.Property);

            result2.IsSuccess.Should().BeTrue();
            result2.Value.Should().Be("Some value");
        }

        [Fact]
        public async Task Select_Task_returns_failure_if_failure_passed_in()
        {
            Task<Result<MyClass>> result = Task.FromResult(Result.Failure<MyClass>("error message"));

            Result<MyClass> result2 = await result.Select(x => x);

            result2.IsSuccess.Should().BeFalse();
            result2.Error.Should().Be("error message");
        }

        [Fact]
        public async Task Select_Task_ResultTE_returns_new_result()
        {
            Task<Result<MyClass, string>> result = Task.FromResult(Result.Success<MyClass, string>(new MyClass { Property = "Some value" }));

            Result<string, string> result2 = await result.Select(x => x.Property);

            result2.IsSuccess.Should().BeTrue();
            result2.Value.Should().Be("Some value");
        }

        [Fact]
        public async Task Select_Task_ResultTE_returns_failure_if_failure_passed_in()
        {
            Task<Result<MyClass, string>> result = Task.FromResult(Result.Failure<MyClass, string>("error message"));

            Result<MyClass, string> result2 = await result.Select(x => x);

            result2.IsSuccess.Should().BeFalse();
            result2.Error.Should().Be("error message");
        }

        private class MyClass
        {
            public string Property { get; set; }
        }
    }
}
