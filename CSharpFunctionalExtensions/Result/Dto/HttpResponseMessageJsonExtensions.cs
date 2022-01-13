#nullable enable
using System.Text.Json;
using System.Threading.Tasks;

using CSharpFunctionalExtensions;

namespace System.Net.Http.Json
{
    public static class HttpResponseMessageJsonExtensions
    {
        public static async Task<Result> ReadResult(this HttpResponseMessage? response)
        {
            if (response is null)
            {
                return Result.Failure("HttpResponseMessage is null");
            }

            var responseContent = await response.Content.ReadAsStringAsync().DefaultAwait();

            if (!response.IsSuccessStatusCode)
            {
                return Result.Failure(responseContent);
            }

            return JsonSerializer.Deserialize<Result>(responseContent, CSharpFunctionalExtensionsJsonSerializerOptions.Options);
        }

        public static async Task<Result<T>> ReadResult<T>(this HttpResponseMessage? response)
        {
            if (response is null) return Result.Failure<T>("HttpResponseMessage is null");

            var responseContent = await response.Content.ReadAsStringAsync().DefaultAwait();

            if (!response.IsSuccessStatusCode) return Result.Failure<T>(responseContent);

            return JsonSerializer.Deserialize<Result<T>>(responseContent, CSharpFunctionalExtensionsJsonSerializerOptions.Options);
        }
    }
}
