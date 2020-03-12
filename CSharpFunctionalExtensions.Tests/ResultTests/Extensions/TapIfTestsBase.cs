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

        protected async Task Task_Action() { actionExecuted = true; }
        protected async Task Task_Action_T(T _) { actionExecuted = true; }
        protected async Task Task_Action_T(bool _) { actionExecuted = true; }

        protected bool Predicate(bool b) { predicateExecuted = true; return b; }
    }
}
