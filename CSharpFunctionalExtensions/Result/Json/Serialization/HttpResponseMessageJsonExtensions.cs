#nullable enable
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Json.Serialization
{
    public static class HttpResponseMessageJsonExtensions
    {
        public static Task<Result> ReadResultAsync(this HttpResponseMessage response, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (response is null)
            {
                return Task.FromResult(Result.Failure(DtoMessages.HttpResponseMessageIsNull));
            }

            return 
            Result.Try(() => response.Content.ReadFromJsonAsync<Result>(CSharpFunctionalExtensionsJsonSerializerOptions.Options, cancellationToken), ex => DtoMessages.ContentJsonNotResult)
                  .Bind(result => result);
        }

        public static Task<Result<T>> ReadResultAsync<T>(this HttpResponseMessage response, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (response is null)
            {
                return Task.FromResult(Result.Failure<T>(DtoMessages.HttpResponseMessageIsNull));
            }

            return
            Result.Try(() => response.Content.ReadFromJsonAsync<Result<T>>(CSharpFunctionalExtensionsJsonSerializerOptions.Options, cancellationToken), ex => DtoMessages.ContentJsonNotResult)
                  .Bind(result => result);
        }
    }
}
