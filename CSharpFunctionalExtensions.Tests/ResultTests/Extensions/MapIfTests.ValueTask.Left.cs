using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class MapIfTests_ValueTask_Left : MapIfTestsBase
    {
        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_ValueTask_Left_T_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            Result<T> returned = await result.MapIf(condition, GetValueTaskAction());

            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_ValueTask_Left_T_E_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            Result<T, E> returned = await result.MapIf(condition, GetValueTaskAction());

            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueErrorResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_ValueTask_Left_computes_predicate_T_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            Result<T> returned = await result.MapIf(GetValuePredicate(condition), GetValueTaskAction());

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_ValueTask_Left_computes_predicate_T_E_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            Result<T, E> returned = await result.MapIf(GetValuePredicate(condition), GetValueTaskAction());

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueErrorResult(isSuccess, condition));
        }
    }
}