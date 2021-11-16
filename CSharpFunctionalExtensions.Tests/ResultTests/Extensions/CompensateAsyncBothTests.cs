using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class CompensateAsyncBothTests : CompensateTestsBase
    {
        [Fact]
        public async Task Compensate_returns_success_and_does_not_execute_func()
        {
            Task<Result> input = Result.Success().AsTask();

            Result output = await input.Compensate(GetErrorResultAsync);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_returns_failure_and_does_not_execute_func()
        {
            Task<Result> input = Result.Failure(ErrorMessage).AsTask();

            Result output = await input.Compensate(GetSuccessResultAsync);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_returns_success_and_execute_func()
        {
            Task<Result> input = Result.Failure(ErrorMessage).AsTask();

            Result output = await input.Compensate(GetErrorResultAsync);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_returns_E_success_and_does_not_execute_func()
        {
            Task<Result> input = Result.Success().AsTask();

            UnitResult<E> output = await input.Compensate(GetErrorUnitResultAsync);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_returns_E_failure_and_does_not_execute_func()
        {
            Task<Result> input = Result.Failure(ErrorMessage).AsTask();

            UnitResult<E> output = await input.Compensate(GetSuccessUnitResultAsync);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_returns_E_success_and_execute_func()
        {
            Task<Result> input = Result.Failure(ErrorMessage).AsTask();

            UnitResult<E> output = await input.Compensate(GetErrorUnitResultAsync);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_T_returns_success_and_does_not_execute_func()
        {
            Task<Result<T>> input = Result.Success(T.Value).AsTask();

            Result output = await input.Compensate(GetErrorResultAsync);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_T_returns_failure_and_does_not_execute_func()
        {
            Task<Result<T>> input = Result.Failure<T>(ErrorMessage).AsTask();

            Result output = await input.Compensate(GetSuccessResultAsync);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_T_returns_success_and_execute_func()
        {
            Task<Result<T>> input = Result.Failure<T>(ErrorMessage).AsTask();

            Result output = await input.Compensate(GetErrorResultAsync);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_T_returns_T_success_and_does_not_execute_func()
        {
            Task<Result<T>> input = Result.Success(T.Value).AsTask();

            Result<T> output = await input.Compensate(GetErrorValueResultAsync);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_T_returns_T_failure_and_does_not_execute_func()
        {
            Task<Result<T>> input = Result.Failure<T>(ErrorMessage).AsTask();

            Result<T> output = await input.Compensate(GetSuccessValueResultAsync);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_T_returns_T_success_and_execute_func()
        {
            Task<Result<T>> input = Result.Failure<T>(ErrorMessage).AsTask();

            Result<T> output = await input.Compensate(GetErrorValueResultAsync);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_T_returns_T_E_success_and_does_not_execute_func()
        {
            Task<Result<T>> input = Result.Success(T.Value).AsTask();

            Result<T, E> output = await input.Compensate(GetErrorValueErrorResultAsync);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_T_returns_T_E_failure_and_does_not_execute_func()
        {
            Task<Result<T>> input = Result.Failure<T>(ErrorMessage).AsTask();

            Result<T, E> output = await input.Compensate(GetSuccessValueErrorResultAsync);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_T_returns_T_E_success_and_execute_func()
        {
            Task<Result<T>> input = Result.Failure<T>(ErrorMessage).AsTask();

            Result<T, E> output = await input.Compensate(GetErrorValueErrorResultAsync);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_E_returns_success_and_does_not_execute_func()
        {
            Task<UnitResult<E>> input = UnitResult.Success<E>().AsTask();

            Result output = await input.Compensate(GetErrorResultAsync);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_E_returns_failure_and_does_not_execute_func()
        {
            Task<UnitResult<E>> input = UnitResult.Failure(E.Value).AsTask();

            Result output = await input.Compensate(GetSuccessResultAsync);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_E_returns_success_and_execute_func()
        {
            Task<UnitResult<E>> input = UnitResult.Failure(E.Value).AsTask();

            Result output = await input.Compensate(GetErrorResultAsync);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_E_returns_E2_success_and_does_not_execute_func()
        {
            Task<UnitResult<E>> input = UnitResult.Success<E>().AsTask();

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResultAsync);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_E_returns_E2_failure_and_does_not_execute_func()
        {
            Task<UnitResult<E>> input = UnitResult.Failure(E.Value).AsTask();

            UnitResult<E2> output = await input.Compensate(GetSuccessUnitResultAsync);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_E_returns_E2_success_and_execute_func()
        {
            Task<UnitResult<E>> input = UnitResult.Failure(E.Value).AsTask();

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResultAsync);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_T_E_returns_success_and_does_not_execute_func()
        {
            Task<Result<T, E>> input = Result.Success<T, E>(T.Value).AsTask();

            Result output = await input.Compensate(GetErrorResultAsync);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_T_E_returns_failure_and_does_not_execute_func()
        {
            Task<Result<T, E>> input = Result.Failure<T, E>(E.Value).AsTask();

            Result output = await input.Compensate(GetSuccessResultAsync);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_T_E_returns_success_and_execute_func()
        {
            Task<Result<T, E>> input = Result.Failure<T, E>(E.Value).AsTask();

            Result output = await input.Compensate(GetErrorResultAsync);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_T_E_returns_E2_success_and_does_not_execute_func()
        {
            Task<Result<T, E>> input = Result.Success<T, E>(T.Value).AsTask();

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResultAsync);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_T_E_returns_E2_failure_and_does_not_execute_func()
        {
            Task<Result<T, E>> input = Result.Failure<T, E>(E.Value).AsTask();

            UnitResult<E2> output = await input.Compensate(GetSuccessUnitResultAsync);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_T_E_returns_E2_success_and_execute_func()
        {
            Task<Result<T, E>> input = Result.Failure<T, E>(E.Value).AsTask();

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResultAsync);

            AssertFailure(output, executed: true);
        }


        [Fact]
        public async Task Compensate_T_E_returns_T_E2_success_and_does_not_execute_func()
        {
            Task<Result<T, E>> input = Result.Success<T, E>(T.Value).AsTask();

            Result<T, E2> output = await input.Compensate(GetErrorValueErrorResultAsync);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_T_E_returns_T_E2_failure_and_does_not_execute_func()
        {
            Task<Result<T, E>> input = Result.Failure<T, E>(E.Value).AsTask();

            Result<T, E2> output = await input.Compensate(GetSuccessValueErrorResultAsync);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_T_E_returns_T_E2_success_and_execute_func()
        {
            Task<Result<T, E>> input = Result.Failure<T, E>(E.Value).AsTask();

            Result<T, E2> output = await input.Compensate(GetErrorValueErrorResultAsync);

            AssertFailure(output, executed: true);
        }
    }
}
