using Xunit;
using FluentAssertions;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions;

public class AsMaybeTests : TestBase
{
    [Fact]
    public void Error_returns_None()
    {
        var result = Result.Failure<T>(ErrorMessage);
        result.AsMaybe().HasValue.Should().BeFalse();
    }
    
    [Fact]
    public void Success_returns_Some()
    {
        var result = Result.Success(T.Value);
        var asMaybe = result.AsMaybe();
        
        asMaybe.HasValue.Should().BeTrue();
        asMaybe.Value.Should().Be(T.Value);
    }
    
    [Fact]
    public void Null_value_returns_None()
    {
        var result = Result.Success<T>(null);
        var asMaybe = result.AsMaybe();
        
        asMaybe.HasValue.Should().BeFalse();
    }
}


