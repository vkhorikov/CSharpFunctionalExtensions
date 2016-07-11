using System;
using FluentAssertions;
using Xunit;


namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class FailedResultTests
    {
        [Fact]
        public void Can_create_a_non_generic_version()
        {
            Result result = Result.Fail("Error message");

            result.Error.Should().Be("Error message");
            result.PrivateError.Should().Be("Error message");
            result.IsFailure.Should().Be(true);
            result.IsSuccess.Should().Be(false);
        }

        [Fact]
        public void Can_create_a_non_generic_version_with_different_private_error()
        {
            Result result = Result.Fail("Error message", "Private error message");

            result.Error.Should().Be("Error message");
            result.PrivateError.Should().Be("Private error message");
            result.IsFailure.Should().Be(true);
            result.IsSuccess.Should().Be(false);
        }

        [Fact]
        public void Can_create_a_non_generic_version_from_exception()
        {
            var ex = new Exception("Exception message");

            Result result = Result.Fail(ex);

            result.Error.Should().Be("Exception message");
            result.PrivateError.Should().Be(ex.ToString());
            result.IsFailure.Should().Be(true);
            result.IsSuccess.Should().Be(false);
        }

        [Fact]
        public void Can_create_a_generic_version()
        {
            Result<MyClass> result = Result.Fail<MyClass>("Error message");

            result.Error.Should().Be("Error message");
            result.PrivateError.Should().Be("Error message");
            result.IsFailure.Should().Be(true);
            result.IsSuccess.Should().Be(false);
        }

        [Fact]
        public void Can_create_a_generic_version_with_different_private_error()
        {
            Result<MyClass> result = Result.Fail<MyClass>("Error message", "Private error message");

            result.Error.Should().Be("Error message");
            result.PrivateError.Should().Be("Private error message");
            result.IsFailure.Should().Be(true);
            result.IsSuccess.Should().Be(false);
        }

        [Fact]
        public void Can_create_a_generic_version_from_exception()
        {
            var ex = new Exception("Exception message");

            Result<MyClass> result = Result.Fail<MyClass>(ex);

            result.Error.Should().Be("Exception message");
            result.PrivateError.Should().Be(ex.ToString());
            result.IsFailure.Should().Be(true);
            result.IsSuccess.Should().Be(false);
        }

        [Fact]
        public void Cannot_access_Value_property()
        {
            Result<MyClass> result = Result.Fail<MyClass>("Error message");

            Action action = () => { MyClass myClass = result.Value; };

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Cannot_create_without_error_message()
        {
            Action action1 = () => { Result.Fail((string)null); };
            Action action2 = () => { Result.Fail(string.Empty); };
            Action action3 = () => { Result.Fail<MyClass>((string)null); };
            Action action4 = () => { Result.Fail<MyClass>(string.Empty); };

            action1.ShouldThrow<ArgumentNullException>();
            action2.ShouldThrow<ArgumentNullException>();
            action3.ShouldThrow<ArgumentNullException>();
            action4.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Cannot_create_without_exception()
        {
            Action action1 = () => { Result.Fail((Exception)null); };
            Action action2 = () => { Result.Fail<MyClass>((Exception)null); };

            action1.ShouldThrow<ArgumentNullException>();
            action2.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Can_create_a_non_generic_version_from_action_throwing_exception()
        {
            Result result = Result.FailOnException(() => { throw new Exception("Exception message"); });

            result.Error.Should().Be("Exception message");
            result.IsFailure.Should().Be(true);
            result.IsSuccess.Should().Be(false);
        }

        [Fact]
        public void Can_create_a_generic_version_from_function_throwing_exception()
        {
            Result<MyClass> result = Result.FailOnException<MyClass>(() => { throw new Exception("Exception message"); });

            result.Error.Should().Be("Exception message");
            result.IsFailure.Should().Be(true);
            result.IsSuccess.Should().Be(false);
        }

        private class MyClass
        {
        }
    }
}
