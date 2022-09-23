using CSharpFunctionalExtensions.Json.Serialization;

using FluentAssertions;

using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

using SerializerOptions = CSharpFunctionalExtensions.Json.Serialization.CSharpFunctionalExtensionsJsonSerializerOptions;

using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Json.Serialization
{
    public class SerializationTests
    {
        [Fact]
        public void Result_Success()
        {
            // Assign
            var originalResult = Result.Success();

            // Act
            var result = SerializeAndDesrialize(originalResult);

            // Assert
            result.IsSuccess.Should().Be(originalResult.IsSuccess);
        }

        [Fact]
        public void Result_Failure()
        {
            // Assign
            var originalResult = Result.Failure("Error");

            // Act
            var result = SerializeAndDesrialize(originalResult);

            // Assert
            result.IsSuccess.Should().Be(originalResult.IsSuccess);
            result.Error.Should().Be(originalResult.Error);
        }

        [Fact]
        public void ResultOfT_Success()
        {
            // Assign
            var originalResult = Result.Success(8);

            // Act
            var result = SerializeAndDesrialize(originalResult);

            // Assert
            result.IsSuccess.Should().Be(originalResult.IsSuccess);
            result.Value.Should().Be(originalResult.Value);
        }

        [Fact]
        public void ResultOfT_Failure()
        {
            // Assign
            var originalResult = Result.Failure<int>("Error");

            // Act
            var result = SerializeAndDesrialize(originalResult);

            // Assert
            result.IsSuccess.Should().Be(originalResult.IsSuccess);
            result.Error.Should().Be(originalResult.Error);
        }

        [Fact]
        public void ResultOfTE_Success()
        {
            // Assign
            var originalResult = Result.Success<int, bool>(8);

            // Act
            var result = SerializeAndDesrialize(originalResult);

            // Assert
            result.IsSuccess.Should().Be(originalResult.IsSuccess);
            result.Value.Should().Be(originalResult.Value);
        }

        [Fact]
        public void ResultOfTE_Failure()
        {
            // Assign
            var originalResult = Result.Failure<int, bool>(true);

            // Act
            var result = SerializeAndDesrialize(originalResult);

            // Assert
            result.IsSuccess.Should().Be(originalResult.IsSuccess);
            result.Error.Should().Be(originalResult.Error);
        }

        [Fact]
        public void UnitResultOfE_Success()
        {
            // Assign
            var originalResult = UnitResult.Success<bool>();

            // Act
            var result = SerializeAndDesrialize(originalResult);

            // Assert
            result.IsSuccess.Should().Be(originalResult.IsSuccess);
        }

        [Fact]
        public void UnitResultOfE_Failure()
        {
            // Assign
            var originalResult = UnitResult.Failure<bool>(true);

            // Act
            var result = SerializeAndDesrialize(originalResult);

            // Assert
            result.IsSuccess.Should().Be(originalResult.IsSuccess);
            result.Error.Should().Be(originalResult.Error);
        }

        private TResult SerializeAndDesrialize<TResult>(TResult result)
        {
            return JsonSerializer.Deserialize<TResult>(
                            JsonSerializer.SerializeToElement(result, SerializerOptions.Options),
                            SerializerOptions.Options);
        }
    }
}
