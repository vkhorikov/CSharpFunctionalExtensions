using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class SelectManyTests_Task
    {
        [Fact]
        public async Task SelectMany_Task_returns_projection_if_maybes_have_values()
        {
            Task<Maybe<int>> maybe1 = Task.FromResult(Maybe<int>.From(1));
            Task<Maybe<int>> maybe2 = Task.FromResult(Maybe<int>.From(2));

            var maybe3 = await (from a in maybe1 from b in maybe2 select a + b);

            maybe3.HasValue.Should().BeTrue();
            maybe3.Value.Should().Be(3);
        }

        [Fact]
        public async Task SelectMany_Task_returns_no_value_if_first_has_no_value()
        {
            Task<Maybe<int>> maybe1 = Task.FromResult(Maybe<int>.None);
            Task<Maybe<int>> maybe2 = Task.FromResult(Maybe<int>.From(2));

            var maybe3 = await (from a in maybe1 from b in maybe2 select a + b);

            maybe3.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task SelectMany_Task_returns_no_value_if_second_has_no_value()
        {
            Task<Maybe<int>> maybe1 = Task.FromResult(Maybe<int>.From(1));
            Task<Maybe<int>> maybe2 = Task.FromResult(Maybe<int>.None);

            var maybe3 = await (from a in maybe1 from b in maybe2 select a + b);

            maybe3.HasValue.Should().BeFalse();
        }
    }
}
