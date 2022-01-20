#nullable enable
using System.Text.Json.Serialization;

namespace CSharpFunctionalExtensions
{
    internal record ResultDto(string? Error)
    {
        [JsonIgnore]
        public bool IsSuccess => Error is null;

        public static ResultDto Success() => new((string)null);
        public static ResultDto Failure(string error) => new(error);

        public static ResultDto<TValue> Success<TValue>(TValue value) => new(value, null);
        public static ResultDto<TValue> Failure<TValue>(string error) => new(default!, error);
    }

    internal record ResultDto<TValue>(TValue Value, string? Error)
    {
        [JsonIgnore]
        public bool IsSuccess => Error is null;
    }
}
