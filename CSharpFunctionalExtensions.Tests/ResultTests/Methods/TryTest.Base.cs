namespace CSharpFunctionalExtensions.Tests.ResultTests.Methods.Try
{
    public abstract class TryTestBase : TryTestBaseCommon
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

    }
}