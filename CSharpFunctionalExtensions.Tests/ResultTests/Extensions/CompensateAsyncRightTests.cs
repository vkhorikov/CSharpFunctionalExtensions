using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class CompensateAsyncRightTests : CompensateTestsBase
    {
        [Fact]
        public async Task Compensate_returns_success_and_does_not_execute_func()
        {
            Result input = Result.Success();

            Result output = await input.Compensate(GetErrorResultAsync);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_returns_failure_and_does_not_execute_func()
        {
            Result input = Result.Failure(ErrorMessage);

            Result output = await input.Compensate(GetSuccessResultAsync);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_returns_success_and_execute_func()
        {
            Result input = Result.Failure(ErrorMessage);

            Result output = await input.Compensate(GetErrorResultAsync);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_returns_E_success_and_does_not_execute_func()
        {
            Result input = Result.Success();

            UnitResult<E> output = await input.Compensate(GetErrorUnitResultAsync);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_returns_E_failure_and_does_not_execute_func()
        {
            Result input = Result.Failure(ErrorMessage);

            UnitResult<E> output = await input.Compensate(GetSuccessUnitResultAsync);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_returns_E_success_and_execute_func()
        {
            Result input = Result.Failure(ErrorMessage);

            UnitResult<E> output = await input.Compensate(GetErrorUnitResultAsync);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_T_returns_success_and_does_not_execute_func()
        {
            Result<T> input = Result.Success(T.Value);

            Result output = await input.Compensate(GetErrorResultAsync);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_T_returns_failure_and_does_not_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result output = await input.Compensate(GetSuccessResultAsync);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_T_returns_success_and_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result output = await input.Compensate(GetErrorResultAsync);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_T_returns_T_success_and_does_not_execute_func()
        {
            Result<T> input = Result.Success(T.Value);

            Result<T> output = await input.Compensate(GetErrorValueResultAsync);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_T_returns_T_failure_and_does_not_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result<T> output = await input.Compensate(GetSuccessValueResultAsync);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_T_returns_T_success_and_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result<T> output = await input.Compensate(GetErrorValueResultAsync);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_T_returns_T_E_success_and_does_not_execute_func()
        {
            Result<T> input = Result.Success(T.Value);

            Result<T, E> output = await input.Compensate(GetErrorValueErrorResultAsync);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_T_returns_T_E_failure_and_does_not_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result<T, E> output = await input.Compensate(GetSuccessValueErrorResultAsync);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_T_returns_T_E_success_and_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result<T, E> output = await input.Compensate(GetErrorValueErrorResultAsync);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_E_returns_success_and_does_not_execute_func()
        {
            UnitResult<E> input = UnitResult.Success<E>();

            Result output = await input.Compensate(GetErrorResultAsync);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_E_returns_failure_and_does_not_execute_func()
        {
            UnitResult<E> input = UnitResult.Failure(E.Value);

            Result output = await input.Compensate(GetSuccessResultAsync);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_E_returns_success_and_execute_func()
        {
            UnitResult<E> input = UnitResult.Failure(E.Value);

            Result output = await input.Compensate(GetErrorResultAsync);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_E_returns_E2_success_and_does_not_execute_func()
        {
            UnitResult<E> input = UnitResult.Success<E>();

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResultAsync);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_E_returns_E2_failure_and_does_not_execute_func()
        {
            UnitResult<E> input = UnitResult.Failure(E.Value);

            UnitResult<E2> output = await input.Compensate(GetSuccessUnitResultAsync);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_E_returns_E2_success_and_execute_func()
        {
            UnitResult<E> input = UnitResult.Failure(E.Value);

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResultAsync);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_T_E_returns_success_and_does_not_execute_func()
        {
            Result<T, E> input = Result.Success<T, E>(T.Value);

            Result output = await input.Compensate(GetErrorResultAsync);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_T_E_returns_failure_and_does_not_execute_func()
        {
            Result<T, E> input = Result.Failure<T, E>(E.Value);

            Result output = await input.Compensate(GetSuccessResultAsync);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_T_E_returns_success_and_execute_func()
        {
            Result<T, E> input = Result.Failure<T, E>(E.Value);

            Result output = await input.Compensate(GetErrorResultAsync);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_T_E_returns_E2_success_and_does_not_execute_func()
        {
            Result<T, E> input = Result.Success<T, E>(T.Value);

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResultAsync);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_T_E_returns_E2_failure_and_does_not_execute_func()
        {
            Result<T, E> input = Result.Failure<T, E>(E.Value);

            UnitResult<E2> output = await input.Compensate(GetSuccessUnitResultAsync);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_T_E_returns_E2_success_and_execute_func()
        {
            Result<T, E> input = Result.Failure<T, E>(E.Value);

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResultAsync);

            AssertFailure(output, executed: true);
        }


        [Fact]
        public async Task Compensate_T_E_returns_T_E2_success_and_does_not_execute_func()
        {
            Result<T, E> input = Result.Success<T, E>(T.Value);

            Result<T, E2> output = await input.Compensate(GetErrorValueErrorResultAsync);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_T_E_returns_T_E2_failure_and_does_not_execute_func()
        {
            Result<T, E> input = Result.Failure<T, E>(E.Value);

            Result<T, E2> output = await input.Compensate(GetSuccessValueErrorResultAsync);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_T_E_returns_T_E2_success_and_execute_func()
        {
            Result<T, E> input = Result.Failure<T, E>(E.Value);

            Result<T, E2> output = await input.Compensate(GetErrorValueErrorResultAsync);

            AssertFailure(output, executed: true);
        }
    }
}
