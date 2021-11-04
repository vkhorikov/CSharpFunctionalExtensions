using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class OnSuccessTryAsyncBothTests : TryTestBase
    {
        [Fact]
        public async Task OnSuccessTry_execute_action_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success().AsTask();
            var result = await success.OnSuccessTry(Func_Task);

            result.IsSuccess.Should().BeTrue();        
        }
        
        [Fact]
        public async Task OnSuccessTry_execute_action_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success().AsTask();
            var result = await success.OnSuccessTry(Throwing_Func_Task);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }
        
        [Fact]
        public async Task OnSuccessTry_execute_action_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success().AsTask();
            var result = await success.OnSuccessTry(Throwing_Func_Task, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }

        [Fact] 
        public async Task OnSuccessTry_T_execute_function_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success().AsTask();
            var result = await success.OnSuccessTry(Func_Task_T);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(T.Value);
        }

        [Fact] 
        public async Task OnSuccessTry_T_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success().AsTask();
            var result = await success.OnSuccessTry(Throwing_Func_Task_T);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact] 
        public async Task OnSuccessTry_T_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success().AsTask();
            var result = await success.OnSuccessTry(Throwing_Func_Task_T, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }

        [Fact]
        public async Task OnSuccessTry_T_execute_action_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success(T.Value).AsTask();
            var result = await success.OnSuccessTry(Func_T_Task);

            result.IsSuccess.Should().BeTrue();
        }
        
        [Fact]
        public async Task OnSuccessTry_T_execute_action_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value).AsTask();
            var result = await success.OnSuccessTry(Throwing_Func_T_Task);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }
        
        [Fact]
        public async Task OnSuccessTry_T_execute_action_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value).AsTask();
            var result = await success.OnSuccessTry(Throwing_Func_T_Task, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }
        
        [Fact]
        public async Task OnSuccessTry_T_K_execute_function_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success(T.Value).AsTask();
            var result = await success.OnSuccessTry(Func_T_Task_K);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(K.Value);
        }

        [Fact] 
        public async Task OnSuccessTry_T_K_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value).AsTask();
            var result = await success.OnSuccessTry(Throwing_Func_T_Task_K);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact] 
        public async Task OnSuccessTry_T_K_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value).AsTask();
            var result = await success.OnSuccessTry(Throwing_Func_T_Task_K, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }
        
        [Fact]
        public async Task OnSuccessTry_T_E_execute_function_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success<T, E>(T.Value).AsTask();
            var result = await success.OnSuccessTry(Func_Task_T, ErrorHandlerE);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(T.Value);
        }

        [Fact] 
        public async Task OnSuccessTry_T_E_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var success =  Result.Success<T, E>(T.Value).AsTask();
            var result = await success.OnSuccessTry(Throwing_Func_Task_T, ErrorHandlerE);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }

        [Fact] 
        public async Task OnSuccessTry_T_E_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var success =  Result.Success<T, E>(T.Value).AsTask();
            var result = await success.OnSuccessTry(Throwing_Func_Task_T, ErrorHandlerE);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }
        
        [Fact]
        public async Task OnSuccessTry_T_K_E_execute_function_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success<T, E>(T.Value).AsTask();
            var result = await success.OnSuccessTry(Func_T_Task_K, ErrorHandlerE);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(K.Value);
        }

        [Fact] 
        public async Task OnSuccessTry_T_K_E_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success<T, E>(T.Value).AsTask();
            var result = await success.OnSuccessTry(Throwing_Func_T_Task_K, ErrorHandlerE);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }

        [Fact] 
        public async Task OnSuccessTry_T_K_E_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success<T, E>(T.Value).AsTask();
            var result = await success.OnSuccessTry(Throwing_Func_T_Task_K, ErrorHandlerE);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }
    }
}