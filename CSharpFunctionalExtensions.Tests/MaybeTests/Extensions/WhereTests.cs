using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class WhereTests : MaybeTestBase
    {
        [Fact]
        public void Where_returns_value_if_predicate_returns_true()
        {
            Maybe<T> maybe = T.Value;

            var maybe2 = maybe.Where(ExpectAndReturn(T.Value, true));

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be(T.Value);
        }

        [Fact]
        public void Where_returns_no_value_if_predicate_returns_false()
        {
            Maybe<T> maybe = T.Value;

            var maybe2 = maybe.Where(ExpectAndReturn(T.Value, false));

            maybe2.HasValue.Should().BeFalse();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Where_returns_no_value_if_initial_maybe_is_null(bool predicateResult)
        {
            Maybe<T> maybe = null;

            var maybe2 = maybe.Where(ExpectAndReturn(null, predicateResult));

            maybe2.HasValue.Should().BeFalse();
        }
    }
}