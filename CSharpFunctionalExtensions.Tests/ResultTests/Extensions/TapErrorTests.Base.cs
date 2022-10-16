using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public abstract class TapErrorTestsBase : TestBase
    {
        protected bool actionExecuted;

        protected TapErrorTestsBase()
        {
            actionExecuted = false;
        }

        protected void Action() => actionExecuted = true;

        protected void ActionString(string _) => actionExecuted = true;

        protected void ActionError(E _) => actionExecuted = true;

        protected Task TaskAction()
        {
            actionExecuted = true;
            return Task.CompletedTask;
        }

        protected Task TaskActionString(string _)
        {
            actionExecuted = true;
            return Task.CompletedTask;
        }

        protected Task TaskActionError(E _)
        {
            actionExecuted = true;
            return Task.CompletedTask;
        }
        
        protected ValueTask ValueTaskAction()
        {
            actionExecuted = true;
            return ValueTask.CompletedTask;
        }

        protected ValueTask ValueTaskActionString(string _)
        {
            actionExecuted = true;
            return ValueTask.CompletedTask;
        }

        protected ValueTask ValueTaskActionError(E _)
        {
            actionExecuted = true;
            return ValueTask.CompletedTask;
        }
    }
}