using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class BindTests : BindTestsBase
    {
        [Fact]
        public void Bind_returns_failure_and_does_not_execute_func()
        {
            Result input = Result.Failure(ErrorMessage);

            Result output = input.Bind(GetResult);

            AssertFailure(output);
        }

        [Fact]
        public void Bind_selects_new_result()
        {
            Result input = Result.Success();

            Result output = input.Bind(GetResult);

            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_returns_failure_and_does_not_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result output = input.Bind(GetResult_WithParam);

            AssertFailure(output);
        }

        [Fact]
        public void Bind_T_selects_new_result()
        {
            Result<T> input = Result.Success(T.Value);

            Result output = input.Bind(GetResult_WithParam);

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void Bind_K_returns_failure_and_does_not_execute_func()
        {
            Result input = Result.Failure(ErrorMessage);

            Result<K> output = input.Bind(GetResult_K);

            AssertFailure(output);
        }

        [Fact]
        public void Bind_K_selects_new_result()
        {
            Result input = Result.Success();

            Result<K> output = input.Bind(GetResult_K);

            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_K_returns_failure_and_does_not_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result<K> output = input.Bind(GetResult_K_WithParam);

            AssertFailure(output);
        }

        [Fact]
        public void Bind_T_K_selects_new_result()
        {
            Result<T> input = Result.Success(T.Value);

            Result<K> output = input.Bind(GetResult_K_WithParam);

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }
        
        [Fact]
        public void Bind_T_K_E_returns_failure_and_does_not_execute_func()
        {
            Result<T, E> input = Result.Failure<T, E>(E.Value);

            Result<K, E> output = input.Bind(GetResult_K_E_WithParam);

            AssertFailure(output);
        }

        [Fact]
        public void Bind_T_K_E_selects_new_result()
        {
            Result<T, E> input = Result.Success<T, E>(T.Value);

            Result<K, E> output = input.Bind(GetResult_K_E_WithParam);

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_E_selects_new_unit_result()
        {
            Result<T, E> input = Result.Success<T, E>(T.Value);

            UnitResult<E> output = input.Bind(GetUnitResult_E_WithParam);

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_E_returns_failure_and_does_not_execute_func()
        {
            Result<T, E> input = Result.Failure<T, E>(E.Value);

            UnitResult<E> output = input.Bind(GetUnitResult_E_WithParam);

            AssertFailure(output);
        }

        [Fact]
        public void Bind_E_selects_new_result()
        {
            UnitResult<E> input = UnitResult.Success<E>();

            UnitResult<E> output = input.Bind(GetResult_T_E);

            AssertSuccess(output);
        }

        [Fact]
        public void Bind_E_returns_failure_and_does_not_execute_func()
        {
            UnitResult<E> input = UnitResult.Failure<E>(E.Value);

            UnitResult<E> output = input.Bind(GetResult_T_E);

            AssertFailure(output);
        }

        [Fact]
        public void Bind_E_selects_new_unit_result()
        {
            UnitResult<E> input = UnitResult.Success<E>();

            UnitResult<E> output = input.Bind(GetUnitResult_E);

            AssertSuccess(output);
        }

        [Fact]
        public void Bind_E_returns_unit_result_failure_and_does_not_execute_func()
        {
            UnitResult<E> input = UnitResult.Failure(E.Value);

            UnitResult<E> output = input.Bind(GetUnitResult_E);

            AssertFailure(output);
        }
    }
}
