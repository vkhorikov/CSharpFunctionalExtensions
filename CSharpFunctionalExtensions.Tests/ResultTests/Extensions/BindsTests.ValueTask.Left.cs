using System.Threading.Tasks;
using CSharpFunctionalExtensions.Tests;
using CSharpFunctionalExtensions.Tests.ResultTests.Extensions;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class BindTests_ValueTask_Left : BindTestsBase
    {
        [Fact]
        public async ValueTask Bind_ValueTask_Left_returns_failure_and_does_not_execute_func()
        {
            Result output = await ValueTask_Failure().Bind(Success);
            AssertFailure(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Left_selects_new_result()
        {
            Result output = await ValueTask_Success().Bind(Success);
            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Left_T_returns_failure_and_does_not_execute_func()
        {
            Result output = await ValueTask_Failure_T().Bind(Success_T);

            AssertFailure(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Left_T_selects_new_result()
        {
            Result output = await ValueTask_Success_T(T.Value).Bind(Success_T);

            FuncParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Left_K_returns_failure_and_does_not_execute_func()
        {
            Result<K> output = await ValueTask_Failure().Bind(Success_K);

            AssertFailure(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Left_K_selects_new_result()
        {
            Result<K> output = await ValueTask_Success().Bind(Success_K);

            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Left_T_K_returns_failure_and_does_not_execute_func()
        {
            Result<K> output = await ValueTask_Failure_T().Bind(Success_T_Func_K);

            AssertFailure(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Left_T_K_selects_new_result()
        {
            Result<K> output = await ValueTask_Success_T(T.Value).Bind(Success_T_Func_K);

            FuncParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Left_T_K_E_returns_failure_and_does_not_execute_func()
        {
            Result<K, E> output = await ValueTask_Failure_T_E().Bind(Success_T_E_Func_K);

            AssertFailure(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Left_T_K_E_selects_new_result()
        {
            Result<K, E> output = await Func_ValueTask_Success_T_E().Bind(Success_T_E_Func_K);

            FuncParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Left_T_E_selects_new_UnitResult()
        {
            UnitResult<E> output = await Func_ValueTask_Success_T_E().Bind(UnitResult_E_T);

            FuncParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Left_T_E_returns_failure_and_does_not_execute_func()
        {
            UnitResult<E> output = await ValueTask_Failure_T_E().Bind(UnitResult_E_T);

            AssertFailure(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Left_E_selects_new_result()
        {
            UnitResult<E> output = await ValueTask_UnitResult_Success_E().Bind(Success_T_E);

            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Left_E_returns_failure_and_does_not_execute_func()
        {
            UnitResult<E> output = await ValueTask_UnitResult_Failure_E().Bind(Success_T_E);

            AssertFailure(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Left_E_selects_new_UnitResult()
        {
            UnitResult<E> output = await ValueTask_UnitResult_Success_E().Bind(UnitResult_Success_E);

            AssertSuccess(output);
        }

        [Fact]
        public async ValueTask Bind_ValueTask_Left_E_returns_UnitResult_failure_and_does_not_execute_func()
        {
            UnitResult<E> output = await ValueTask_UnitResult_Failure_E().Bind(UnitResult_Success_E);

            AssertFailure(output);
        }
    }
}
