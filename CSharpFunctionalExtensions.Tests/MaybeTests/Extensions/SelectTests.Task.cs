using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class SelectTests_Task
    {
        [Fact]
        public async Task Select_Task_returns_new_maybe()
        {
            Task<Maybe<MyClass>> maybe = Task.FromResult(Maybe<MyClass>.From(new MyClass { Property = "Some value" }));

            Maybe<string> maybe2 = await maybe.Select(x => x.Property);

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be("Some value");
        }

        [Fact]
        public async Task Select_Task_returns_no_value_if_no_value_passed_in()
        {
            Task<Maybe<MyClass>> maybe = Task.FromResult(Maybe<MyClass>.None);

            Maybe<string> maybe2 = await maybe.Select(x => x.Property);

            maybe2.HasValue.Should().BeFalse();
        }

        private class MyClass
        {
            public string Property { get; set; }
        }
    }
}
