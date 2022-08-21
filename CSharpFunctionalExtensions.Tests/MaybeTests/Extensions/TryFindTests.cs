using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions;

public class TryFindTests
{
    [Fact]
    public void TryFind_dict_does_not_contains_key()
    {
        var dict = new Dictionary<string, string>();

        var maybe = dict.TryFind("key");

        maybe.HasValue.Should().BeFalse();
    }
}