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
        public void Cannot_access_Value_property()
        {
            Result<MyClass> result = Result.Fail<MyClass>("Error message");

            Action action = () => { MyClass myClass = result.Value; };

            action.ShouldThrow<ResultFailureException>();
        }

        [Fact]
        public void Cannot_access_Value_property_with_a_generic_error()
        {
            Result<MyClass, MyErrorClass> result = Result.Fail<MyClass, MyErrorClass>(new MyErrorClass());

            Action action = () => { MyClass myClass = result.Value; };

            action.ShouldThrow<ResultFailureException<MyErrorClass>>();
        }

        [Fact]
        public void Cannot_access_Error_property_with_a_generic_error()
        {
            Cannot_access_Error_property_with_a_generic_error_typed<MyErrorClass>();
            Cannot_access_Error_property_with_a_generic_error_typed<MyErrorStruct>();
        }

        [Fact]
        public void Cannot_create_without_error_message()
        {
            Action action1 = () => { Result.Fail(null); };
            Action action2 = () => { Result.Fail(string.Empty); };
            Action action3 = () => { Result.Fail<MyClass>(null); };
            Action action4 = () => { Result.Fail<MyClass>(string.Empty); };

            action1.ShouldThrow<ArgumentNullException>();
            action2.ShouldThrow<ArgumentNullException>();
            action3.ShouldThrow<ArgumentNullException>();
            action4.ShouldThrow<ArgumentNullException>();
        }

        private void Cannot_access_Error_property_with_a_generic_error_typed<E>()
        {
            Result<MyClass, E> result = Result.Ok<MyClass, E>(new MyClass());

            Action action = () => { E myErrorClass = result.Error; };

            action.ShouldThrow<ResultSuccessException>();
        }

        private class MyClass
        {
        }

        private class MyErrorClass
        {
        }

        private struct MyErrorStruct
        {
        }
    }
}
