using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class BindAsyncBothTests : BindTestsBase
    {
        [Fact]
        public void Bind_AsyncBoth_returns_failure_and_does_not_execute_func()
        {
            Result input = Result.Failure(ErrorMessage);

            Result output = input.AsTask().Bind(GetResultTask).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_AsyncBoth_selects_new_result()
        {
            Result input = Result.Success();

            Result output = input.AsTask().Bind(GetResultTask).Result;

            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_AsyncBoth_returns_failure_and_does_not_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result output = input.AsTask().Bind(GetResult_WithParam_Task).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_T_AsyncBoth_selects_new_result()
        {
            Result<T> input = Result.Success(T.Value);

            Result output = input.AsTask().Bind(GetResult_WithParam_Task).Result;

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void Bind_K_AsyncBoth_returns_failure_and_does_not_execute_func()
        {
            Result input = Result.Failure(ErrorMessage);

            Result<K> output = input.AsTask().Bind(GetResult_K_Task).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_K_AsyncBoth_selects_new_result()
        {
            Result input = Result.Success();

            Result<K> output = input.AsTask().Bind(GetResult_K_Task).Result;

            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_K_AsyncBoth_returns_failure_and_does_not_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result<K> output = input.AsTask().Bind(GetResult_K_WithParam_Task).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_T_K_AsyncBoth_selects_new_result()
        {
            Result<T> input = Result.Success(T.Value);

            Result<K> output = input.AsTask().Bind(GetResult_K_WithParam_Task).Result;

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_K_E_AsyncBoth_returns_failure_and_does_not_execute_func()
        {
            Result<T, E> input = Result.Failure<T, E>(E.Value);

            Result<K, E> output = input.AsTask().Bind(GetResult_K_E_WithParam_Task).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_T_K_E_AsyncBoth_selects_new_result()
        {
            Result<T, E> input = Result.Success<T, E>(T.Value);

            Result<K, E> output = input.AsTask().Bind(GetResult_K_E_WithParam_Task).Result;

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_E_selects_new_unit_result()
        {
            Result<T, E> input = Result.Success<T, E>(T.Value);

            UnitResult<E> output = input.AsTask().Bind(GetUnitResult_E_WithParam_Task).Result;

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_E_returns_failure_and_does_not_execute_func()
        {
            Result<T, E> input = Result.Failure<T, E>(E.Value);

            UnitResult<E> output = input.AsTask().Bind(GetUnitResult_E_WithParam_Task).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_E_selects_new_result()
        {
            UnitResult<E> input = UnitResult.Success<E>();

            UnitResult<E> output = input.AsTask().Bind(GetResult_T_E_Task).Result;

            AssertSuccess(output);
        }

        [Fact]
        public void Bind_E_returns_failure_and_does_not_execute_func()
        {
            UnitResult<E> input = UnitResult.Failure<E>(E.Value);

            UnitResult<E> output = input.AsTask().Bind(GetResult_T_E).Result;

            AssertFailure(output);
        }
    }
}
