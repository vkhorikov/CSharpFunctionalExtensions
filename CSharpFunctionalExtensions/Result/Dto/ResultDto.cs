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

        public static ResultDto<TResult> Success<TResult>(TResult result) => new(result, null);
        public static ResultDto<TResult> Failure<TResult>(string errorMessage) => new(default!, errorMessage);
    }

    internal record ResultDto<TResult>(TResult Result, string? ErrorMessage)
    {
        [JsonIgnore]
        public bool IsSuccess => ErrorMessage is null;
    }
}
