using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public abstract class TapIfTestsBase : TestBase
    {
        protected bool actionExecuted;
        protected bool predicateExecuted;

        protected TapIfTestsBase()
        {
            actionExecuted = false;
            predicateExecuted = false;
        }

        protected void Action() { actionExecuted = true; }
        protected void Action_T(T _) { actionExecuted = true; }
        protected void Action_T(bool _) { actionExecuted = true; }

#pragma warning disable 1998
        protected async Task Task_Action() { actionExecuted = true; }
        protected async Task Task_Action_T(T _) { actionExecuted = true; }
        protected async Task Task_Action_T(bool _) { actionExecuted = true; }
#pragma warning restore 1998
        protected Result Func_Result(bool _) { actionExecuted = true; return Result.Success(); } 
        protected Result<K> Func_Result_K(bool _) { actionExecuted = true; return Result.Success<K>(K.Value); }
        protected Result<K,E> Func_Result_K_E(bool _) { actionExecuted = true; return Result.Success<K, E>(K.Value); }

        protected Task<Result> Task_Func_Result(bool _) { actionExecuted = true; return Result.Success().AsTask(); }
        protected Task<Result<K>> Task_Func_Result_K(bool _) { actionExecuted = true; return Result.Success<K>(K.Value).AsTask(); }
        protected Task<Result<K, E>> Task_Func_Result_K_E(bool _) { actionExecuted = true; return Result.Success<K, E>(K.Value).AsTask(); }

        protected bool Predicate(bool b) { predicateExecuted = true; return b; }
    }
}
