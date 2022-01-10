#nullable enable
using System.Text.Json.Serialization;

namespace CSharpFunctionalExtensions
{
    public record ResultDto
    {
        public ResultDto() { }
        public ResultDto(string errorMessage) => (ErrorMessage) = (errorMessage);

        public string? ErrorMessage { get; init; }
        public bool IsSuccess => ErrorMessage is null;

        public static ResultDto Success() => new();
        public static ResultDto Failure(string errorMessage) => new(errorMessage);

        public static ResultDto<TResult> Success<TResult>(TResult result) => new(result, null);
        public static ResultDto<TResult> Failure<TResult>(string errorMessage) => new(default!, errorMessage);
    }

    public record ResultDto<TResult>(TResult Result, string? ErrorMessage)
    {
        [JsonIgnore]
        public bool IsSuccess => ErrorMessage is null;
    }
}
