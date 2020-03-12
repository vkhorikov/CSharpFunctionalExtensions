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
        public void Bind_F_returns_failure_and_does_not_execute_func()
        {
            Result input = Result.Failure(ErrorMessage);

            Result<F> output = input.Bind(GetResult_F);

            AssertFailure(output);
        }

        [Fact]
        public void Bind_F_selects_new_result()
        {
            Result input = Result.Success();

            Result<F> output = input.Bind(GetResult_F);

            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_F_returns_failure_and_does_not_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result<F> output = input.Bind(GetResult_F_WithParam);

            AssertFailure(output);
        }

        [Fact]
        public void Bind_T_F_selects_new_result()
        {
            Result<T> input = Result.Success(T.Value);

            Result<F> output = input.Bind(GetResult_F_WithParam);

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void Bind_T_F_E_returns_failure_and_does_not_execute_func()
        {
            Result<T, E> input = Result.Failure<T, E>(E.Value);

            Result<F, E> output = input.Bind(GetResult_F_E_WithParam);

            AssertFailure(output);
        }

        [Fact]
        public void Bind_T_F_E_selects_new_result()
        {
            Result<T, E> input = Result.Success<T, E>(T.Value);

            Result<F, E> output = input.Bind(GetResult_F_E_WithParam);

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }
    }
}
