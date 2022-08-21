using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class EnsureTests : TestBase
    {
        [Fact]
        public void Ensure_source_result_is_failure_predicate_do_not_invoked_expect_is_result_failure()
        {
            Result sut = Result.Failure("some error");

            Result result = sut.Ensure(() => true, string.Empty);

            result.Should().Be(sut);
        }

        [Fact]
        public void Ensure_source_result_is_success_predicate_is_failed_expected_result_failure()
        {
            Result sut = Result.Success();

            Result result = sut.Ensure(() => false, "predicate failed");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate failed");
        }

        [Fact]
        public void Ensure_source_result_is_success_predicate_is_passed_expected_result_success()
        {
            Result sut = Result.Success();

            Result result = sut.Ensure(() => true, string.Empty);

            result.Should().Be(sut);
        }

        [Fact]
        public async Task Ensure_source_result_is_failure_async_predicate_do_not_invoked_expect_is_result_failure()
        {
            Result sut = Result.Failure("some error");

            Result result = await sut.Ensure(() => Task.FromResult(true), string.Empty);

            result.Should().Be(sut);
        }

        [Fact]
        public async Task Ensure_source_result_is_success_async_predicate_is_failed_expected_result_failure()
        {
            Result sut = Result.Success();

            Result result = await sut.Ensure(() => Task.FromResult(false), "predicate problems");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate problems");
        }

        [Fact]
        public async Task Ensure_source_result_is_success_async_predicate_is_passed_expected_result_success()
        {
            Result sut = Result.Success();

            Result result = await sut.Ensure(() => Task.FromResult(true), string.Empty);

            result.Should().Be(sut);
        }

        [Fact]
        public async Task Ensure_task_source_result_is_success_predicate_is_passed_error_predicate_is_not_invoked()
        {
            Task<Result<int?>> sut = Task.FromResult(Result.Success<int?>(null));

            Result<int?> result = await sut.Ensure(value => !value.HasValue,
                value => Task.FromResult($"should be null but found {value.Value}"));

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task Ensure_task_source_result_is_failure_predicate_do_not_invoked_expect_is_result_failure()
        {
            Task<Result> sut = Task.FromResult(Result.Failure("some error"));

            Result result = await sut.Ensure(() => true, string.Empty);

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task Ensure_task_source_result_is_success_predicate_is_failed_expected_result_failure()
        {
            Task<Result> sut = Task.FromResult(Result.Success());

            Result result = await sut.Ensure(() => false, "predicate problems");

            result.Should().NotBe(sut.Result);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate problems");
        }

        [Fact]
        public async Task Ensure_task_source_result_is_success_predicate_is_passed_expected_result_success()
        {
            Task<Result> sut = Task.FromResult(Result.Success());

            Result result = await sut.Ensure(() => true, string.Empty);

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task Ensure_task_source_result_is_failure_async_predicate_do_not_invoked_expect_is_result_failure()
        {
            Task<Result> sut = Task.FromResult(Result.Failure("some error"));

            Result result = await sut.Ensure(() => Task.FromResult(false), string.Empty);

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task Ensure_task_source_result_is_success_async_predicate_is_failed_expected_result_failure()
        {
            Task<Result> sut = Task.FromResult(Result.Success());

            Result result = await sut.Ensure(() => Task.FromResult(false), "predicate problems");

            result.Should().NotBe(sut.Result);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate problems");
        }

        [Fact]
        public async Task Ensure_task_source_result_is_success_async_predicate_is_passed_expected_result_success()
        {
            Task<Result> sut = Task.FromResult(Result.Success());

            Result result = await sut.Ensure(() => Task.FromResult(true), string.Empty);

            result.Should().Be(sut.Result);
        }

        [Fact]
        public void Ensure_generic_source_result_is_failure_predicate_do_not_invoked_expect_is_error_result_failure()
        {
            Result<TimeSpan> sut = Result.Failure<TimeSpan>("some error");

            Result<TimeSpan> result = sut.Ensure(time => true, "test error");

            result.Should().Be(sut);
        }

        [Fact]
        public void Ensure_generic_source_result_is_success_predicate_is_failed_expected_error_result_failure()
        {
            Result<int> sut = Result.Success(10101);

            Result<int> result = sut.Ensure(i => false, "test error");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("test error");
        }

        [Fact]
        public void Ensure_generic_source_result_is_success_predicate_is_passed_expected_error_result_success()
        {
            Result<decimal> sut = Result.Success(.03m);

            Result<decimal> result = sut.Ensure(d => true, "test error");

            result.Should().Be(sut);
        }

        [Fact]
        public async Task
            Ensure_generic_source_result_is_failure_async_predicate_do_not_invoked_expect_is_error_result_failure()
        {
            Result<DateTimeOffset> sut = Result.Failure<DateTimeOffset>("some result error");

            Result<DateTimeOffset> result = await sut.Ensure(d => Task.FromResult(true), "test ensure error");

            result.Should().Be(sut);
        }

        [Fact]
        public async Task
            Ensure_generic_source_result_is_success_async_predicate_is_failed_expected_error_result_failure()
        {
            Result<int> sut = Result.Success(333);

            Result<int> result = await sut.Ensure(i => Task.FromResult(false), "test ensure error");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("test ensure error");
        }

        [Fact]
        public async Task
            Ensure_generic_source_result_is_success_async_predicate_is_passed_expected_error_result_success()
        {
            Result<decimal> sut = Result.Success(.33m);

            Result<decimal> result = await sut.Ensure(d => Task.FromResult(true), "test error");

            result.Should().Be(sut);
        }

        [Fact]
        public async Task
            Ensure_generic_task_source_result_is_failure_async_predicate_do_not_invoked_expect_is_error_result_failure()
        {
            Task<Result<TimeSpan>> sut = Task.FromResult(Result.Failure<TimeSpan>("some result error"));

            Result<TimeSpan> result = await sut.Ensure(t => Task.FromResult(true), "test ensure error");

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task
            Ensure_generic_task_source_result_is_success_async_predicate_is_failed_expected_error_result_failure()
        {
            Task<Result<long>> sut = Task.FromResult(Result.Success<long>(333));

            Result<long> result = await sut.Ensure(l => Task.FromResult(false), "test ensure error");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("test ensure error");
        }

        [Fact]
        public async Task
            Ensure_generic_task_source_result_is_success_async_predicate_is_passed_expected_error_result_success()
        {
            Task<Result<double>> sut = Task.FromResult(Result.Success(.33));

            Result<double> result = await sut.Ensure(d => Task.FromResult(true), "test error");

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task
            Ensure_generic_task_source_result_is_failure_predicate_do_not_invoked_expect_is_error_result_failure()
        {
            Task<Result<TimeSpan>> sut = Task.FromResult(Result.Failure<TimeSpan>("some result error"));

            Result<TimeSpan> result = await sut.Ensure(t => true, "test ensure error");

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task
            Ensure_generic_task_source_result_is_success_predicate_is_failed_expected_error_result_failure()
        {
            Task<Result<long>> sut = Task.FromResult(Result.Success<long>(333));

            Result<long> result = await sut.Ensure(l => false, "test ensure error");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("test ensure error");
        }

        [Fact]
        public async Task
            Ensure_generic_task_source_result_is_success_predicate_is_passed_expected_error_result_success()
        {
            Task<Result<double>> sut = Task.FromResult(Result.Success(.33));

            Result<double> result = await sut.Ensure(d => true, "test error");

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task
            Ensure_generic_source_result_with_error_is_failure_async_predicate_do_not_invoked_expect_is_error_result_failure()
        {
            Result<DateTime, Error> sut = Result.Failure<DateTime, Error>(new Error());

            Result<DateTime, Error> result = await sut.Ensure(d => Task.FromResult(true), new Error());

            result.Should().Be(sut);
        }

        [Fact]
        public async Task
            Ensure_generic_source_result_with_error_is_success_async_predicate_is_failed_expected_error_result_failure()
        {
            Result<int, Error> sut = Result.Success<int, Error>(101);
            var error = new Error();

            Result<int, Error> result = await sut.Ensure(i => Task.FromResult(false), error);

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public async Task
            Ensure_generic_source_result_with_error_is_success_async_predicate_is_passed_expected_error_result_success()
        {
            Result<decimal, Error> sut = Result.Success<decimal, Error>(.0003m);

            Result<decimal, Error> result = await sut.Ensure(d => Task.FromResult(true), new Error());

            result.Should().Be(sut);
        }

        [Fact]
        public async Task
            Ensure_task_source_result_is_failure_async_predicate_with_arg_do_not_invoked_expect_is_error_result_failure()
        {
            Task<Result<DateTime, Error>> sut = Task.FromResult(Result.Failure<DateTime, Error>(new Error()));

            Result<DateTime, Error> result = await sut.Ensure(d => Task.FromResult(true), new Error());

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task
            Ensure_task_source_result_is_success_async_predicate_with_arg_is_failed_expected_error_result_failure()
        {
            Task<Result<int, Error>> sut = Task.FromResult(Result.Success<int, Error>(100));
            var error = new Error();

            Result<int, Error> result = await sut.Ensure(i => Task.FromResult(false), error);

            result.Should().NotBe(sut.Result);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public async Task
            Ensure_task_source_result_is_success_async_predicate_with_arg_is_passed_expected_error_result_success()
        {
            Task<Result<decimal, Error>> sut = Task.FromResult(Result.Success<decimal, Error>(.3m));

            Result<decimal, Error> result = await sut.Ensure(d => Task.FromResult(true), new Error());

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task
            Ensure_task_source_result_is_failure_predicate_with_arg_do_not_invoked_expect_is_error_result_failure()
        {
            Task<Result<TimeSpan, Error>> sut = Task.FromResult(Result.Failure<TimeSpan, Error>(new Error()));

            Result<TimeSpan, Error> result = await sut.Ensure(t => true, new Error());

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task
            Ensure_task_source_result_is_success_predicate_with_arg_is_failed_expected_error_result_failure()
        {
            Task<Result<byte, Error>> sut = Task.FromResult(Result.Success<byte, Error>(32));
            var error = new Error();

            Result<byte, Error> result = await sut.Ensure(b => false, error);

            result.Should().NotBe(sut.Result);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public async Task
            Ensure_task_source_result_is_success_predicate_with_arg_is_passed_expected_error_result_success()
        {
            Task<Result<double, Error>> sut = Task.FromResult(Result.Success<double, Error>(.35));

            Result<double, Error> result = await sut.Ensure(d => true, new Error());

            result.Should().Be(sut.Result);
        }

        [Fact]
        public void Ensure_source_result_is_failure_predicate_with_arg_do_not_invoked_expect_is_error_result_failure()
        {
            Result<TimeSpan, Error> sut = Result.Failure<TimeSpan, Error>(new Error());

            Result<TimeSpan, Error> result = sut.Ensure(t => true, new Error());

            result.Should().Be(sut);
        }

        [Fact]
        public void Ensure_source_result_is_success_predicate_with_arg_is_failed_expected_error_result_failure()
        {
            Result<byte, Error> sut = Result.Success<byte, Error>(32);
            var error = new Error();

            Result<byte, Error> result = sut.Ensure(b => false, error);

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public void Ensure_source_result_is_success_predicate_with_arg_is_passed_expected_error_result_success()
        {
            Result<double, Error> sut = Result.Success<double, Error>(.35);

            Result<double, Error> result = sut.Ensure(d => true, new Error());

            result.Should().Be(sut);
        }


        [Fact(DisplayName = "Given failed UnitResult, when predicate is true, Ensure() yields original UnitResult")]
        public void Given_failed_UnitResult__when_predicate_is_true__Ensure_yields_original_UnitResult()
        {
            var sut = UnitResult.Failure<Error>(new Error());

            var result = sut.Ensure(() => true, new Error());

            result.Should().Be(sut);
        }

        [Fact(DisplayName = "Given failed UnitResult, when predicate is false, Ensure() yields original UnitResult")]
        public void Given_failed_UnitResult__when_predicate_is_false__Ensure_yields_original_UnitResult()
        {
            var sut = UnitResult.Failure<Error>(new Error());

            var result = sut.Ensure(() => false, new Error());

            result.Should().Be(sut);
        }

        [Fact(DisplayName =
            "Given successful UnitResult, when predicate is false, Ensure() yields original successful UnitResult")]
        public void Given_successful_UnitResult__when_predicate_is_false__Ensure_yields_original_UnitResult()
        {
            var sut = UnitResult.Success<Error>();
            var error = new Error();

            var result = sut.Ensure(() => false, error);

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact(DisplayName = "Given successful UnitResult, when predicate is false, Ensure() yields failed UnitResult")]
        public void Given_successfu_UnitResult__when_predicate_is_false__Ensure_yields_failed_UnitResult()
        {
            var sut = UnitResult.Success<Error>();

            var result = sut.Ensure(() => true, new Error());

            result.Should().Be(sut);
        }

        [Fact]
        public void Ensure_with_successInput_and_successPredicate()
        {
            var initialResult = Result.Success("Initial message");

            var result = initialResult.Ensure(() => Result.Success("Success message"));

            result.IsSuccess.Should().BeTrue("Initial result and predicate succeeded");
            result.Value.Should().Be("Initial message");
        }

        [Fact]
        public void Ensure_with_successInput_and_failurePredicate()
        {
            var initialResult = Result.Success("Initial Result");

            var result = initialResult.Ensure(() => Result.Failure("Error message"));

            result.IsSuccess.Should().BeFalse("Predicate is failure result");
            result.Error.Should().Be("Error message");
        }

        [Fact]
        public void Ensure_with_failureInput_and_successPredicate()
        {
            var initialResult = Result.Failure("Initial Error message");

            var result = initialResult.Ensure(() => Result.Success("Success message"));

            result.IsSuccess.Should().BeFalse("Initial result is failure result");
            result.Error.Should().Be("Initial Error message");
        }

        [Fact]
        public void Ensure_with_failureInput_and_failurePredicate()
        {
            var initialResult = Result.Failure("Initial Error message");

            var result = initialResult.Ensure(() => Result.Failure("Error message"));

            result.IsSuccess.Should().BeFalse("Initial result is failure result");
            result.Error.Should().Be("Initial Error message");
        }

        [Fact]
        public void Ensure_with_successInput_and_parameterisedFailurePredicate()
        {
            var initialResult = Result.Success("Initial Success message");

            var result = initialResult.Ensure(_ => Result.Failure("Error Message"));

            result.IsSuccess.Should().BeFalse("Predicate is failure result");
            result.Error.Should().Be("Error Message");
        }

        [Fact]
        public void Ensure_with_successInput_and_parameterisedSuccessPredicate()
        {
            var initialResult = Result.Success("Initial Success message");

            var result = initialResult.Ensure(_ => Result.Success("Success Message"));

            result.IsSuccess.Should().BeTrue("Initial result and predicate succeeded");
            ;
            result.Value.Should().Be("Initial Success message");
        }

        [Fact]
        public void Ensure_with_failureInput_and_parameterisedSuccessPredicate()
        {
            var initialResult = Result.Failure<string>("Initial Error message");

            var result = initialResult.Ensure(_ => Result.Success("Success Message"));

            result.IsSuccess.Should().BeFalse("Initial result is failure result");
            ;
            result.Error.Should().Be("Initial Error message");
        }

        [Fact]
        public void Ensure_with_failureInput_and_parameterisedFailurePredicate()
        {
            var initialResult = Result.Failure<string>("Initial Error message");

            var result = initialResult.Ensure(_ => Result.Failure("Success Message"));

            result.IsSuccess.Should().BeFalse("Initial result and predicate is failure result");
            ;
            result.Error.Should().Be("Initial Error message");
        }
    }
}
