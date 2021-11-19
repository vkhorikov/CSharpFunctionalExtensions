using FluentAssertions;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public abstract class CompensateTestsBase : TestBase
    {
        protected bool funcExecuted;

        protected CompensateTestsBase()
        {
            funcExecuted = false;
        }

        protected Result GetSuccessResult(string _)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return Result.Success();
        }

        protected Result GetErrorResult(string error)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return Result.Failure(error);
        }

        protected Result GetSuccessResult(E _)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return Result.Success();
        }

        protected Result GetErrorResult(E error)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return Result.Failure(ErrorMessage);
        }

        protected UnitResult<E> GetSuccessUnitResult(string _)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return UnitResult.Success<E>();
        }

        protected UnitResult<E> GetErrorUnitResult(string _)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return UnitResult.Failure(E.Value);
        }

        protected UnitResult<E2> GetSuccessUnitResult(E _)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return UnitResult.Success<E2>();
        }

        protected UnitResult<E2> GetErrorUnitResult(E _)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return UnitResult.Failure(E2.Value);
        }

        protected Result<T> GetSuccessValueResult(string _)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return Result.Success(T.Value);
        }

        protected Result<T> GetErrorValueResult(string error)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return Result.Failure<T>(error);
        }

        protected Result<T, E> GetSuccessValueErrorResult(string _)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return Result.Success<T, E>(T.Value);
        }

        protected Result<T, E> GetErrorValueErrorResult(string _)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return Result.Failure<T, E>(E.Value);
        }

        protected Result<T, E2> GetSuccessValueErrorResult(E _)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return Result.Success<T, E2>(T.Value);
        }

        protected Result<T, E2> GetErrorValueErrorResult(E _)
        {
            funcExecuted.Should().BeFalse();

            funcExecuted = true;
            return Result.Failure<T, E2>(E2.Value);
        }

        protected Task<Result> GetSuccessResultAsync(string error) => GetSuccessResult(error).AsTask();

        protected Task<Result> GetErrorResultAsync(string error) => GetErrorResult(error).AsTask();

        protected Task<Result> GetSuccessResultAsync(E error) => GetSuccessResult(error).AsTask();

        protected Task<Result> GetErrorResultAsync(E error) => GetErrorResult(error).AsTask();

        protected Task<UnitResult<E>> GetSuccessUnitResultAsync(string error) => GetSuccessUnitResult(error).AsTask();

        protected Task<UnitResult<E>> GetErrorUnitResultAsync(string error) => GetErrorUnitResult(error).AsTask();

        protected Task<UnitResult<E2>> GetSuccessUnitResultAsync(E error) => GetSuccessUnitResult(error).AsTask();

        protected Task<UnitResult<E2>> GetErrorUnitResultAsync(E error) => GetErrorUnitResult(error).AsTask();

        protected Task<Result<T>> GetSuccessValueResultAsync(string error) => GetSuccessValueResult(error).AsTask();

        protected Task<Result<T>> GetErrorValueResultAsync(string error) => GetErrorValueResult(error).AsTask();

        protected Task<Result<T, E>> GetSuccessValueErrorResultAsync(string error) => GetSuccessValueErrorResult(error).AsTask();

        protected Task<Result<T, E>> GetErrorValueErrorResultAsync(string error) => GetErrorValueErrorResult(error).AsTask();

        protected Task<Result<T, E2>> GetSuccessValueErrorResultAsync(E error) => GetSuccessValueErrorResult(error).AsTask();

        protected Task<Result<T, E2>> GetErrorValueErrorResultAsync(E error) => GetErrorValueErrorResult(error).AsTask();

        protected void AssertFailure(Result output, bool executed = false)
        {
            funcExecuted.Should().Be(executed);
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(ErrorMessage);
        }

        protected void AssertFailure(Result<K> output, bool executed = false)
        {
            funcExecuted.Should().Be(executed);
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(ErrorMessage);
        }

        protected void AssertFailure(Result<K, E> output, bool executed = false)
        {
            funcExecuted.Should().Be(executed);
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(E.Value);
        }

        protected void AssertFailure(UnitResult<E> output, bool executed = false)
        {
            funcExecuted.Should().Be(executed);
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(E.Value);
        }

        protected void AssertFailure(UnitResult<E2> output, bool executed = false)
        {
            funcExecuted.Should().Be(executed);
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(E2.Value);
        }

        protected void AssertSuccess(Result output, bool executed = true)
        {
            funcExecuted.Should().Be(executed);
            output.IsSuccess.Should().BeTrue();
        }

        protected void AssertSuccess(Result<K> output, bool executed = true)
        {
            funcExecuted.Should().Be(executed);
            output.IsSuccess.Should().BeTrue();
            output.Value.Should().Be(K.Value);
        }

        protected void AssertSuccess(Result<K, E> output, bool executed = true)
        {
            funcExecuted.Should().Be(executed);
            output.IsSuccess.Should().BeTrue();
            output.Value.Should().Be(K.Value);
        }

        protected void AssertSuccess(UnitResult<E> output, bool executed = true)
        {
            funcExecuted.Should().Be(executed);
            output.IsSuccess.Should().BeTrue();
        }

        protected void AssertSuccess(UnitResult<E2> output, bool executed = true)
        {
            funcExecuted.Should().Be(executed);
            output.IsSuccess.Should().BeTrue();
        }
    }
}
