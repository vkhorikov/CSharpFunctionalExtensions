using FluentAssertions;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public abstract class FinallyTestsBase : TestBase
    {
        protected bool funcExecuted;
        protected Result funcResult;
        protected Result<T> funcResultT;
        protected Result<T, E> funcResultTE;
        protected UnitResult<E> funcUnitResultE;

        protected FinallyTestsBase()
        {
            funcExecuted = false;
        }

        protected K Func_Result(Result result) 
        { 
            funcExecuted = true;
            funcResult = result;
            return K.Value;
        }

        protected K Func_Result_T(Result<T> result) 
        { 
            funcExecuted = true;
            funcResultT = result;
            return K.Value;
        }

        protected K Func_Result_T_E(Result<T, E> result) 
        { 
            funcExecuted = true;
            funcResultTE = result;
            return K.Value;
        }

        protected K Func_UnitResult_E(UnitResult<E> result) 
        { 
            funcExecuted = true;
            funcUnitResultE = result;
            return K.Value;
        }

        protected Task<K> Task_Func_Result(Result result) => Func_Result(result).AsTask();
        protected Task<K> Task_Func_Result_T(Result<T> result) => Func_Result_T(result).AsTask();
        protected Task<K> Task_Func_Result_T_E(Result<T, E> result) => Func_Result_T_E(result).AsTask();
        protected Task<K> Task_Func_UnitResult_E(UnitResult<E> result) => Func_UnitResult_E(result).AsTask();

        protected ValueTask<K> ValueTask_Func_Result(Result result) => Func_Result(result).AsValueTask();
        protected ValueTask<K> ValueTask_Func_Result_T(Result<T> result) => Func_Result_T(result).AsValueTask();
        protected ValueTask<K> ValueTask_Func_Result_T_E(Result<T, E> result) => Func_Result_T_E(result).AsValueTask();
        protected ValueTask<K> ValueTask_Func_UnitResult_E(UnitResult<E> result) => Func_UnitResult_E(result).AsValueTask();
        
        private void AssertCalled(K output) {
            funcExecuted.Should().BeTrue();
            output.Should().Be(K.Value);
        }

        protected void AssertCalled(Result result, K output) {
            funcResult.Should().Be(result);
            AssertCalled(output);
        }

        protected void AssertCalled(Result<T> result, K output) {
            funcResultT.Should().Be(result);
            AssertCalled(output);
        }

        protected void AssertCalled(Result<T, E> result, K output) {
            funcResultTE.Should().Be(result);
            AssertCalled(output);
        }

        protected void AssertCalled(UnitResult<E> result, K output) {
            funcUnitResultE.Should().Be(result);
            AssertCalled(output);
        }
    }
}
