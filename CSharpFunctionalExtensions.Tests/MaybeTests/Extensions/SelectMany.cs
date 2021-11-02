using CSharpFunctionalExtensions.Tests.ResultTests;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions;

public class SelectMany 
{
    [Fact]
    public void SelectMany_returns_no_value_if_maybe_has_no_value()
    {
        Maybe<int> maybe1 = 1;
        var maybe2 = Maybe<int>.None;

        var maybe3 = from a in maybe1 from b in maybe2 select a + b;

        maybe3.HasValue.Should().BeFalse();
    }

    [Fact]
    public void SelectMany_returns_projection_if_maybes_has_values()
    {
        Maybe<int> maybe1 = 1;
        Maybe<int> maybe2 = 2;

        var maybe3 = from a in maybe1 from b in maybe2 select a + b;

        maybe3.HasValue.Should().BeTrue();
        maybe3.Value.Should().Be(3);
    }

    [Fact]
    public void SelectMany_returns_new_maybe()
    {
        Maybe<MyClass> maybe = new MyClass { Property = "Some value" };

        Maybe<string> maybe2 = maybe.SelectMany(GetPropertyIfExists);

        maybe2.HasValue.Should().BeTrue();
        maybe2.Value.Should().Be("Some value");
    }

    [Fact]
    public void SelectMany_returns_no_value_if_internal_method_returns_no_value()
    {
        Maybe<MyClass> maybe = new MyClass { Property = null };

        Maybe<string> maybe2 = maybe.SelectMany(GetPropertyIfExists);

        maybe2.HasValue.Should().BeFalse();
    }
        
    private static Maybe<string> GetPropertyIfExists(MyClass Value)
    {
        return Value.Property;
    }
    
    private class MyClass
    {
        public string Property { get; set; }
    }
}