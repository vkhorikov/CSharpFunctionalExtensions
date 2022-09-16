using CSharpFunctionalExtensions.Tests.MaybeTests.Extensions;
using FluentAssertions;
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class MapTryTestsBase : MapTestsBase
    {        
        protected K Throwing_K() => throw new Exception(ErrorMessage, GetFuncException());
        protected K Throwing_T_K(T _) => throw new Exception(ErrorMessage, GetFuncException());

        protected Task<K> Task_Throwing_K() => throw new Exception(ErrorMessage, GetFuncException());
        protected Task<K> Task_Throwing_T_K(T _) => throw new Exception(ErrorMessage, GetFuncException());

        protected ValueTask<K> ValueTask_Throwing_K() => throw new Exception(ErrorMessage, GetFuncException());
        protected ValueTask<K> ValueTask_Throwing_T_K(T _) => throw new Exception(ErrorMessage, GetFuncException());


        protected static string ErrorHandler(Exception _) => ErrorMessage2;
        protected static E ErrorHandler_E(Exception _) => E.Value2;

        protected void AssertSuccess(Result<K,E> result)
        {
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        protected void AssertSuccess(Result<K> result)
        {
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(K.Value);                   
            FuncExecuted.Should().BeTrue();
        }

        protected void AssertFailure(Result<K,E> result)
        {
            AssertFailure(result, E.Value, false);
        }
        protected void AssertFailureFromHandler(Result<K, E> result)
        {
            AssertFailure(result, E.Value2, true);
        }
        protected void AssertFailure(Result result)
        {
            AssertFailure(result, ErrorMessage, false);
        }
        protected void AssertFailureFromHandler(Result result)
        {
            AssertFailure(result, ErrorMessage2, true);
        }
        protected void AssertFailureFromDefaultHandler(Result result)
        {
            AssertFailure(result, ErrorMessage, true);
        }

        protected void AssertFailure(Result result, string message, bool fromFunc)
        {
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(message);
            FuncExecuted.Should().Be(fromFunc);
        }
        protected void AssertFailure(Result<T,E> result, E error, bool fromFunc)
        {
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
            FuncExecuted.Should().Be(fromFunc);
        }
        protected void AssertFailure(UnitResult<E> result, E errorValue, bool fromFunc)
        {
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(errorValue);
            FuncExecuted.Should().Be(fromFunc);
        }
        private Exception GetFuncException()
        {
            Func_K();
            return new Exception("Thrown from function");
        }
    }
}
