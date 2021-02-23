using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ValueObjectTests
{
    public class IComparableTests
    {
        [Fact]
        public void Can_sort_simple_value_objects()
        {
            var name3 = new NameSuffix(3);
            var name1 = new NameSuffix(1);
            var name4 = new NameSuffix(4);
            var name2 = new NameSuffix(2);

            NameSuffix[] nameSuffixes = new [] { name3, name1, name4, name2 }
                .OrderBy(x => x)
                .ToArray();

            nameSuffixes[0].Should().BeSameAs(name1);
            nameSuffixes[1].Should().BeSameAs(name2);
            nameSuffixes[2].Should().BeSameAs(name3);
            nameSuffixes[3].Should().BeSameAs(name4);
        }

        [Fact]
        public void Can_sort_complex_value_objects()
        {
            var name112 = new Name("111", "111", new NameSuffix(2));
            var name111 = new Name("111", "111", new NameSuffix(1));
            var name221 = new Name("222", "222", new NameSuffix(1));
            var name222 = new Name("222", "222", new NameSuffix(2));
            var name121 = new Name("111", "222", new NameSuffix(1));
            var name122 = new Name("111", "222", new NameSuffix(2));
            var name212 = new Name("222", "111", new NameSuffix(2));
            var name211 = new Name("222", "111", new NameSuffix(1));

            Name[] names = new[] { name112, name111, name221, name222, name121, name122, name212, name211 }
                .OrderBy(x => x)
                .ToArray();

            names[0].Should().BeSameAs(name111);
            names[1].Should().BeSameAs(name112);
            names[2].Should().BeSameAs(name121);
            names[3].Should().BeSameAs(name122);
            names[4].Should().BeSameAs(name211);
            names[5].Should().BeSameAs(name212);
            names[6].Should().BeSameAs(name221);
            names[7].Should().BeSameAs(name222);
        }

        [Fact]
        public void Can_sort_value_objects_containing_nulls()
        {
            var name2 = new Name("1", "1", new NameSuffix(1));
            var name1 = new Name("1", null, new NameSuffix(1));

            Name[] names = new[] { name1, name2, null }
                .OrderBy(x => x)
                .ToArray();

            names[0].Should().BeNull();
            names[1].Should().BeSameAs(name1);
            names[2].Should().BeSameAs(name2);
        }

        [Fact]
        public void Two_value_objects_are_not_equal_if_they_contain_non_comparable_components_of_different_values()
        {
            var vo1 = new VOWithObjectProperty(new object());
            var vo2 = new VOWithObjectProperty(new object());

            int result1 = vo1.CompareTo(vo2);
            int result2 = vo2.CompareTo(vo1);

            result1.Should().NotBe(0);
            result2.Should().NotBe(0);
        }

        [Fact]
        public void Can_compare_value_objects_with_collections()
        {
            var vo1 = new VOWithCollection("one", "two");
            var vo2 = new VOWithCollection("one", "three");

            int result1 = vo1.CompareTo(vo2);
            int result2 = vo2.CompareTo(vo1);

            result1.Should().NotBe(0);
            result2.Should().NotBe(0);
        }

        [Fact]
        public void Can_compare_value_objects_with_collections_of_variable_size()
        {
            var vo1 = new VOWithCollection("one", "two");
            var vo2 = new VOWithCollection("one", "two", "three");

            int result1 = vo1.CompareTo(vo2);
            int result2 = vo2.CompareTo(vo1);

            result1.Should().NotBe(0);
            result2.Should().NotBe(0);
        }

        private class VOWithCollection : ValueObject
        {
            readonly string[] _components;

            public VOWithCollection(params string[] components)
            {
                _components = components;
            }

            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return _components.Length;
                foreach (string component in _components)
                {
                    yield return component;
                }
            }
        }

        private class VOWithObjectProperty : ValueObject
        {
            public object SomeProperty { get; }

            public VOWithObjectProperty(object someProperty)
            {
                SomeProperty = someProperty;
            }

            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return SomeProperty;
            }
        }

        private class Name : ValueObject
        {
            public string First { get; }
            public string Last { get; }
            public NameSuffix Suffix { get; }

            public Name(string first, string last, NameSuffix suffix)
            {
                First = first;
                Last = last;
                Suffix = suffix;
            }

            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return First;
                yield return Last;
                yield return Suffix;
            }
        }


        private class NameSuffix : SimpleValueObject<int>
        {
            public NameSuffix(int value)
                : base(value)
            {
            }
        }
    }
}
