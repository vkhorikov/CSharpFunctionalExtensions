#nullable enable
using System.Text.Json.Serialization;

namespace CSharpFunctionalExtensions.Json.Serialization
{
    internal partial record ResultDto
    {
        public static ResultDto Success() => new(true, (string)null);
        public static ResultDto Failure(string error) => new(false, error);

        public static ResultDto<TValue> Success<TValue>(TValue value) => new(true, value, null);
        public static ResultDto<TValue> Failure<TValue>(string error) => new(false, default!, error);

        public static ResultDto<TValue, TError> Success<TValue, TError>(TValue value) => new(true, value, default!);
        public static ResultDto<TValue, TError> Failure<TValue, TError>(TError error) => new(false, default!, error);
    }

    internal partial record ResultDto(bool IsSuccess, string? Error);

    internal record ResultDto<TValue>(bool IsSuccess, TValue Value, string? Error)
        : ResultDto<TValue, string>(IsSuccess, Value, Error);

    internal record ResultDto<TValue, TError>(bool IsSuccess, TValue Value, TError? Error);
}
