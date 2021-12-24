using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
  public class EnsureTests
  {
    [Fact]
    public void Ensure_with_successInput_and_successPredicate()
    {
      var initialResult = Result.Success("Initial message");

      var result = initialResult.Ensure(() => Result.Success("Success message"));

      result.IsSuccess.Should().BeTrue("Initial result and predicate succeeded");
      result.Value.Should().Be("Initial message");
    }

    [Fact]
    public void Ensure_with_successInput_and_failurePredicate()
    {
      var initialResult = Result.Success("Initial Result");

      var result = initialResult.Ensure(() => Result.Failure("Error message"));

      result.IsSuccess.Should().BeFalse("Predicate is failure result");
      result.Error.Should().Be("Error message");
    }
    
    [Fact]
    public void Ensure_with_failureInput_and_successPredicate()
    {
      var initialResult = Result.Failure("Initial Error message");

      var result = initialResult.Ensure(() => Result.Success("Success message"));

      result.IsSuccess.Should().BeFalse("Initial result is failure result");
      result.Error.Should().Be("Initial Error message");
    }

    [Fact]
    public void Ensure_with_failureInput_and_failurePredicate()
    {
      var initialResult = Result.Failure("Initial Error message");

      var result = initialResult.Ensure(() => Result.Failure("Error message"));

      result.IsSuccess.Should().BeFalse("Initial result is failure result");
      result.Error.Should().Be("Initial Error message");
    }
    
    [Fact]
    public void Ensure_with_successInput_and_paramerterisedFailurePredicate()
    {
      var initialResult = Result.Success("Initial Success message");

      var result = initialResult.Ensure(_ => Result.Failure("Error Message"));

      result.IsSuccess.Should().BeFalse("Predicate is failure result");
      result.Error.Should().Be("Error Message");
    }
    
    [Fact]
    public void Ensure_with_successInput_and_paramerterisedSuccessPredicate()
    {
      var initialResult = Result.Success("Initial Success message");

      var result = initialResult.Ensure(_ => Result.Success("Success Message"));

      result.IsSuccess.Should().BeTrue("Initial result and predicate succeeded");;
      result.Value.Should().Be("Initial Success message");
    }
    
    [Fact]
    public void Ensure_with_failureInput_and_paramerterisedSuccessPredicate()
    {
      var initialResult = Result.Failure<string>("Initial Error message");

      var result = initialResult.Ensure(_ => Result.Success("Success Message"));

      result.IsSuccess.Should().BeFalse("Initial result is failure result");;
      result.Error.Should().Be("Initial Error message");
    }
    
    [Fact]
    public void Ensure_with_failureInput_and_paramerterisedFailurePredicate()
    {
      var initialResult = Result.Failure<string>("Initial Error message");

      var result = initialResult.Ensure(_ => Result.Failure("Success Message"));

      result.IsSuccess.Should().BeFalse("Initial result and predicate is failure result");;
      result.Error.Should().Be("Initial Error message");
    }
  }
}