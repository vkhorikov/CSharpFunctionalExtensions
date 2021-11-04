using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public abstract class TryTestBase : TestBase
    {
        protected TryTestBase()
        {
            FuncExecuted = false;
        }
        
        protected static readonly Exception Exception = new Exception(ErrorMessage);
        protected const string ErrorHandlerMessage = "Error message from error handler";
        protected static readonly Func<Exception, string> ErrorHandler = exc => ErrorHandlerMessage;
        protected static readonly Func<Exception, E> ErrorHandlerE = exc => E.Value;

        protected bool FuncExecuted;

        protected void Action() => FuncExecuted = true;
        protected void Action_T(T _) => FuncExecuted = true;

        protected T Throwing_Func_T() => throw Exception;
        protected K Throwing_Func_T_K(T _) => throw Exception;
        protected void Throwing_Action() => throw Exception;
        protected void Throwing_Action_T(T _) => throw Exception;
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

        protected Task Throwing_Func_Task() => Exception.AsTask();
        protected Task<T> Throwing_Func_Task_T() => Exception.AsTask<T>();
        protected Task Throwing_Func_T_Task(T _) => Exception.AsTask();
        protected Task<K> Throwing_Func_T_Task_K(T _) => Exception.AsTask<K>();
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
    }
}