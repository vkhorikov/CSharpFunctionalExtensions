using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class MapIfTests_Task_Right : MapIfTestsBase
    {
        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_Task_Right_T_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition)
        {
            Task<Result<T>> resultTask = Result.SuccessIf(isSuccess, T.Value, ErrorMessage).AsTask();

            Result<T> returned = await resultTask.MapIf(condition, GetAction());

            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_Task_Right_T_E_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition)
        {
            Task<Result<T, E>> resultTask = Result.SuccessIf(isSuccess, T.Value, E.Value).AsTask();

            Result<T, E> returned = await resultTask.MapIf(condition, GetAction());

            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueErrorResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_Task_Right_computes_predicate_T_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition)
        {
            Task<Result<T>> resultTask = Result.SuccessIf(isSuccess, T.Value, ErrorMessage).AsTask();

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
        public async Task MapIf_Task_Right_computes_predicate_T_E_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition)
        {
            Task<Result<T, E>> resultTask = Result.SuccessIf(isSuccess, T.Value, E.Value).AsTask();

            Result<T, E> returned = await resultTask.MapIf(GetValuePredicate(condition), GetAction());

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueErrorResult(isSuccess, condition));
        }
    }
}
