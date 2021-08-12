using FluentAssertions;
using System;
using Xunit;


namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class SucceededResultTests
    {
        [Fact]
        public void Can_create_a_non_generic_version()
        {
            Result result = Result.Success();

            result.IsFailure.Should().Be(false);
            result.IsSuccess.Should().Be(true);
        }

        [Fact]
        public void Can_create_a_generic_version()
        {
            var myClass = new MyClass();

            Result<MyClass> result = Result.Success(myClass);

            result.IsFailure.Should().Be(false);
            result.IsSuccess.Should().Be(true);
            result.Value.Should().Be(myClass);
        }

        [Fact]
        public void Can_create_a_unit_result()
        {
            UnitResult<MyErrorClass> result = Result.Success<MyErrorClass>();

            result.IsFailure.Should().Be(false);
            result.IsSuccess.Should().Be(true);
        }

        [Fact]
        public void Can_create_a_unit_result_using_UnitResult_entry_point()
        {
            UnitResult<MyErrorClass> result = UnitResult.Success<MyErrorClass>();

            result.IsFailure.Should().Be(false);
            result.IsSuccess.Should().Be(true);
        }

        [Fact]
        public void Can_create_a_generic_version_with_a_generic_error()
        {
            Can_create_a_generic_version_with_a_generic_error_typed<MyErrorClass>();
            Can_create_a_generic_version_with_a_generic_error_typed<MyErrorStruct>();
        }

        [Fact]
        public void Can_create_without_Value()
        {
            Result<MyClass> result = Result.Success((MyClass)null);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeNull();
        }

        [Fact]
        public void Cannot_access_Error_non_generic_version()
        {
            Result result = Result.Success();

            Action action = () =>
            {
                string error = result.Error;
            };

            action.Should().Throw<ResultSuccessException>();
        }

        [Fact]
        public void Cannot_access_Error_generic_version()
        {
            Result<MyClass> result = Result.Success(new MyClass());

            Action action = () =>
            {
                string error = result.Error;
            };

            action.Should().Throw<ResultSuccessException>();
        }

        [Fact]
        public void Cannot_access_Error_generic_error_version()
        {
            Result<MyClass, MyErrorClass> result = Result.Success<MyClass, MyErrorClass>(new MyClass());

            Action action = () =>
            {
                MyErrorClass error = result.Error;
            };

            action.Should().Throw<ResultSuccessException>();
        }

        [Fact]
        public void Cannot_access_Error_unit_result_version()
        {
            UnitResult<MyErrorClass> result = Result.Success<MyErrorClass>();

            Action action = () =>
            {
                MyErrorClass error = result.Error;
            };

            action.Should().Throw<ResultSuccessException>();
        }

        private void Can_create_a_generic_version_with_a_generic_error_typed<E>()
        {
            var myClass = new MyClass();

            Result<MyClass, E> result = Result.Success<MyClass, E>(myClass);

            result.IsFailure.Should().Be(false);
            result.IsSuccess.Should().Be(true);
            result.Value.Should().Be(myClass);
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
