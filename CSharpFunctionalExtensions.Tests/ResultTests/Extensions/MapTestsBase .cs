using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public abstract class MapTestsBase : TestBase
    {
        protected bool funcExecuted;
        protected T funcValue;

        protected MapTestsBase()
        {
            funcExecuted = false;
        }

        protected K Func_K() 
        { 
            funcExecuted = true; 
            return K.Value;
        }

        protected K Func_T_K(T value) 
        { 
            funcValue = value;
            funcExecuted = true; 
            return K.Value;
        }

        protected Task<K> Task_Func_K() => Func_K().AsTask();
        protected Task<K> Task_Func_T_K(T value) => Func_T_K(value).AsTask();
    }
}
