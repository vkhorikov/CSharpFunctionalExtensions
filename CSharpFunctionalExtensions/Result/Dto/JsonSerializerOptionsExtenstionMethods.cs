using CSharpFunctionalExtensions;

namespace System.Text.Json
{
    public static class JsonSerializerOptionsExtenstionMethods
    {
        public static JsonSerializerOptions AddResultCoverters(this JsonSerializerOptions options)
        {
            options.Converters.Add(new ResultDtoJsonConverter());
            options.Converters.Add(new ResultDtoJsonConverterFactory());
            return options;
        }
    }

}
