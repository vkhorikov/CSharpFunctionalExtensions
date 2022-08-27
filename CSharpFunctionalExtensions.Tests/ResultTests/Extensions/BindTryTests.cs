using CSharpFunctionalExtensions.Tests.ResultTests.Methods.Try;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public sealed class BindTryTests : TryTestBase
    {
        #region BindTry for Result with function returning Result
        [Fact]
        public void BindTry_execute_func_returning_success_on_success_returns_success()
        {
            var sut = Result.Success();
            var func = Result () => Result.Success(Func_T());

            var result = sut.BindTry(func);

            result.IsSuccess.Should().BeTrue();                        
            FuncExecuted.Should().BeTrue();
        }
        [Fact]
        public void BindTry_execute_func_returning_success_on_failure_returns_self()
        {
            var sut = Result.Failure(ErrorMessage);
            var func = Result () => Result.Success(Func_T());
            
            var result = sut.BindTry(func);
                        
            AssertFailure(result);
            result.Should().Equals(sut);            
            FuncExecuted.Should().BeFalse();
        }
        [Fact]
        public void BindTry_execute_func_returning_failure_on_success_returns_failure()
        {
            var sut = Result.Success();
            var func = Result () => Result.Failure(ErrorMessage);

            var result = sut.BindTry(func);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(ErrorMessage);                        
        }       

        [Fact]
        public void BindTry_execute_throwing_func_on_success_returns_failure_with_exception_message()
        {
            var sut = Result.Success();
            var func = Result () => Result.Success(Throwing_Func_T());

            var result = sut.BindTry(func);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(ErrorMessage);
        }
        [Fact]
        public void BindTry_execute_throwing_func_on_success_with_custom_error_handler_returns_failure_with_custom_message()
        {
            var sut = Result.Success();
            var func = Result () => Result.Success(Throwing_Func_T());
         
            var result = sut.BindTry(func,e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for Result with function returning Result<K>
        [Fact]
        public void BindTry_execute_func_K_returning_success_on_success_returns_success()
        {
            var sut = Result.Success();
            var func = Result<K> () => Result.Success(Func_T_K(T.Value));

            var result = sut.BindTry(func);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();            
        }
        [Fact]
        public void BindTry_execute_func_K_returning_success_on_failure_returns_self()
        {
            var sut = Result.Failure(ErrorMessage);
            var func = Result<K> () => Result.Success(Func_T_K(T.Value));

            var result = sut.BindTry(func);

            AssertFailure(result);            
            result.Should().Equals(sut);
            FuncExecuted.Should().BeFalse();
        }
        [Fact]
        public void BindTry_execute_func_K_returning_failure_on_success_returns_failure()
        {
            var sut = Result.Success();
            var func = Result<K> () => Result.Failure<K>(ErrorMessage);

            var result = sut.BindTry(func);

            AssertFailure(result);
        }

        [Fact]
        public void BindTry_execute_throwing_func_K_on_success_returns_failure_with_exception_message()
        {
            var sut = Result.Success();
            var func = Result<K> () => Result.Success(Throwing_Func_T_K(T.Value));

            var result = sut.BindTry(func);

            AssertFailure(result);            
        }
        [Fact]
        public void BindTry_execute_throwing_func_K_on_success_with_custom_error_handler_returns_failure_with_custom_message()
        {
            var sut = Result.Success();
            var func = Result () => Result.Success(Throwing_Func_T_K(T.Value));
            
            var result = sut.BindTry(func, e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for Result<T> with function returning Result
        [Fact]
        public void BindTry_execute_func_returning_success_on_success_T_returns_success()
        {
            Result<T> sut = Result.Success(T.Value);
            var func = Result (T t) => Result.Success(Func_T());

            var result = sut.BindTry(func);
            result.IsSuccess.Should().BeTrue();                
            FuncExecuted.Should().BeTrue();
        }
        [Fact]
        public void BindTry_execute_func_returning_success_on_failure_T_returns_self()
        {
            Result<T> sut = Result.Failure<T>(ErrorMessage);
            var func = Result (T t) => Result.Success(Func_T_K(t));

            var result = sut.BindTry(func);

            AssertFailure(result);
            result.Should().Equals(sut);
            FuncExecuted.Should().BeFalse();
        }
        [Fact]
        public void BindTry_execute_func_returning_failure_on_success_T_returns_failure()
        {
            Result<T> sut = Result.Success(T.Value);
            var func = Result (T _) => Result.Failure<T>(ErrorMessage);

            var result = sut.BindTry(func);

            AssertFailure(result);
        }

        [Fact]
        public void BindTry_execute_throwing_func_on_success_T_returns_failure_with_exception_message()
        {
            Result<T> sut = Result.Success(T.Value);
            var func = Result (T t) => Result.Success(Throwing_Func_T());

            var result = sut.BindTry(func);

            AssertFailure(result);
        }
        [Fact]
        public void BindTry_execute_throwing_func_on_success_T_with_custom_error_handler_returns_failure_with_custom_message()
        {
            Result<T> sut = Result.Success(T.Value);
            var func = Result (T _) => Result.Success(Throwing_Func_T());

            var result = sut.BindTry(func, e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for Result<T> with function returning Result<K>
        [Fact]
        public void BindTry_execute_func_T_K_returning_success_on_success_T_returns_success_K()
        {
            Result<T> sut = Result.Success(T.Value);
            var func = Result<K> (T t) => Result.Success(Func_T_K(t));

            var result = sut.BindTry(func);

            result.IsSuccess.Should().BeTrue();
            result.Should().BeOfType<Result<K>>();
            result.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }
        [Fact]
        public void BindTry_execute_func_T_K_returning_success_on_failure_T_returns_failure_K()
        {
            Result<T> sut = Result.Failure<T>(ErrorMessage);
            var func = Result<K> (T t) => Result.Success(Func_T_K(t));

            var result = sut.BindTry(func);

            AssertFailure(result);
            result.Should().BeOfType<Result<K>>();
            result.Should().Equals(sut);            
            FuncExecuted.Should().BeFalse();
        }
        [Fact]
        public void BindTry_execute_func_K_returning_failure_K_on_success_returns_failure_K()
        {
            Result<T> sut = Result.Success(T.Value);
            var func = Result<K> (T _) => Result.Failure<K>(ErrorMessage);

            var result = sut.BindTry(func);

            AssertFailure(result);
        }

        [Fact]
        public void BindTry_execute_throwing_func_T_K_on_success_T_returns_failure_K_with_exception_message()
        {
            Result<T> sut = Result.Success(T.Value);
            var func = Result<K> (T t) => Result.Success(Throwing_Func_T_K(T.Value));

            var result = sut.BindTry(func);

            AssertFailure(result);
        }
        [Fact]
        public void BindTry_execute_throwing_func_T_K_on_success_T_with_custom_error_handler_returns_failure_K_with_custom_message()
        {
            var sut = Result.Success();
            var func = Result () => Result.Success(Throwing_Func_T_K(T.Value));

            var result = sut.BindTry(func, e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for Result<T,E> with function returning Result<K,E>
        [Fact]
        public void BindTry_execute_func_T_K_E_returning_success_on_success_T_E_returns_success_K_E()
        {
            Result<T,E> sut = Result.Success<T,E>(T.Value);
            var func = Result<K,E> (T t) => Result.Success<K,E>(Func_T_K(t));

            var result = sut.BindTry(func, e => E.Value2);

            result.IsSuccess.Should().BeTrue();
            result.Should().BeOfType<Result<K,E>>();
            result.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }
        [Fact]
        public void BindTry_execute_func_T_K_E_returning_success_on_failure_T_E_returns_failure_K_E()
        {
            Result<T,E> sut = Result.Failure<T,E>(E.Value);
            var func = Result<K,E> (T t) => Result.Success<K,E>(Func_T_K(t));

            var result = sut.BindTry(func, e => E.Value2);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value);
            result.Should().BeOfType<Result<K,E>>();            
            FuncExecuted.Should().BeFalse();
        }
        [Fact]
        public void BindTry_execute_func_T_K_E_returning_failure_on_success_T_E_returns_failure_K_E()
        {
            Result<T,E> sut = Result.Success<T,E>(T.Value);
            var func = Result<K,E> (T _) => Result.Failure<K,E>(E.Value);

            var result = sut.BindTry(func, e => E.Value2);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value);
            result.Should().BeOfType<Result<K, E>>();
        }

        [Fact]
        public void BindTry_execute_throwing_func_T_K_E_on_success_T_E_returns_failure_K_E_with_value_from_error_handler()
        {
            Result<T,E> sut = Result.Success<T,E>(T.Value);
            var func = Result<K,E> (T t) => Result.Success<K,E>(Throwing_Func_T_K(T.Value));

            var result = sut.BindTry(func, e=> E.Value2);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value2);
            result.Should().BeOfType<Result<K, E>>();
        }
        #endregion

        #region BindTry for UnitResult<E> with function returning UnitResult<E>
        [Fact]
        public void BindTry_execute_func_E_returning_unitresult_success_on_success_E_returns_success_K_E()
        {
            UnitResult<E> sut = UnitResult.Success<E>();
            var func = UnitResult<E> () => Result.Success(Func_T()).Map(_ => UnitResult.Success<E>()).Value;

            var result = sut.BindTry(func, e => E.Value2    );

            result.IsSuccess.Should().BeTrue();
            result.Should().BeOfType<UnitResult<E>>();            
            FuncExecuted.Should().BeTrue();
        }
        [Fact]
        public void BindTry_execute_func_E_returning_success_on_failure_E_returns_failure_E()
        {
            UnitResult<E> sut = UnitResult.Failure(E.Value);
            var func = UnitResult<E> () => Result.Success(Func_T()).Map(_ => UnitResult.Success<E>()).Value;

            var result = sut.BindTry(func, e => E.Value2);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value);
            result.Should().BeOfType<UnitResult<E>>();
            FuncExecuted.Should().BeFalse();
        }
        [Fact]
        public void BindTry_execute_func_E_returning_failure_on_success_E_returns_failure_E()
        {
            UnitResult<E> sut = UnitResult.Success<E>();
            var func = UnitResult<E> () => UnitResult.Failure(E.Value);

            var result = sut.BindTry(func, e => E.Value2);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value);
            result.Should().BeOfType<UnitResult<E>>();
        }

        [Fact]
        public void BindTry_execute_throwing_func_E_on_success_E_returns_failure_E_with_value_from_error_handler()
        {
            UnitResult<E> sut = UnitResult.Success<E>();
            var func = UnitResult<E> () => Result.Success<K, E>(Throwing_Func_T_K(T.Value));

            var result = sut.BindTry(func, e=> E.Value2);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value2);
            result.Should().BeOfType<UnitResult<E>>();
        }
        #endregion

        #region BindTry for UnitResult<E> with function returning Result<T,E>
        [Fact]
        public void BindTry_execute_func_T_E_returning_success_on_success_E_returns_success_T_E()
        {
            UnitResult<E> sut = UnitResult.Success<E>();
            var func = Result<T,E> () => Result.Success<T,E>(Func_T());

            var result = sut.BindTry(func, e => E.Value2);

            result.IsSuccess.Should().BeTrue();
            result.Should().BeOfType<Result<T,E>>();
            FuncExecuted.Should().BeTrue();
        }
        [Fact]
        public void BindTry_execute_func_T_E_returning_success_on_failure_E_returns_failure_T_E()
        {
            UnitResult<E> sut = UnitResult.Failure(E.Value);
            var func = Result<T,E> () => Result.Success<T,E>(Func_T());

            var result = sut.BindTry(func,e => E.Value2);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value);
            result.Should().BeOfType<Result<T,E>>();
            FuncExecuted.Should().BeFalse();
        }
        [Fact]
        public void BindTry_execute_func_T_E_returning_failure_on_success_E_returns_failure_T_E()
        {
            UnitResult<E> sut = UnitResult.Success<E>();
            var func = Result<T,E> () => Result.Failure<T,E>(E.Value);

            var result = sut.BindTry(func, e => E.Value2);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value);
            result.Should().BeOfType<Result<T,E>>();
        }

        [Fact]
        public void BindTry_execute_throwing_func_T_E_on_success_E_returns_failure_E_with_value_from_error_handler()
        {
            UnitResult<E> sut = UnitResult.Success<E>();
            var func = Result<T,E> () => Result.Success<T, E>(Throwing_Func_T());

            var result = sut.BindTry(func, e => E.Value2);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value2);
            result.Should().BeOfType<Result<T,E>>();
        }
        #endregion

        #region BindTry for Result<T,E> with function returning UnitResult<E>
        [Fact]
        public void BindTry_execute_func_E_returning_success_on_success_T_E_returns_success_E()
        {
            Result<T,E> sut = Result.Success<T,E>(T.Value);
            var func = UnitResult<E> (T _) => Result.Success<T, E>(Func_T());

            var result = sut.BindTry(func, e => E.Value2);

            result.IsSuccess.Should().BeTrue();
            result.Should().BeOfType<UnitResult<E>>();            
            FuncExecuted.Should().BeTrue();
        }
        [Fact]
        public void BindTry_execute_func_E_returning_success_on_failure_T_E_returns_failure_E()
        {
            Result<T, E> sut = Result.Failure<T, E>(E.Value);
            var func = UnitResult<E> (T t) => Result.Success<T, E>(Func_T());

            var result = sut.BindTry(func, e => E.Value2);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value);
            result.Should().BeOfType<UnitResult<E>>();
            FuncExecuted.Should().BeFalse();
        }
        [Fact]
        public void BindTry_execute_func_E_returning_failure_on_success_T_E_returns_failure_E()
        {
            Result<T,E> sut = Result.Success<T,E>(T.Value);
            var func = UnitResult<E> (T t) => Result.Failure<T, E>(E.Value);

            var result = sut.BindTry(func, e => E.Value2);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value);
            result.Should().BeOfType<UnitResult<E>>();
        }

        [Fact]
        public void BindTry_execute_throwing_func_E_on_success_T_E_returns_failure_E_with_value_from_error_handler()
        {
            Result<T,E> sut = Result.Success<T,E>(T.Value);
            var func = UnitResult<E> (T t) => Result.Success<T, E>(Throwing_Func_T());

            var result = sut.BindTry(func, e => E.Value2);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(E.Value2);
            result.Should().BeOfType<UnitResult<E>>();
        }
        #endregion

        private static void AssertFailure(Result result, string errorMessage=ErrorMessage)
        {
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(errorMessage);
        }
    }
}
