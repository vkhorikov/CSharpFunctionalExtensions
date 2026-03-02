using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class SelectManyTests_ValueTask
    {
        [Fact]
        public async Task SelectMany_ValueTask_returns_projection_if_maybes_have_values()
        {
            ValueTask<Maybe<int>> maybe1 = new ValueTask<Maybe<int>>(Maybe<int>.From(1));
            ValueTask<Maybe<int>> maybe2 = new ValueTask<Maybe<int>>(Maybe<int>.From(2));

            var maybe3 = await (from a in maybe1 from b in maybe2 select a + b);

            maybe3.HasValue.Should().BeTrue();
            maybe3.Value.Should().Be(3);
        }

        [Fact]
        public async Task SelectMany_ValueTask_returns_no_value_if_first_has_no_value()
        {
            ValueTask<Maybe<int>> maybe1 = new ValueTask<Maybe<int>>(Maybe<int>.None);
            ValueTask<Maybe<int>> maybe2 = new ValueTask<Maybe<int>>(Maybe<int>.From(2));

            var maybe3 = await (from a in maybe1 from b in maybe2 select a + b);

            maybe3.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task SelectMany_ValueTask_returns_no_value_if_second_has_no_value()
        {
            ValueTask<Maybe<int>> maybe1 = new ValueTask<Maybe<int>>(Maybe<int>.From(1));
            ValueTask<Maybe<int>> maybe2 = new ValueTask<Maybe<int>>(Maybe<int>.None);

            var maybe3 = await (from a in maybe1 from b in maybe2 select a + b);

            maybe3.HasValue.Should().BeFalse();
        }
    }
}
