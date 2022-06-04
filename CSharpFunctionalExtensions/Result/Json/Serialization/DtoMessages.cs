using System.Net;

namespace CSharpFunctionalExtensions.Json.Serialization
{
    internal static class DtoMessages
    {
        public static readonly string HttpResponseMessageIsNull = "HttpResponseMessage is null";

        public static readonly string ContentJsonNotResult = "The response content in not a Result";

        public static string NotSuccsessStatusCodeFormat(HttpStatusCode statusCode, string content) => $"HttpStatus code is {statusCode}, Content {content}";
    }
}
