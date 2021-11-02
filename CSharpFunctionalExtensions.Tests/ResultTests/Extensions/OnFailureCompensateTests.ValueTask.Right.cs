using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class OnFailureCompensateTests_ValueTask_Right : TestBase
    {
        [Fact]
        public async Task OnFailureCompensate_ValueTask_Right_on_failure_returns_Ok()
        {
            var myResult = Result.Failure(ErrorMessage);
            var newResult = await myResult.OnFailureCompensate(() => Result.Success().AsValueTask());

            newResult.IsSuccess.Should().Be(true);
        }
        
        [Fact]
        public async Task OnFailureCompensate_ValueTask_Right_func_string_on_failure_returns_Ok()
        {
            var myResult = Result.Failure(ErrorMessage);
            var newResult = await myResult.OnFailureCompensate(_ => Result.Success().AsValueTask());

            newResult.IsSuccess.Should().Be(true);
        }

        [Fact]
        public async Task OnFailureCompensate_ValueTask_Right_T_func_on_generic_failure_returns_Ok()
        {
            var myResult = Result.Failure<T>(ErrorMessage);
            var newResult = await myResult.OnFailureCompensate(() => Result.Success(T.Value).AsValueTask());

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }

        [Fact]
        public async Task OnFailureCompensate_ValueTask_Right_T_func_with_result_on_generic_failure_returns_Ok()
        {
            var myResult = Result.Failure<T>(ErrorMessage);
            var newResult = await myResult.OnFailureCompensate(_ => Result.Success(T.Value).AsValueTask());

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }

        [Fact]
        public async Task OnFailureCompensate_ValueTask_Right_T_E_func_with_error_object_on_generic_failure_returns_Ok()
        {
            var myResult = Result.Failure<T, E>(E.Value);
            var newResult = await myResult.OnFailureCompensate(_ => Result.Success<T, E>(T.Value).AsValueTask());

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }
        
        [Fact]
        public async Task OnFailureCompensate_ValueTask_Right_T_E_func_on_generic_failure_returns_Ok()
        {
            var myResult = Result.Failure<T, E>(E.Value);
            var newResult = await myResult.OnFailureCompensate(() => Result.Success<T, E>(T.Value).AsValueTask());

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }
    }
}