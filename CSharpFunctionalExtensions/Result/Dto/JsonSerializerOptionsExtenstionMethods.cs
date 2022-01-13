using System.Text.Json;

namespace CSharpFunctionalExtensions
{
    public static class JsonSerializerOptionsExtensionMethods
    {
        public static JsonSerializerOptions AddResultCoverters(this JsonSerializerOptions options)
        {
            options.Converters.Add(new ResultDtoJsonConverter());
            options.Converters.Add(new ResultDtoJsonConverterFactory());
            return options;
        }
    }

}
