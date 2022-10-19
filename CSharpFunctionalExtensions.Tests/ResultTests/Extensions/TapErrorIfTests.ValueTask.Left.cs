using FluentAssertions;
using CSharpFunctionalExtensions.ValueTasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class TapErrorIfTests_ValueTask_Left : TapErrorIfTestsBase
    {
        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapErrorIf_ValueTask_Left_executes_action_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Result result = Result.SuccessIf(isSuccess, ErrorMessage);

            var returned = result.AsValueTask().TapErrorIf(condition, Action).Result;

            actionExecuted.Should().Be(!isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapErrorIf_ValueTask_Left_executes_action_String_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Result result = Result.SuccessIf(isSuccess, ErrorMessage);

            var returned = result.AsValueTask().TapErrorIf(condition, Action_String).Result;

            actionExecuted.Should().Be(!isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapErrorIf_ValueTask_Left_T_executes_action_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            var returned = result.AsValueTask().TapErrorIf(condition, Action).Result;

            actionExecuted.Should().Be(!isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapErrorIf_ValueTask_Left_T_executes_action_T_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            var returned = result.AsValueTask().TapErrorIf(condition, Action_String).Result;

            actionExecuted.Should().Be(!isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapErrorIf_ValueTask_Left_T_E_executes_action_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            var returned = result.AsValueTask().TapErrorIf(condition, Action).Result;

            actionExecuted.Should().Be(!isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapErrorIf_ValueTask_Left_T_E_executes_action_T_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            var returned = result.AsValueTask().TapErrorIf(condition, Action_E).Result;

            actionExecuted.Should().Be(!isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapErrorIf_ValueTask_Left_E_executes_action_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            UnitResult<E> result = UnitResult.SuccessIf(isSuccess, E.Value);

            var returned = result.AsValueTask().TapErrorIf(condition, Action).Result;

            actionExecuted.Should().Be(!isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapErrorIf_ValueTask_Left_E_executes_action_T_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            UnitResult<E> result = UnitResult.SuccessIf(isSuccess, E.Value);

            var returned = result.AsValueTask().TapErrorIf(condition, Action_E).Result;

            actionExecuted.Should().Be(!isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapErrorIf_ValueTask_Left_executes_action_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Result result = Result.SuccessIf(isSuccess, ErrorMessage);

            var returned = result.AsValueTask().TapErrorIf(Predicate_String(condition), Action).Result;

            predicateExecuted.Should().Be(!isSuccess);
            actionExecuted.Should().Be(!isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapErrorIf_ValueTask_Left_executes_action_String_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Result result = Result.SuccessIf(isSuccess, ErrorMessage);

            var returned = result.AsValueTask().TapErrorIf(Predicate_String(condition), Action_String).Result;

            predicateExecuted.Should().Be(!isSuccess);
            actionExecuted.Should().Be(!isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapErrorIf_ValueTask_Left_T_executes_action_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            var returned = result.AsValueTask().TapErrorIf(Predicate_String(condition), Action).Result;

            predicateExecuted.Should().Be(!isSuccess);
            actionExecuted.Should().Be(!isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapErrorIf_ValueTask_Left_T_executes_action_String_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            var returned = result.AsValueTask().TapErrorIf(Predicate_String(condition), Action_String).Result;

            predicateExecuted.Should().Be(!isSuccess);
            actionExecuted.Should().Be(!isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapErrorIf_ValueTask_Left_T_E_executes_action_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            var returned = result.AsValueTask().TapErrorIf(Predicate_E(condition), Action).Result;

            predicateExecuted.Should().Be(!isSuccess);
            actionExecuted.Should().Be(!isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapErrorIf_ValueTask_Left_T_E_executes_action_E_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            var returned = result.AsValueTask().TapErrorIf(Predicate_E(condition), Action_E).Result;

            predicateExecuted.Should().Be(!isSuccess);
            actionExecuted.Should().Be(!isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapErrorIf_ValueTask_Left_E_executes_action_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            UnitResult<E> result = UnitResult.SuccessIf(isSuccess, E.Value);

            var returned = result.AsValueTask().TapErrorIf(Predicate_E(condition), Action).Result;

            predicateExecuted.Should().Be(!isSuccess);
            actionExecuted.Should().Be(!isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapErrorIf_ValueTask_Left_E_executes_action_E_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            UnitResult<E> result = UnitResult.SuccessIf(isSuccess, E.Value);

            var returned = result.AsValueTask().TapErrorIf(Predicate_E(condition), Action_E).Result;

            predicateExecuted.Should().Be(!isSuccess);
            actionExecuted.Should().Be(!isSuccess && condition);
            result.Should().Be(returned);
        }
    }
}
