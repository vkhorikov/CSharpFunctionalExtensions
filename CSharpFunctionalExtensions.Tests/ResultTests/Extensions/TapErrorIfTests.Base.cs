using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public abstract class TapErrorIfTestsBase : TestBase
    {
        protected bool actionExecuted;
        protected bool predicateExecuted;

        protected TapErrorIfTestsBase()
        {
            actionExecuted = false;
            predicateExecuted = false;
        }

        protected void Action()
        {
            actionExecuted = true;
        }

        protected void Action_String(string _)
        {
            actionExecuted = true;
        }

        protected void Action_E(E _)
        {
            actionExecuted = true;
        }

        protected Task Task_Action()
        {
            actionExecuted = true;
            return Task.CompletedTask;
        }

        protected Task Task_Action_String(string _)
        {
            actionExecuted = true;
            return Task.CompletedTask;
        }

        protected Task Task_Action_E(E _)
        {
            actionExecuted = true;
            return Task.CompletedTask;
        }

        protected ValueTask ValueTask_Action()
        {
            actionExecuted = true;
            return ValueTask.CompletedTask;
        }

        protected ValueTask ValueTask_Action_String(string _)
        {
            actionExecuted = true;
            return ValueTask.CompletedTask;
        }

        protected ValueTask ValueTask_Action_E(E _)
        {
            actionExecuted = true;
            return ValueTask.CompletedTask;
        }

        protected Func<string, bool> Predicate_String(bool condition)
        {
            return _ =>
            {
                predicateExecuted = true;
                return condition;
            };
        }

        protected Func<E, bool> Predicate_E(bool condition)
        {
            return _ =>
            {
                predicateExecuted = true;
                return condition;
            };
        }
    }
}
