using System;
using FluentAssertions;
using Xunit;


namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class SucceededResultTests
    {
        [Fact]
        public void Can_create_a_non_generic_version()
        {
            Result result = Result.Ok();

            result.Error.Should().BeEmpty();
            result.IsFailure.Should().Be(false);
            result.IsSuccess.Should().Be(true);
        }

        [Fact]
        public void Can_create_a_generic_version()
        {
            var myClass = new MyClass();

            Result<MyClass> result = Result.Ok(myClass);

            result.Error.Should().BeEmpty();
            result.IsFailure.Should().Be(false);
            result.IsSuccess.Should().Be(true);
            result.Value.Should().Be(myClass);
        }

        [Fact]
        public void Cannot_create_without_Value()
        {
            Action action = () => { Result.Ok((MyClass)null); };

            action.ShouldThrow<InvalidOperationException>();;
        }


        private class MyClass
        {
        }
    }
}
