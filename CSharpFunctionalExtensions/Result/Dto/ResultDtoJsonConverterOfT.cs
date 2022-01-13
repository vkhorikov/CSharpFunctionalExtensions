#nullable enable
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpFunctionalExtensions
{
    public class ResultDtoJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsGenericType) return false;

            return typeToConvert.GetGenericTypeDefinition() == typeof(Result<>);
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type wrappedType = typeToConvert.GetGenericArguments()[0];

            var genericResultType = typeof(ResultDtoJsonConverterOfT<>).MakeGenericType(wrappedType);
            JsonConverter? converter = Activator.CreateInstance(genericResultType) as JsonConverter;

            return converter!;
        }
    }

    public class ResultDtoJsonConverterOfT<T> : JsonConverter<Result<T>>
    {
        public override Result<T> Read(ref Utf8JsonReader reader,
                                      Type typeToConvert,
                                      JsonSerializerOptions options)
        => ToResult(JsonSerializer.Deserialize<ResultDto<T>>(ref reader, options));

        public override void Write(Utf8JsonWriter writer,
                                   Result<T> value,
                                   JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, ToResultDto(value), options);

        private static Result<T> ToResult(ResultDto<T>? resultDto)
        {
            if (resultDto is not null)
            {
                if (resultDto.IsSuccess)
                {
                    return Result.Success<T>(resultDto.Result!);
                }

                if (resultDto.ErrorMessage is not null)
                {
                    return Result.Failure<T>(resultDto.ErrorMessage);
                }

                return Result.Failure<T>("ResultDto was not successful and ErrorMessage is null");
            }

            return Result.Failure<T>("ResultDto is null");
        }

        private static ResultDto<T> ToResultDto(Result<T> result)
        => result.IsSuccess
           ? ResultDto.Success<T>(result.Value)
           : ResultDto.Failure<T>(result.Error);
    }
}
