using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class OnFailureCompensateTests_ValueTask : TestBase
    {
        [Fact]
        public async Task OnFailureCompensate_ValueTask_on_failure_returns_Ok()
        {
            var myResult = Result.Failure(ErrorMessage).AsValueTask();
            var newResult = await myResult.OnFailureCompensate(() => Result.Success().AsValueTask());

            newResult.IsSuccess.Should().Be(true);
        }
        
        [Fact]
        public async Task OnFailureCompensate_ValueTask_func_string_on_failure_returns_Ok()
        {
            var myResult = Result.Failure(ErrorMessage).AsValueTask();
            var newResult = await myResult.OnFailureCompensate(errorMessage => Result.Success().AsValueTask());

            newResult.IsSuccess.Should().Be(true);
        }

        [Fact]
        public async Task OnFailureCompensate_ValueTask_T_func_on_generic_failure_returns_Ok()
        {
            var myResult = Result.Failure<T>(ErrorMessage).AsValueTask();
            var newResult = await myResult.OnFailureCompensate(() => Result.Success(T.Value).AsValueTask());

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }

        [Fact]
        public async Task OnFailureCompensate_ValueTask_T_func_with_result_on_generic_failure_returns_Ok()
        {
            var myResult = Result.Failure<T>(ErrorMessage).AsValueTask();
            var newResult = await myResult.OnFailureCompensate(error => Result.Success(T.Value).AsValueTask());

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }

        [Fact]
        public async Task OnFailureCompensate_ValueTask_T_E_func_with_error_object_on_generic_failure_returns_Ok()
        {
            var myResult = Result.Failure<T, E>(E.Value).AsValueTask();
            var newResult = await myResult.OnFailureCompensate(error => Result.Success<T, E>(T.Value).AsValueTask());

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }
        
        [Fact]
        public async Task OnFailureCompensate_ValueTask_T_E_func_on_generic_failure_returns_Ok()
        {
            var myResult = Result.Failure<T, E>(E.Value).AsValueTask();
            var newResult = await myResult.OnFailureCompensate(() => Result.Success<T, E>(T.Value).AsValueTask());

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }
    }
}