using System;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class ImplicitConversionTests
    {
        [Fact]
        public void Implicit_conversion_of_dynamic_result()
        {
            Result<dynamic> result = Result.Success<dynamic>((dynamic)"result");

            Type type = result.Value.GetType();
            type.Should().Be(typeof(string));
        }
    }
}
