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

            result.IsFailure.Should().Be(false);
            result.IsSuccess.Should().Be(true);
        }

        [Fact]
        public void Can_create_a_generic_version()
        {
            var myClass = new MyClass();

            Result<MyClass> result = Result.Ok(myClass);

            result.IsFailure.Should().Be(false);
            result.IsSuccess.Should().Be(true);
            result.Value.Should().Be(myClass);
        }

        [Fact]
        public void Cannot_create_without_Value()
        {
            Action action = () => { Result.Ok((MyClass)null); };

            action.ShouldThrow<ArgumentNullException>();;
        }

        [Fact]
        public void Cannot_access_Errors_non_generic_version()
        {
            Result result = Result.Ok();

            Action action1 = () => { string error = result.Error; };
            Action action2 = () => { string error = result.PrivateError; };

            action1.ShouldThrow<InvalidOperationException>();
            action2.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Cannot_access_Errors_generic_version()
        {
            Result<MyClass> result = Result.Ok(new MyClass());

            Action action1 = () => { string error = result.Error; };
            Action action2 = () => { string error = result.PrivateError; };

            action1.ShouldThrow<InvalidOperationException>();
            action2.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Can_create_a_non_generic_version_from_Action()
        {
            Result result = Result.FailOnException(() => { });

            result.IsFailure.Should().Be(false);
            result.IsSuccess.Should().Be(true);
        }

        [Fact]
        public void Can_create_a_generic_version_from_function()
        {
            var myClass = new MyClass();

            Result<MyClass> result = Result.FailOnException(() => myClass);

            result.IsFailure.Should().Be(false);
            result.IsSuccess.Should().Be(true);
            result.Value.Should().Be(myClass);
        }

        private class MyClass
        {
        }
    }
}
