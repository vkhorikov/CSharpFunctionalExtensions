using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class CompensateTests : CompensateTestsBase
    {
        [Fact]
        public void Compensate_returns_success_and_does_not_execute_func()
        {
            Result input = Result.Success();

            Result output = input.Compensate(GetErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public void Compensate_returns_failure_and_does_not_execute_func()
        {
            Result input = Result.Failure(ErrorMessage);

            Result output = input.Compensate(GetSuccessResult);

            AssertSuccess(output);
        }

        [Fact]
        public void Compensate_returns_success_and_execute_func()
        {
            Result input = Result.Failure(ErrorMessage);

            Result output = input.Compensate(GetErrorResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public void Compensate_returns_E_success_and_does_not_execute_func()
        {
            Result input = Result.Success();

            UnitResult<E> output = input.Compensate(GetErrorUnitResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public void Compensate_returns_E_failure_and_does_not_execute_func()
        {
            Result input = Result.Failure(ErrorMessage);

            UnitResult<E> output = input.Compensate(GetSuccessUnitResult);

            AssertSuccess(output);
        }

        [Fact]
        public void Compensate_returns_E_success_and_execute_func()
        {
            Result input = Result.Failure(ErrorMessage);

            UnitResult<E> output = input.Compensate(GetErrorUnitResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public void Compensate_T_returns_success_and_does_not_execute_func()
        {
            Result<T> input = Result.Success(T.Value);

            Result output = input.Compensate(GetErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public void Compensate_T_returns_failure_and_does_not_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result output = input.Compensate(GetSuccessResult);

            AssertSuccess(output);
        }

        [Fact]
        public void Compensate_T_returns_success_and_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result output = input.Compensate(GetErrorResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public void Compensate_T_returns_T_success_and_does_not_execute_func()
        {
            Result<T> input = Result.Success(T.Value);

            Result<T> output = input.Compensate(GetErrorValueResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public void Compensate_T_returns_T_failure_and_does_not_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result<T> output = input.Compensate(GetSuccessValueResult);

            AssertSuccess(output);
        }

        [Fact]
        public void Compensate_T_returns_T_success_and_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result<T> output = input.Compensate(GetErrorValueResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public void Compensate_T_returns_T_E_success_and_does_not_execute_func()
        {
            Result<T> input = Result.Success(T.Value);

            Result<T, E> output = input.Compensate(GetErrorValueErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public void Compensate_T_returns_T_E_failure_and_does_not_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result<T, E> output = input.Compensate(GetSuccessValueErrorResult);

            AssertSuccess(output);
        }

        [Fact]
        public void Compensate_T_returns_T_E_success_and_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result<T, E> output = input.Compensate(GetErrorValueErrorResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public void Compensate_E_returns_success_and_does_not_execute_func()
        {
            UnitResult<E> input = UnitResult.Success<E>();

            Result output = input.Compensate(GetErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public void Compensate_E_returns_failure_and_does_not_execute_func()
        {
            UnitResult<E> input = UnitResult.Failure(E.Value);

            Result output = input.Compensate(GetSuccessResult);

            AssertSuccess(output);
        }

        [Fact]
        public void Compensate_E_returns_success_and_execute_func()
        {
            UnitResult<E> input = UnitResult.Failure(E.Value);

            Result output = input.Compensate(GetErrorResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public void Compensate_E_returns_E2_success_and_does_not_execute_func()
        {
            UnitResult<E> input = UnitResult.Success<E>();

            UnitResult<E2> output = input.Compensate(GetErrorUnitResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public void Compensate_E_returns_E2_failure_and_does_not_execute_func()
        {
            UnitResult<E> input = UnitResult.Failure(E.Value);

            UnitResult<E2> output = input.Compensate(GetSuccessUnitResult);

            AssertSuccess(output);
        }

        [Fact]
        public void Compensate_E_returns_E2_success_and_execute_func()
        {
            UnitResult<E> input = UnitResult.Failure(E.Value);

            UnitResult<E2> output = input.Compensate(GetErrorUnitResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public void Compensate_T_E_returns_success_and_does_not_execute_func()
        {
            Result<T, E> input = Result.Success<T, E>(T.Value);

            Result output = input.Compensate(GetErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public void Compensate_T_E_returns_failure_and_does_not_execute_func()
        {
            Result<T, E> input = Result.Failure<T, E>(E.Value);

            Result output = input.Compensate(GetSuccessResult);

            AssertSuccess(output);
        }

        [Fact]
        public void Compensate_T_E_returns_success_and_execute_func()
        {
            Result<T, E> input = Result.Failure<T, E>(E.Value);

            Result output = input.Compensate(GetErrorResult);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public void Compensate_T_E_returns_E2_success_and_does_not_execute_func()
        {
            Result<T, E> input = Result.Success<T, E>(T.Value);

            UnitResult<E2> output = input.Compensate(GetErrorUnitResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public void Compensate_T_E_returns_E2_failure_and_does_not_execute_func()
        {
            Result<T, E> input = Result.Failure<T, E>(E.Value);

            UnitResult<E2> output = input.Compensate(GetSuccessUnitResult);

            AssertSuccess(output);
        }

        [Fact]
        public void Compensate_T_E_returns_E2_success_and_execute_func()
        {
            Result<T, E> input = Result.Failure<T, E>(E.Value);

            UnitResult<E2> output = input.Compensate(GetErrorUnitResult);

            AssertFailure(output, executed: true);
        }


        [Fact]
        public void Compensate_T_E_returns_T_E2_success_and_does_not_execute_func()
        {
            Result<T, E> input = Result.Success<T, E>(T.Value);

            Result<T, E2> output = input.Compensate(GetErrorValueErrorResult);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public void Compensate_T_E_returns_T_E2_failure_and_does_not_execute_func()
        {
            Result<T, E> input = Result.Failure<T, E>(E.Value);

            Result<T, E2> output = input.Compensate(GetSuccessValueErrorResult);

            AssertSuccess(output);
        }

        [Fact]
        public void Compensate_T_E_returns_T_E2_success_and_execute_func()
        {
            Result<T, E> input = Result.Failure<T, E>(E.Value);

            Result<T, E2> output = input.Compensate(GetErrorValueErrorResult);

            AssertFailure(output, executed: true);
        }
    }
}
