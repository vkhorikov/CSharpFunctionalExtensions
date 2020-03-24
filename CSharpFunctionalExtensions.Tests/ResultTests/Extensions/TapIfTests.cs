using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class TapIf : TapIfTestsBase
    {
        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_executes_action_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Result result = Result.SuccessIf(isSuccess, ErrorMessage);

            var returned = result.TapIf(condition, Action);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_executes_action_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            var returned = result.TapIf(condition, Action);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_executes_action_T_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            var returned = result.TapIf(condition, Action_T);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_E_executes_action_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            var returned = result.TapIf(condition, Action);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_E_executes_action_T_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            var returned = result.TapIf(condition, Action_T);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_executes_func_result_T_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Result<bool> result = Result.SuccessIf(isSuccess, condition, ErrorMessage);

            var returned = result.TapIf(condition, Func_Result);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_executes_func_result_K_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Result<bool> result = Result.SuccessIf(isSuccess, condition, ErrorMessage);

            var returned = result.TapIf(condition, Func_Result_K);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_executes_func_result_K_E_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Result<bool, E> result = Result.SuccessIf(isSuccess, condition, E.Value);

            var returned = result.TapIf(condition, Func_Result_K_E);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_executes_action_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Result<bool> result = Result.SuccessIf(isSuccess, condition, ErrorMessage);

            var returned = result.TapIf(Predicate, Action);

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_executes_action_T_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Result<bool> result = Result.SuccessIf(isSuccess, condition, ErrorMessage);

            var returned = result.TapIf(Predicate, Action_T);

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_E_executes_action_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Result<bool, E> result = Result.SuccessIf(isSuccess, condition, E.Value);

            var returned = result.TapIf(Predicate, Action);

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_E_executes_action_T_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Result<bool, E> result = Result.SuccessIf(isSuccess, condition, E.Value);

            var returned = result.TapIf(Predicate, Action_T);

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_executes_func_result_T_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Result<bool> result = Result.SuccessIf(isSuccess, condition, ErrorMessage);

            var returned = result.TapIf(Predicate, Func_Result);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_executes_func_result_K_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Result<bool> result = Result.SuccessIf(isSuccess, condition, ErrorMessage);

            var returned = result.TapIf(Predicate, Func_Result_K);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_executes_func_result_K_E_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Result<bool, E> result = Result.SuccessIf(isSuccess, condition, E.Value);

            var returned = result.TapIf(Predicate, Func_Result_K_E);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }
    }
}
