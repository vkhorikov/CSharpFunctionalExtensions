using CSharpFunctionalExtensions.Tests.ResultTests;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions;

public class GetValueOrDefaultTests : TestBase
{

    [Fact]
    public void GetValueOrDefault_extracts_value_if_not_null()
    {
        Result<T> result = T.Value;

        T myClass = result.GetValueOrDefault();

        myClass.Should().Be(T.Value);
    }

    [Fact]
    public void GetValueOrDefault_extracts_null_if_no_value()
    {
        Result<T> result = null;

        T myClass = result.GetValueOrDefault();

        myClass.Should().BeNull();
    }

    [Fact]
    public void Can_use_selector_in_GetValueOrDefault()
    {
        Result<MyClass> result = new MyClass { Property = "Some value" };

        string value = result.GetValueOrDefault(x => x.Property);

        value.Should().Be("Some value");
    }

    [Fact]
    public void Can_use_default_value_in_GetValueOrDefault()
    {
        Result<string> result = null;

        string value = result.GetValueOrDefault("");

        value.Should().Be("");
    }

    private class MyClass
    {
        public string Property { get; set; }
    }
}
