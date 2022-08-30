using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class BindTests_ValueTask_Right : BindTestsBase
    {
        [Fact]
        public async ValueTask Bind_ValueTask_Right_returns_failure_and_does_not_execute_func()
        {
            Result output = await Failure().Bind(ValueTask_Success);

            AssertFailure(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Right_selects_new_result()
        {
            Result output = await Success().Bind(ValueTask_Success);

            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Right_T_returns_failure_and_does_not_execute_func()
        {
            Result output = await Failure_T().Bind(ValueTask_Success_T);

            AssertFailure(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Right_T_selects_new_result()
        {
            Result output = await Success_T(T.Value).Bind(ValueTask_Success_T);

            FuncParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Right_K_returns_failure_and_does_not_execute_func()
        {
            Result<K> output = await Failure().Bind(ValueTask_Success_K);

            AssertFailure(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Right_K_selects_new_result()
        {
            Result<K> output = await Success().Bind(ValueTask_Success_K);

            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Right_T_K_returns_failure_and_does_not_execute_func()
        {
            Result<K> output = await Failure_T().Bind(Func_T_ValueTask_Success_K);

            AssertFailure(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Right_T_K_selects_new_result()
        {
            Result<K> output = await Success_T(T.Value).Bind(Func_T_ValueTask_Success_K);

            FuncParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Right_T_K_E_returns_failure_and_does_not_execute_func()
        {
            Result<K, E> output = await Failure_T_E().Bind(ValueTask_Success_K_E);

            AssertFailure(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Right_T_K_E_selects_new_result()
        {
            Result<K, E> output = await Success_T_E().Bind(ValueTask_Success_K_E);

            FuncParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Right_T_E_selects_new_UnitResult()
        {
            UnitResult<E> output = await Success_T_E().Bind(Func_T_ValueTask_UnitResult_E);

            FuncParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_RightT_E__returns_failure_and_does_not_execute_func()
        {
            UnitResult<E> output = await Failure_T_E().Bind(Func_T_ValueTask_UnitResult_E);

            AssertFailure(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Right_E_selects_new_result()
        {
            UnitResult<E> output = await UnitResult_Success_E().Bind(Func_ValueTask_Success_T_E);

            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Right_E_returns_failure_and_does_not_execute_func()
        {
            UnitResult<E> output = await UnitResult_Failure_E().Bind(Func_ValueTask_Success_T_E);

            AssertFailure(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Right_E_selects_new_UnitResult()
        {
            UnitResult<E> output = await UnitResult_Success_E().Bind(ValueTask_UnitResult_Success_E);

            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Right_E_returns_UnitResult_failure_and_does_not_execute_func()
        {
            UnitResult<E> output = await UnitResult_Failure_E().Bind(ValueTask_UnitResult_Success_E);

            AssertFailure(output);
        }
    }
}
