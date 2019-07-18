﻿using System;
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
        public void Can_create_a_generic_version_with_a_generic_error()
        {
            var myClass = new MyClass();

            Result<MyClass, MyClass> result = Result.Ok<MyClass, MyClass>(myClass);

            result.IsFailure.Should().Be(false);
            result.IsSuccess.Should().Be(true);
            result.Value.Should().Be(myClass);
        }

        [Fact]
        public void Can_create_without_Value()
        {
            Result<MyClass> result = Result.Ok((MyClass)null);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeNull();
        }

        [Fact]
        public void Cannot_access_Error_non_generic_version()
        {
            Result result = Result.Ok();

            Action action = () =>
            {
                string error = result.Error;
            };

            action.ShouldThrow<ResultSuccessException>();
        }

        [Fact]
        public void Cannot_access_Error_generic_version()
        {
            Result<MyClass> result = Result.Ok(new MyClass());

            Action action = () =>
            {
                string error = result.Error;
            };

            action.ShouldThrow<ResultSuccessException>();
        }

        [Fact]
        public void Cannot_access_Error_generic_error_version()
        {
            Result<MyClass, MyErrorClass> result = Result.Ok<MyClass, MyErrorClass>(new MyClass());

            Action action = () =>
            {
                MyErrorClass error = result.Error;
            };

            action.ShouldThrow<ResultSuccessException>();
        }


        private class MyClass
        {
        }

        private class MyErrorClass
        {
        }
    }
}
