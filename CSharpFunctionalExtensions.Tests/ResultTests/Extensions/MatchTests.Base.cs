using System.Threading.Tasks;
using FluentAssertions;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class MatchTestsBase : TestBase
    {
        private bool _failure;
        private bool _success;
        
        protected void OnFailure_String(string arg)
        {
            _failure = true;
        }
        
        protected void OnSuccess()
        {
            _success = true;
        }
        
        protected K OnSuccess_K()
        {
            _success = true;
            return K.Value;
        }
        
        protected K OnFailure_String_K(string arg)
        {
            _failure = true;
            return K.Value2;
        }
        
        protected void OnSuccess_T(T value)
        {
            _success = true;
        }
        
        protected void OnFailure_E(E error)
        {
            _failure = true;
        }
        
        protected K OnSuccess_T_K(T value)
        {
            _success = true;
            return K.Value;
        }
        
        protected K OnFailure_E_K(E error)
        {
            _failure = true;
            return K.Value2;
        }

        protected Task OnFailure_String_Task(string arg)
        {
            _failure = true;
            return Task.CompletedTask;
        }
        
        protected Task OnSuccess_Task()
        {
            OnSuccess();
            return Task.CompletedTask;
        }
        
        protected Task<K> OnSuccess_K_Task()
        {
            return OnSuccess_K().AsTask();
        }
        
        protected Task<K> OnFailure_String_K_Task(string arg)
        {
            return OnFailure_String_K(arg).AsTask();
        }
        
        protected Task OnSuccess_T_Task(T value)
        {
            _success = true;
            return Task.CompletedTask;
        }
        
        protected Task OnFailure_E_Task(E error)
        {
            OnFailure_E(error);
            return Task.CompletedTask;
        }
        
        protected Task<K> OnSuccess_T_K_Task(T value)
        {
            return OnSuccess_T_K(value).AsTask();
        }
        
        protected Task<K> OnFailure_E_K_Task(E error)
        {
            return OnFailure_E_K(error).AsTask();
        }
        
        protected ValueTask OnFailure_String_ValueTask(string arg)
        {
            _failure = true;
            return ValueTask.CompletedTask;
        }
        
        protected ValueTask OnSuccess_ValueTask()
        {
            OnSuccess();
            return ValueTask.CompletedTask;
        }
        
        protected ValueTask<K> OnSuccess_K_ValueTask()
        {
            return OnSuccess_K().AsValueTask();
        }
        
        protected ValueTask<K> OnFailure_String_K_ValueTask(string arg)
        {
            return OnFailure_String_K(arg).AsValueTask();
        }
        
        protected ValueTask OnSuccess_T_ValueTask(T value)
        {
            _success = true;
            return ValueTask.CompletedTask;
        }
        
        protected ValueTask OnFailure_E_ValueTask(E error)
        {
            OnFailure_E(error);
            return ValueTask.CompletedTask;
        }
        
        protected ValueTask<K> OnSuccess_T_K_ValueTask(T value)
        {
            return OnSuccess_T_K(value).AsValueTask();
        }
        
        protected ValueTask<K> OnFailure_E_K_ValueTask(E error)
        {
            return OnFailure_E_K(error).AsValueTask();
        }
        
        protected void AssertSuccess()
        {
            _success.Should().BeTrue();
            _failure.Should().BeFalse();
        }
        
        protected void AssertFailure()
        {
            _failure.Should().BeTrue();
            _success.Should().BeFalse();
        }
    }
}