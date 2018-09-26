using System;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests
{
    public class BasicTests
    {
        [Fact]
        public void Can_create_a_nullable_maybe()
        {
            Maybe<MyClass> maybe = null;

            maybe.HasValue.Should().BeFalse();
            maybe.HasNoValue.Should().BeTrue();
        }

        [Fact]
        public void Can_create_a_maybe_none()
        {
            Maybe<MyClass> maybe = Maybe<MyClass>.None;

            maybe.HasValue.Should().BeFalse();
            maybe.HasNoValue.Should().BeTrue();
        }

        [Fact]
        public void Nullable_maybe_is_same_as_maybe_none()
        {
            Maybe<MyClass> nullableMaybe = null;
            Maybe<MyClass> maybeNone = Maybe<MyClass>.None;

            nullableMaybe.Should().Be(maybeNone);
        }

        [Fact]
        public void Cannot_access_Value_if_none()
        {
            Maybe<MyClass> maybe = null;

            Action action = () =>
            {
                MyClass myClass = maybe.Value;
            };

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Can_create_a_non_nullable_maybe()
        {
            var instance = new MyClass();

            Maybe<MyClass> maybe = instance;

            maybe.HasValue.Should().BeTrue();
            maybe.HasNoValue.Should().BeFalse();
            maybe.Value.Should().Be(instance);
        }

        [Fact]
        public void ToString_returns_No_Value_if_no_value()
        {
            Maybe<MyClass> maybe = null;

            string str = maybe.ToString();

            str.Should().Be("No value");
        }

        [Fact]
        public void ToString_returns_underlying_objects_string_representation()
        {
            Maybe<MyClass> maybe = new MyClass();

            string str = maybe.ToString();

            str.Should().Be("My custom class");
        }

        [Fact]
        public void Maybe_None_has_no_value()
        {
            Maybe<string>.None.HasValue.Should().BeFalse();
            Maybe<int>.None.HasValue.Should().BeFalse();
        }

        private class MyClass
        {
            public override string ToString()
            {
                return "My custom class";
            }
        }
    }
}
