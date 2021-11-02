using System.Threading.Tasks;
using CSharpFunctionalExtensions.Tests.ResultTests.Extensions;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class BindTests_Task : BindTestsBase
    {
        [Fact]
        public async Task Bind_Task_returns_failure_and_does_not_execute_func()
        {
            Result output = await Task_Failure().Bind(Task_Success);

            AssertFailure(output);
        }

        [Fact]
        public async Task Bind_Task_selects_new_result()
        {
            Result output = await Task_Success().Bind(Task_Success);
            
            AssertSuccess(output);
        }

        [Fact]
        public async Task Bind_Task_T_returns_failure_and_does_not_execute_func()
        {
            Result output = await Task_Failure_T().Bind(Task_Success_T);

            AssertFailure(output);
        }

        [Fact]
        public async Task Bind_Task_T_selects_new_result()
        {
            Result output = await Task_Success_T(T.Value).Bind(Task_Success_T);

            FuncParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public async Task Bind_Task_K_returns_failure_and_does_not_execute_func()
        {
            Result<K> output = await Task_Failure().Bind(Task_Success_K);
            AssertFailure(output);
        }

        [Fact]
        public async Task Bind_Task_K_selects_new_result()
        {
            Result<K> output = await Task_Success().Bind(Task_Success_K);
            AssertSuccess(output);
        }

        [Fact]
        public async Task Bind_Task_T_K_returns_failure_and_does_not_execute_func()
        {
            Result<K> output = await Task_Failure_T().Bind(Func_T_Task_Success_K);

            AssertFailure(output);
        }

        [Fact]
        public async Task Bind_Task_T_K_selects_new_result()
        {
            Result<K> output = await Task_Success_T(T.Value).Bind(Func_T_Task_Success_K);

            FuncParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public async Task Bind_Task_T_K_E_returns_failure_and_does_not_execute_func()
        {
            Result<K, E> output = await Task_Failure_T_E().Bind(Task_Success_K_E);
            AssertFailure(output);
        }

        [Fact]
        public async Task Bind_Task_T_K_E_selects_new_result()
        {
            Result<K, E> output = await Task_Success_T_E().Bind(Task_Success_K_E);

            FuncParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public async Task Bind_Task_T_E_selects_new_UnitResult()
        {
            UnitResult<E> output = await Task_Success_T_E().Bind(Func_T_Task_UnitResult_E);

            FuncParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public async Task Bind_Task_T_E_returns_failure_and_does_not_execute_func()
        {
            UnitResult<E> output = await Task_Failure_T_E().Bind(Func_T_Task_UnitResult_E);

            AssertFailure(output);
        }

        [Fact]
        public async Task Bind_Task_E_selects_new_result()
        {
            UnitResult<E> output = await Task_UnitResult_Success_E().Bind(Task_Success_T_E);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Bind_Task_E_returns_failure_and_does_not_execute_func()
        {
            UnitResult<E> output = await Task_UnitResult_Failure_E().Bind(Task_Success_T_E);

            AssertFailure(output);
        }

        [Fact]
        public async Task Bind_Task_E_selects_new_UnitResult()
        {
            UnitResult<E> output = await Task_UnitResult_Success_E().Bind(Task_UnitResult_Success_E);

            AssertSuccess(output);
        }

        [Fact]
        public async Task Bind_Task_E_returns_UnitResult_failure_and_does_not_execute_func()
        {
            UnitResult<E> output = await Task_UnitResult_Failure_E().Bind(Task_UnitResult_Success_E);

            AssertFailure(output);
        }
    }
}
