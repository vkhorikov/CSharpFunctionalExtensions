using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Methods.Try
{
    public class TryTestBaseTestsValueTask : TryTestBaseValueTask
    {
        [Fact]
        public async ValueTask Try_ValueTask_execute_action_success_without_error_handler_function_result_expected()
        {
            var result = await Result.Try(Func_ValueTask);

            result.IsSuccess.Should().BeTrue();    
            FuncExecuted.Should().BeTrue();
        }
        
        [Fact]
        public async ValueTask Try_ValueTask_execute_action_failed_without_error_handler_failed_result_expected()
        {
            var result = await Result.Try(Throwing_Func_ValueTask);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }
        
        [Fact]
        public async ValueTask Try_ValueTask_execute_action_failed_with_error_handler_failed_result_expected()
        {
            var result = await Result.Try(Throwing_Func_ValueTask, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }

        [Fact] 
        public async ValueTask Try_ValueTask_T_execute_function_success_without_error_handler_function_result_expected()
        {
            var result = await Result.Try(Func_ValueTask_T);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(T.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact] 
        public async ValueTask Try_ValueTask_T_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var result = await Result.Try(Throwing_Func_ValueTask_T);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact] 
        public async ValueTask Try_ValueTask_T_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var result = await Result.Try(Throwing_Func_ValueTask_T, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }
        
        [Fact]
        public async ValueTask Try_ValueTask_T_E_execute_function_success_without_error_handler_function_result_expected()
        {
            var result = await Result.Try(Func_ValueTask_T, ErrorHandler_E);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(T.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact] 
        public async ValueTask Try_ValueTask_T_E_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var result = await Result.Try(Throwing_Func_ValueTask_T, ErrorHandler_E);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }

        [Fact] 
        public async ValueTask Try_ValueTask_T_E_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var result = await Result.Try(Throwing_Func_ValueTask_T, ErrorHandler_E);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }
    }
}