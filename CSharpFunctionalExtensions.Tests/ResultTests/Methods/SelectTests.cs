using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Methods;

public class SelectTests : TestBase
{
    private static class Fixture
    {
        public const string ExpectingValue = "Hello, LINQ";
    }

    [Fact]
    public void Select_Result_then_Select_Another_Result_return_success()
    {
        var result = (
            from s in FetchSome()
            from a in FetchAnother()
            select MapFetches(s, a)
        );

        using (_ = new AssertionScope())
        {
            var (isSuccess, _, resultValue) = result;

            isSuccess.Should().BeTrue();
            resultValue.Should().Be(Fixture.ExpectingValue);
        }
    }

    [Fact]
    public void Select_Result_of_Error_then_Select_Another_Result_return_first_failure()
    {
        var result = (
            from s in FetchSomeError()
            from a in FetchAnother()
            select MapFetches(s, a)
        );

        using (_ = new AssertionScope())
        {
            var (_, isFailure, _, error) = result;

            isFailure.Should().BeTrue();
            error.Should().Be(ErrorMessage);
        }
    }

    [Fact]
    public async Task Select_ResultTask_then_Select_Another_Result_return_success()
    {
        var result = await (
            from s in FetchSome().AsCompletedTask()
            from a in FetchAnother()
            select MapFetches(s, a)
        );

        using (_ = new AssertionScope())
        {
            var (isSuccess, _, resultValue) = result;

            isSuccess.Should().BeTrue();
            resultValue.Should().Be(Fixture.ExpectingValue);
        }
    }

    [Fact]
    public async Task Select_ResultTask_of_Error_then_Select_Another_Result_return_first_failure()
    {
        var result = await (
            from s in FetchSomeError().AsCompletedTask()
            from a in FetchAnother()
            select MapFetches(s, a)
        );

        using (_ = new AssertionScope())
        {
            var (_, isFailure, _, error) = result;

            isFailure.Should().BeTrue();
            error.Should().Be(ErrorMessage);
        }
    }

    private static Result<T> FetchSome() =>
        T.Value;

    private static Result<T> FetchSomeError() =>
        Result.Failure<T>(ErrorMessage);

    private static Result<K> FetchAnother() =>
        K.Value;

    private static string MapFetches(T s, K a) =>
        Fixture.ExpectingValue;
}
