using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class ResultTryTests : TryTestBase
    {
        [Fact]
        public void ResultTry_execute_action_success_without_error_handler_function_result_expected()
        {
            var result = Result.Try(Action);
            result.IsSuccess.Should().BeTrue();
            FuncExecuted.Should().BeTrue();
        }
        
        [Fact]
        public void ResultTry_execute_action_failed_without_error_handler_failed_result_expected()
        {
            var result = Result.Try(Throwing_Action);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }
        
        [Fact]
        public void ResultTry_execute_action_failed_with_error_handler_failed_result_expected()
        {
            var result = Result.Try(Throwing_Action, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }

        [Fact] 
        public void ResultTry_T_execute_function_success_without_error_handler_function_result_expected()
        {
            var result = Result.Try(Func_T);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(T.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact] 
        public void ResultTry_T_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var result = Result.Try(Throwing_Func_T);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
        }

        [Fact] 
        public void ResultTry_T_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var result = Result.Try(Throwing_Func_T, ErrorHandler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorHandlerMessage);
        }

        [Fact]
        public void ResultTry_T_E_execute_function_success_without_error_handler_function_result_expected()
        {
            var result = Result.Try(Func_T, ErrorHandlerE);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(T.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact] 
        public void ResultTry_T_E_execute_function_failed_without_error_handler_failed_result_expected()
        {
            var result = Result.Try(Throwing_Func_T, ErrorHandlerE);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }

        [Fact] 
        public void ResultTry_T_E_execute_function_failed_with_error_handler_failed_result_expected()
        {
            var result = Result.Try(Throwing_Func_T, ErrorHandlerE);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }
        
    }
}