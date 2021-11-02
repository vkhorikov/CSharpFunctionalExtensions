using System.Threading.Tasks;
using CSharpFunctionalExtensions.Tests.ResultTests.Methods.Try;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class OnSuccessTryTests_ValueTask_Left : TryTestBaseTask
    {
        [Fact]
        public async Task OnSuccessTry_ValueTask_Left_execute_action_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success().AsValueTask();
            var result = await success.OnSuccessTry(Action);

            result.IsSuccess.Should().BeTrue();        
        }
        
        [Fact]
        public async Task OnSuccessTry_ValueTask_Left_execute_action_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success().AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Action);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }
        
        [Fact]
        public async Task OnSuccessTry_ValueTask_Left_execute_action_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success().AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Action, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }

        [Fact] 
        public async Task OnSuccessTry_ValueTask_Left_T_execute_function_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success().AsValueTask();
            var result = await success.OnSuccessTry(Func_T);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(T.Value);
        }

        [Fact] 
        public async Task OnSuccessTry_ValueTask_Left_T_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success().AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Func_T);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact] 
        public async Task OnSuccessTry_ValueTask_Left_T_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success().AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Func_T, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }

        [Fact]
        public async Task OnSuccessTry_ValueTask_Left_T_execute_action_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Action_T);

            result.IsSuccess.Should().BeTrue();
        }
        
        [Fact]
        public async Task OnSuccessTry_ValueTask_Left_T_execute_action_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Action_T);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }
        
        [Fact]
        public async Task OnSuccessTry_ValueTask_Left_T_execute_action_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Action_T, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }
        
        [Fact]
        public async Task OnSuccessTry_ValueTask_Left_T_K_execute_function_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Func_T_K);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(K.Value);
        }

        [Fact] 
        public async Task OnSuccessTry_ValueTask_Left_T_K_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Func_T_K);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact] 
        public async Task OnSuccessTry_ValueTask_Left_T_K_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Func_T_K, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }
        
        [Fact]
        public async Task OnSuccessTry_ValueTask_Left_T_E_execute_function_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success<T, E>(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Func_T, ErrorHandler_E);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(T.Value);
        }

        [Fact] 
        public async Task OnSuccessTry_ValueTask_Left_T_E_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success<T, E>(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Func_T, ErrorHandler_E);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }

        [Fact] 
        public async Task OnSuccessTry_ValueTask_Left_T_E_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success<T, E>(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Func_T, ErrorHandler_E);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }
        
        [Fact]
        public async Task OnSuccessTry_ValueTask_Left_T_K_E_execute_function_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success<T, E>(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Func_T_K, ErrorHandler_E);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(K.Value);
        }

        [Fact] 
        public async Task OnSuccessTry_ValueTask_Left_T_K_E_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success<T, E>(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Func_T_K, ErrorHandler_E);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }

        [Fact] 
        public async Task OnSuccessTry_ValueTask_Left_T_K_E_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success<T, E>(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Func_T_K, ErrorHandler_E);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }
    }
}