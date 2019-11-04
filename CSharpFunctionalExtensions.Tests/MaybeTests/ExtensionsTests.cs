using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;


namespace CSharpFunctionalExtensions.Tests.MaybeTests
{
    public class ExtensionsTests
    {
        [Fact]
        public void Unwrap_extracts_value_if_not_null()
        {
            var instance = new MyClass();
            Maybe<MyClass> maybe = instance;

            MyClass myClass = maybe.Unwrap();

            myClass.Should().Be(instance);
        }

        [Fact]
        public void Unwrap_extracts_null_if_no_value()
        {
            Maybe<MyClass> maybe = null;

            MyClass myClass = maybe.Unwrap();

            myClass.Should().BeNull();
        }

        [Fact]
        public void Can_use_selector_in_Unwrap()
        {
            Maybe<MyClass> maybe = new MyClass { Property = "Some value" };

            string value = maybe.Unwrap(x => x.Property);

            value.Should().Be("Some value");
        }

        [Fact]
        public void Can_use_default_value_in_Unwrap()
        {
            Maybe<string> maybe = null;

            string value = maybe.Unwrap("");

            value.Should().Be("");
        }

        [Fact]
        public void ToResult_returns_success_if_value_exists()
        {
            var instance = new MyClass();
            Maybe<MyClass> maybe = instance;

            Result<MyClass> result = maybe.ToResult("Error");

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(instance);
        }

        [Fact]
        public void ToResult_returns_failure_if_no_value()
        {
            Maybe<MyClass> maybe = null;

            Result<MyClass> result = maybe.ToResult("Error");

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Error");
        }

        [Fact]
        public void ToResult_with_custom_error_type_returns_success_if_value_exists()
        {
            var instance = new MyClass();
            Maybe<MyClass> maybe = instance;

            Result<MyClass, MyErrorClass> result = maybe.ToResult(new MyErrorClass());

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(instance);
        }

        [Fact]
        public void ToResult_with_custom_error_type_returns_custom_failure_if_no_value()
        {
            Maybe<MyClass> maybe = null;

            var errorInstance = new MyErrorClass();
            Result<MyClass, MyErrorClass> result = maybe.ToResult(errorInstance);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(errorInstance);
        }

        [Fact]
        public void ToResult_with_struct_error_type_returns_custom_failure_if_no_value_with_default_error()
        {
            Maybe<MyClass> maybe = null;

            int errorInstance = 0;
            Result<MyClass, int> result = maybe.ToResult(errorInstance);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(errorInstance);
        }

        [Fact]
        public void Where_returns_value_if_predicate_returns_true()
        {
            var instance = new MyClass { Property = "Some value" };
            Maybe<MyClass> maybe = instance;

            Maybe<MyClass> maybe2 = maybe.Where(x => x.Property == "Some value");

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be(instance);
        }

        [Fact]
        public void Where_returns_no_value_if_predicate_returns_false()
        {
            var instance = new MyClass { Property = "Some value" };
            Maybe<MyClass> maybe = instance;

            Maybe<MyClass> maybe2 = maybe.Where(x => x.Property == "Different value");

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public void Where_returns_no_value_if_initial_maybe_is_null()
        {
            Maybe<MyClass> maybe = null;

            Maybe<MyClass> maybe2 = maybe.Where(x => x.Property == "Some value");

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public void Select_returns_new_maybe()
        {
            Maybe<MyClass> maybe = new MyClass { Property = "Some value" };

            Maybe<string> maybe2 = maybe.Select(x => x.Property);

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be("Some value");
        }

        [Fact]
        public void Select_returns_no_value_if_no_value_passed_in()
        {
            Maybe<MyClass> maybe = null;

            Maybe<string> maybe2 = maybe.Select(x => x.Property);

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public void SelectMany_returns_no_value_if_maybe_has_no_value()
        {
	        Maybe<int> maybe1 = 1;
	        var maybe2 = Maybe<int>.None;

	        var maybe3 = from a in maybe1 from b in maybe2 select a + b;

	        maybe3.HasValue.Should().BeFalse();
        }

        [Fact]
        public void SelectMany_returns_projection_if_maybes_has_values()
        {
	        Maybe<int> maybe1 = 1;
	        Maybe<int> maybe2 = 2;

	        var maybe3 = from a in maybe1 from b in maybe2 select a + b;

	        maybe3.HasValue.Should().BeTrue();
	        maybe3.Value.Should().Be(3);
        }

		[Fact]
        public void Bind_returns_new_maybe()
        {
            Maybe<MyClass> maybe = new MyClass { Property = "Some value" };

            Maybe<string> maybe2 = maybe.SelectMany(x => GetPropertyIfExists(x));

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be("Some value");
        }

        [Fact]
        public void Bind_returns_no_value_if_internal_method_returns_no_value()
        {
            Maybe<MyClass> maybe = new MyClass { Property = null };

            Maybe<string> maybe2 = maybe.SelectMany(x => GetPropertyIfExists(x));

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public void Execute_executes_action()
        {
            string property = null;
            Maybe<MyClass> maybe = new MyClass { Property = "Some value" };

            maybe.Execute(x => property = x.Property);

            property.Should().Be("Some value");
        }

        [Fact]
        public void Unwrap_supports_NET_value_types()
        {
            Maybe<MyClass> maybe = new MyClass { IntProperty = 42 };

            int integer = maybe.Select(x => x.IntProperty).Unwrap();

            integer.Should().Be(42);
        }

        [Fact]
        public void Unwrap_returns_default_for_NET_value_types()
        {
            Maybe<MyClass> maybe = null;

            int integer = maybe.Select(x => x.IntProperty).Unwrap();

            integer.Should().Be(0);
        }

        [Fact]
        public void Match_follows_some_branch_where_there_is_a_value()
        {
            Maybe<MyClass> maybe = new MyClass { IntProperty = 42 };

            maybe.Match(
                Some: (value) => value.IntProperty.Should().Be(42),
                None: () => throw new FieldAccessException("Accessed None path while maybe has value")
            );
        }

        [Fact]
        public void Match_follows_none_branch_where_is_no_value()
        {
            Maybe<MyClass> maybe = null;

            maybe.Match(
                Some: (value) => throw new FieldAccessException("Accessed Some path while maybe has no value"),
                None: () => Assert.True(true)
            );
        }

        [Fact]
        public void Choose_double_values()
        {
            var source = new [] 
            { 
                Maybe<int>.None, 
                1,
                Maybe<int>.None, 
                2, 
                3 
            };

            var doubled = source.Choose(x => x * 2);

            var expected = new [] { 2, 4, 6 };
            doubled.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void TryFirst_source_has_elements()
        {
            var source = new[]
            {
                new { Index = 1, Value = 1 },
                new { Index = 2, Value = 2 },
                new { Index = 3, Value = 3 }
            };

            var maybe = source.TryFirst();

            maybe.HasValue.Should().BeTrue();
            maybe.Value.Should().Be(source[0]);
        }

        [Fact]
        public void TryFirst_source_has_no_elements()
        {
            var source = new int[0];

            var maybe = source.TryFirst();

            maybe.HasValue.Should().BeFalse();
        }

        [Fact]
        public void TryFirst_source_predicate_contains()
        {
            var source = new[]
            {
                new { Index = 1, Value = 1 },
                new { Index = 2, Value = 2 },
                new { Index = 3, Value = 2 }
            };

            var maybe = source.TryFirst(x => x.Value == 2);

            maybe.HasValue.Should().BeTrue();
            maybe.Value.Should().Be(source[1]);
        }

        [Fact]
        public void TryFirst_source_predicate_not_contains()
        {
            var source = new[]
            {
                new { Index = 1, Value = 1 },
                new { Index = 2, Value = 2 },
                new { Index = 3, Value = 3 }
            };

            var maybe = source.TryFirst(x => x.Value == 5);

            maybe.HasValue.Should().BeFalse();
        }

        [Fact]
        public void TryLast_source_has_elements()
        {
            var source = new[]
            {
                new { Index = 1, Value = 1 },
                new { Index = 2, Value = 2 },
                new { Index = 3, Value = 3 }
            };

            var maybe = source.TryLast();

            maybe.HasValue.Should().BeTrue();
            maybe.Value.Should().Be(source[2]);
        }

        [Fact]
        public void TryLast_source_has_no_elements()
        {
            var source = new int[0];

            var maybe = source.TryLast();

            maybe.HasValue.Should().Be(false);
        }

        [Fact]
        public void TryLast_source_predicate_contains()
        {
            var source = new[]
            {
                new { Index = 1, Value = 2 },
                new { Index = 2, Value = 2 },
                new { Index = 3, Value = 3 }
            };

            var maybe = source.TryLast(x => x.Value == 2);

            maybe.HasValue.Should().BeTrue();
            maybe.Value.Should().Be(source[1]);
        }

        [Fact]
        public void TryLast_source_predicate_not_contains()
        {
            var source = new[]
            {
                new { Index = 1, Value = 1 },
                new { Index = 2, Value = 2 },
                new { Index = 3, Value = 3 }
            };

            var maybe = source.TryLast(x => x.Value == 5);

            maybe.HasValue.Should().BeFalse();
        }

        [Fact]
        public void TryFind_dict_contains_key() 
        {
            var dict = new Dictionary<string, string> 
            { 
                { "key", "value" } 
            };

            var maybe = dict.TryFind("key");

            maybe.HasValue.Should().BeTrue();
            maybe.Value.Should().Be("value");
        }

        [Fact]
        public void TryFind_dict_does_not_contains_key() 
        {
            var dict = new Dictionary<string, string>();

            var maybe = dict.TryFind("key");

            maybe.HasValue.Should().BeFalse();
        }

        private static Maybe<string> GetPropertyIfExists(MyClass myClass)
        {
            return myClass.Property;
        }


        private class MyClass
        {
            public string Property { get; set; }
            public int IntProperty { get; set; }
        }

        private class MyErrorClass
        {
        }
    }
}
