using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Methods.Try
{
    public abstract class TryTestBaseTask : TryTestBaseCommon
    {

        protected void Action() => FuncExecuted = true;
        protected void Action_T(T _) => FuncExecuted = true;

        protected T Func_T()
        {
            FuncExecuted = true;
            return T.Value;
        }

        protected K Func_T_K(T _)
        {
            FuncExecuted = true;
            return K.Value;
        }

        protected T Throwing_Func_T() => throw Exception;
        protected K Throwing_Func_T_K(T _) => throw Exception;
        protected void Throwing_Action() => throw Exception;
        protected void Throwing_Action_T(T _) => throw Exception;
        
        protected Task Func_Task()
        {
            FuncExecuted = true;
            return Task.CompletedTask;
        }

        protected Task Func_T_Task(T _)
        {
            FuncExecuted = true;
            return Task.CompletedTask;
        }

        protected Task<T> Func_Task_T()
        {
            FuncExecuted = true;
            return T.Value.AsTask();
        }

        protected Task<K> Func_T_Task_K(T _)
        {
            FuncExecuted = true;
            return K.Value.AsTask();
        }

        protected Task Throwing_Func_Task() => Exception.AsTask();
        protected Task<T> Throwing_Func_Task_T() => Exception.AsTask<T>();
        protected Task Throwing_Func_T_Task(T _) => Exception.AsTask();
        protected Task<K> Throwing_Func_T_Task_K(T _) => Exception.AsTask<K>();
        
        protected ValueTask Func_ValueTask()
        {
            FuncExecuted = true;
            return ValueTask.CompletedTask;
        }

        protected ValueTask Func_T_ValueTask(T _)
        {
            FuncExecuted = true;
            return ValueTask.CompletedTask;
        }

        protected ValueTask<T> Func_ValueTask_T()
        {
            FuncExecuted = true;
            return T.Value.AsValueTask();
        }

        protected ValueTask<K> Func_T_ValueTask_K(T _)
        {
            FuncExecuted = true;
            return K.Value.AsValueTask();
        }

        protected ValueTask Throwing_Func_ValueTask() => Exception.AsValueTask();
        protected ValueTask<T> Throwing_Func_ValueTask_T() => Exception.AsValueTask<T>();
        protected ValueTask Throwing_Func_T_ValueTask(T _) => Exception.AsValueTask();
        protected ValueTask<K> Throwing_Func_T_ValueTask_K(T _) => Exception.AsValueTask<K>();


    }
}