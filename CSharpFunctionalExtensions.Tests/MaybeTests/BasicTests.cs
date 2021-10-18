using FluentAssertions;
using System;
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

            action.Should().Throw<InvalidOperationException>();
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

        [Fact]
        public void Maybe_None_Tuples_has_no_value_is_true()
        {
            Maybe<(Array, Exception)>.None.HasNoValue.Should().BeTrue();
            Maybe<(double, int, byte)>.None.HasNoValue.Should().BeTrue();
        }

        [Fact]
        public void Maybe_None_Tuples_has_value_is_false()
        {
            Maybe<(DateTime, bool, char)>.None.HasValue.Should().BeFalse();
            Maybe<(string, TimeSpan)>.None.HasValue.Should().BeFalse();
        }

        [Fact]
        public void Maybe_None_Select_from_class_to_struct_retains_None()
        {
            Maybe<string>.None.Select(_ => 42).HasValue.Should().BeFalse();
        }

        [Fact]
        public void Maybe_None_Where_respects_structs()
        {
            Maybe<int>.From(0).Where(_ => true).HasValue.Should().BeTrue();
            Maybe<int>.From(0).Where(_ => false).HasValue.Should().BeFalse();

            Maybe<int>.None.Where(_ => true).HasValue.Should().BeFalse();
            Maybe<int>.None.Where(_ => false).HasValue.Should().BeFalse();
        }

        [Fact]
        public void Maybe_From_without_type_parameter_creates_new_maybe()
        {
            var withoutTypeParam = Maybe.From("test");
            var withTypeParam = Maybe<string>.From("test");
            var differentValueTypeParam = Maybe<string>.From("tests");
            
            withoutTypeParam.Should().Be(withTypeParam);
            withoutTypeParam.Should().NotBe(differentValueTypeParam);
        }

        [Fact]
        public void Can_cast_non_generic_maybe_none_to_maybe_none()
        {
            Maybe<int> maybe = Maybe.None;

            maybe.HasValue.Should().BeFalse();
            maybe.HasNoValue.Should().BeTrue();
        }

        [Fact]
        public void GetValueOrThrow_throws_with_message_if_source_is_empty()
        {
            const string errorMessage = "Maybe is none";

            Action action = () =>
            {
                var maybe = Maybe<int>.None;
                int _ = maybe.GetValueOrThrow(errorMessage);
            };

            action.Should().Throw<InvalidOperationException>().WithMessage(errorMessage);
        }

        [Fact]
        public void GetValueOrThrow_returns_value_if_source_has_value()
        {
            const int value = 5;
            var maybe = Maybe.From(value);

            const string errorMessage = "Maybe is none";
            var result = maybe.GetValueOrThrow(errorMessage);

            result.Should().Be(value);
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
