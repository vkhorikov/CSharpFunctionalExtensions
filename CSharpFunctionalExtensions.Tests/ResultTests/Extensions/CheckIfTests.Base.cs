using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public abstract class CheckIfTestsBase : TestBase
    {
        protected bool actionExecuted;
        protected bool predicateExecuted;

        protected CheckIfTestsBase()
        {
            actionExecuted = false;
            predicateExecuted = false;
        }
        
        protected Result Func_Result(bool _) { actionExecuted = true; return Result.Success(); } 
        
        protected Result<K> Func_Result_K(bool _) { actionExecuted = true; return Result.Success(K.Value); }
        protected Result<K,E> Func_Result_K_E(bool _) { actionExecuted = true; return Result.Success<K, E>(K.Value); }
        protected UnitResult<E> Func_UnitResult_E(bool _) { actionExecuted = true; return UnitResult.Success<E>(); }
        protected UnitResult<E> Func_UnitResult_E() { actionExecuted = true; return UnitResult.Success<E>(); }

        protected Task<Result> Task_Func_Result(bool _) { actionExecuted = true; return Result.Success().AsTask(); }
        protected Task<Result<K>> Task_Func_Result_K(bool _) { actionExecuted = true; return Result.Success(K.Value).AsTask(); }
        protected Task<Result<K, E>> Task_Func_Result_K_E(bool _) { actionExecuted = true; return Result.Success<K, E>(K.Value).AsTask(); }
        protected Task<UnitResult<E>> Task_Func_UnitResult_E(bool _) { actionExecuted = true; return UnitResult.Success<E>().AsTask(); }
        protected Task<UnitResult<E>> Task_Func_UnitResult_E() { actionExecuted = true; return UnitResult.Success<E>().AsTask(); }

        protected ValueTask<Result> ValueTask_Func_Result(bool _) { actionExecuted = true; return Result.Success().AsValueTask(); }
        protected ValueTask<Result<K>> ValueTask_Func_Result_K(bool _) { actionExecuted = true; return Result.Success(K.Value).AsValueTask(); }
        protected ValueTask<Result<K, E>> ValueTask_Func_Result_K_E(bool _) { actionExecuted = true; return Result.Success<K, E>(K.Value).AsValueTask(); }
        protected ValueTask<UnitResult<E>> ValueTask_Func_UnitResult_E(bool _) { actionExecuted = true; return UnitResult.Success<E>().AsValueTask(); }
        protected ValueTask<UnitResult<E>> ValueTask_Func_UnitResult_E() { actionExecuted = true; return UnitResult.Success<E>().AsValueTask(); }
        
        protected bool Predicate(bool b) { predicateExecuted = true; return b; }
    }
}