using CSharpFunctionalExtensions;
using CSharpFunctionalExtensions.Json.Serialization;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace C2i.Common.C2iCSharpFunctionalExtensions.FunctionalApiResult
{
    internal class ResultOfTEJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsGenericType) return false;

            return typeToConvert.GetGenericTypeDefinition() == typeof(Result<,>);
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type wrappedValue = typeToConvert.GetGenericArguments()[0];
            Type wrappedError = typeToConvert.GetGenericArguments()[1];

            var genericResultType = typeof(ResultOfTEJsonConverterConverterOfT<,>).MakeGenericType(wrappedValue, wrappedError);
            JsonConverter? converter = Activator.CreateInstance(genericResultType) as JsonConverter;

            return converter!;
        }
    }

    internal class ResultOfTEJsonConverterConverterOfT<TValue, TError> : JsonConverter<Result<TValue, TError>>
    {
        public override Result<TValue, TError> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                return ToResultTE(JsonSerializer.Deserialize<ResultDto<TValue, TError>>(ref reader, options));
            }
            catch (JsonException)
            {
                return Result.Failure<TValue, TError>(default!);
            }
        }

        public override void Write(Utf8JsonWriter writer, Result<TValue, TError> value, JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, ToResultTEDto(value), options);

        private static Result<TValue, TError> ToResultTE(ResultDto<TValue, TError>? resultDto)
            => resultDto is not null
               ? resultDto.IsSuccess
                 ? Result.Success<TValue, TError>(resultDto.Value)
                 : Result.Failure<TValue, TError>(resultDto.Error)
               : Result.Failure<TValue, TError>(default!);

        private static ResultDto<TValue, TError> ToResultTEDto(Result<TValue, TError> result)
        => result.IsSuccess
           ? ResultDto.Success<TValue, TError>(result.Value)
           : ResultDto.Failure<TValue, TError>(result.Error);
    }
}
