using CSharpFunctionalExtensions.Tests.ResultTests.Methods.Try;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class OnSuccessTryTests : TryTestBase
    {
        [Fact]
        public void OnSuccessTry_execute_action_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success();
            var result = success.OnSuccessTry(Action);

            result.IsSuccess.Should().BeTrue();
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public void OnSuccessTry_execute_action_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success();
            var result = success.OnSuccessTry(Throwing_Action);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact]
        public void OnSuccessTry_execute_action_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success();
            var result = success.OnSuccessTry(Throwing_Action, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }

        [Fact]
        public void OnSuccessTry_execute_throwing_action_on_faiulre_failed_with_error_from_failure()
        {
            var failure = Result.Failure(ErrorMessage);
            var result = failure.OnSuccessTry(Throwing_Action, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            FuncExecuted.Should().BeFalse();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact]
        public void OnSuccessTry_T_execute_action_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success(T.Value);
            var result = success.OnSuccessTry(Action_T);

            result.IsSuccess.Should().BeTrue();
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public void OnSuccessTry_T_execute_action_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value);
            var result = success.OnSuccessTry(Throwing_Action_T);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact]
        public void OnSuccessTry_T_execute_action_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value);
            var result = success.OnSuccessTry(Throwing_Action_T, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }

        [Fact]
        public void OnSuccessTry_T_execute_throwing_action_on_faiulre_failed_with_error_from_failure()
        {
            var failure = Result.Failure<T>(ErrorMessage);
            var result = failure.OnSuccessTry(Throwing_Action_T, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            FuncExecuted.Should().BeFalse();
            result.Error.Should().Be(ErrorMessage);
        }
    }
}
