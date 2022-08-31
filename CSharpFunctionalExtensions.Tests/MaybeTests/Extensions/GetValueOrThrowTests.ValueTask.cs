using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class GetValueOrThrowTests_ValueTask : MaybeTestBase
    {

        [Fact]
        public void Async_GetValueOrThrow_throws_with_message_if_source_is_empty()
        {
            const string errorMessage = "Maybe is none";

            Func<Task<int>> func = async () => await Maybe<int>.None.AsValueTask().GetValueOrThrow(errorMessage);

            func.Should().ThrowAsync<InvalidOperationException>().WithMessage(errorMessage);
        }

        [Fact]
        public async Task Async_GetValueOrThrow_returns_value_if_source_has_value()
        {
            const int value = 1;
            var maybe = Maybe.From(value).AsValueTask();
            
            const string errorMessage = "Maybe is none";
            var result = await maybe.GetValueOrThrow(errorMessage);

            result.Should().Be(value);
        }
    }
}