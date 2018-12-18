using System;
using System.Collections.Generic;

using FluentAssertions;

using Xunit;


namespace CSharpFunctionalExtensions.Tests.MaybeTests
{
    public class BugTests
    {
        [Fact]
        public void Bug_MaybeDynamicNone()
        {
            bool compareUsingMaybeDynamic = EqualityComparer<Maybe<dynamic>>.Default.Equals(Maybe<dynamic>.None, Maybe<dynamic>.None);
            bool compareObjectNotDynamic = EqualityComparer<object>.Default.Equals(Maybe<int>.None, Maybe<int>.None);
            bool compareDynamicInt = EqualityComparer<object>.Default.Equals((dynamic)1, (dynamic)1);
            //NSubstitute is using object as generic type which doesnt work for Maybe<dynamic>
            bool compareUsingMaybeObject = EqualityComparer<object>.Default.Equals(Maybe<dynamic>.None, Maybe<dynamic>.None);
            bool equalsDynamic1 = Maybe<dynamic>.None == (dynamic)Maybe<dynamic>.None;
            bool equalsDynamic2 = Maybe<dynamic>.None.Equals((dynamic)Maybe<dynamic>.None);
            bool equalsDynamic3 = Maybe<object>.None == (object)new Maybe<object>();

            equalsDynamic1.Should().BeTrue();
            equalsDynamic2.Should().BeTrue();
            equalsDynamic3.Should().BeTrue();
            compareUsingMaybeDynamic.Should().BeTrue();
            compareObjectNotDynamic.Should().BeTrue();
            compareDynamicInt.Should().BeTrue();
            compareUsingMaybeObject.Should().BeTrue(); // Only comparission of Maybe<dynamic>.None using object comparer fails.
        }


        [Fact]
        public void Bug_DefaultInstance()
        {
            bool compareMaybeIntUsingObject = EqualityComparer<object>.Default.Equals(Activator.CreateInstance(typeof(Maybe<int>)), Activator.CreateInstance(typeof(Maybe<int>)));
            bool compareUsingMaybeDynamic = EqualityComparer<Maybe<dynamic>>.Default.Equals(Activator.CreateInstance(typeof(Maybe<dynamic>)), Activator.CreateInstance(typeof(Maybe<dynamic>)));
            //NSubstitute is using object as generic type which doesnt work for Maybe<dynamic>
            bool compareMaybeDynamicUsingObject = EqualityComparer<object>.Default.Equals(Activator.CreateInstance(typeof(Maybe<dynamic>)), Activator.CreateInstance(typeof(Maybe<dynamic>)));

            compareMaybeIntUsingObject.Should().BeTrue();
            compareUsingMaybeDynamic.Should().BeTrue(); // Surprisingly this one fails for Default instance but not for Maybe<>.None
            compareMaybeDynamicUsingObject.Should().BeTrue(); //Here is the same problem as with Maybe<dynamic>.None in the test above 
        }
    }
}
