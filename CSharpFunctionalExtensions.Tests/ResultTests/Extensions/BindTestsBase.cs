using FluentAssertions;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class BindTestsBase : TestBase
    {
        protected const string ErrorMessage = "Error Message";

        protected bool funcExecuted;
        protected T funcParam;

        protected BindTestsBase()
        {
            funcExecuted = false;
            funcParam = null;
        }

        protected Result GetResult()
        {
            funcExecuted = true;
            return Result.Success();
        }

        protected Task<Result> GetResultTask()
            => GetResult().AsCompletedTask();

        protected Result GetResult_WithParam(T value)
        {
            funcExecuted = true;
            funcParam = value;
            return Result.Success(value);
        }

        protected Task<Result> GetResult_WithParam_Task(T value)
            => GetResult_WithParam(value).AsCompletedTask();

        protected Result<K> GetResult_K()
        {
            funcExecuted = true;
            return Result.Success(K.Value);
        }

        protected Task<Result<K>> GetResult_K_Task()
            => GetResult_K().AsCompletedTask();

        protected Result<K> GetResult_K_WithParam(T value)
        {
            funcExecuted = true;
            funcParam = value;
            return Result.Success(K.Value);
        }

        protected Task<Result<K>> GetResult_K_WithParam_Task(T value)
            => GetResult_K_WithParam(value).AsCompletedTask();

        protected Result<K, E> GetResult_K_E_WithParam(T value)
        {
            funcExecuted = true;
            funcParam = value;
            return Result.Success<K, E>(K.Value);
        }

        protected Task<Result<K, E>> GetResult_K_E_WithParam_Task(T value)
            => GetResult_K_E_WithParam(value).AsCompletedTask();

        protected void AssertFailure(Result output)
        {
            funcExecuted.Should().BeFalse();
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(ErrorMessage);
        }

        protected void AssertFailure(Result<K> output)
        {
            funcExecuted.Should().BeFalse();
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(ErrorMessage);
        }

        protected void AssertFailure(Result<K, E> output)
        {
            funcExecuted.Should().BeFalse();
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(E.Value);
        }

        protected void AssertSuccess(Result output)
        {
            funcExecuted.Should().BeTrue();
            output.IsSuccess.Should().BeTrue();
        }

        protected void AssertSuccess(Result<K> output)
        {
            funcExecuted.Should().BeTrue();
            output.IsSuccess.Should().BeTrue();
            output.Value.Should().Be(K.Value);
        }

        protected void AssertSuccess(Result<K, E> output)
        {
            funcExecuted.Should().BeTrue();
            output.IsSuccess.Should().BeTrue();
            output.Value.Should().Be(K.Value);
        }
    }
}
