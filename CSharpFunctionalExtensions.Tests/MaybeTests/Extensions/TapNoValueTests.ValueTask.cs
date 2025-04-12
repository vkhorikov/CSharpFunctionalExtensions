using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class TapNoValueTests_ValueTask : MaybeTestBase
    {
        [Fact]
        public async Task TapNoValue_ValueTask_executes_action_when_no_value()
        {
            string property = null;

            Maybe<T> maybe = null;

            var returnedMaybe = await maybe
                .AsValueTask()
                .TapNoValue(() =>
                {
                    property = "Some value";
                    return ValueTask.CompletedTask;
                });

            property.Should().Be("Some value");
            returnedMaybe.Should().BeSameAs(maybe);
        }
    }
}
