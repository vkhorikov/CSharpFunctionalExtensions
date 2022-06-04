using System;
using System.Text.Json;

namespace CSharpFunctionalExtensions.Json.Serialization
{
    public static class CSharpFunctionalExtensionsJsonSerializerOptions
    {
        private static readonly Lazy<JsonSerializerOptions> LazyOptions = new(() =>
        {
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            options.AddCSharpFunctionalExtensionsConverters();
            return options;
        });

        public static JsonSerializerOptions Options => LazyOptions.Value;
    }
}
