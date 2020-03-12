using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class BindAsyncRightTests : BindTestsBase
    {
        [Fact]
        public void Bind_AsyncRight_returns_failure_and_does_not_execute_func()
        {
            Result input = Result.Failure(ErrorMessage);

            Result output = input.Bind(GetResultTask).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_AsyncRight_selects_new_result()
        {
            Result input = Result.Success();

            Result output = input.Bind(GetResultTask).Result;

            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_AsyncRight_returns_failure_and_does_not_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result output = input.Bind(GetResult_WithParam_Task).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_T_AsyncRight_selects_new_result()
        {
            Result<T> input = Result.Success(T.Value);

            Result output = input.Bind(GetResult_WithParam_Task).Result;

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void Bind_K_AsyncRight_returns_failure_and_does_not_execute_func()
        {
            Result input = Result.Failure(ErrorMessage);

            Result<K> output = input.Bind(GetResult_K_Task).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_K_AsyncRight_selects_new_result()
        {
            Result input = Result.Success();

            Result<K> output = input.Bind(GetResult_K_Task).Result;

            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_K_AsyncRight_returns_failure_and_does_not_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result<K> output = input.Bind(GetResult_K_WithParam_Task).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_T_K_AsyncRight_selects_new_result()
        {
            Result<T> input = Result.Success(T.Value);

            Result<K> output = input.Bind(GetResult_K_WithParam_Task).Result;

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_K_E_AsyncRight_returns_failure_and_does_not_execute_func()
        {
            Result<T, E> input = Result.Failure<T, E>(E.Value);

            Result<K, E> output = input.Bind(GetResult_K_E_WithParam_Task).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_T_K_E_AsyncRight_selects_new_result()
        {
            Result<T, E> input = Result.Success<T, E>(T.Value);

            Result<K, E> output = input.Bind(GetResult_K_E_WithParam_Task).Result;

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }
    }
}
