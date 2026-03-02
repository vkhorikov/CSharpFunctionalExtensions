using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class TapNoValueTests_Task : MaybeTestBase
    {
        [Fact]
        public async Task TapNoValue_Task_executes_action_when_no_value()
        {
            string property = null;

            Maybe<T> maybe = null;

            var returnedMaybe = await maybe
                .AsTask()
                .TapNoValue(() => property = "Some value");

            property.Should().Be("Some value");
            returnedMaybe.HasNoValue.Should().BeTrue();
        }

        [Fact]
        public async Task TapNoValue_Task_does_not_execute_action_when_has_value()
        {
            var executed = false;

            Maybe<T> maybe = T.Value;

            var returnedMaybe = await maybe
                .AsTask()
                .TapNoValue(() => executed = true);

            executed.Should().BeFalse();
            returnedMaybe.Value.Should().BeSameAs(maybe.Value);
        }
    }
}
