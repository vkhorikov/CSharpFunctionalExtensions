using System;
using System.Text.Json;

namespace CSharpFunctionalExtensions
{
    public static class CommonJsonSerializerOptions
    {
        private static readonly Lazy<JsonSerializerOptions> LazyOptions = new(() =>
        {
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            options.AddResultCoverters();
            return options;
        });

        public static JsonSerializerOptions Options => LazyOptions.Value;
    }
}
