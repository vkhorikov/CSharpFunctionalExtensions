using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public abstract class OnFailureTestsBase : TestBase
    {
        protected bool actionExecuted;

        protected OnFailureTestsBase()
        {
            actionExecuted = false;
        }

        protected void Action() => actionExecuted = true;

        protected void ActionString(string _) => actionExecuted = true;

        protected void ActionError(E _) => actionExecuted = true;

        protected Task AsyncAction()
        {
            actionExecuted = true;
            return Task.CompletedTask;
        }

        protected Task AsyncActionString(string _)
        {
            actionExecuted = true;
            return Task.CompletedTask;
        }

        protected Task AsyncActionError(E _)
        {
            actionExecuted = true;
            return Task.CompletedTask;
        }
    }
}