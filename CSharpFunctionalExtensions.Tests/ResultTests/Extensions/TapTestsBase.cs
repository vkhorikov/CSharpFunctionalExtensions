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

        protected void Action() { actionExecuted = true; }
        protected void Action_T(T _) { actionExecuted = true; }

        protected async Task Task_Action() { actionExecuted = true; }
        protected async Task Task_Action_T(T _) { actionExecuted = true; }
    }
}
