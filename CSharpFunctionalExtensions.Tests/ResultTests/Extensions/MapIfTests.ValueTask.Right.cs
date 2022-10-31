using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class MapIfTests_ValueTask_Right : MapIfTestsBase
    {
        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_ValueTask_Right_T_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition)
        {
            ValueTask<Result<T>> resultTask = Result.SuccessIf(isSuccess, T.Value, ErrorMessage).AsValueTask();

            Result<T> returned = await resultTask.MapIf(condition, GetAction());

            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_ValueTask_Right_T_E_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition)
        {
            ValueTask<Result<T, E>> resultTask = Result.SuccessIf(isSuccess, T.Value, E.Value).AsValueTask();

            Result<T, E> returned = await resultTask.MapIf(condition, GetAction());

            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueErrorResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_ValueTask_Right_computes_predicate_T_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition)
        {
            ValueTask<Result<T>> resultTask = Result.SuccessIf(isSuccess, T.Value, ErrorMessage).AsValueTask();

            Result<T> returned = await resultTask.MapIf(GetValuePredicate(condition), GetAction());

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_ValueTask_Right_computes_predicate_T_E_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition)
        {
            ValueTask<Result<T, E>> resultTask = Result.SuccessIf(isSuccess, T.Value, E.Value).AsValueTask();

            Result<T, E> returned = await resultTask.MapIf(GetValuePredicate(condition), GetAction());

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueErrorResult(isSuccess, condition));
        }
    }
}