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
        public void Implicit_conversion_E_is_converted_to_Failure_unit_result_of_E()
        {
            int error = 42;

            UnitResult<int> result = error;

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(42);
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
        public void Value_in_Result_TE_can_be_cast_to_dynamic()
        {
            dynamic value = "Test";
            dynamic result = Result.Success<string, MyError>(value);

            var cast = (Result<dynamic, MyError>)result;

            string castValue = cast.Value;
            castValue.Should().Be(value);
        }

        [Fact]
        public void Result_can_be_cast_to_UnitResult()
        {
            Result result = Result.Failure("Error");

            UnitResult<string> unitResult = result;

            unitResult.IsFailure.Should().BeTrue();
            unitResult.Error.Should().Be("Error");
        }

        [Fact]
        public void Result_T_can_be_cast_to_UnitResult()
        {
            Result<MyClass> result = Result.Failure<MyClass>("Error");

            UnitResult<string> unitResult = result;

            unitResult.IsFailure.Should().BeTrue();
            unitResult.Error.Should().Be("Error");
        }

        [Fact]
        public void Result_TE_can_be_cast_to_UnitResult()
        {
            var error = new MyError();
            Result<MyClass, MyError> result = Result.Failure<MyClass, MyError>(error);

            UnitResult<MyError> unitResult = result;

            unitResult.IsFailure.Should().BeTrue();
            unitResult.Error.Should().Be(error);
        }

        [Fact]
        public void Error_in_Result_TE_can_be_cast_to_dynamic()
        {
            dynamic error = new MyError();
            dynamic result = Result.Failure<string, MyError>(error);

            var cast = (Result<string, dynamic>)result;

            MyError castError = cast.Error;
            castError.Should().Be(error);
        }

        [Fact]
        public void IResult_T_can_be_used_covariantly()
        {
            IResult<ICovariantResult> covariantResult = GetCovariantResultT();
            Assert.IsType<CovariantResult>(covariantResult.Value);
        }

        [Fact]
        public void Value_in_IResult_TE_value_can_be_used_covariantly()
        {
            IResult<ICovariantResult, IMyError> covariantResult = GetCovariantSuccessResultTE();
            Assert.IsType<CovariantResult>(covariantResult.Value);
        }

        [Fact]
        public void Error_in_IResult_TE_can_be_used_covariantly()
        {
            IResult<ICovariantResult, IMyError> covariantResult = GetCovariantFailureResultTE();
            Assert.IsType<MyError>(covariantResult.Error);
        }

        private static IResult<ICovariantResult> GetCovariantResultT()
        {
            return Result.Success(new CovariantResult());
        }

        private static IResult<ICovariantResult, IMyError> GetCovariantSuccessResultTE()
        {
            return Result.Success<CovariantResult, MyError>(new CovariantResult());
        }

        private static IResult<ICovariantResult, IMyError> GetCovariantFailureResultTE()
        {
            return Result.Failure<CovariantResult, MyError>(new MyError());
        }

        private interface ICovariantResult
        { 
        }

        private interface IMyError
        {
        }

        private class CovariantResult : ICovariantResult
        {
        }

        private class MyError : IMyError
        {
        }

        private class MyClass
        {
        }
    }
}
