using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class FinallyTests : FinallyTestsBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Finally_result_returns_K(bool isSuccess)
        {
            Result result = Result.SuccessIf(isSuccess, ErrorMessage);
            K output = result.Finally(Func_Result);

            AssertCalled(result, output);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Finally_result_T_returns_K(bool isSuccess)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);
            K output = result.Finally(Func_Result_T);

            AssertCalled(result, output);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Finally_result_T_E_returns_K(bool isSuccess)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);
            K output = result.Finally(Func_Result_T_E);

            AssertCalled(result, output);
        }

        [Fact]
        public void Finally_UnitResult_E_executes_on_success_returns_K()
        {
            UnitResult<E> result = UnitResult.Success<E>();
            K output = result.Finally(Func_UnitResult_E);

            AssertCalled(result, output);
        }

        [Fact]
        public void Finally_UnitResult_E_executes_on_failure_returns_K() {
            UnitResult<E> result = UnitResult.Failure(E.Value);
            K output = result.Finally(Func_UnitResult_E);

            AssertCalled(result, output);
        }
    }
}
