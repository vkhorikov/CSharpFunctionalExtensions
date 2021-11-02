using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions 
{
    public class MapTests_ValueTask : MapTestsBase 
    {
        [Fact]
        public async Task Map_ValueTask_executes_on_success_returns_new_success()
        {
            ValueTask<Result> result = Result.Success().AsValueTask();
            Result<K> actual = await result.Map(ValueTask_Func_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_ValueTask_executes_on_failure_returns_new_failure()
        {
            ValueTask<Result> result = Result.Failure(ErrorMessage).AsValueTask();
            Result<K> actual = await result.Map(ValueTask_Func_K);

            actual.IsSuccess.Should().BeFalse();
            FuncExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_ValueTask_T_executes_on_success_returns_new_success()
        {
            ValueTask<Result<T>> result = Result.Success(T.Value).AsValueTask();
            Result<K> actual = await result.Map(ValueTask_Func_T_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_ValueTask_T_executes_on_failure_returns_new_failure()
        {
            ValueTask<Result<T>> result = Result.Failure<T>(ErrorMessage).AsValueTask();
            Result<K> actual = await result.Map(ValueTask_Func_T_K);

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(ErrorMessage);
            FuncExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_ValueTask_T_E_executes_on_success_returns_new_success()
        {
            ValueTask<Result<T, E>> result = Result.Success<T, E>(T.Value).AsValueTask();
            Result<K, E> actual = await result.Map(ValueTask_Func_T_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_ValueTask_T_E_executes_on_failure_returns_new_failure()
        {
            ValueTask<Result<T, E>> result = Result.Failure<T, E>(E.Value).AsValueTask();
            Result<K, E> actual = await result.Map(ValueTask_Func_T_K);

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            FuncExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_ValueTask_UnitResult_E_executes_on_success_returns_success()
        {
            ValueTask<UnitResult<E>> result = UnitResult.Success<E>().AsValueTask();
            Result<K, E> actual = await result.Map(ValueTask_Func_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            FuncExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_ValueTask_UnitResult_E_executes_on_failure_returns_failure()
        {
            ValueTask<UnitResult<E>> result = UnitResult.Failure(E.Value).AsValueTask();
            Result<K, E> actual = await result.Map(ValueTask_Func_K);

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            FuncExecuted.Should().BeFalse();
        }
    }
}
