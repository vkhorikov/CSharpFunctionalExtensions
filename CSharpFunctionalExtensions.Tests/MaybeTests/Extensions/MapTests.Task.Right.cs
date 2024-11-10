using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class MapTests_Task_Right : MaybeTestBase
    {
        [Fact]
        public async Task Map_Task_Right_returns_mapped_value()
        {
            Maybe<T> maybe = T.Value;

            var maybe2 = await maybe.Map(ExpectAndReturn_Task(T.Value, T.Value2));

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be(T.Value2);
        }

        [Fact]
        public async Task Map_Task_Right_returns_no_value_if_initial_maybe_is_null()
        {
            Maybe<T> maybe = null;

            var maybe2 = await maybe.Map(ExpectAndReturn_Task(null, T.Value2));

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task Map_Task_Right_provides_context_to_selector()
        {
            Maybe<T> maybe = T.Value;
            var context = 5;

            var maybe2 = await maybe.Map(
                (value, ctx) =>
                {
                    ctx.Should().Be(context);
                    return value.AsTask();
                },
                context
            );

            maybe2.HasValue.Should().BeTrue();
        }
    }
}
