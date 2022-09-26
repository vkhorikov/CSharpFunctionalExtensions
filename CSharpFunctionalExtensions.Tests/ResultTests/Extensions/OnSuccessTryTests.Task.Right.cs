using System.Threading.Tasks;
using CSharpFunctionalExtensions.Tests.ResultTests.Methods.Try;
using FluentAssertions;
using FluentAssertions.CSharpFunctionalExtensions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class OnSuccessTryTestBaseTests_Task_Right : TryTestBaseTask
    {       
        [Fact]
        public async Task OnSuccess_Task_Right_execute_action_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success();
            var result = await success.OnSuccessTry(Func_Task);

            result.IsSuccess.Should().BeTrue();        
        }

        [Fact]
        public async Task OnSuccess_Task_Right_execute_action_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success();
            var result = await success.OnSuccessTry(Throwing_Func_Task);

            result.Should()
                .BeFailure()
                .And.Subject.Error.Should()
                .Be(ErrorMessage);
        }
        
        [Fact]
        public async Task OnSuccess_Task_Right_execute_action_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success();
            var result = await success.OnSuccessTry(Throwing_Func_Task, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }

        [Fact]
        public async Task OnSuccessTry_Task_Right_execute_action_on_faiulre_failed_with_error_from_failure()
        {
            var failure = Result.Failure(ErrorMessage);
            var result = await failure.OnSuccessTry(Throwing_Func_Task, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            FuncExecuted.Should().BeFalse();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact] 
        public async Task OnSuccess_Task_Right_T_execute_function_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success();
            var result = await success.OnSuccessTry(Func_Task_T);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(T.Value);
        }

        [Fact] 
        public async Task OnSuccess_Task_Right_T_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success();
            var result = await success.OnSuccessTry(Throwing_Func_Task_T);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact] 
        public async Task OnSuccess_Task_Right_T_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success();
            var result = await success.OnSuccessTry(Throwing_Func_Task_T, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }

        [Fact]
        public async Task OnSuccess_Task_Right_T_execute_action_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success(T.Value);
            var result = await success.OnSuccessTry(Func_T_Task);

            result.IsSuccess.Should().BeTrue();
        }
        
        [Fact]
        public async Task OnSuccess_Task_Right_T_execute_action_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value);
            var result = await success.OnSuccessTry(Throwing_Func_T_Task);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }
        
        [Fact]
        public async Task OnSuccess_Task_Right_T_execute_action_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value);
            var result = await success.OnSuccessTry(Throwing_Func_T_Task, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }

        [Fact]
        public async Task OnSuccessTry_Task_Right_T_execute_action_on_faiulre_failed_with_error_from_failure()
        {
            var failure = Result.Failure<T>(ErrorMessage);
            var result = await failure.OnSuccessTry(Throwing_Func_T_Task, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            FuncExecuted.Should().BeFalse();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact]
        public async Task OnSuccess_Task_Right_T_K_execute_function_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success(T.Value);
            var result = await success.OnSuccessTry(Func_T_Task_K);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(K.Value);
        }

        [Fact] 
        public async Task OnSuccess_Task_Right_T_K_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value);
            var result = await success.OnSuccessTry(Throwing_Func_T_Task_K);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact] 
        public async Task OnSuccess_Task_Right_T_K_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success(T.Value);
            var result = await success.OnSuccessTry(Throwing_Func_T_Task_K, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }
        
        [Fact]
        public async Task OnSuccess_Task_Right_T_E_execute_function_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success<T, E>(T.Value);
            var result = await success.OnSuccessTry(Func_Task_T, ErrorHandler_E);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(T.Value);
        }

        [Fact] 
        public async Task OnSuccess_Task_Right_T_E_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var success =  Result.Success<T, E>(T.Value);
            var result = await success.OnSuccessTry(Throwing_Func_Task_T, ErrorHandler_E);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }

        [Fact] 
        public async Task OnSuccess_Task_Right_T_E_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var success =  Result.Success<T, E>(T.Value);
            var result = await success.OnSuccessTry(Throwing_Func_Task_T, ErrorHandler_E);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }
        
        [Fact]
        public async Task OnSuccess_Task_Right_T_K_E_execute_function_success_without_error_handler_function_result_expected()
        {
            var success = Result.Success<T, E>(T.Value);
            var result = await success.OnSuccessTry(Func_T_Task_K, ErrorHandler_E);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(K.Value);
        }

        [Fact] 
        public async Task OnSuccess_Task_Right_T_K_E_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var success = Result.Success<T, E>(T.Value);
            var result = await success.OnSuccessTry(Throwing_Func_T_Task_K, ErrorHandler_E);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }

        [Fact] 
        public async Task OnSuccess_Task_Right_T_K_E_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var success = Result.Success<T, E>(T.Value);
            var result = await success.OnSuccessTry(Throwing_Func_T_Task_K, ErrorHandler_E);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }
    }
}