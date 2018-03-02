using System.Runtime.Serialization;
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
    }

    public struct SerializationTestObject
    {
        public string String { get; set; }
        public int Number { get; set; }
    }
}