using System.Threading.Tasks;
using CSharpFunctionalExtensions.Tests.ResultTests.Methods.Try;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class OnSuccessTryTests_ValueTask_Right : TryTestBaseTask
    {

        [Fact] 
        public async Task OnSuccess_ValueTask_Right_T_execute_function_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success();
            var result = await success.OnSuccessTry(valueTask: Func_ValueTask_T);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(T.Value);
        }

        [Fact] 
        public async Task OnSuccess_ValueTask_Right_T_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success();
            var result = await success.OnSuccessTry(valueTask: Throwing_Func_ValueTask_T);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact] 
        public async Task OnSuccess_ValueTask_Right_T_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success();
            var result = await success.OnSuccessTry(valueTask: Throwing_Func_ValueTask_T, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }
        
        [Fact]
        public async Task OnSuccess_ValueTask_Right_T_K_execute_function_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success(T.Value);
            var result = await success.OnSuccessTry(valueTask: Func_T_ValueTask_K);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(K.Value);
        }

        [Fact] 
        public async Task OnSuccess_ValueTask_Right_T_K_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value);
            var result = await success.OnSuccessTry(valueTask: Throwing_Func_T_ValueTask_K);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact] 
        public async Task OnSuccess_ValueTask_Right_T_K_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value);
            var result = await success.OnSuccessTry(valueTask: Throwing_Func_T_ValueTask_K, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }
        
        [Fact]
        public async Task OnSuccess_ValueTask_Right_T_E_execute_function_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success<T, E>(T.Value);
            var result = await success.OnSuccessTry(Func_ValueTask_T, ErrorHandler_E);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(T.Value);
        }

        [Fact] 
        public async Task OnSuccess_ValueTask_Right_T_E_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var success =  Result.Success<T, E>(T.Value);
            var result = await success.OnSuccessTry(Throwing_Func_ValueTask_T, ErrorHandler_E);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }

        [Fact] 
        public async Task OnSuccess_ValueTask_Right_T_E_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var success =  Result.Success<T, E>(T.Value);
            var result = await success.OnSuccessTry(Throwing_Func_ValueTask_T, ErrorHandler_E);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }
        
        [Fact]
        public async Task OnSuccess_ValueTask_Right_T_K_E_execute_function_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success<T, E>(T.Value);
            var result = await success.OnSuccessTry(valueTask: Func_T_ValueTask_K, ErrorHandler_E);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(K.Value);
        }

        [Fact] 
        public async Task OnSuccess_ValueTask_Right_T_K_E_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success<T, E>(T.Value);
            var result = await success.OnSuccessTry(valueTask: Throwing_Func_T_ValueTask_K, ErrorHandler_E);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }

        [Fact] 
        public async Task OnSuccess_ValueTask_Right_T_K_E_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success<T, E>(T.Value);
            var result = await success.OnSuccessTry(valueTask: Throwing_Func_T_ValueTask_K, ErrorHandler_E);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }
    }
}