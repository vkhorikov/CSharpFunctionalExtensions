using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class GetValueOrThrowTests_Task : MaybeTestBase
    {

        [Fact]
        public async Task GetValueOrThrow_Task_throws_with_message_if_source_is_empty()
        {
            const string errorMessage = "Maybe is none";

            Func<Task<int>> func = () => Maybe<int>.None.AsTask().GetValueOrThrow(errorMessage);

            await func.Should().ThrowAsync<InvalidOperationException>().WithMessage(errorMessage);
        }

        [Fact]
        public async Task GetValueOrThrow_Task_returns_value_if_source_has_value()
        {
            const int value = 1;
            var maybe = Maybe.From(value).AsTask();
            
            const string errorMessage = "Maybe is none";
            var result = await maybe.GetValueOrThrow(errorMessage);

            result.Should().Be(value);
        }
    }
}