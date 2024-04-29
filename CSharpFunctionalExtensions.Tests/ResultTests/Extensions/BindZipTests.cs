using System.Runtime.CompilerServices;
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

        using (var _ = new AssertionScope())
        {
            AssertSuccess(output);

            (var _, var _, (T t, K k)) = output;
            t.Should().Be(T.Value);
            k.Should().Be(K.Value);
        }
    }

    [Fact]
    public void BindZip_T_With_Bind_K_eight_times_returns_success()
    {
        Result<(T, K, K, K, K, K, K, K)> output = Success_T(T.Value)
            .BindZip(_                     => Success_K())
            .BindZip((_, _)                => Success_K())
            .BindZip((_, _, _)             => Success_K())
            .BindZip((_, _, _, _)          => Success_K())
            .BindZip((_, _, _, _, _)       => Success_K())
            .BindZip((_, _, _, _, _, _)    => Success_K())
            .BindZip((_, _, _, _, _, _, _) => Success_K());

        ((ITuple)output.Value).Length.Should().Be(8);
    }
}
