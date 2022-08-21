using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions;

public class SelectTests
{
    [Fact]
    public void Select_returns_new_maybe()
    {
        Maybe<MyClass> maybe = new MyClass { Property = "Some value" };

        Maybe<string> maybe2 = maybe.Select(x => x.Property);

        maybe2.HasValue.Should().BeTrue();
        maybe2.Value.Should().Be("Some value");
    }

    [Fact]
    public void Select_returns_no_value_if_no_value_passed_in()
    {
        Maybe<MyClass> maybe = null;

        Maybe<string> maybe2 = maybe.Select(x => x.Property);

        maybe2.HasValue.Should().BeFalse();
    }
    
    private class MyClass
    {
        public string Property { get; set; }
    }
}