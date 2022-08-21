using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public abstract class MapTestsBase : TestBase
    {
        protected bool FuncExecuted;

        protected MapTestsBase()
        {
            FuncExecuted = false;
        }

        protected K Func_K() 
        { 
            FuncExecuted = true; 
            return K.Value;
        }

        protected K Func_T_K(T value) 
        {
            FuncExecuted = true; 
            return K.Value;
        }

        protected Task<K> Task_Func_K() => Func_K().AsTask();
        protected Task<K> Task_Func_T_K(T value) => Func_T_K(value).AsTask();
        
        protected ValueTask<K> ValueTask_Func_K() => Func_K().AsValueTask();
        protected ValueTask<K> ValueTask_Func_T_K(T value) => Func_T_K(value).AsValueTask();
    }
}