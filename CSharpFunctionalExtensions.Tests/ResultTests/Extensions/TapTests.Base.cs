using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public abstract class TapTestsBase : TestBase
    {
        protected bool actionExecuted;

        protected TapTestsBase()
        {
            actionExecuted = false;
        }

        protected void Action()
        {
            actionExecuted = true;
        }

        protected void Action_T(T _)
        {
            actionExecuted = true;
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
    }
}
