#nullable enable
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpFunctionalExtensions.Json.Serialization
{
    internal class UnitResultJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsGenericType) return false;

            return typeToConvert.GetGenericTypeDefinition() == typeof(UnitResult<>);
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type wrappedType = typeToConvert.GetGenericArguments()[0];

            var genericResultType = typeof(UnitResultJsonConverterOfT<>).MakeGenericType(wrappedType);
            JsonConverter? converter = Activator.CreateInstance(genericResultType) as JsonConverter;

            return converter!;
        }
    }

    internal class UnitResultJsonConverterOfT<E> : JsonConverter<UnitResult<E>>
    {
        public override UnitResult<E> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                return ToUnitResult(JsonSerializer.Deserialize<UnitResultDto<E>>(ref reader, options));
            }
            catch (JsonException)
            {
                return UnitResult.Failure<E>(default!);
            }
        }

        public override void Write(Utf8JsonWriter writer, UnitResult<E> value, JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, ToUnitResultDto(value), options);

        private static UnitResult<E> ToUnitResult(UnitResultDto<E>? resultDto)
        {
            if (resultDto is not null)
            {
                if (resultDto.IsSuccess)
                {
                    return UnitResult.Success<E>();
                }

                if (resultDto.Error is not null)
                {
                    return UnitResult.Failure<E>(resultDto.Error);
                }
            }

            return UnitResult.Failure<E>(default!);
        }

        private static UnitResultDto<E> ToUnitResultDto(UnitResult<E> unitResult)
        => unitResult.IsSuccess
           ? UnitResultDto.Success<E>()
           : UnitResultDto.Failure(unitResult.Error);
    }
}
