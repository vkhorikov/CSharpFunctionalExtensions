using System.Threading.Tasks;
using CSharpFunctionalExtensions.Tests.ResultTests.Methods.Try;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class OnSuccessTryTests_Task : TryTestBaseTask
    {
        [Fact]
        public async Task OnSuccessTry_Task_execute_action_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success().AsTask();
            var result = await success.OnSuccessTry(Func_Task);

            result.IsSuccess.Should().BeTrue();        
        }
        
        [Fact]
        public async Task OnSuccessTry_Task_execute_action_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success().AsTask();
            var result = await success.OnSuccessTry(Throwing_Func_Task);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact]
        public async Task OnSuccessTry_Task_execute_action_failed_with_configured_default_error_handler_failed_result_expected()
        {
            var defaultTryErrorHandler = Result.Configuration.DefaultTryErrorHandler;
            Result.Configuration.DefaultTryErrorHandler = ErrorHandler;
            var success = Result.Success().AsTask();
            var result = await success.OnSuccessTry(Throwing_Func_Task);
            Result.Configuration.DefaultTryErrorHandler = defaultTryErrorHandler;

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }

        [Fact]
        public async Task OnSuccessTry_Task_execute_action_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success().AsTask();
            var result = await success.OnSuccessTry(Throwing_Func_Task, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }
        [Fact]
        public async Task OnSuccessTry_Task_execute_throwing_action_on_faiulre_failed_with_error_from_failure()
        {
            var failure = Result.Failure(ErrorMessage).AsTask();
            var result = await failure.OnSuccessTry(Throwing_Func_Task, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            FuncExecuted.Should().BeFalse();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact] 
        public async Task OnSuccessTry_Task_T_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success().AsTask();
            var result = await success.OnSuccessTry(Throwing_Func_Task_T);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact] 
        public async Task OnSuccessTry_Task_T_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success().AsTask();
            var result = await success.OnSuccessTry(Throwing_Func_Task_T, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }

        [Fact]
        public async Task OnSuccessTry_Task_T_execute_action_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success(T.Value).AsTask();
            var result = await success.OnSuccessTry(Func_T_Task);

            result.IsSuccess.Should().BeTrue();
        }
        
        [Fact]
        public async Task OnSuccessTry_Task_T_execute_action_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value).AsTask();
            var result = await success.OnSuccessTry(Throwing_Func_T_Task);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }
        
        [Fact]
        public async Task OnSuccessTry_Task_T_execute_action_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value).AsTask();
            var result = await success.OnSuccessTry(Throwing_Func_T_Task, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }

        [Fact]
        public async Task OnSuccessTry_Task_T_execute_throwing_action_on_faiulre_failed_with_error_from_failure()
        {
            var failure = Result.Failure<T>(ErrorMessage).AsTask();
            var result = await failure.OnSuccessTry(Throwing_Func_T_Task, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            FuncExecuted.Should().BeFalse();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact] 
        public async Task OnSuccessTry_Task_T_K_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value).AsTask();
            var result = await success.OnSuccessTry(Throwing_Func_T_Task_K);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact] 
        public async Task OnSuccessTry_Task_T_K_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value).AsTask();
            var result = await success.OnSuccessTry(Throwing_Func_T_Task_K, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }
    }
}
