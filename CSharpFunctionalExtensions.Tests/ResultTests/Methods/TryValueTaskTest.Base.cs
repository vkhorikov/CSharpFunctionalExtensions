using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Methods.Try
{
    public abstract class TryTestBaseValueTask : TryTestBaseCommon
    {
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