using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions;

public class BindZipTests : BindTestsBase
{
    [Fact]
    public void BindZip_T_with_Bind_K_returns_success()
    {
        Result<(T, K)> output = Success_T(T.Value).BindZip(_ => Success_K());

        using var _ = new AssertionScope();

        AssertSuccess(output);

        (var _, var _, (T first, K second)) = output;

        first.Should().Be(T.Value);

        second.Should().Be(K.Value);
    }
}
