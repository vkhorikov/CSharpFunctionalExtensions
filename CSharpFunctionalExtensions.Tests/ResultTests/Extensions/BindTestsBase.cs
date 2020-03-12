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

        protected Result<F> GetResult_F()
        {
            funcExecuted = true;
            return Result.Success(F.Value);
        }

        protected Task<Result<F>> GetResult_F_Task()
            => GetResult_F().AsCompletedTask();

        protected Result<F> GetResult_F_WithParam(T value)
        {
            funcExecuted = true;
            funcParam = value;
            return Result.Success(F.Value);
        }

        protected Task<Result<F>> GetResult_F_WithParam_Task(T value)
            => GetResult_F_WithParam(value).AsCompletedTask();

        protected Result<F, E> GetResult_F_E_WithParam(T value)
        {
            funcExecuted = true;
            funcParam = value;
            return Result.Success<F, E>(F.Value);
        }

        protected Task<Result<F, E>> GetResult_F_E_WithParam_Task(T value)
            => GetResult_F_E_WithParam(value).AsCompletedTask();

        protected void AssertFailure(Result output)
        {
            funcExecuted.Should().BeFalse();
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(ErrorMessage);
        }

        protected void AssertFailure(Result<F> output)
        {
            funcExecuted.Should().BeFalse();
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(ErrorMessage);
        }

        protected void AssertFailure(Result<F, E> output)
        {
            funcExecuted.Should().BeFalse();
            output.IsFailure.Should().BeTrue();
            output.Error.Should().Be(E.Value);
        }

        protected void AssertFailure(Result<T, E> output)
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

        protected void AssertSuccess(Result<F> output)
        {
            funcExecuted.Should().BeTrue();
            output.IsSuccess.Should().BeTrue();
            output.Value.Should().Be(F.Value);
        }

        protected void AssertSuccess(Result<F, E> output)
        {
            funcExecuted.Should().BeTrue();
            output.IsSuccess.Should().BeTrue();
            output.Value.Should().Be(F.Value);
        }

        protected void AssertSuccess(Result<T, E> output)
        {
            funcExecuted.Should().BeTrue();
            output.IsSuccess.Should().BeTrue();
            output.Value.Should().Be(T.Value);
        }
    }
}
