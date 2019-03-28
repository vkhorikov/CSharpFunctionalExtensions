using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class SerializationTests
    {
        private static readonly string _errorMessage = "this failed";

        [Fact]
        public void GetObjectData_sets_correct_statuses_on_success_result()
        {
            Result okResult = Result.Ok();
            ISerializable serializableObject = okResult;

            var serializationInfo = new SerializationInfo(typeof(Result), new FormatterConverter());
            serializableObject.GetObjectData(serializationInfo, new StreamingContext());

            serializationInfo.GetBoolean(nameof(Result.IsSuccess)).Should().BeTrue();
            serializationInfo.GetBoolean(nameof(Result.IsFailure)).Should().BeFalse();
        }

        [Fact]
        public void GetObjectData_sets_correct_statuses_on_failure_result()
        {
            Result okResult = Result.Fail(_errorMessage);
            ISerializable serializableObject = okResult;

            var serializationInfo = new SerializationInfo(typeof(Result), new FormatterConverter());
            serializableObject.GetObjectData(serializationInfo, new StreamingContext());

            serializationInfo.GetBoolean(nameof(Result.IsSuccess)).Should().BeFalse();
            serializationInfo.GetBoolean(nameof(Result.IsFailure)).Should().BeTrue();
        }

        [Fact]
        public void GetObjectData_adds_message_in_context_on_failure_result()
        {
            Result okResult = Result.Fail(_errorMessage);
            ISerializable serializableObject = okResult;

            var serializationInfo = new SerializationInfo(typeof(Result), new FormatterConverter());
            serializableObject.GetObjectData(serializationInfo, new StreamingContext());

            serializationInfo.GetString(nameof(Result.Error)).Should().Be(_errorMessage);
        }

        [Fact]
        public void GetObjectData_of_generic_result_adds_object_in_context_when_success_result()
        {
            SerializationTestObject language = new SerializationTestObject { Number = 232, String = "C#" };
            Result<SerializationTestObject> okResult = Result.Ok(language);
            ISerializable serializableObject = okResult;

            var serializationInfo = new SerializationInfo(typeof(Result), new FormatterConverter());
            serializableObject.GetObjectData(serializationInfo, new StreamingContext());

            serializationInfo.GetValue(nameof(Result<SerializationTestObject>.Value), typeof(SerializationTestObject))
                .Should().Be(language);
        }

        [Fact]
        public void GetObjectData_adds_error_object_in_serialization_context_when_failure_result()
        {
            SerializationTestObject errorObject = new SerializationTestObject { Number = 500, String = "Error message" };
            Result<object, SerializationTestObject> failResult = Result.Fail<object, SerializationTestObject>(errorObject);
            ISerializable serializableObject = failResult;

            var serializationInfo = new SerializationInfo(typeof(Result), new FormatterConverter());
            serializableObject.GetObjectData(serializationInfo, new StreamingContext());

            serializationInfo
                .GetValue(nameof(Result<object, SerializationTestObject>.Error), typeof(SerializationTestObject))
                .Should().Be(errorObject);
        }

        [Fact]
        public void Ok()
        {
            Result result = Result.Ok();
            var serialized = Serialize(result);

            Result deserialized = Deserialize<Result>(serialized);

            deserialized.IsSuccess.ShouldBeEquivalentTo(result.IsSuccess);
            deserialized.IsFailure.ShouldBeEquivalentTo(result.IsFailure);
        }

        [Fact]
        public void Fail()
        {
            Result result = Result.Fail("test error");
            var serialized = Serialize(result);

            Result deserialized = Deserialize<Result>(serialized);

            deserialized.IsSuccess.ShouldBeEquivalentTo(result.IsSuccess);
            deserialized.IsFailure.ShouldBeEquivalentTo(result.IsFailure);
            deserialized.Error.ShouldBeEquivalentTo(result.Error);
        }

        [Fact]
        public void Ok_GenericValue()
        {
            Result<string> result = Result.Ok("test value");
            var serialized = Serialize(result);

            Result<string> deserialized = Deserialize<Result<string>>(serialized);

            deserialized.IsSuccess.ShouldBeEquivalentTo(result.IsSuccess);
            deserialized.IsFailure.ShouldBeEquivalentTo(result.IsFailure);
            deserialized.Value.ShouldBeEquivalentTo(result.Value);
        }

        [Fact]
        public void Fail_GenericValue()
        {
            Result<string> result = Result.Fail<string>("test error");
            var serialized = Serialize(result);

            Result<string> deserialized = Deserialize<Result<string>>(serialized);

            deserialized.IsSuccess.ShouldBeEquivalentTo(result.IsSuccess);
            deserialized.IsFailure.ShouldBeEquivalentTo(result.IsFailure);
            deserialized.Error.ShouldBeEquivalentTo(result.Error);
        }

        [Fact]
        public void Ok_GenericValue_GenericError()
        {
            Result<int, string> result = Result.Ok<int, string>(123);
            var serialized = Serialize(result);

            Result<int, string> deserialized = Deserialize<Result<int, string>>(serialized);

            deserialized.IsSuccess.ShouldBeEquivalentTo(result.IsSuccess);
            deserialized.IsFailure.ShouldBeEquivalentTo(result.IsFailure);
            deserialized.Value.ShouldBeEquivalentTo(result.Value);
        }

        [Fact]
        public void Fail_GenericValue_GenericError()
        {
            Result<int, string> result = Result.Fail<int, string>("test error");
            var serialized = Serialize(result);

            Result<int, string> deserialized = Deserialize<Result<int, string>>(serialized);

            deserialized.IsSuccess.ShouldBeEquivalentTo(result.IsSuccess);
            deserialized.IsFailure.ShouldBeEquivalentTo(result.IsFailure);
            deserialized.Error.ShouldBeEquivalentTo(result.Error);
        }

        public static Stream Serialize(object source)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            formatter.Serialize(stream, source);
            return stream;
        }

        public static T Deserialize<T>(Stream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            stream.Position = 0;
            return (T)formatter.Deserialize(stream);
        }
    }

    public class SerializationTestObject
    {
        public string String { get; set; }
        public int Number { get; set; }
    }
}