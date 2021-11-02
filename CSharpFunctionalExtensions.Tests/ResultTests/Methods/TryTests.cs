using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Methods.Try
{
    public class TryTests : TryTestBase
    {
        [Fact]
        public void Try_execute_action_success_without_error_handler_function_result_expected()
        {
            var result = Result.Try(Action);
            result.IsSuccess.Should().BeTrue();
            FuncExecuted.Should().BeTrue();
        }
        
        [Fact]
        public void Try_execute_action_failed_without_error_handler_failed_result_expected()
        {
            var result = Result.Try(Throwing_Action);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }
        
        [Fact]
        public void Try_execute_action_failed_with_error_handler_failed_result_expected()
        {
            var result = Result.Try(Throwing_Action, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }

        [Fact] 
        public void Try_T_execute_function_success_without_error_handler_function_result_expected()
        {
            var result = Result.Try(Func_T);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(T.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact] 
        public void Try_T_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var result = Result.Try(Throwing_Func_T);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact] 
        public void Try_T_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var result = Result.Try(Throwing_Func_T, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }

        [Fact]
        public void Try_T_E_execute_function_success_without_error_handler_function_result_expected()
        {
            var result = Result.Try(Func_T, ErrorHandler_E);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(T.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact] 
        public void Try_T_E_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var result = Result.Try(Throwing_Func_T, ErrorHandler_E);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }

        [Fact] 
        public void Try_T_E_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var result = Result.Try(Throwing_Func_T, ErrorHandler_E);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }
        
    }
}