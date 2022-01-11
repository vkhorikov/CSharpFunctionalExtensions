#nullable enable
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpFunctionalExtensions
{
    public class ResultDtoJsonConverter : JsonConverter<Result>
    {
        public override Result Read(ref Utf8JsonReader reader,
                                      Type typeToConvert,
                                      JsonSerializerOptions options)
        => ToResult(JsonSerializer.Deserialize<ResultDto>(ref reader, options));

        public override void Write(Utf8JsonWriter writer,
                                   Result value,
                                   JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, ToApiResult(value), options);

        private static Result ToResult(ResultDto? apiResult)
        => apiResult is not null
            ? apiResult.IsSuccess ? Result.Success() : Result.Failure(apiResult.ErrorMessage)
            : Result.Failure("ResultDto is null");

        private static ResultDto ToApiResult(Result result)
        => result.IsSuccess ? ResultDto.Success() : ResultDto.Failure(result.Error);
    }
}
