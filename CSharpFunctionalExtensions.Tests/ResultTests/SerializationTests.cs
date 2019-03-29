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
        public void Create_sets_correct_statuses_on_success_result()
        {
            Result okResult = Result.Ok();
            ISerializable serializableObject = okResult;

            var serializationInfo = new SerializationInfo(typeof(Result), new FormatterConverter());
            serializableObject.GetObjectData(serializationInfo, new StreamingContext());

            Result result = new Result(serializationInfo, new StreamingContext());

            result.IsSuccess.Should().BeTrue();
            result.IsFailure.Should().BeFalse();
        }

        [Fact]
        public void Create_sets_correct_statuses_on_failure_result()
        {
            Result okResult = Result.Fail(_errorMessage);
            ISerializable serializableObject = okResult;

            var serializationInfo = new SerializationInfo(typeof(Result), new FormatterConverter());
            serializableObject.GetObjectData(serializationInfo, new StreamingContext());

            Result result = new Result(serializationInfo, new StreamingContext());

            result.IsSuccess.Should().BeFalse();
            result.IsFailure.Should().BeTrue();
        }

        [Fact]
        public void Create_adds_message_in_context_on_failure_result()
        {
            Result okResult = Result.Fail(_errorMessage);
            ISerializable serializableObject = okResult;

            var serializationInfo = new SerializationInfo(typeof(Result), new FormatterConverter());
            serializableObject.GetObjectData(serializationInfo, new StreamingContext());

            Result result = new Result(serializationInfo, new StreamingContext());

            result.Error.Should().Be(_errorMessage);
        }

        [Fact]
        public void Create_of_generic_result_adds_object_in_context_when_success_result()
        {
            SerializationTestObject language = new SerializationTestObject { Number = 232, String = "C#" };
            Result<SerializationTestObject> okResult = Result.Ok(language);
            ISerializable serializableObject = okResult;

            var serializationInfo = new SerializationInfo(typeof(Result), new FormatterConverter());
            serializableObject.GetObjectData(serializationInfo, new StreamingContext());

            Result<SerializationTestObject> result = new Result<SerializationTestObject>(serializationInfo, new StreamingContext());

            result.Value.Should().Be(language);
        }

        [Fact]
        public void Create_adds_error_object_in_serialization_context_when_failure_result()
        {
            SerializationTestObject errorObject = new SerializationTestObject { Number = 500, String = "Error message" };
            Result<object, SerializationTestObject> failResult = Result.Fail<object, SerializationTestObject>(errorObject);
            ISerializable serializableObject = failResult;

            var serializationInfo = new SerializationInfo(typeof(Result), new FormatterConverter());
            serializableObject.GetObjectData(serializationInfo, new StreamingContext());

            Result<object, SerializationTestObject> result = new Result<object, SerializationTestObject>(serializationInfo, new StreamingContext());

            result.Error.Should().Be(errorObject);
        }
    }

    public class SerializationTestObject
    {
        public string String { get; set; }
        public int Number { get; set; }
    }
}