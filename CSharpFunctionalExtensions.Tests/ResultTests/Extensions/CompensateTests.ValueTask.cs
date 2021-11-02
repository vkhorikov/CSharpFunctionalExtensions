using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class CompensateTests_ValueTask : CompensateTestsBase
    {
        [Fact]
        public async Task Compensate_ValueTask_returns_success_and_does_not_execute_func()
        {
            ValueTask<Result> input = Result.Success().AsValueTask();

            Result output = await input.Compensate(GetErrorResultValueTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_ValueTask_returns_failure_and_does_not_execute_func()
        {
            ValueTask<Result> input = Result.Failure(ErrorMessage).AsValueTask();

            Result output = await input.Compensate(GetSuccessResultValueTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_ValueTask_returns_success_and_execute_func()
        {
            ValueTask<Result> input = Result.Failure(ErrorMessage).AsValueTask();

            Result output = await input.Compensate(GetErrorResultValueTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_ValueTask_returns_E_success_and_does_not_execute_func()
        {
            ValueTask<Result> input = Result.Success().AsValueTask();

            UnitResult<E> output = await input.Compensate(GetErrorUnitResultValueTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_ValueTask_returns_E_failure_and_does_not_execute_func()
        {
            ValueTask<Result> input = Result.Failure(ErrorMessage).AsValueTask();

            UnitResult<E> output = await input.Compensate(GetSuccessUnitResultValueTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_ValueTask_returns_E_success_and_execute_func()
        {
            ValueTask<Result> input = Result.Failure(ErrorMessage).AsValueTask();

            UnitResult<E> output = await input.Compensate(GetErrorUnitResultValueTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_ValueTask_T_returns_success_and_does_not_execute_func()
        {
            ValueTask<Result<T>> input = Result.Success(T.Value).AsValueTask();

            Result output = await input.Compensate(GetErrorResultValueTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_ValueTask_T_returns_failure_and_does_not_execute_func()
        {
            ValueTask<Result<T>> input = Result.Failure<T>(ErrorMessage).AsValueTask();

            Result output = await input.Compensate(GetSuccessResultValueTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_ValueTask_T_returns_success_and_execute_func()
        {
            ValueTask<Result<T>> input = Result.Failure<T>(ErrorMessage).AsValueTask();

            Result output = await input.Compensate(GetErrorResultValueTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_ValueTask_T_returns_T_success_and_does_not_execute_func()
        {
            ValueTask<Result<T>> input = Result.Success(T.Value).AsValueTask();

            Result<T> output = await input.Compensate(GetErrorValueResultValueTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_ValueTask_T_returns_T_failure_and_does_not_execute_func()
        {
            ValueTask<Result<T>> input = Result.Failure<T>(ErrorMessage).AsValueTask();

            Result<T> output = await input.Compensate(GetSuccessValueResultValueTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_ValueTask_T_returns_T_success_and_execute_func()
        {
            ValueTask<Result<T>> input = Result.Failure<T>(ErrorMessage).AsValueTask();

            Result<T> output = await input.Compensate(GetErrorValueResultValueTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_ValueTask_T_returns_T_E_success_and_does_not_execute_func()
        {
            ValueTask<Result<T>> input = Result.Success(T.Value).AsValueTask();

            Result<T, E> output = await input.Compensate(GetErrorValueErrorResultValueTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_ValueTask_T_returns_T_E_failure_and_does_not_execute_func()
        {
            ValueTask<Result<T>> input = Result.Failure<T>(ErrorMessage).AsValueTask();

            Result<T, E> output = await input.Compensate(GetSuccessValueErrorResultValueTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_ValueTask_T_returns_T_E_success_and_execute_func()
        {
            ValueTask<Result<T>> input = Result.Failure<T>(ErrorMessage).AsValueTask();

            Result<T, E> output = await input.Compensate(GetErrorValueErrorResultValueTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_ValueTask_E_returns_success_and_does_not_execute_func()
        {
            ValueTask<UnitResult<E>> input = UnitResult.Success<E>().AsValueTask();

            Result output = await input.Compensate(GetErrorResultValueTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_ValueTask_E_returns_failure_and_does_not_execute_func()
        {
            ValueTask<UnitResult<E>> input = UnitResult.Failure(E.Value).AsValueTask();

            Result output = await input.Compensate(GetSuccessResultValueTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_ValueTask_E_returns_success_and_execute_func()
        {
            ValueTask<UnitResult<E>> input = UnitResult.Failure(E.Value).AsValueTask();

            Result output = await input.Compensate(GetErrorResultValueTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_ValueTask_E_returns_E2_success_and_does_not_execute_func()
        {
            ValueTask<UnitResult<E>> input = UnitResult.Success<E>().AsValueTask();

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResultValueTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_ValueTask_E_returns_E2_failure_and_does_not_execute_func()
        {
            ValueTask<UnitResult<E>> input = UnitResult.Failure(E.Value).AsValueTask();

            UnitResult<E2> output = await input.Compensate(GetSuccessUnitResultValueTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_ValueTask_E_returns_E2_success_and_execute_func()
        {
            ValueTask<UnitResult<E>> input = UnitResult.Failure(E.Value).AsValueTask();

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResultValueTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_ValueTask_T_E_returns_success_and_does_not_execute_func()
        {
            ValueTask<Result<T, E>> input = Result.Success<T, E>(T.Value).AsValueTask();

            Result output = await input.Compensate(GetErrorResultValueTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_ValueTask_T_E_returns_failure_and_does_not_execute_func()
        {
            ValueTask<Result<T, E>> input = Result.Failure<T, E>(E.Value).AsValueTask();

            Result output = await input.Compensate(GetSuccessResultValueTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_ValueTask_T_E_returns_success_and_execute_func()
        {
            ValueTask<Result<T, E>> input = Result.Failure<T, E>(E.Value).AsValueTask();

            Result output = await input.Compensate(GetErrorResultValueTask);

            AssertFailure(output, executed: true);
        }

        [Fact]
        public async Task Compensate_ValueTask_T_E_returns_E2_success_and_does_not_execute_func()
        {
            ValueTask<Result<T, E>> input = Result.Success<T, E>(T.Value).AsValueTask();

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResultValueTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_ValueTask_T_E_returns_E2_failure_and_does_not_execute_func()
        {
            ValueTask<Result<T, E>> input = Result.Failure<T, E>(E.Value).AsValueTask();

            UnitResult<E2> output = await input.Compensate(GetSuccessUnitResultValueTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_ValueTask_T_E_returns_E2_success_and_execute_func()
        {
            ValueTask<Result<T, E>> input = Result.Failure<T, E>(E.Value).AsValueTask();

            UnitResult<E2> output = await input.Compensate(GetErrorUnitResultValueTask);

            AssertFailure(output, executed: true);
        }


        [Fact]
        public async Task Compensate_ValueTask_T_E_returns_T_E2_success_and_does_not_execute_func()
        {
            ValueTask<Result<T, E>> input = Result.Success<T, E>(T.Value).AsValueTask();

            Result<T, E2> output = await input.Compensate(GetErrorValueErrorResultValueTask);

            AssertSuccess(output, executed: false);
        }

        [Fact]
        public async Task Compensate_ValueTask_T_E_returns_T_E2_failure_and_does_not_execute_func()
        {
            ValueTask<Result<T, E>> input = Result.Failure<T, E>(E.Value).AsValueTask();

            Result<T, E2> output = await input.Compensate(GetSuccessValueErrorResultValueTask);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Compensate_ValueTask_T_E_returns_T_E2_success_and_execute_func()
        {
            ValueTask<Result<T, E>> input = Result.Failure<T, E>(E.Value).AsValueTask();

            Result<T, E2> output = await input.Compensate(GetErrorValueErrorResultValueTask);

            AssertFailure(output, executed: true);
        }
    }
}
