using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class SelectTests_ValueTask
    {
        [Fact]
        public async Task Select_ValueTask_returns_new_maybe()
        {
            ValueTask<Maybe<MyClass>> maybe = new ValueTask<Maybe<MyClass>>(Maybe<MyClass>.From(new MyClass { Property = "Some value" }));

            Maybe<string> maybe2 = await maybe.Select(x => x.Property);

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be("Some value");
        }

        [Fact]
        public async Task Select_ValueTask_returns_no_value_if_no_value_passed_in()
        {
            ValueTask<Maybe<MyClass>> maybe = new ValueTask<Maybe<MyClass>>(Maybe<MyClass>.None);

            Maybe<string> maybe2 = await maybe.Select(x => x.Property);

            maybe2.HasValue.Should().BeFalse();
        }

        private class MyClass
        {
            public string Property { get; set; }
        }
    }
}
