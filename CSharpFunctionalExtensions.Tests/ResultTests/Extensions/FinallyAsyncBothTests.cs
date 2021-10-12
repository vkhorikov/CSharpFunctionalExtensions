using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class FinallyAsyncBothTests : FinallyTestsBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Finally_BothAsync_result_returns_K(bool isSuccess)
        {
            Result result = Result.SuccessIf(isSuccess, ErrorMessage);
            K output = await result.AsTask().Finally(Task_Func_Result);

            AssertCalled(result, output);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Finally_BothAsync_result_T_returns_K(bool isSuccess)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);
            K output = await result.AsTask().Finally(Task_Func_Result_T);

            AssertCalled(result, output);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Finally_BothAsync_result_T_E_returns_K(bool isSuccess)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);
            K output = await result.AsTask().Finally(Task_Func_Result_T_E);

            AssertCalled(result, output);
        }

        [Fact]
        public async Task Finally_BothAsync_unit_result_E_executes_on_success_returns_K()
        {
            UnitResult<E> result = UnitResult.Success<E>();
            K output = await result.AsTask().Finally(Task_Func_Unit_Result_E);

            AssertCalled(result, output);
        }

        [Fact]
        public async Task Finally_BothAsync_unit_result_E_executes_on_failure_returns_K() {
            UnitResult<E> result = UnitResult.Failure(E.Value);
            K output = await result.AsTask().Finally(Task_Func_Unit_Result_E);

            AssertCalled(result, output);
        }
    }
}
