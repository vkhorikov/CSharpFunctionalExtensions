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
        => JsonSerializer.Serialize(writer, ToResultDto(value), options);

        private static Result ToResult(ResultDto? resultDto)
        => resultDto is not null
            ? resultDto.IsSuccess ? Result.Success() : Result.Failure(resultDto.Error)
            : Result.Failure("ResultDto is null");

        private static ResultDto ToResultDto(Result result)
        => result.IsSuccess ? ResultDto.Success() : ResultDto.Failure(result.Error);
    }
}
