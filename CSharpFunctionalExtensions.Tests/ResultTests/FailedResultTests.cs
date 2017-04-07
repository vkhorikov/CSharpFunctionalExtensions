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
            result.IsFailure.Should().Be(true);
            result.IsSuccess.Should().Be(false);
        }

        [Fact]
        public void Can_create_a_generic_version()
        {
            Result<MyClass> result = Result.Fail<MyClass>("Error message");

            result.Error.Should().Be("Error message");
            result.IsFailure.Should().Be(true);
            result.IsSuccess.Should().Be(false);
        }

        [Fact]
        public void Does_exception_overload_works_with_non_generic()
        {
            const string exceptionMessage = "message";
            Exception exception = new Exception(exceptionMessage);

            Result result = Result.Fail(exception);

            result.Error.Should().Contain(exceptionMessage);
            result.Exception.Should().Equals(exception);
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public void Does_exception_overload_works_with_generic()
        {
            const string exceptionMessage = "message";
            Exception exception = new Exception(exceptionMessage);

            Result<MyClass> result = Result.Fail<MyClass>(exception);

            result.Error.Should().Contain(exceptionMessage);
            result.Exception.Should().Equals(exception);
            result.IsSuccess.Should().BeFalse();
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
            Action action1 = () => { Result.Fail(exception: null); };
            Action action2 = () => { Result.Fail(string.Empty); };
            Action action3 = () => { Result.Fail<MyClass>(error: string.Empty); };            
            Action action4 = () => { Result.Fail<MyClass>(string.Empty); };
            Action action5 = () => { Result.Fail<MyClass>(exception: null); };

            action1.ShouldThrow<ArgumentNullException>();
            action2.ShouldThrow<ArgumentNullException>();
            action3.ShouldThrow<ArgumentNullException>();
            action4.ShouldThrow<ArgumentNullException>();
            action5.ShouldThrow<ArgumentNullException>();
        }

        private class MyClass
        {
        }
    }
}
