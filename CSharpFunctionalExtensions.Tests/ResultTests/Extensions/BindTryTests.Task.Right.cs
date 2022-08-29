using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class BindTryTests_Task_Right : BindTryTestsBase
    {
        #region BindTry for Result with function returning Task<Result>
        [Fact]
        public async Task BindTry_execute_task_func_returning_success_on_success_returns_success()
        {
            Result sut = Result.Success();

            Result result = await sut.BindTry(Task_Success);

            AssertSuccess(result);
        }

        [Fact]
        public async Task BindTry_execute_task_func_returning_success_on_failure_returns_failure()
        {
            Result sut = Result.Failure(ErrorMessage);

            Result result = await sut.BindTry(Task_Success);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_task_func_returning_failure_on_success_returns_failure()
        {
            Result sut = Result.Success();

            Result result = await sut.BindTry(Task_Failure);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_task_func_on_success_returns_failure_with_exception_message()
        {
            Result sut = Result.Success();

            Result result = await sut.BindTry(Task_Throwing);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_task_func_on_success_with_custom_error_handler_returns_failure_with_custom_message()
        {
            Result sut = Result.Success();

            Result result = await sut.BindTry(Task_Throwing, e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for Result with function returning Task<Result<K>>
        [Fact]
        public async Task BindTry_execute_task_func_returning_success_K_on_success_returns_success()
        {
            Result sut = Result.Success();

            Result<K> result = await sut.BindTry(Task_Success_K);

            AssertSuccess(result);
        }

        [Fact]
        public async Task BindTry_execute_task_func_returning_success_K_on_failure_returns_failure()
        {
            Result sut = Result.Failure(ErrorMessage);

            Result<K> result = await sut.BindTry(Task_Success_K);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_task_func_returning_failure_K_on_success_returns_failure()
        {
            Result sut = Result.Success();

            Result<K> result = await sut.BindTry(Task_Failure_K);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_task_func_K_on_success_returns_failure_with_exception_message()
        {
            Result sut = Result.Success();

            Result<K> result = await sut.BindTry(Task_Throwing_K);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_task_func_K_on_success_with_custom_error_handler_returns_failure_with_custom_message()
        {
            Result sut = Result.Success();

            Result<K> result = await sut.BindTry(Task_Throwing_K, e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for Result<T> with function returning Task<Result>
        [Fact]
        public async Task BindTry_execute_task_func_returning_success_T_on_success_returns_success()
        {
            Result<T> sut = Result.Success(T.Value);

            Result result = await sut.BindTry(t => Task_Success());

            AssertSuccess(result);
        }

        [Fact]
        public async Task BindTry_execute_task_func_returning_success_T_on_failure_returns_failure()
        {
            Result<T> sut = Result.Failure<T>(ErrorMessage);

            Result result = await sut.BindTry(t => Task_Success());

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_task_func_returning_failure_T_on_success_returns_failure()
        {
            Result<T> sut = Result.Failure<T>(ErrorMessage);

            Result result = await sut.BindTry(t => Task_Failure());

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_task_func_on_success_T_returns_failure_with_exception_message()
        {
            Result<T> sut = Result.Success(T.Value);

            Result result = await sut.BindTry(t => Task_Throwing());

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_task_func_on_success_T_with_custom_error_handler_returns_failure_with_custom_message()
        {
            Result<T> sut = Result.Success(T.Value);

            Result result = await sut.BindTry(t => Task_Throwing(), e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for Result<T> with function returning Task<Result<K>>
        [Fact]
        public async Task BindTry_execute_task_func_returning_success_K_on_success_T_returns_success()
        {
            Result<T> sut = Result.Success(T.Value);

            Result<K> result = await sut.BindTry(t => Task_Success_K());

            AssertSuccess(result);
        }

        [Fact]
        public async Task BindTry_execute_task_func_returning_success_K_on_failure_T_returns_failure()
        {
            Result<T> sut = Result.Failure<T>(ErrorMessage);

            Result<K> result = await sut.BindTry(t => Task_Success_K());

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_task_func_returning_failure_K_on_success_T_returns_failure()
        {
            Result<T> sut = Result.Success(T.Value);

            Result<K> result = await sut.BindTry(t => Task_Failure_K());

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_task_func_K_on_success_T_returns_failure_with_exception_message()
        {
            Result<T> sut = Result.Success(T.Value);

            Result<K> result = await sut.BindTry(t => Task_Throwing_K());

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_task_func_K_on_success_T_with_custom_error_handler_returns_failure_with_custom_message()
        {
            Result<T> sut = Result.Success(T.Value);

            Result<K> result = await sut.BindTry(t => Task_Throwing_K(), e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for Result<T,E> with function returning Task<UnitResult<E>>
        [Fact]
        public async Task BindTry_execute_task_func_returning_success_E_on_success_T_E_returns_success()
        {
            Result<T, E> sut = Result.Success<T, E>(T.Value);

            UnitResult<E> result = await sut.BindTry(t => Task_UnitResult_Success_E(), e => E.Value2);

            AssertSuccess(result);
        }

        [Fact]
        public async Task BindTry_execute_task_func_returning_success_E_on_failure_T_E_returns_failure()
        {
            Result<T, E> sut = Result.Failure<T, E>(E.Value);

            UnitResult<E> result = await sut.BindTry(t => Task_UnitResult_Success_E(), e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_task_func_returning_failure_E_on_success_T_E_returns_failure()
        {
            Result<T, E> sut = Result.Success<T, E>(T.Value);

            UnitResult<E> result = await sut.BindTry(t => Task_UnitResult_Failure_E(), e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_task_func_E_on_success_T_E_returns_failure_with_value_from_error_handler()
        {
            Result<T, E> sut = Result.Success<T, E>(T.Value);

            UnitResult<E> result = await sut.BindTry(t => Task_Throwing_E(), e => E.Value2);

            AssertFailure(result, E.Value2);
        }
        #endregion

        #region BindTry for Result<T,E> with function returning Task<Result<K,E>>
        [Fact]
        public async Task BindTry_execute_task_func_returning_success_K_E_on_success_T_E_returns_success()
        {
            Result<T, E> sut = Result.Success<T, E>(T.Value);

            Result<K, E> result = await sut.BindTry(Task_Success_K_E, e => E.Value2);

            AssertSuccess(result);
        }

        [Fact]
        public async Task BindTry_execute_task_func_returning_success_K_E_on_failure_T_E_returns_failure()
        {
            Result<T, E> sut = Result.Failure<T, E>(E.Value);

            Result<K, E> result = await sut.BindTry(Task_Success_K_E, e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_task_func_returning_failure_K_E_on_success_T_E_returns_failure()
        {
            Result<T, E> sut = Result.Success<T, E>(T.Value);

            Result<K, E> result = await sut.BindTry(Task_Failure_K_E, e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_task_func_K_E_on_success_T_E_returns_failure_with_value_from_error_handler()
        {
            Result<T, E> sut = Result.Success<T, E>(T.Value);

            Result<K, E> result = await sut.BindTry(t => Task_Throwing_K_E(), e => E.Value2);

            AssertFailure(result, E.Value2);
        }
        #endregion

        #region BindTry for UnitResult<E> with function returning Task<Result<T,E>>
        [Fact]
        public async Task BindTry_execute_task_func_returning_success_T_E_on_success_E_returns_success()
        {
            UnitResult<E> sut = UnitResult.Success<E>();

            Result<T, E> result = await sut.BindTry(Task_Success_T_E, e => E.Value2);

            AssertSuccess(result);
        }

        [Fact]
        public async Task BindTry_execute_task_func_returning_success_T_E_on_failure_E_returns_failure()
        {
            UnitResult<E> sut = UnitResult.Failure(E.Value);

            Result<T, E> result = await sut.BindTry(Task_Success_T_E, e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_task_func_returning_failure_T_E_on_success_E_returns_failure()
        {
            UnitResult<E> sut = UnitResult.Success<E>();

            Result<T, E> result = await sut.BindTry(Task_Failure_T_E, e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_task_func_T_E_on_success_E_returns_failure_with_value_from_error_handler()
        {
            UnitResult<E> sut = UnitResult.Success<E>();

            Result<T, E> result = await sut.BindTry(Task_Throwing_T_E, e => E.Value2);

            AssertFailure(result, E.Value2);
        }
        #endregion

        #region BindTry for UnitResult<E> with function returning Task<UnitResult<E>>
        [Fact]
        public async Task BindTry_execute_task_func_returning_success_E_on_success_E_returns_success()
        {
            UnitResult<E> sut = UnitResult.Success<E>();

            UnitResult<E> result = await sut.BindTry(Task_UnitResult_Success_E, e => E.Value2);

            AssertSuccess(result);
        }

        [Fact]
        public async Task BindTry_execute_task_func_returning_success_E_on_failure_E_returns_failure()
        {
            UnitResult<E> sut = UnitResult.Failure(E.Value);

            UnitResult<E> result = await sut.BindTry(Task_UnitResult_Success_E, e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_task_func_returning_failure_E_on_success_E_returns_failure()
        {
            UnitResult<E> sut = UnitResult.Success<E>();

            UnitResult<E> result = await sut.BindTry(Task_UnitResult_Failure_E, e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_task_func_E_on_success_E_returns_failure_with_value_from_error_handler()
        {
            UnitResult<E> sut = UnitResult.Success<E>();

            UnitResult<E> result = await sut.BindTry(Task_Throwing_E, e => E.Value2);

            AssertFailure(result, E.Value2);
        }
        #endregion
    }
}
