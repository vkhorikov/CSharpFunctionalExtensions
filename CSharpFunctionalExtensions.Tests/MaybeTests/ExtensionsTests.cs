using FluentAssertions;
using Xunit;


namespace CSharpFunctionalExtensions.Tests.MaybeTests
{
    public class ExtensionsTests
    {
        [Fact]
        public void Unwrap_extracts_value_if_not_null()
        {
            var isntance = new MyClass();
            Maybe<MyClass> maybe = isntance;

            MyClass myClass = maybe.Unwrap();

            myClass.Should().Be(isntance);
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
        public void Bind_returns_new_maybe()
        {
            Maybe<MyClass> maybe = new MyClass { Property = "Some value" };

            Maybe<string> maybe2 = maybe.Select(x => GetPropertyIfExists(x));

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be("Some value");
        }

        [Fact]
        public void Bind_returns_no_value_if_internal_method_returns_no_value()
        {
            Maybe<MyClass> maybe = new MyClass { Property = null };

            Maybe<string> maybe2 = maybe.Select(x => GetPropertyIfExists(x));

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


        private static Maybe<string> GetPropertyIfExists(MyClass myClass)
        {
            return myClass.Property;
        }


        private class MyClass
        {
            public string Property { get; set; }
        }
    }
}
