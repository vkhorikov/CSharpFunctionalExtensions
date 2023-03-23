using System.Threading.Tasks;
using CSharpFunctionalExtensions.Tests.ResultTests.Methods.Try;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class OnSuccessTryTestBaseTests_Task_Left : TryTestBaseTask
    {
        [Fact]
        public async Task OnSuccessTry_Task_Left_execute_action_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success().AsTask();
            var result = await success.OnSuccessTry(Action);

            result.IsSuccess.Should().BeTrue();        
        }
        
        [Fact]
        public async Task OnSuccessTry_Task_Left_execute_action_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success().AsTask();
            var result = await success.OnSuccessTry(Throwing_Action);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }
        
        [Fact]
        public async Task OnSuccessTry_Task_Left_execute_action_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success().AsTask();
            var result = await success.OnSuccessTry(Throwing_Action, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }
        [Fact]
        public async Task OnSuccessTry_Task_Left_execute_throwing_action_on_faiulre_failed_with_error_from_failure()
        {
            var failure = Result.Failure(ErrorMessage).AsTask();
            var result = await failure.OnSuccessTry(Throwing_Action, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            FuncExecuted.Should().BeFalse();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact]
        public async Task OnSuccessTry_Task_Left_T_execute_action_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success(T.Value).AsTask();
            var result = await success.OnSuccessTry(Action_T);

            result.IsSuccess.Should().BeTrue();
        }
        
        [Fact]
        public async Task OnSuccessTry_Task_Left_T_execute_action_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value).AsTask();
            var result = await success.OnSuccessTry(Throwing_Action_T);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }
        
        [Fact]
        public async Task OnSuccessTry_Task_Left_T_execute_action_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value).AsTask();
            var result = await success.OnSuccessTry(Throwing_Action_T, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }

        [Fact]
        public async Task OnSuccessTry_Task_Left_T_execute_throwing_action_on_faiulre_failed_with_error_from_failure()
        {
            var failure = Result.Failure<T>(ErrorMessage).AsTask();
            var result = await failure.OnSuccessTry(Throwing_Action_T, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            FuncExecuted.Should().BeFalse();
            result.Error.Should().Be(ErrorMessage);
        }
    }
}
