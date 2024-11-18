using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions;
public class SelectTests
{
    [Fact]
    public void Select_returns_new_result()
    {
        Result<MyClass> result = new MyClass { Property = "Some value" };

        Result<string> result2 = result.Select(x => x.Property);

        result2.IsSuccess.Should().BeTrue();
        result2.GetValueOrDefault().Should().Be("Some value");
    }

    [Fact]
    public void Select_returns_no_value_if_no_value_passed_in()
    {
        Result<MyClass> result = Result.Failure<MyClass>("error message");

        Result<MyClass> result2 = result.Select(x => x);

        result2.IsSuccess.Should().BeFalse();
        result2.GetValueOrDefault().Should().Be(default);
    }

    [Fact]
    public void Result_Error_Select_from_class_to_struct_retains_Error()
    {
        Result.Failure<string>("error message").Select(_ => 42).IsSuccess.Should().BeFalse();
        Result.Failure<string>("error message").Select(_ => 42).Error.Should().Be("error message");
    }

    [Fact]
    public void Result_can_be_used_with_linq_query_syntax()
    {
        Result<string> name = "John";

        Result<string> upper = from x in name select x.ToUpper();

        upper.IsSuccess.Should().BeTrue();
        upper.GetValueOrDefault().Should().Be("JOHN");
    }

    private class MyClass
    {
        public string Property { get; set; }
    }
}
