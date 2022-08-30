using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class BindTests_ValueTask : BindTestsBase
    {
        [Fact]
        public async ValueTask Bind_ValueTask_returns_failure_and_does_not_execute_func()
        {
            Result output = await ValueTask_Failure().Bind(ValueTask_Success);

            AssertFailure(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_selects_new_result()
        {
            Result output = await ValueTask_Success().Bind(ValueTask_Success);
            
            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_T_returns_failure_and_does_not_execute_func()
        {
            Result output = await ValueTask_Failure_T().Bind(ValueTask_Success_T);

            AssertFailure(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_T_selects_new_result()
        {
            Result output = await ValueTask_Success_T(T.Value).Bind(ValueTask_Success_T);

            FuncParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_K_returns_failure_and_does_not_execute_func()
        {
            Result<K> output = await ValueTask_Failure().Bind(ValueTask_Success_K);
            AssertFailure(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_K_selects_new_result()
        {
            Result<K> output = await ValueTask_Success().Bind(ValueTask_Success_K);
            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_T_K_returns_failure_and_does_not_execute_func()
        {
            Result<K> output = await ValueTask_Failure_T().Bind(Func_T_ValueTask_Success_K);

            AssertFailure(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_T_K_selects_new_result()
        {
            Result<K> output = await ValueTask_Success_T(T.Value).Bind(Func_T_ValueTask_Success_K);

            FuncParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_T_K_E_returns_failure_and_does_not_execute_func()
        {
            Result<K, E> output = await ValueTask_Failure_T_E().Bind(ValueTask_Success_K_E);
            AssertFailure(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_T_K_E_selects_new_result()
        {
            Result<K, E> output = await Func_ValueTask_Success_T_E().Bind(ValueTask_Success_K_E);

            FuncParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_T_E_selects_new_UnitResult()
        {
            UnitResult<E> output = await Func_ValueTask_Success_T_E().Bind(Func_T_ValueTask_UnitResult_E);

            FuncParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_T_E_returns_failure_and_does_not_execute_func()
        {
            UnitResult<E> output = await ValueTask_Failure_T_E().Bind(Func_T_ValueTask_UnitResult_E);

            AssertFailure(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_E_selects_new_result()
        {
            UnitResult<E> output = await ValueTask_UnitResult_Success_E().Bind(Func_ValueTask_Success_T_E);

            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_E_returns_failure_and_does_not_execute_func()
        {
            UnitResult<E> output = await ValueTask_UnitResult_Failure_E().Bind(Func_ValueTask_Success_T_E);

            AssertFailure(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_E_selects_new_UnitResult()
        {
            UnitResult<E> output = await ValueTask_UnitResult_Success_E().Bind(ValueTask_UnitResult_Success_E);

            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_E_returns_UnitResult_failure_and_does_not_execute_func()
        {
            UnitResult<E> output = await ValueTask_UnitResult_Failure_E().Bind(ValueTask_UnitResult_Success_E);

            AssertFailure(output);
        }
    }
}