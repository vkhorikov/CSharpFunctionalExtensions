using CSharpFunctionalExtensions.Json.Serialization;

using FluentAssertions;

using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Json.Serialization
{
    public class HttpResponseMessageJsonExtensionsTests
    {
        [Fact]
        public async Task ReadResultAsync_NullHttpResponseMessage_Failure()
        {
            // Assign
            HttpResponseMessage httpResponseMessage = null;

            // Act
            var result = await httpResponseMessage.ReadResultAsync();

            // Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public async Task ReadResultAsyncOfT_NullHttpResponseMessage_Failure()
        {
            // Assign
            HttpResponseMessage httpResponseMessage = null;

            // Act
            var result = await httpResponseMessage.ReadResultAsync<int>();

            // Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public async Task ReadUnitResultAsyncOfT_NullHttpResponseMessage_Failure()
        {
            // Assign
            HttpResponseMessage httpResponseMessage = null;

            // Act
            var result = await httpResponseMessage.ReadUnitResultAsync<int>();

            // Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public async Task ReadResultAsync_NullHttpResponseMessageContent_Failure()
        {
            // Assign
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);

            // Act
            var result = await httpResponseMessage.ReadResultAsync();

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(DtoMessages.ContentJsonNotResult);
        }

        [Fact]
        public async Task ReadResultAsyncOfT_NullHttpResponseMessageContent_Failure()
        {
            // Assign
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);

            // Act
            var result = await httpResponseMessage.ReadResultAsync<int>();

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(DtoMessages.ContentJsonNotResult);
        }

        [Fact]
        public async Task ReadUnitResultAsyncOfT_NullHttpResponseMessageContent_Failure()
        {
            // Assign
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);

            // Act
            var result = await httpResponseMessage.ReadUnitResultAsync<UnitResultError>();

            // Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public async Task ReadResultAsync_EmptyResponseMessageContent_Failure()
        {
            // Assign
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = new StringContent(string.Empty);

            // Act
            var result = await httpResponseMessage.ReadResultAsync();

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(DtoMessages.ContentJsonNotResult);
        }

        [Fact]
        public async Task ReadResultAsyncOfT_EmptyResponseMessageContent_Failure()
        {
            // Assign
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = new StringContent(string.Empty);

            // Act
            var result = await httpResponseMessage.ReadResultAsync<int>();

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(DtoMessages.ContentJsonNotResult);
        }

        [Fact]
        public async Task ReadUnitResultAsyncOfT_EmptyResponseMessageContent_Failure()
        {
            // Assign
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = new StringContent(string.Empty);

            // Act
            var result = await httpResponseMessage.ReadUnitResultAsync<UnitResultError>();

            // Assert
            result.IsSuccess.Should().BeFalse();
        }

        [Fact]
        public async Task ReadResultAsync_JsonNull_Failure()
        {
            // Assign
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = JsonContent.Create<string>(null);


            // Act
            var result = await httpResponseMessage.ReadResultAsync();

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(DtoMessages.ContentJsonNotResult);
        }

        [Fact]
        public async Task ReadResultAsyncOfT_JsonNull_Failure()
        {
            // Assign
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = JsonContent.Create<string>(null);


            // Act
            var result = await httpResponseMessage.ReadResultAsync<string>();

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(DtoMessages.ContentJsonNotResult);
        }

        [Fact]
        public async Task ReadUnitResultAsyncOfT_JsonNull_Failure()
        {
            // Assign
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = JsonContent.Create<UnitResultError>(null);


            // Act
            var result = await httpResponseMessage.ReadResultAsync<UnitResultError>();

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(DtoMessages.ContentJsonNotResult);
        }

        [Fact]
        public async Task ReadResultAsync_JsonInt_Failure()
        {
            // Assign
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = JsonContent.Create(8);

            // Act
            var result = await httpResponseMessage.ReadResultAsync();

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(DtoMessages.ContentJsonNotResult);
        }

        [Fact]
        public async Task ReadResultAsyncOfT_JsonInt_Failure()
        {
            // Assign
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = JsonContent.Create(8);

            // Act
            var result = await httpResponseMessage.ReadResultAsync<string>();

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(DtoMessages.ContentJsonNotResult);
        }

        [Fact(Skip = "Fails when building on Linux")]
        public async Task ReadResultAsync_JsonObject_Failure()
        {
            // Assign
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = JsonContent.Create(new object());

            // Act
            var result = await httpResponseMessage.ReadResultAsync();

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(DtoMessages.ContentJsonNotResult);
        }

        [Fact(Skip = "Fails when building on Linux")]
        public async Task ReadResultAsyncOfT_JsonObject_Failure()
        {
            // Assign
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = JsonContent.Create(new object());

            // Act
            var result = await httpResponseMessage.ReadResultAsync<string>();

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(DtoMessages.ContentJsonNotResult);
        }

        [Fact]
        public async Task ReadResultAsync_JsonResultDtoOfSuccess_Success()
        {
            // Assign
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = JsonContent.Create(ResultDto.Success());

            // Act
            var result = await httpResponseMessage.ReadResultAsync();

            // Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task ReadResultAsyncOfT_JsonResultDtoOfSuccess_Success()
        {
            // Assign
            const string value = "Great Success";
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = JsonContent.Create(ResultDto.Success(value));

            // Act
            var result = await httpResponseMessage.ReadResultAsync<string>();

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(value);
        }

        [Fact]
        public async Task ReadUnitResultAsyncOfT_JsonResultDtoOfSuccess_Success()
        {
            // Assign
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = JsonContent.Create(UnitResultDto.Success<UnitResultError>());

            // Act
            var result = await httpResponseMessage.ReadUnitResultAsync<UnitResultError>();

            // Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task ReadResultAsync_JsonResultDtoOfFailure_Failure()
        {
            // Assign
            const string error = "Failure";
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = JsonContent.Create(ResultDto.Failure(error));

            // Act
            var result = await httpResponseMessage.ReadResultAsync();
            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(error);
        }

        [Fact]
        public async Task ReadResultAsyncOfT_JsonResultDtoOfFailure_Failure()
        {
            // Assign
            const string error = "Failure";
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = JsonContent.Create(ResultDto.Failure<string>(error));

            // Act
            var result = await httpResponseMessage.ReadResultAsync<string>();

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be(error);
        }

        [Fact]
        public async Task ReadUnitResultAsyncOfT_JsonResultDtoOfFailure_Failure()
        {
            // Assign
            var error = new UnitResultError() { ErrorMessage = "Failure" };
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = JsonContent.Create(UnitResultDto.Failure(error));

            // Act
            var result = await httpResponseMessage.ReadUnitResultAsync<UnitResultError>();

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().BeEquivalentTo(error);
        }

        [Fact]
        public async Task ReadResultAsync_StringResultDtoOfSuccess_Success()
        {
            // Assign
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = new StringContent("{ \"Error\": null }");

            // Act
            var result = await httpResponseMessage.ReadResultAsync();

            // Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task ReadResultAsyncOfT_StringResultDtoOfSuccess_Success()
        {
            // Assign
            const string value = "Great Success";
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = new StringContent($"{{ \"Error\": null, \"Value\": \"{value}\"}}");

            // Act
            var result = await httpResponseMessage.ReadResultAsync<string>();

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(value);
        }

        [Fact]
        public async Task ReadUnitResultAsyncOfT_UnitResultErrorResultDtoOfSuccess_Success()
        {
            // Assign
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = new StringContent($"{{ \"Error\": null }}");

            // Act
            var result = await httpResponseMessage.ReadUnitResultAsync<UnitResultError>();

            // Assert
            result.IsSuccess.Should().BeTrue();
        }

        private class UnitResultError
        {
            public UnitResultError() { }

            public string ErrorMessage { get; set; }
        }

    }
}
