using System.Collections.Generic;
using CSharpFunctionalExtensions.Tests.ResultTests;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions;

public class ToListTest : TestBase
{
    
    [Fact]
    public void ToList_gives_empty_list_if_null()
    {
        Maybe<T> maybe = null;

        List<T> myClasses = maybe.ToList();

        myClasses.Count.Should().Be(0);
    }

    [Fact]
    public void ToList_gives_single_item_list_if_not_null()
    {
        Maybe<T> maybe = T.Value;

        List<T> myClasses = maybe.ToList();

        myClasses.Count.Should().Be(1);
        myClasses[0].Should().Be(T.Value);
    }
}