using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class ExecuteTests_ValueTask_Left : MaybeTestBase
    {
        [Fact]
        public async Task Execute_ValueTask_Lef_does_not_execute_action_if_no_value()
        {
            Maybe<T> instance = null;
            
            await instance.AsValueTask().Execute(value => instance = T.Value);

            instance.HasNoValue.Should().BeTrue();
        }

        [Fact]
        public async Task Execute_ValueTask_Lef_executes_action_if_value()
        {
            Maybe<T> instance = T.Value;

            await instance.AsValueTask().Execute(value => value.Should().Be(T.Value));

            instance.Value.Should().Be(T.Value);
        }
    }
}