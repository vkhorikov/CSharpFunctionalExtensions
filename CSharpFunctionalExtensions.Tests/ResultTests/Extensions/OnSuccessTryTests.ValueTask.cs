using System.Threading.Tasks;
using CSharpFunctionalExtensions.Tests.ResultTests.Methods.Try;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class OnSuccessTryTests_ValueTask_Tests : TryTestBaseTask
    {
        [Fact]
        public async Task OnSuccessTry_ValueTask_execute_action_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success().AsValueTask();
            var result = await success.OnSuccessTry(Func_ValueTask);

            result.IsSuccess.Should().BeTrue();        
        }
        
        [Fact]
        public async Task OnSuccessTry_ValueTask_execute_action_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success().AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Func_ValueTask);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact]
        public async Task OnSuccessTry_ValueTask_execute_action_failed_with_configured_default_error_handler_failed_result_expected()
        {
            var defaultTryErrorHandler = Result.Configuration.DefaultTryErrorHandler;
            Result.Configuration.DefaultTryErrorHandler = ErrorHandler;
            var success = Result.Success().AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Func_ValueTask);
            Result.Configuration.DefaultTryErrorHandler = defaultTryErrorHandler;

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }

        [Fact]
        public async Task OnSuccessTry_ValueTask_execute_action_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success().AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Func_ValueTask, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }

        [Fact] 
        public async Task OnSuccessTry_ValueTask_T_execute_function_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success().AsValueTask();
            var result = await success.OnSuccessTry(Func_ValueTask_T);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(T.Value);
        }

        [Fact] 
        public async Task OnSuccessTry_ValueTask_T_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success().AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Func_ValueTask_T);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact] 
        public async Task OnSuccessTry_ValueTask_T_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success().AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Func_ValueTask_T, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }

        [Fact]
        public async Task OnSuccessTry_ValueTask_T_execute_action_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Func_T_ValueTask);

            result.IsSuccess.Should().BeTrue();
        }
        
        [Fact]
        public async Task OnSuccessTry_ValueTask_T_execute_action_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Func_T_ValueTask);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }
        
        [Fact]
        public async Task OnSuccessTry_ValueTask_T_execute_action_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Func_T_ValueTask, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }
        
        [Fact]
        public async Task OnSuccessTry_ValueTask_T_K_execute_function_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Func_T_ValueTask_K);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(K.Value);
        }

        [Fact] 
        public async Task OnSuccessTry_ValueTask_T_K_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Func_T_ValueTask_K);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact] 
        public async Task OnSuccessTry_ValueTask_T_K_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Func_T_ValueTask_K, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }
        
        [Fact]
        public async Task OnSuccessTry_ValueTask_T_E_execute_function_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success<T, E>(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Func_ValueTask_T, ErrorHandler_E);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(T.Value);
        }

        [Fact] 
        public async Task OnSuccessTry_ValueTask_T_E_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var success =  Result.Success<T, E>(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Func_ValueTask_T, ErrorHandler_E);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }

        [Fact] 
        public async Task OnSuccessTry_ValueTask_T_E_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var success =  Result.Success<T, E>(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Func_ValueTask_T, ErrorHandler_E);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }
        
        [Fact]
        public async Task OnSuccessTry_ValueTask_T_K_E_execute_function_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success<T, E>(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Func_T_ValueTask_K, ErrorHandler_E);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(K.Value);
        }

        [Fact] 
        public async Task OnSuccessTry_ValueTask_T_K_E_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success<T, E>(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Func_T_ValueTask_K, ErrorHandler_E);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }

        [Fact] 
        public async Task OnSuccessTry_ValueTask_T_K_E_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success<T, E>(T.Value).AsValueTask();
            var result = await success.OnSuccessTry(Throwing_Func_T_ValueTask_K, ErrorHandler_E);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }
    }
}