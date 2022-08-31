using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class EnsureTests_ValueTask_Left
    {
        [Fact]
        public async Task Ensure_ValueTask_Left_with_errorPredicate_does_not_throw_when_given_result_failure()
        {
            var result = Result.Failure<string>("initial error message").AsCompletedValueTask();
            Func<Task> ensure = async () => await result.Ensure(
                x => x != "",
                x => "new error message: string should not be empty");

            await ensure.Should().NotThrowAsync<Exception>("passing in a Result.Failure is a valid use case");
        }

        [Fact]
        public async Task Ensure_ValueTask_Left_with_errorPredicate_initial_result_has_failure_state()
        {
            var tResult = Result.Failure<string>("initial error message").AsCompletedValueTask();

            var result = await tResult.Ensure(x => x != "", 
                x => "new error message: string should not be empty");
            
            result.IsSuccess.Should().BeFalse("Input Result.Failure should be returned");
            result.Error.Should().Be("initial error message");
        }

        [Fact]
        public async Task Ensure_ValueTask_Left_with_errorPredicate_predicate_passes()
        {
            var tResult = Result.Success("initial ok").AsCompletedValueTask();

            var result = await tResult.Ensure(x => x != "", 
                x => "new error message: string should not be empty");
            
            result.IsSuccess.Should().BeTrue("Input Result passes predicate condition");
            result.Value.Should().Be("initial ok");
        }

        [Fact]
        public async Task Ensure_ValueTask_Left_with_errorPredicate_does_not_execute_error_predicate_when_predicate_passes()
        {
            var tResult = Result.Success<int?>(null).AsCompletedValueTask();

            Result<int?> result = await tResult.Ensure(value => !value.HasValue, value => $"should be null but found {value.Value}");

            result.Should().Be(tResult.Result);
        }

        [Fact]
        public async Task Ensure_ValueTask_Left_with_errorPredicate_using_errorPredicate()
        {
            var tResult = Result.Success("").AsCompletedValueTask();

            var result = await tResult.Ensure(x => x != "", 
                x => "new error message: string should not be empty");
            
            result.IsSuccess.Should().BeFalse("Input Result fails predicate condition");
            result.Error.Should().Be("new error message: string should not be empty");
        }

        [Fact]
        public async Task Ensure_ValueTask_Left_with_successInput_and_successPredicate()
        {
          var initialResult = Result.Success("Initial message").AsCompletedValueTask();

          var result = await initialResult.Ensure(() => Result.Success("Success message"));

          result.IsSuccess.Should().BeTrue("Initial result and predicate succeeded");
          result.Value.Should().Be("Initial message");
        }

        [Fact]
        public async Task Ensure_ValueTask_Left_with_successInput_and_failurePredicate()
        {
          var initialResult = Result.Success("Initial Result").AsCompletedValueTask();

          var result = await initialResult.Ensure(() => Result.Failure("Error message"));

          result.IsSuccess.Should().BeFalse("Predicate is failure result");
          result.Error.Should().Be("Error message");
        }
        
        [Fact]
        public async Task Ensure_ValueTask_Left_with_failureInput_and_successPredicate()
        {
          var initialResult = Result.Failure("Initial Error message").AsCompletedValueTask();

          var result = await initialResult.Ensure(() => Result.Success("Success message"));

          result.IsSuccess.Should().BeFalse("Initial result is failure result");
          result.Error.Should().Be("Initial Error message");
        }

        [Fact]
        public async Task Ensure_ValueTask_Left_with_failureInput_and_failurePredicate()
        {
          var initialResult = Result.Failure("Initial Error message").AsCompletedValueTask();

          var result = await initialResult.Ensure(() => Result.Failure("Error message"));

          result.IsSuccess.Should().BeFalse("Initial result is failure result");
          result.Error.Should().Be("Initial Error message");
        }
        
        [Fact]
        public async Task Ensure_ValueTask_Left_with_successInput_and_parameterisedFailurePredicate()
        {
          var initialResult = Result.Success("Initial Success message").AsCompletedValueTask();

          var result = await initialResult.Ensure(_ => Result.Failure("Error Message"));

          result.IsSuccess.Should().BeFalse("Predicate is failure result");
          result.Error.Should().Be("Error Message");
        }
    
        [Fact]
        public async Task Ensure_ValueTask_Left_with_successInput_and_parameterisedSuccessPredicate()
        {
          var initialResult = Result.Success("Initial Success message").AsCompletedValueTask();

          var result = await initialResult.Ensure(_ => Result.Success("Success Message"));

          result.IsSuccess.Should().BeTrue("Initial result and predicate succeeded");;
          result.Value.Should().Be("Initial Success message");
        }
    
        [Fact]
        public async Task Ensure_ValueTask_Left_with_failureInput_and_parameterisedSuccessPredicate()
        {
          var initialResult = Result.Failure<string>("Initial Error message").AsCompletedValueTask();

          var result = await initialResult.Ensure(_ => Result.Success("Success Message"));

          result.IsSuccess.Should().BeFalse("Initial result is failure result");;
          result.Error.Should().Be("Initial Error message");
        }
    
        [Fact]
        public async Task Ensure_ValueTask_Left_with_failureInput_and_parameterisedFailurePredicate()
        {
          var initialResult = Result.Failure<string>("Initial Error message").AsCompletedValueTask();

          var result = await initialResult.Ensure(_ => Result.Failure("Success Message"));

          result.IsSuccess.Should().BeFalse("Initial result and predicate is failure result");;
          result.Error.Should().Be("Initial Error message");
        }
    }
}