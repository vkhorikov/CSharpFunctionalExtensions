using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class TapIfAsyncBoth : TapIfTestsBase
    {
        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_AsyncBoth_executes_action_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Result result = Result.SuccessIf(isSuccess, ErrorMessage);

            var returned = result.AsTask().TapIf(condition, Task_Action).Result;

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_AsyncBoth_executes_action_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            var returned = result.AsTask().TapIf(condition, Task_Action).Result;

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_AsyncBoth_executes_action_T_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            var returned = result.AsTask().TapIf(condition, Task_Action_T).Result;

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_E_AsyncBoth_executes_action_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            var returned = result.AsTask().TapIf(condition, Task_Action).Result;

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_E_AsyncBoth_executes_action_T_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            var returned = result.AsTask().TapIf(condition, Task_Action_T).Result;

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_AsyncBoth_executes_func_result_T_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Result<bool> result = Result.SuccessIf(isSuccess, condition, ErrorMessage);

            var returned = result.AsTask().TapIf(condition, Task_Func_Result).Result;

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_AsyncBoth_executes_func_result_K_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Result<bool> result = Result.SuccessIf(isSuccess, condition, ErrorMessage);

            var returned = result.AsTask().TapIf(condition, Task_Func_Result_K).Result;

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_AsyncBoth_executes_func_result_K_E_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Result<bool, E> result = Result.SuccessIf(isSuccess, condition, E.Value);

            var returned = result.AsTask().TapIf(condition, Task_Func_Result_K_E).Result;

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_AsyncBoth_executes_action_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Result<bool> result = Result.SuccessIf(isSuccess, condition, ErrorMessage);

            var returned = result.AsTask().TapIf(Predicate, Task_Action).Result;

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_AsyncBoth_executes_action_T_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Result<bool> result = Result.SuccessIf(isSuccess, condition, ErrorMessage);

            var returned = result.AsTask().TapIf(Predicate, Task_Action_T).Result;

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_E_AsyncBoth_executes_action_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Result<bool, E> result = Result.SuccessIf(isSuccess, condition, E.Value);

            var returned = result.AsTask().TapIf(Predicate, Task_Action).Result;

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_E_AsyncBoth_executes_action_T_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Result<bool, E> result = Result.SuccessIf(isSuccess, condition, E.Value);

            var returned = result.AsTask().TapIf(Predicate, Task_Action_T).Result;

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_AsyncBoth_executes_func_result_T_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Result<bool> result = Result.SuccessIf(isSuccess, condition, ErrorMessage);

            var returned = result.AsTask().TapIf(Predicate, Task_Func_Result).Result;

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_AsyncBoth_executes_func_result_K_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Result<bool> result = Result.SuccessIf(isSuccess, condition, ErrorMessage);

            var returned = result.AsTask().TapIf(Predicate, Task_Func_Result_K).Result;

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_AsyncBoth_executes_func_result_K_E_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Result<bool, E> result = Result.SuccessIf(isSuccess, condition, E.Value);

            var returned = result.AsTask().TapIf(Predicate, Task_Func_Result_K_E).Result;

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }
    }
}
