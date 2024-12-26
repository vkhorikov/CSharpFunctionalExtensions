using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class MapTests_ValueTask_Right : MaybeTestBase
    {
        [Fact]
        public async Task Map_ValueTask_Right_returns_mapped_value()
        {
            Maybe<T> maybe = T.Value;

            var maybe2 = await maybe.Map(valueTask: ExpectAndReturn_ValueTask(T.Value, T.Value2));

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be(T.Value2);
        }

        [Fact]
        public async Task Map_ValueTask_Right_returns_no_value_if_initial_maybe_is_null()
        {
            Maybe<T> maybe = null;

            var maybe2 = await maybe.Map(valueTask: ExpectAndReturn_ValueTask(null, T.Value2));

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task Map_ValueTask_Right_provides_context_to_selector()
        {
            Maybe<T> maybe = T.Value;
            var context = 5;

            var maybe2 = await maybe.Map(
                valueTask: (value, ctx) =>
                {
                    ctx.Should().Be(context);
                    return value.AsValueTask();
                },
                context
            );

            maybe2.HasValue.Should().BeTrue();
        }
    }
}
