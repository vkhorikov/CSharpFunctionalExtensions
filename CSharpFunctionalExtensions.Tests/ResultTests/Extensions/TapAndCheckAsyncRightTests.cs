using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class TapAndCheckAsyncRightTests : BindTestsBase
    {
        [Fact]
        public void TapAndCheck_AsyncRight_returns_failure_and_does_not_execute_func()
        {
            Result input = Result.Failure(ErrorMessage);

            Result output = input.TapAndCheck(GetResultTask).Result;

            AssertFailure(output);
        }

        [Fact]
        public void TapAndCheck_AsyncRight_selects_new_result()
        {
            Result input = Result.Success();

            Result output = input.TapAndCheck(GetResultTask).Result;

            AssertSuccess(output);
        }

        [Fact]
        public void TapAndCheck_T_AsyncRight_returns_failure_and_does_not_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result output = input.TapAndCheck(GetResult_WithParam_Task).Result;

            AssertFailure(output);
        }

        [Fact]
        public void TapAndCheck_T_AsyncRight_selects_new_result()
        {
            Result<T> input = Result.Success(T.Value);

            Result output = input.TapAndCheck(GetResult_WithParam_Task).Result;

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void TapAndCheck_F_AsyncRight_returns_failure_and_does_not_execute_func()
        {
            Result<F> input = Result.Failure<F>(ErrorMessage);

            Result<F> output = input.TapAndCheck(GetResult_F_Task).Result;

            AssertFailure(output);
        }

        [Fact]
        public void TapAndCheck_F_AsyncRight_selects_new_result()
        {
            Result input = Result.Success();

            Result output = input.TapAndCheck(GetResult_F_Task).Result;

            AssertSuccess(output);
        }

        [Fact]
        public void TapAndCheck_T_F_AsyncRight_returns_failure_and_does_not_execute_func()
        {
            Result<T> input = Result.Failure<T>(ErrorMessage);

            Result<T> output = input.TapAndCheck(GetResult_F_WithParam_Task).Result;

            AssertFailure(output);
        }

        [Fact]
        public void TapAndCheck_T_F_AsyncRight_selects_new_result()
        {
            Result<T> input = Result.Success(T.Value);

            Result<T> output = input.TapAndCheck(GetResult_F_WithParam_Task).Result;

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void TapAndCheck_T_F_E_AsyncRight_returns_failure_and_does_not_execute_func()
        {
            Result<T, E> input = Result.Failure<T, E>(E.Value);

            Result<T, E> output = input.TapAndCheck(GetResult_F_E_WithParam_Task).Result;

            AssertFailure(output);
        }

        [Fact]
        public void TapAndCheck_T_F_E_AsyncRight_selects_new_result()
        {
            Result<T, E> input = Result.Success<T, E>(T.Value);

            Result<T, E> output = input.TapAndCheck(GetResult_F_E_WithParam_Task).Result;

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }
    }
}
