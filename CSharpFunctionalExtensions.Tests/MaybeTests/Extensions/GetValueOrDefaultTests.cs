using CSharpFunctionalExtensions.Tests.ResultTests;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions;

public class GetValueOrDefaultTests : TestBase
{
    
    [Fact]
    public void GetValueOrDefault_extracts_value_if_not_null()
    {
        Maybe<T> maybe = T.Value;

        T myClass = maybe.GetValueOrDefault();

        myClass.Should().Be(T.Value);
    }

    [Fact]
    public void GetValueOrDefault_extracts_null_if_no_value()
    {
        Maybe<T> maybe = null;

        T myClass = maybe.GetValueOrDefault();

        myClass.Should().BeNull();
    }

    [Fact]
    public void Can_use_selector_in_GetValueOrDefault()
    {
        Maybe<MyClass> maybe = new MyClass { Property = "Some value" };

        string value = maybe.GetValueOrDefault(x => x.Property);

        value.Should().Be("Some value");
    }

    [Fact]
    public void Can_use_default_value_in_GetValueOrDefault()
    {
        Maybe<string> maybe = null;

        string value = maybe.GetValueOrDefault("");

        value.Should().Be("");
    }
    
    private class MyClass
    {
        public string Property { get; set; }
    }
}