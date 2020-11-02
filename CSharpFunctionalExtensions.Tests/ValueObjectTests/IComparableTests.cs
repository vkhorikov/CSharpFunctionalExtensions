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
        public void Sorting_value_objects_returns_same_collection_if_one_of_properties_doesnt_implement_IComparable()
        {
            var vo1 = new VOWithObjectProperty(new object());
            var vo2 = new VOWithObjectProperty(new object());

            VOWithObjectProperty[] array = new[] { vo1, vo2 }
                .OrderBy(x => x)
                .ToArray();

            array[0].Should().Be(vo1);
            array[1].Should().Be(vo2);
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
