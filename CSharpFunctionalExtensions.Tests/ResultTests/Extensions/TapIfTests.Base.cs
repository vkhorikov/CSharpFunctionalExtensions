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

        protected void Action()
        {
            actionExecuted = true;
        }

        protected void Action_T(T _)
        {
            actionExecuted = true;
        }

        protected void Action_T(bool _)
        {
            actionExecuted = true;
        }

        protected Result Func_Result(bool _)
        {
            actionExecuted = true;
            return Result.Success();
        }

        protected Result<K> Func_Result_K(bool _)
        {
            actionExecuted = true;
            return Result.Success(K.Value);
        }

        protected Result<K, E> Func_Result_K_E(bool _)
        {
            actionExecuted = true;
            return Result.Success<K, E>(K.Value);
        }

        protected Task Task_Action()
        {
            actionExecuted = true;
            return Task.CompletedTask;
        }

        protected Task Task_Action_T(T _)
        {
            actionExecuted = true;
            return Task.CompletedTask;
        }

        protected Task Task_Action_T(bool _)
        {
            actionExecuted = true;
            return Task.CompletedTask;
        }
        
        protected Task<Result> Task_Func_Result(bool _)
        {
            actionExecuted = true;
            return Result.Success().AsTask();
        }

        protected Task<Result<K>> Task_Func_Result_K(bool _)
        {
            actionExecuted = true;
            return Result.Success(K.Value).AsTask();
        }

        protected Task<Result<K, E>> Task_Func_Result_K_E(bool _)
        {
            actionExecuted = true;
            return Result.Success<K, E>(K.Value).AsTask();
        }

        protected ValueTask ValueTask_Action()
        {
            actionExecuted = true;
            return ValueTask.CompletedTask;
        }

        protected ValueTask ValueTask_Action_T(T _)
        {
            actionExecuted = true;
            return ValueTask.CompletedTask;
        }

        protected ValueTask ValueTask_Action_T(bool _)
        {
            actionExecuted = true;
            return ValueTask.CompletedTask;
        }
        
        protected ValueTask<Result> ValueTask_Func_Result(bool _)
        {
            actionExecuted = true;
            return Result.Success().AsValueTask();
        }

        protected ValueTask<Result<K>> ValueTask_Func_Result_K(bool _)
        {
            actionExecuted = true;
            return Result.Success(K.Value).AsValueTask();
        }

        protected ValueTask<Result<K, E>> ValueTask_Func_Result_K_E(bool _)
        {
            actionExecuted = true;
            return Result.Success<K, E>(K.Value).AsValueTask();
        }

        protected bool Predicate(bool b)
        {
            predicateExecuted = true;
            return b;
        }
    }
}
