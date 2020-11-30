using System;
using System.Collections.Generic;
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

        [Fact]
        public void Implicit_conversion_T_is_converted_to_Success_result_of_T()
        {
            string value = "result";

            Result<string> result = value;

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(value);
        }

        [Fact]
        public void Implicit_conversion_T_is_converted_to_Success_result_of_T_E()
        {
            string value = "result";

            Result<string, int> result = value;

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(value);
        }

        [Fact]
        public void Implicit_conversion_E_is_converted_to_Failure_result_of_T_E()
        {
            int value = 42;

            Result<string, int> result = value;

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(value);
        }

        [Fact]
        public void Result_of_dynamic_can_be_cast_as_dynamic_result()
        {
            dynamic value = "Test";
            dynamic result = Result.Success(value);

            var cast = (Result<dynamic>)result;

            string castValue = cast.Value;
            castValue.Should().Be(value);
        }

        [Fact]
        public void Result_TE_of_dynamic_can_be_cast_as_dynamic_result()
        {
            dynamic value = "Test";
            dynamic result = Result.Success<string, MyError>(value);

            var cast = (Result<dynamic, MyError>)result;

            string castValue = cast.Value;
            castValue.Should().Be(value);
        }

        private class MyError
        {
        }
    }
}
