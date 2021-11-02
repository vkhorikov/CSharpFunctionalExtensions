using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
  public class Ensure_ValueTask_Tests
  {
    [Fact]
    public async Task Ensure_ValueTask_with_successInput_and_successPredicate()
    {
      var initialResult = ValueTask.FromResult(Result.Success("Initial message"));

      var result = await initialResult.Ensure(() => ValueTask.FromResult(Result.Success("Success message")));

      result.IsSuccess.Should().BeTrue("Initial result and predicate succeeded");
      result.Value.Should().Be("Initial message");
    }

    [Fact]
    public async Task Ensure_ValueTask_with_successInput_and_failurePredicate()
    {
      var initialResult = ValueTask.FromResult(Result.Success("Initial Result"));

      var result = await initialResult.Ensure(() => ValueTask.FromResult(Result.Failure("Error message")));

      result.IsSuccess.Should().BeFalse("Predicate is failure result");
      result.Error.Should().Be("Error message");
    }
    
    [Fact]
    public async Task Ensure_ValueTask_with_failureInput_and_successPredicate()
    {
      var initialResult = ValueTask.FromResult(Result.Failure("Initial Error message"));

      var result = await initialResult.Ensure(() => ValueTask.FromResult(Result.Success("Success message")));

      result.IsSuccess.Should().BeFalse("Initial result is failure result");
      result.Error.Should().Be("Initial Error message");
    }

    [Fact]
    public async Task Ensure_ValueTask_with_failureInput_and_failurePredicate()
    {
      var initialResult = ValueTask.FromResult(Result.Failure("Initial Error message"));

      var result = await initialResult.Ensure(() => ValueTask.FromResult(Result.Failure("Error message")));

      result.IsSuccess.Should().BeFalse("Initial result is failure result");
      result.Error.Should().Be("Initial Error message");
    }
    
    [Fact]
    public async Task Ensure_ValueTask_with_successInput_and_parameterisedFailurePredicate()
    {
      var initialResult = ValueTask.FromResult(Result.Success("Initial Success message"));

      var result = await initialResult.Ensure(_ => ValueTask.FromResult(Result.Failure("Error Message")));

      result.IsSuccess.Should().BeFalse("Predicate is failure result");
      result.Error.Should().Be("Error Message");
    }
    
    [Fact]
    public async Task Ensure_ValueTask_with_successInput_and_parameterisedSuccessPredicate()
    {
      var initialResult = ValueTask.FromResult(Result.Success("Initial Success message"));

      var result = await initialResult.Ensure(_ => ValueTask.FromResult(Result.Success("Success Message")));

      result.IsSuccess.Should().BeTrue("Initial result and predicate succeeded");;
      result.Value.Should().Be("Initial Success message");
    }
    
    [Fact]
    public async Task Ensure_ValueTask_with_failureInput_and_parameterisedSuccessPredicate()
    {
      var initialResult = ValueTask.FromResult(Result.Failure<string>("Initial Error message"));

      var result = await initialResult.Ensure(_ => ValueTask.FromResult(Result.Success("Success Message")));

      result.IsSuccess.Should().BeFalse("Initial result is failure result");;
      result.Error.Should().Be("Initial Error message");
    }
    
    [Fact]
    public async Task Ensure_ValueTask_with_failureInput_and_parameterisedFailurePredicate()
    {
      var initialResult = ValueTask.FromResult(Result.Failure<string>("Initial Error message"));

      var result = await initialResult.Ensure(_ => ValueTask.FromResult(Result.Failure("Success Message")));

      result.IsSuccess.Should().BeFalse("Initial result and predicate is failure result");;
      result.Error.Should().Be("Initial Error message");
    }
  }
}