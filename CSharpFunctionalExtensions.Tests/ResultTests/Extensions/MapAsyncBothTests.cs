using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions 
{
    public class MapAsyncBothTests : MapTestsBase 
    {
        [Fact]
        public async Task Map_AsyncBoth_executes_on_success_returns_new_success()
        {
            Task<Result> result = Result.Success().AsTask();
            Result<K> actual = await result.Map(Task_Func_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            funcExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_AsyncBoth_executes_on_failure_returns_new_failure()
        {
            Task<Result> result = Result.Failure(ErrorMessage).AsTask();
            Result<K> actual = await result.Map(Task_Func_K);

            actual.IsSuccess.Should().BeFalse();
            funcExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_AsyncBoth_T_executes_on_success_returns_new_success()
        {
            Task<Result<T>> result = Result.Success(T.Value).AsTask();
            Result<K> actual = await result.Map(Task_Func_T_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            funcExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_AsyncBoth_T_executes_on_failure_returns_new_failure()
        {
            Task<Result<T>> result = Result.Failure<T>(ErrorMessage).AsTask();
            Result<K> actual = await result.Map(Task_Func_T_K);

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(ErrorMessage);
            funcExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_AsyncBoth_T_E_executes_on_success_returns_new_success()
        {
            Task<Result<T, E>> result = Result.Success<T, E>(T.Value).AsTask();
            Result<K, E> actual = await result.Map(Task_Func_T_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            funcExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_AsyncBoth_T_E_executes_on_failure_returns_new_failure()
        {
            Task<Result<T, E>> result = Result.Failure<T, E>(E.Value).AsTask();
            Result<K, E> actual = await result.Map(Task_Func_T_K);

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            funcExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task Map_AsyncBoth_unit_result_E_executes_on_success_returns_success()
        {
            Task<UnitResult<E>> result = UnitResult.Success<E>().AsTask();
            Result<K, E> actual = await result.Map(Task_Func_K);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(K.Value);
            funcExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task Map_AsyncBoth_unit_result_E_executes_on_failure_returns_failure()
        {
            Task<UnitResult<E>> result = UnitResult.Failure(E.Value).AsTask();
            Result<K, E> actual = await result.Map(Task_Func_K);

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            funcExecuted.Should().BeFalse();
        }
    }
}
