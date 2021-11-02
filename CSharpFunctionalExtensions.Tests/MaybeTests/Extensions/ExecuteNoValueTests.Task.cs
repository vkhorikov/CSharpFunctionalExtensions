using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class ExecuteNoValueTests_Task : MaybeTestBase
    {
        [Fact]
        public async Task ExecuteNoValue_Task_executes_action_when_no_value()
        {
            string property = null;

            Maybe<T> maybe = null;

            await maybe.AsTask().ExecuteNoValue(() =>
            {
                property = "Some value";
                return Task.CompletedTask;
            });

            property.Should().Be("Some value");
        }
    }
}