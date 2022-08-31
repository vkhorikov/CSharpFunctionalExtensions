using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class MapTests_ValueTask : MaybeTestBase
    {
        [Fact]
        public async Task Map_ValueTask_returns_mapped_value()
        {
            Maybe<T> maybe = T.Value;

            var maybe2 = await maybe.AsValueTask().Map(ExpectAndReturn_ValueTask(T.Value, T.Value2));

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be(T.Value2);
        }

        [Fact]
        public async Task Map_ValueTask_returns_no_value_if_initial_maybe_is_null()
        {
            Maybe<T> maybe = null;

            var maybe2 = await maybe.AsValueTask().Map(ExpectAndReturn_ValueTask(null, T.Value2));

            maybe2.HasValue.Should().BeFalse();
        }
    }
}