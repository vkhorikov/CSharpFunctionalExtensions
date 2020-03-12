using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class TapAndCheckTests : BindTestsBase
    {
        [Fact]
        public void TapAndCheck_returns_failure_and_does_not_execute_func()
        {
            Result input = Result.Failure(ErrorMessage);

            Result output = input.TapAndCheck(GetResult);

            AssertFailure(output);
        }

        [Fact]
        public void TapAndCheck_selects_new_result()
        {
            Result input = Result.Success();

            Result output = input.TapAndCheck(GetResult);

            AssertSuccess(output);
        }

        [Fact]
        public void TapAndCheck_T_returns_failure_and_does_not_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result output = input.TapAndCheck(GetResult_WithParam);

            AssertFailure(output);
        }

        [Fact]
        public void TapAndCheck_T_selects_new_result()
        {
            Result<T> input = Result.Success(T.Value);

            Result output = input.TapAndCheck(GetResult_WithParam);

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void TapAndCheck_F_returns_failure_and_does_not_execute_func()
        {
            Result<F> input = Result.Failure<F>(ErrorMessage);

            Result<F> output = input.TapAndCheck(GetResult_F);

            AssertFailure(output);
        }

        [Fact]
        public void TapAndCheck_F_selects_new_result()
        {
            Result<F> input = Result.Success<F>(F.Value);

            Result<F> output = input.TapAndCheck(GetResult_F);

            AssertSuccess(output);
        }

        [Fact]
        public void TapAndCheck_T_F_returns_failure_and_does_not_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result<T> output = input.TapAndCheck(GetResult_F_WithParam);

            AssertFailure(output);
        }

        [Fact]
        public void TapAndCheck_T_F_selects_new_result()
        {
            Result<T> input = Result.Success(T.Value);

            Result<T> output = input.TapAndCheck(GetResult_F_WithParam);

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void TapAndCheck_T_F_E_returns_failure_and_does_not_execute_func()
        {
            Result<T, E> input = Result.Failure<T, E>(E.Value);

            Result<T, E> output = input.TapAndCheck(GetResult_F_E_WithParam);

            AssertFailure(output);
        }

        [Fact]
        public void TapAndCheck_T_F_E_selects_new_result()
        {
            Result<T, E> input = Result.Success<T, E>(T.Value);

            Result<T, E> output = input.TapAndCheck(GetResult_F_E_WithParam);

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }
    }
}
