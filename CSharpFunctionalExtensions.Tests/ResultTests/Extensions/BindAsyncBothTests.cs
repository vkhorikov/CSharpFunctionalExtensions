using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class BindAsyncBothTests : BindTestsBase
    {
        [Fact]
        public void Bind_AsyncBoth_returns_failure_and_does_not_execute_func()
        {
            Task<Result> input = Result.Failure(ErrorMessage).AsCompletedTask();

            Result output = input.Bind(GetResultTask).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_AsyncBoth_selects_new_result()
        {
            Task<Result> input = Result.Success().AsCompletedTask();

            Result output = input.Bind(GetResultTask).Result;

            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_AsyncBoth_returns_failure_and_does_not_execute_func()
        {
            Task<Result<T>> input = Result.Failure<T>(ErrorMessage).AsCompletedTask();

            Result output = input.Bind(GetResult_WithParam_Task).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_T_AsyncBoth_selects_new_result()
        {
            Task<Result<T>> input = Result.Success(T.Value).AsCompletedTask();

            Result output = input.Bind(GetResult_WithParam_Task).Result;

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void Bind_K_AsyncBoth_returns_failure_and_does_not_execute_func()
        {
            Task<Result> input = Result.Failure(ErrorMessage).AsCompletedTask();

            Result<K> output = input.Bind(GetResult_K_Task).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_K_AsyncBoth_selects_new_result()
        {
            Task<Result> input = Result.Success().AsCompletedTask();

            Result<K> output = input.Bind(GetResult_K_Task).Result;

            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_K_AsyncBoth_returns_failure_and_does_not_execute_func()
        {
            Task<Result<T>> input = Result.Failure<T>(ErrorMessage).AsCompletedTask();

            Result<K> output = input.Bind(GetResult_K_WithParam_Task).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_T_K_AsyncBoth_selects_new_result()
        {
            Task<Result<T>> input = Result.Success(T.Value).AsCompletedTask();

            Result<K> output = input.Bind(GetResult_K_WithParam_Task).Result;

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_K_E_AsyncBoth_returns_failure_and_does_not_execute_func()
        {
            Task<Result<T, E>> input = Result.Failure<T, E>(E.Value).AsCompletedTask();

            Result<K, E> output = input.Bind(GetResult_K_E_WithParam_Task).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_T_K_E_AsyncBoth_selects_new_result()
        {
            Task<Result<T, E>> input = Result.Success<T, E>(T.Value).AsCompletedTask();

            Result<K, E> output = input.Bind(GetResult_K_E_WithParam_Task).Result;

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }
    }
}
