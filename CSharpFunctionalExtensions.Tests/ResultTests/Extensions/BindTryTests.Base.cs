using FluentAssertions;
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class BindTryTestsBase : BindTestsBase
    {
        protected static Result Throwing() => throw new Exception(ErrorMessage);
        protected static Result<T> Throwing_T() => throw new Exception(ErrorMessage);
        protected static UnitResult<E> Throwing_E() => throw new Exception(ErrorMessage);
        protected static Result<T, E> Throwing_T_E() => throw new Exception(ErrorMessage);
        protected static Result<K> Throwing_K() => throw new Exception(ErrorMessage);
        protected static Result<T, K> Throwing_T_K() => throw new Exception(ErrorMessage);
        protected static Result<K, E> Throwing_K_E() => throw new Exception(ErrorMessage);

        protected static Task<Result> Task_Throwing() => throw new Exception(ErrorMessage);
        protected static Task<Result<T>> Task_Throwing_T() => throw new Exception(ErrorMessage);
        protected static Task<UnitResult<E>> Task_Throwing_E() => throw new Exception(ErrorMessage);
        protected static Task<Result<T, E>> Task_Throwing_T_E() => throw new Exception(ErrorMessage);
        protected static Task<Result<K>> Task_Throwing_K() => throw new Exception(ErrorMessage);
        protected static Task<Result<T, K>> Task_Throwing_T_K() => throw new Exception(ErrorMessage);
        protected static Task<Result<K, E>> Task_Throwing_K_E() => throw new Exception(ErrorMessage);

        protected static ValueTask<Result> ValueTask_Throwing() => throw new Exception(ErrorMessage);
        protected static ValueTask<Result<T>> ValueTask_Throwing_T() => throw new Exception(ErrorMessage);
        protected static ValueTask<UnitResult<E>> ValueTask_Throwing_E() => throw new Exception(ErrorMessage);
        protected static ValueTask<Result<T, E>> ValueTask_Throwing_T_E() => throw new Exception(ErrorMessage);
        protected static ValueTask<Result<K>> ValueTask_Throwing_K() => throw new Exception(ErrorMessage);
        protected static ValueTask<Result<T, K>> ValueTask_Throwing_T_K() => throw new Exception(ErrorMessage);
        protected static ValueTask<Result<K, E>> ValueTask_Throwing_K_E() => throw new Exception(ErrorMessage);


        protected void AssertFailure(Result result, string message)
        {
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(message);
            FuncExecuted.Should().BeFalse();
        }
        protected void AssertFailure(UnitResult<E> result, E errorValue)
        {
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(errorValue);
            FuncExecuted.Should().BeFalse();
        }
    }
}
