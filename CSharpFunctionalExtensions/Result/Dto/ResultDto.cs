#nullable enable
using System.Text.Json.Serialization;

namespace CSharpFunctionalExtensions
{
    internal record ResultDto
    {
        public ResultDto() { }
        public ResultDto(string error) => (Error) = (error);

        public string? Error { get; init; }
        public bool IsSuccess => Error is null;

        public static ResultDto Success() => new();
        public static ResultDto Failure(string errorMessage) => new(errorMessage);

        public static ResultDto<TValue> Success<TValue>(TValue result) => new(result, null);
        public static ResultDto<TValue> Failure<TValue>(string errorMessage) => new(default!, errorMessage);
    }

    internal record ResultDto<TValue>(TValue Result, string? ErrorMessage)
    {
        [JsonIgnore]
        public bool IsSuccess => ErrorMessage is null;
    }
}
