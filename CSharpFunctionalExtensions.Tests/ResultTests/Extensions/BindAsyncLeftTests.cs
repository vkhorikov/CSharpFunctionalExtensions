using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class BindAsyncLeftTests : BindTestsBase
    {
        [Fact]
        public void Bind_AsyncLeft_returns_failure_and_does_not_execute_func()
        {
            Result input = Result.Failure(ErrorMessage);

            Result output = input.AsTask().Bind(GetResult).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_AsyncLeft_selects_new_result()
        {
            Result input = Result.Success();

            Result output = input.AsTask().Bind(GetResult).Result;

            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_AsyncLeft_returns_failure_and_does_not_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result output = input.AsTask().Bind(GetResult_WithParam).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_T_AsyncLeft_selects_new_result()
        {
            Result<T> input = Result.Success(T.Value);

            Result output = input.AsTask().Bind(GetResult_WithParam).Result;

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void Bind_K_AsyncLeft_returns_failure_and_does_not_execute_func()
        {
            Result input = Result.Failure(ErrorMessage);

            Result<K> output = input.AsTask().Bind(GetResult_K).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_K_AsyncLeft_selects_new_result()
        {
            Result input = Result.Success();

            Result<K> output = input.AsTask().Bind(GetResult_K).Result;

            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_K_AsyncLeft_returns_failure_and_does_not_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result<K> output = input.AsTask().Bind(GetResult_K_WithParam).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_T_K_AsyncLeft_selects_new_result()
        {
            Result<T> input = Result.Success(T.Value);

            Result<K> output = input.AsTask().Bind(GetResult_K_WithParam).Result;

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_K_E_AsyncLeft_returns_failure_and_does_not_execute_func()
        {
            Result<T, E> input = Result.Failure<T, E>(E.Value);

            Result<K, E> output = input.AsTask().Bind(GetResult_K_E_WithParam).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_T_K_E_AsyncLeft_selects_new_result()
        {
            Result<T, E> input = Result.Success<T, E>(T.Value);

            Result<K, E> output = input.AsTask().Bind(GetResult_K_E_WithParam).Result;

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_E_selects_new_unit_result()
        {
            Result<T, E> input = Result.Success<T, E>(T.Value);

            UnitResult<E> output = input.AsTask().Bind(GetUnitResult_E_WithParam).Result;

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_E_returns_failure_and_does_not_execute_func()
        {
            Result<T, E> input = Result.Failure<T, E>(E.Value);

            UnitResult<E> output = input.AsTask().Bind(GetUnitResult_E_WithParam).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_E_selects_new_result()
        {
            UnitResult<E> input = UnitResult.Success<E>();

            UnitResult<E> output = input.AsTask().Bind(GetResult_T_E).Result;

            AssertSuccess(output);
        }

        [Fact]
        public void Bind_E_returns_failure_and_does_not_execute_func()
        {
            UnitResult<E> input = UnitResult.Failure<E>(E.Value);

            UnitResult<E> output = input.AsTask().Bind(GetResult_T_E).Result;

            AssertFailure(output);
        }

        [Fact]
        public void Bind_E_selects_new_unit_result()
        {
            UnitResult<E> input = UnitResult.Success<E>();

            UnitResult<E> output = input.AsTask().Bind(GetUnitResult_E).Result;

            AssertSuccess(output);
        }

        [Fact]
        public void Bind_E_returns_unit_result_failure_and_does_not_execute_func()
        {
            UnitResult<E> input = UnitResult.Failure(E.Value);

            UnitResult<E> output = input.AsTask().Bind(GetUnitResult_E).Result;

            AssertFailure(output);
        }
    }
}
