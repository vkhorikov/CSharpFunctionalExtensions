#nullable enable
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpFunctionalExtensions.Json.Serialization
{
    internal class ResultJsonConverter : JsonConverter<Result>
    {
        public override Result Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                return ToResult(JsonSerializer.Deserialize<ResultDto>(ref reader, options));
            }
            catch (JsonException)
            {
                return Result.Failure(DtoMessages.ContentJsonNotResult);
            }
        }

        public override void Write(Utf8JsonWriter writer, Result value, JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, ToResultDto(value), options);

        private static Result ToResult(ResultDto? resultDto)
        => resultDto is not null
            ? resultDto.IsSuccess ? Result.Success() : Result.Failure(resultDto.Error)
            : Result.Failure(DtoMessages.ContentJsonNotResult);

        private static ResultDto ToResultDto(Result result)
        => result.IsSuccess ? ResultDto.Success() : ResultDto.Failure(result.Error);
    }
}
