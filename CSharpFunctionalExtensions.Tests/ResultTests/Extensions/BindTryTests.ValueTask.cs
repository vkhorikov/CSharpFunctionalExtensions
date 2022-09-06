using CSharpFunctionalExtensions.ValueTasks;
using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class BindTryTests_ValueTask : BindTryTestsBase
    {
        #region BindTry for ValueTask<Result> with function returning ValueTask<Result>
        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_success_on_valuetask_success_returns_success()
        {
            ValueTask<Result> sut = Result.Success().AsValueTask();

            Result result = await sut.BindTry(ValueTask_Success);

            AssertSuccess(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_success_on_valuetask_failure_returns_failure()
        {
            ValueTask<Result> sut = Result.Failure(ErrorMessage).AsValueTask();

            Result result = await sut.BindTry(ValueTask_Success);

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_failure_on_valuetask_success_returns_failure()
        {
            ValueTask<Result> sut = Result.Success().AsValueTask();

            Result result = await sut.BindTry(ValueTask_Failure);

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_throwing_valuetask_func_on_taks_success_returns_failure_with_exception_message()
        {
            ValueTask<Result> sut = Result.Success().AsValueTask();

            Result result = await sut.BindTry(ValueTask_Throwing);

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_throwing_valuetask_func_on_success_with_custom_error_handler_returns_failure_with_custom_message()
        {
            ValueTask<Result> sut = Result.Success().AsValueTask();

            Result result = await sut.BindTry(ValueTask_Throwing, e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for ValueTask<Result> with function returning ValueTask<Result<K>>
        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_success_K_on_valuetask_success_returns_success()
        {
            ValueTask<Result> sut = Result.Success().AsValueTask();

            Result<K> result = await sut.BindTry(ValueTask_Success_K);

            AssertSuccess(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_success_K_on_valuetask_failure_returns_failure()
        {
            ValueTask<Result> sut = Result.Failure(ErrorMessage).AsValueTask();

            Result<K> result = await sut.BindTry(ValueTask_Success_K);

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_failure_K_on_valuetask_success_returns_failure()
        {
            ValueTask<Result> sut = Result.Success().AsValueTask();

            Result<K> result = await sut.BindTry(ValueTask_Failure_K);

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_throwing_valuetask_func_K_on_taks_success_returns_failure_with_exception_message()
        {
            ValueTask<Result> sut = Result.Success().AsValueTask();

            Result<K> result = await sut.BindTry(ValueTask_Throwing_K);

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_throwing_valuetask_func_K_on_valuetask_success_with_custom_error_handler_returns_failure_with_custom_message()
        {
            ValueTask<Result> sut = Result.Success().AsValueTask();

            Result<K> result = await sut.BindTry(ValueTask_Throwing_K, e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for ValueTask<Result<T>> with function returning ValueTask<Result>
        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_success_T_on_valuetask_success_returns_success()
        {
            ValueTask<Result<T>> sut = Result.Success(T.Value).AsValueTask();

            Result result = await sut.BindTry(t => ValueTask_Success());

            AssertSuccess(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_success_T_on_valuetask_failure_returns_failure()
        {
            ValueTask<Result<T>> sut = Result.Failure<T>(ErrorMessage).AsValueTask();

            Result result = await sut.BindTry(t => ValueTask_Success());

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_failure_T_on_valuetask_success_returns_failure()
        {
            ValueTask<Result<T>> sut = Result.Success(T.Value).AsValueTask();

            Result result = await sut.BindTry(t => ValueTask_Failure());

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_throwing_valuetask_func_on_taks_success_T_returns_failure_with_exception_message()
        {
            ValueTask<Result<T>> sut = Result.Success(T.Value).AsValueTask();

            Result result = await sut.BindTry(t => ValueTask_Throwing());

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_throwing_valuetask_func_on_success_T_with_custom_error_handler_returns_failure_with_custom_message()
        {
            ValueTask<Result<T>> sut = Result.Success(T.Value).AsValueTask();

            Result result = await sut.BindTry(t => ValueTask_Throwing(), e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for ValueTask<Result<T>> with function returning ValueTask<Result<K>>
        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_success_K_on_valuetask_success_T_returns_success()
        {
            ValueTask<Result<T>> sut = Result.Success(T.Value).AsValueTask();

            Result<K> result = await sut.BindTry(t => ValueTask_Success_K());

            AssertSuccess(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_success_K_on_valuetask_failure_T_returns_failure()
        {
            ValueTask<Result<T>> sut = Result.Failure<T>(ErrorMessage).AsValueTask();

            Result<K> result = await sut.BindTry(t => ValueTask_Success_K());

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_failure_K_on_valuetask_success_T_returns_failure()
        {
            ValueTask<Result<T>> sut = Result.Success(T.Value).AsValueTask();

            Result<K> result = await sut.BindTry(t => ValueTask_Failure_K());

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_throwing_valuetask_func_K_on_taks_success_T_returns_failure_with_exception_message()
        {
            ValueTask<Result<T>> sut = Result.Success(T.Value).AsValueTask();

            Result<K> result = await sut.BindTry(t => ValueTask_Throwing_K());

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_throwing_valuetask_func_K_on_success_T_with_custom_error_handler_returns_failure_with_custom_message()
        {
            ValueTask<Result<T>> sut = Result.Success(T.Value).AsValueTask();

            Result<K> result = await sut.BindTry(t => ValueTask_Throwing_K(), e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for ValueTask<Result<T,E>> with function returning ValueTask<UnitResult<E>>
        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_success_E_on_valuetask_success_T_E_returns_success()
        {
            ValueTask<Result<T, E>> sut = Result.Success<T, E>(T.Value).AsValueTask();

            UnitResult<E> result = await sut.BindTry(t => ValueTask_UnitResult_Success_E(), e => E.Value2);

            AssertSuccess(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_success_E_on_valuetask_failure_T_E_returns_failure()
        {
            ValueTask<Result<T, E>> sut = Result.Failure<T, E>(E.Value).AsValueTask();

            UnitResult<E> result = await sut.BindTry(t => ValueTask_UnitResult_Success_E(), e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_failure_E_on_valuetask_success_T_E_returns_failure()
        {
            ValueTask<Result<T, E>> sut = Result.Success<T, E>(T.Value).AsValueTask();

            UnitResult<E> result = await sut.BindTry(t => ValueTask_UnitResult_Failure_E(), e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_throwing_valuetask_func_E_on_success_T_E_returns_failure_with_value_from_error_handler()
        {
            ValueTask<Result<T, E>> sut = Result.Success<T, E>(T.Value).AsValueTask();

            UnitResult<E> result = await sut.BindTry(t => ValueTask_Throwing_E(), e => E.Value2);

            AssertFailure(result, E.Value2);
        }
        #endregion

        #region BindTry for ValueTask<Result<T,E>> with function returning ValueTask<Result<K,E>>
        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_success_K_E_on_valuetask_success_T_E_returns_success()
        {
            ValueTask<Result<T, E>> sut = Result.Success<T, E>(T.Value).AsValueTask();

            Result<K, E> result = await sut.BindTry(ValueTask_Success_K_E, e => E.Value2);

            AssertSuccess(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_success_K_E_on_valuetask_failure_T_E_returns_failure()
        {
            ValueTask<Result<T, E>> sut = Result.Failure<T, E>(E.Value).AsValueTask();

            Result<K, E> result = await sut.BindTry(ValueTask_Success_K_E, e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_failure_K_E_on_valuetask_success_T_E_returns_failure()
        {
            ValueTask<Result<T, E>> sut = Result.Success<T, E>(T.Value).AsValueTask();

            Result<K, E> result = await sut.BindTry(ValueTask_Failure_K_E, e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_throwing_valuetask_func_K_E_on_success_T_E_returns_failure_with_value_from_error_handler()
        {
            ValueTask<Result<T, E>> sut = Result.Success<T, E>(T.Value).AsValueTask();

            Result<K, E> result = await sut.BindTry(t => ValueTask_Throwing_K_E(), e => E.Value2);

            AssertFailure(result, E.Value2);
        }
        #endregion

        #region BindTry for ValueTask<UnitResult<E>> with function returning ValueTask<Result<T,E>>
        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_success_T_E_on_valuetask_success_E_returns_success()
        {
            ValueTask<UnitResult<E>> sut = UnitResult.Success<E>().AsValueTask();

            Result<T, E> result = await sut.BindTry(ValueTask_Success_T_E, e => E.Value2);

            AssertSuccess(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_success_T_E_on_valuetask_failure_E_returns_failure()
        {
            ValueTask<UnitResult<E>> sut = UnitResult.Failure(E.Value).AsValueTask();

            Result<T, E> result = await sut.BindTry(ValueTask_Success_T_E, e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_failure_T_E_on_valuetask_success_E_returns_failure()
        {
            ValueTask<UnitResult<E>> sut = UnitResult.Success<E>().AsValueTask();

            Result<T, E> result = await sut.BindTry(ValueTask_Failure_T_E, e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_throwing_valuetask_func_T_E_on_success_E_returns_failure_with_value_from_error_handler()
        {
            ValueTask<UnitResult<E>> sut = UnitResult.Success<E>().AsValueTask();

            Result<T, E> result = await sut.BindTry(ValueTask_Throwing_T_E, e => E.Value2);

            AssertFailure(result, E.Value2);
        }
        #endregion

        #region BindTry for ValueTask<UnitResult<E>> with function returning ValueTask<UnitResult<E>>
        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_success_E_on_valuetask_success_E_returns_success()
        {
            ValueTask<UnitResult<E>> sut = UnitResult.Success<E>().AsValueTask();

            UnitResult<E> result = await sut.BindTry(ValueTask_UnitResult_Success_E, e => E.Value2);

            AssertSuccess(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_success_E_on_valuetask_failure_E_returns_failure()
        {
            ValueTask<UnitResult<E>> sut = UnitResult.Failure(E.Value).AsValueTask();

            UnitResult<E> result = await sut.BindTry(ValueTask_UnitResult_Success_E, e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_valuetask_func_returning_failure_E_on_valuetask_success_E_returns_failure()
        {
            ValueTask<UnitResult<E>> sut = UnitResult.Success<E>().AsValueTask();

            UnitResult<E> result = await sut.BindTry(ValueTask_UnitResult_Failure_E, e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async ValueTask BindTry_execute_throwing_valuetask_func_E_on_success_E_returns_failure_with_value_from_error_handler()
        {
            ValueTask<UnitResult<E>> sut = UnitResult.Success<E>().AsValueTask();

            UnitResult<E> result = await sut.BindTry(ValueTask_Throwing_E, e => E.Value2);

            AssertFailure(result, E.Value2);
        }
        #endregion
    }
}
