using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class BindTests : BindTestsBase
    {
        [Fact]
        public void Bind_returns_failure_and_does_not_execute_func()
        {
            Result output = Failure().Bind(Success);

            AssertFailure(output);
        }

        [Fact]
        public void Bind_selects_new_result()
        {
            Result output = Success().Bind(Success);

            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_returns_failure_and_does_not_execute_func()
        {
            Result output = Failure_T().Bind(Success_T);

            AssertFailure(output);
        }

        [Fact]
        public void Bind_T_selects_new_result()
        {
            Result output = Success_T(T.Value).Bind(Success_T);

            FuncParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void Bind_K_returns_failure_and_does_not_execute_func()
        {
            Result<K> output = Failure().Bind(Success_K);

            AssertFailure(output);
        }

        [Fact]
        public void Bind_K_selects_new_result()
        {
            Result<K> output = Success().Bind(Success_K);

            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_K_returns_failure_and_does_not_execute_func()
        {
            Result<K> output = Failure_T().Bind(Success_T_Func_K);

            AssertFailure(output);
        }

        [Fact]
        public void Bind_T_K_selects_new_result()
        {
            Result<K> output = Success_T(T.Value).Bind(Success_T_Func_K);

            FuncParam.Should().Be(T.Value);
            AssertSuccess(output);
        }
        
        [Fact]
        public void Bind_T_K_E_returns_failure_and_does_not_execute_func()
        {
            Result<K, E> output = Failure_T_E().Bind(Success_T_E_Func_K);

            AssertFailure(output);
        }

        [Fact]
        public void Bind_T_K_E_selects_new_result()
        {
            Result<K, E> output = Success_T_E().Bind(Success_T_E_Func_K);

            FuncParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_E_selects_new_UnitResult()
        {
            UnitResult<E> output = Success_T_E().Bind(UnitResult_E_T);

            FuncParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_E_returns_failure_and_does_not_execute_func()
        {
            UnitResult<E> output = Failure_T_E().Bind(UnitResult_E_T);

            AssertFailure(output);
        }

        [Fact]
        public void Bind_E_selects_new_result()
        {
            UnitResult<E> output = UnitResult_Success_E().Bind(Success_T_E);

            AssertSuccess(output);
        }

        [Fact]
        public void Bind_E_returns_failure_and_does_not_execute_func()
        {
            UnitResult<E> output = UnitResult_Failure_E().Bind(Success_T_E);

            AssertFailure(output);
        }

        [Fact]
        public void Bind_E_selects_new_UnitResult()
        {
            UnitResult<E> output = UnitResult_Success_E().Bind(UnitResult_Success_E);

            AssertSuccess(output);
        }

        [Fact]
        public void Bind_E_returns_UnitResult_failure_and_does_not_execute_func()
        {
            UnitResult<E> output = UnitResult_Failure_E().Bind(UnitResult_Success_E);

            AssertFailure(output);
        }
    }
}
