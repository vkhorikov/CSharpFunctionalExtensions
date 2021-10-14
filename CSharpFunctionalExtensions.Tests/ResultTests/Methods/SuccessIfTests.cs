using FluentAssertions;
using System.Threading.Tasks;
using System;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Methods
{
    public class SuccessIfTests
    {
        [Fact]
        public void Create_value_is_null_Success_result_expected()
        {
            Result result = Result.SuccessIf<string>(true, null, null);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Create_error_is_null_Exception_expected()
        {
            var exception = Record.Exception(() =>
                Result.SuccessIf<string, string>(false, null, null));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void Create_error_is_default_Failure_result_expected()
        {
            Result<bool, int> result = Result.SuccessIf<bool, int>(false, false, 0);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(0);
        }

        [Fact]
        public void Create_argument_is_true_Success_result_expected()
        {
            Result result = Result.SuccessIf(true, string.Empty);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Create_argument_is_false_Failure_result_expected()
        {
            Result result = Result.SuccessIf(false, "simple result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("simple result error");
        }

        [Fact]
        public void Create_predicate_is_true_Success_result_expected()
        {
            Result result = Result.SuccessIf(() => true, string.Empty);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Create_predicate_is_false_Failure_result_expected()
        {
            Result result = Result.SuccessIf(() => false, "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }

        [Fact]
        public async Task Create_async_predicate_is_true_Success_result_expected()
        {
            Result result = await Result.SuccessIf(() => Task.FromResult(true), string.Empty);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Create_async_predicate_is_false_Failure_result_expected()
        {
            Result result = await Result.SuccessIf(() => Task.FromResult(false), "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }

        [Fact]
        public void Create_generic_argument_is_true_Success_result_expected()
        {
            byte val = 7;
            Result<byte> result = Result.SuccessIf(true, val, string.Empty);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public void Create_generic_argument_is_false_Failure_result_expected()
        {
            double val = .56;
            Result<double> result = Result.SuccessIf(false, val, "simple result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("simple result error");
        }

        [Fact]
        public void Create_generic_predicate_is_true_Success_result_expected()
        {
            DateTime val = new DateTime(2000, 1, 1);

            Result<DateTime> result = Result.SuccessIf(() => true, val, string.Empty);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public void Create_generic_predicate_is_false_Failure_result_expected()
        {
            string val = "string value";

            Result<string> result = Result.SuccessIf(() => false, val, "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }

        [Fact]
        public async Task Create_generic_async_predicate_is_true_Success_result_expected()
        {
            int val = 42;

            Result<int> result = await Result.SuccessIf(() => Task.FromResult(true), val, string.Empty);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public async Task Create_generic_async_predicate_is_false_Failure_result_expected()
        {
            bool val = true;

            Result<bool> result = await Result.SuccessIf(() => Task.FromResult(false), val, "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }

        private class Error
        {
        }

        [Fact]
        public void Create_error_generic_argument_is_true_Success_unit_result_expected()
        {
            UnitResult<Error> result = UnitResult.SuccessIf(true, new Error());

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Create_error_generic_argument_is_false_Failure_unit_result_expected()
        {
            var error = new Error();

            UnitResult<Error> result = UnitResult.SuccessIf(false, error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public void Create_error_generic_predicate_is_true_Success_unit_result_expected()
        {
            UnitResult<Error> result = UnitResult.SuccessIf(() => true, new Error());

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Create_error_generic_predicate_is_false_Failure_unit_result_expected()
        {
            var error = new Error();

            UnitResult<Error> result = UnitResult.SuccessIf(() => false, error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public async Task Create_error_generic_async_predicate_is_true_Success_unit_result_expected()
        {
            UnitResult<Error> result = await UnitResult.SuccessIf(() => Task.FromResult(true), new Error());

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Create_error_generic_async_predicate_is_false_Failure_unit_result_expected()
        {
            var error = new Error();

            UnitResult<Error> result = await UnitResult.SuccessIf(() => Task.FromResult(false), error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public void Create_error_generic_argument_is_true_Success_result_expected()
        {
            byte val = 7;
            Result<byte, Error> result = Result.SuccessIf(true, val, new Error());

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public void Create_error_generic_argument_is_false_Failure_result_expected()
        {
            double val = .56;
            var error = new Error();

            Result<double, Error> result = Result.SuccessIf(false, val, error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public void Create_error_generic_predicate_is_true_Success_result_expected()
        {
            DateTime val = new DateTime(2000, 1, 1);

            Result<DateTime, Error> result = Result.SuccessIf(() => true, val, new Error());

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public void Create_error_generic_predicate_is_false_Failure_result_expected()
        {
            string val = "string value";
            var error = new Error();

            Result<string, Error> result = Result.SuccessIf(() => false, val, error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public async Task Create_error_generic_async_predicate_is_true_Success_result_expected()
        {
            int val = 42;

            Result<int, Error> result = await Result.SuccessIf(() => Task.FromResult(true), val, new Error());

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public async Task Create_error_generic_async_predicate_is_false_Failure_result_expected()
        {
            bool val = true;
            var error = new Error();

            Result<bool, Error> result = await Result.SuccessIf(() => Task.FromResult(false), val, error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }
    }
}
