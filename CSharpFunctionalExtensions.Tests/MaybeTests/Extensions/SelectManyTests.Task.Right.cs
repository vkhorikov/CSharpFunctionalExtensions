using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class SelectManyTests_Task_Right
    {
        [Fact]
        public async Task SelectMany_Task_Right_returns_projection_if_maybes_have_values()
        {
            Maybe<int> maybe1 = 1;

            var maybe3 = await (
                from a in maybe1
                from b in Task.FromResult(Maybe<int>.From(2))
                select a + b
            );

            maybe3.HasValue.Should().BeTrue();
            maybe3.Value.Should().Be(3);
        }

        [Fact]
        public async Task SelectMany_Task_Right_returns_no_value_if_source_has_no_value()
        {
            Maybe<int> maybe1 = Maybe<int>.None;

            var maybe3 = await (
                from a in maybe1
                from b in Task.FromResult(Maybe<int>.From(2))
                select a + b
            );

            maybe3.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task SelectMany_Task_Right_returns_no_value_if_selector_returns_no_value()
        {
            Maybe<int> maybe1 = 1;

            var maybe3 = await (
                from a in maybe1
                from b in Task.FromResult(Maybe<int>.None)
                select a + b
            );

            maybe3.HasValue.Should().BeFalse();
        }
    }
}
