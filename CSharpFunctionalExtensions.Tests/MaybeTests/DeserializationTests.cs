using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests
{
    public class DeserializationTests
    {
        [Fact]
        public void Deserialize_sets_no_value_on_maybe_none()
        {
            Maybe<MyClass> maybe = Maybe<MyClass>.None;
            var serialized = Serialize(maybe);

            Maybe<MyClass> deserialized = Deserialize<Maybe<MyClass>>(serialized);

            deserialized.HasValue.Should().BeFalse();
            deserialized.HasNoValue.Should().BeTrue();
        }

        [Fact]
        public void Deserialize_sets_correct_value_on_maybe()
        {
            var instance = new MyClass();

            Maybe<MyClass> maybe = instance;
            var serialized = Serialize(maybe);

            Maybe<MyClass> deserialized = Deserialize<Maybe<MyClass>>(serialized);

            deserialized.HasValue.Should().BeTrue();
            deserialized.HasNoValue.Should().BeFalse();
            deserialized.Value.ShouldBeEquivalentTo(instance);
        }

        private static Stream Serialize(object source)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            formatter.Serialize(stream, source);
            return stream;
        }

        private static T Deserialize<T>(Stream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            stream.Position = 0;
            return (T)formatter.Deserialize(stream);
        }

        [Serializable]
        public class MyClass
        {
            public string String { get; set; }
            public int Number { get; set; }
        }
    }
}