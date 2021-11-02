using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class OrTests_ValueTask_Right : MaybeTestBase
    {
        [Fact]
        public async Task Or_ValueTask_Right_fallback_value_returns_source_if_source_has_value()
        {
            Maybe<T> maybe = T.Value;

            var maybe2 = await maybe.Or(() => T.Value2.AsValueTask());

            maybe2.HasValue.Should().BeTrue();
            maybe2.Should().Be(T.Value);
        }

        [Fact]
        public async Task Or_ValueTask_Right_fallback_value_returns_a_new_instance_with_value_when_source_is_empty()
        {
            var maybeValueTask = Maybe<T>.None;

            var maybe2 = await maybeValueTask.Or(() => T.Value2.AsValueTask());

            maybe2.HasValue.Should().BeTrue();
            maybe2.Should().Be(T.Value2);
        }
    }
}