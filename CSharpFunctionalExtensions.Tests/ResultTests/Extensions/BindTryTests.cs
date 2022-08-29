using FluentAssertions;
using Xunit;
using System;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public sealed class BindTryTests : BindTryTestsBase
    {
        #region BindTry for Result with function returning Result
        [Fact]
        public void BindTry_execute_func_returning_success_on_success_returns_success()
        {
            Result sut = Result.Success();

            Result result = sut.BindTry(Success);

            AssertSuccess(result);
        }
        [Fact]
        public void BindTry_execute_func_returning_success_on_failure_returns_self()
        {
            Result sut = Result.Failure(ErrorMessage);

            Result result = sut.BindTry(Success);

            AssertFailure(result);
        }
        [Fact]
        public void BindTry_execute_func_returning_failure_on_success_returns_failure()
        {
            Result sut = Result.Success();

            Result result = sut.BindTry(Failure);

            AssertFailure(result);
        }

        [Fact]
        public void BindTry_execute_throwing_func_on_success_returns_failure_with_exception_message()
        {
            Result sut = Result.Success();

            Result result = sut.BindTry(Throwing);

            AssertFailure(result);
        }


        [Fact]
        public void BindTry_execute_throwing_func_on_success_with_custom_error_handler_returns_failure_with_custom_message()
        {
            Result sut = Result.Success();

            Result result = sut.BindTry(Throwing, e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for Result with function returning Result<K>
        [Fact]
        public void BindTry_execute_func_K_returning_success_on_success_returns_success()
        {
            Result sut = Result.Success();

            Result<K> result = sut.BindTry(Success_K);

            AssertSuccess(result);
        }
        [Fact]
        public void BindTry_execute_func_K_returning_success_on_failure_returns_self()
        {
            Result sut = Result.Failure(ErrorMessage);

            Result<K> result = sut.BindTry(Success_K);

            AssertFailure(result);
        }
        [Fact]
        public void BindTry_execute_func_K_returning_failure_on_success_returns_failure()
        {
            Result sut = Result.Success();

            Result<K> result = sut.BindTry(Failure_K);

            AssertFailure(result);
        }

        [Fact]
        public void BindTry_execute_throwing_func_K_on_success_returns_failure_with_exception_message()
        {
            Result sut = Result.Success();

            Result<K> result = sut.BindTry(Throwing_K);

            AssertFailure(result);
        }
        [Fact]
        public void BindTry_execute_throwing_func_K_on_success_with_custom_error_handler_returns_failure_with_custom_message()
        {
            Result sut = Result.Success();

            Result<K> result = sut.BindTry(Throwing_K, e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for Result<T> with function returning Result
        [Fact]
        public void BindTry_execute_func_returning_success_on_success_T_returns_success()
        {
            Result<T> sut = Result.Success(T.Value);

            Result result = sut.BindTry(t => Success());

            AssertSuccess(result);
        }
        [Fact]
        public void BindTry_execute_func_returning_success_on_failure_T_returns_self()
        {
            Result<T> sut = Result.Failure<T>(ErrorMessage);

            Result result = sut.BindTry(t => Success());

            AssertFailure(result);
        }
        [Fact]
        public void BindTry_execute_func_returning_failure_on_success_T_returns_failure()
        {
            Result<T> sut = Result.Success(T.Value);

            Result result = sut.BindTry(t => Failure());

            AssertFailure(result);
        }

        [Fact]
        public void BindTry_execute_throwing_func_on_success_T_returns_failure_with_exception_message()
        {
            Result<T> sut = Result.Success(T.Value);

            Result result = sut.BindTry(t => Throwing());

            AssertFailure(result);
        }
        [Fact]
        public void BindTry_execute_throwing_func_on_success_T_with_custom_error_handler_returns_failure_with_custom_message()
        {
            Result<T> sut = Result.Success(T.Value);

            Result result = sut.BindTry(t => Throwing(), e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for Result<T> with function returning Result<K>
        [Fact]
        public void BindTry_execute_func_T_K_returning_success_on_success_T_returns_success_K()
        {
            Result<T> sut = Result.Success(T.Value);

            Result<K> result = sut.BindTry(t => Success_K());

            AssertSuccess(result);            
        }
        [Fact]
        public void BindTry_execute_func_T_K_returning_success_on_failure_T_returns_failure_K()
        {
            Result<T> sut = Result.Failure<T>(ErrorMessage);

            Result<K> result = sut.BindTry(t => Success_K());

            AssertFailure(result);
            result.Should().BeOfType<Result<K>>();
        }
        [Fact]
        public void BindTry_execute_func_K_returning_failure_K_on_success_returns_failure_K()
        {
            Result<T> sut = Result.Success(T.Value);

            Result<K> result = sut.BindTry(t => Failure_K());

            AssertFailure(result);
        }

        [Fact]
        public void BindTry_execute_throwing_func_T_K_on_success_T_returns_failure_K_with_exception_message()
        {
            Result<T> sut = Result.Success(T.Value);

            Result<K> result = sut.BindTry(t => Throwing_K());

            AssertFailure(result);
        }
        [Fact]
        public void BindTry_execute_throwing_func_T_K_on_success_T_with_custom_error_handler_returns_failure_K_with_custom_message()
        {
            Result sut = Result.Success();

            Result<K> result = sut.BindTry(() => Throwing_K(), e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for Result<T,E> with function returning Result<K,E>
        [Fact]
        public void BindTry_execute_func_T_K_E_returning_success_on_success_T_E_returns_success_K_E()
        {
            Result<T, E> sut = Result.Success<T, E>(T.Value);

            Result<K, E> result = sut.BindTry(Success_T_E_Func_K, e => E.Value);

            AssertSuccess(result);
            result.Should().BeOfType<Result<K, E>>();
        }
        [Fact]
        public void BindTry_execute_func_T_K_E_returning_success_on_failure_T_E_returns_failure_K_E()
        {
            Result<T, E> sut = Result.Failure<T, E>(E.Value);

            Result<K, E> result = sut.BindTry(Success_T_E_Func_K, e => E.Value);

            AssertFailure(result);
            result.Should().BeOfType<Result<K, E>>();
        }
        [Fact]
        public void BindTry_execute_func_T_K_E_returning_failure_on_success_T_E_returns_failure_K_E()
        {
            Result<T, E> sut = Result.Success<T, E>(T.Value);
            System.Func<T, Result<K, E>> func = Result<K, E> (T _) => Result.Failure<K, E>(E.Value);

            Result<K, E> result = sut.BindTry(func, e => E.Value2);

            AssertFailure(result);
            result.Should().BeOfType<Result<K, E>>();
        }

        [Fact]
        public void BindTry_execute_throwing_func_T_K_E_on_success_T_E_returns_failure_K_E_with_value_from_error_handler()
        {
            Result<T, E> sut = Result.Success<T, E>(T.Value);

            Result<K, E> result = sut.BindTry(t => Throwing_K_E(), e => E.Value2);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value2);
            result.Should().BeOfType<Result<K, E>>();
        }
        #endregion

        #region BindTry for UnitResult<E> with function returning UnitResult<E>
        [Fact]
        public void BindTry_execute_func_E_returning_unitresult_success_on_success_E_returns_success_E()
        {
            UnitResult<E> sut = UnitResult.Success<E>();

            UnitResult<E> result = sut.BindTry(UnitResult_Success_E, e => E.Value2);

            AssertSuccess(result);
        }
        [Fact]
        public void BindTry_execute_func_E_returning_success_on_failure_E_returns_failure_E()
        {
            UnitResult<E> sut = UnitResult.Failure(E.Value);

            UnitResult<E> result = sut.BindTry(UnitResult_Success_E, e => E.Value2);

            AssertFailure(result);
        }
        [Fact]
        public void BindTry_execute_func_E_returning_failure_on_success_E_returns_failure_E()
        {
            UnitResult<E> sut = UnitResult.Success<E>();

            UnitResult<E> result = sut.BindTry(UnitResult_Failure_E, e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public void BindTry_execute_throwing_func_E_on_success_E_returns_failure_E_with_value_from_error_handler()
        {
            UnitResult<E> sut = UnitResult.Success<E>();

            UnitResult<E> result = sut.BindTry(Throwing_K_E, e => E.Value2);

            AssertFailure(result, E.Value2);            
        }
        #endregion

        #region BindTry for UnitResult<E> with function returning Result<T,E>
        [Fact]
        public void BindTry_execute_func_T_E_returning_success_on_success_E_returns_success_T_E()
        {
            UnitResult<E> sut = UnitResult.Success<E>();

            Result<T, E> result = sut.BindTry(Success_T_E, e => E.Value2);

            AssertSuccess(result);            
        }
        [Fact]
        public void BindTry_execute_func_T_E_returning_success_on_failure_E_returns_failure_T_E()
        {
            UnitResult<E> sut = UnitResult.Failure(E.Value);

            Result<T, E> result = sut.BindTry(Success_T_E, e => E.Value2);

            AssertFailure(result);
        }
        [Fact]
        public void BindTry_execute_func_T_E_returning_failure_on_success_E_returns_failure_T_E()
        {
            UnitResult<E> sut = UnitResult.Success<E>();

            Result<T, E> result = sut.BindTry(Failure_T_E, e => E.Value2);

            AssertFailure(result);            
        }

        [Fact]
        public void BindTry_execute_throwing_func_T_E_on_success_E_returns_failure_E_with_value_from_error_handler()
        {
            UnitResult<E> sut = UnitResult.Success<E>();

            Result<T, E> result = sut.BindTry(Throwing_T_E, e => E.Value2);

            AssertFailure(result, E.Value2);            
        }
        #endregion

        #region BindTry for Result<T,E> with function returning UnitResult<E>
        [Fact]
        public void BindTry_execute_func_E_returning_success_on_success_T_E_returns_success_E()
        {
            Result<T, E> sut = Result.Success<T, E>(T.Value);

            UnitResult<E> result = sut.BindTry(UnitResult_E_T, e => E.Value2);

            AssertSuccess(result);            
        }
        [Fact]
        public void BindTry_execute_func_E_returning_success_on_failure_T_E_returns_failure_E()
        {
            Result<T, E> sut = Result.Failure<T, E>(E.Value);            

            UnitResult<E> result = sut.BindTry(UnitResult_E_T, e => E.Value2);

            AssertFailure(result);            
        }
        [Fact]
        public void BindTry_execute_func_E_returning_failure_on_success_T_E_returns_failure_E()
        {
            Result<T, E> sut = Result.Success<T, E>(T.Value);

            UnitResult<E> result = sut.BindTry(t=> UnitResult_Failure_E(), e => E.Value2);

            AssertFailure(result);            
        }

        [Fact]
        public void BindTry_execute_throwing_func_E_on_success_T_E_returns_failure_E_with_value_from_error_handler()
        {
            Result<T, E> sut = Result.Success<T, E>(T.Value);

            UnitResult<E> result = sut.BindTry(t => Throwing_E(), e => E.Value2);

            AssertFailure(result, E.Value2);
        }
        #endregion

    }
}
