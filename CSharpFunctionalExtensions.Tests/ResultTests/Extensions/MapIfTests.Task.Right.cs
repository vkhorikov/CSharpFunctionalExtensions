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
        public async Task MapIf_Task_Right_T_executes_func_conditionally_and_returns_new_result(
            bool isSuccess,
            bool condition
        )
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            Result<T> returned = await result.MapIf(condition, GetTaskAction());

            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_Task_Right_T_E_executes_func_conditionally_and_returns_new_result(
            bool isSuccess,
            bool condition
        )
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            Result<T, E> returned = await result.MapIf(condition, GetTaskAction());

            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueErrorResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_Task_Right_computes_predicate_T_executes_func_conditionally_and_returns_new_result(
            bool isSuccess,
            bool condition
        )
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            Result<T> returned = await result.MapIf(GetValuePredicate(condition), GetTaskAction());

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_Task_Right_computes_predicate_T_E_executes_func_conditionally_and_returns_new_result(
            bool isSuccess,
            bool condition
        )
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            Result<T, E> returned = await result.MapIf(
                GetValuePredicate(condition),
                GetTaskAction()
            );

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueErrorResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_Task_Right_T_executes_func_conditionally_and_passes_context(
            bool isSuccess,
            bool condition
        )
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            Result<T> returned = await result.MapIf(
                condition,
                async (value, context) =>
                {
                    context.Should().Be(ContextMessage);
                    return await GetTaskAction()(value);
                },
                ContextMessage
            );

            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_Task_Right_T_E_executes_func_conditionally_and_passes_context(
            bool isSuccess,
            bool condition
        )
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            Result<T, E> returned = await result.MapIf(
                condition,
                async (value, context) =>
                {
                    context.Should().Be(ContextMessage);
                    return await GetTaskAction()(value);
                },
                ContextMessage
            );

            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueErrorResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_Task_Right_computes_predicate_T_executes_func_conditionally_and_passes_context(
            bool isSuccess,
            bool condition
        )
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            Result<T> returned = await result.MapIf(
                (value, context) => GetValuePredicate(condition)(value),
                async (value, context) =>
                {
                    context.Should().Be(ContextMessage);
                    return await GetTaskAction()(value);
                },
                ContextMessage
            );

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_Task_Right_computes_predicate_T_E_executes_func_conditionally_and_passes_context(
            bool isSuccess,
            bool condition
        )
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            Result<T, E> returned = await result.MapIf(
                (value, context) => GetValuePredicate(condition)(value),
                async (value, context) =>
                {
                    context.Should().Be(ContextMessage);
                    return await GetTaskAction()(value);
                },
                ContextMessage
            );

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueErrorResult(isSuccess, condition));
        }
    }
}
