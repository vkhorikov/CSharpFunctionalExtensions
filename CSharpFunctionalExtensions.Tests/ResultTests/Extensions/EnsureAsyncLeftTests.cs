using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class EnsureAsyncLeftTests
    {
        [Fact]
        public async Task Ensure_with_errorPredicate_does_not_throw_when_given_result_failure()
        {
            var result = Task.FromResult(Result.Failure<string>("initial error message"));
            Func<Task> ensure = () => result.Ensure(
                x => x != "", 
                x =>"new error message: string should not be empty");
            
            await ensure.Should().NotThrowAsync<Exception>("passing in a Result.Failure is a valid use case");
        }
        
        [Fact]
        public async Task Ensure_with_errorPredicate_initial_result_has_failure_state()
        {
            var tResult = Task.FromResult(Result.Failure<string>("initial error message"));

            var result = await tResult.Ensure(x => x != "", 
                x => "new error message: string should not be empty");
            
            result.IsSuccess.Should().BeFalse("Input Result.Failure should be returned");
            result.Error.Should().Be("initial error message");
        }

        [Fact]
        public async Task Ensure_with_errorPredicate_predicate_passes()
        {
            var tResult = Task.FromResult(Result.Success("initial ok"));

            var result = await tResult.Ensure(x => x != "", 
                x => "new error message: string should not be empty");
            
            result.IsSuccess.Should().BeTrue("Input Result passes predicate condition");
            result.Value.Should().Be("initial ok");
        }

        [Fact]
        public async Task Ensure_with_errorPredicate_using_errorPredicate()
        {
            var tResult = Task.FromResult(Result.Success(""));

            var result = await tResult.Ensure(x => x != "", 
                x => "new error message: string should not be empty");
            
            result.IsSuccess.Should().BeFalse("Input Result fails predicate condition");
            result.Error.Should().Be("new error message: string should not be empty");
        }
    }
}