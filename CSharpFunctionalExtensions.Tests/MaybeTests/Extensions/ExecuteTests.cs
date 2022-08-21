using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class ExecuteTests : MaybeTestBase
    {
        [Fact]
        public void Execute_does_not_execute_action_if_no_value()
        {
            Maybe<T> instance = null;
            
            instance.Execute(value => instance = T.Value);

            instance.HasNoValue.Should().BeTrue();
        }

        [Fact]
        public void Execute_executes_action_if_value()
        {
            Maybe<T> instance = T.Value;

            instance.Execute(value => value.Should().Be(T.Value));

            instance.Value.Should().Be(T.Value);
        }
    }
}