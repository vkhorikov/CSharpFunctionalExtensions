namespace CSharpFunctionalExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    [DebuggerDisplay("{Message}")]
    public sealed class Error : ValueObject
    {
        private const string Separator = "||";

        public string Code { get; }
        public string Message { get; }

        internal Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }

        public string Serialize()
        {
            return $"{Code}{Separator}{Message}";
        }

        public static Error Deserialize(string serialized)
        {
            if (serialized == "A non-empty request body is required.")
                return Errors.General.ValueIsRequired();

            string[] data = serialized.Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries);

            if (data.Length < 2)
                throw new Exception($"Invalid error serialization: '{serialized}'");

            return new Error(data[0], data[1]);
        }
    }

    public static class Errors
    {
        public static class General
        {
            public static Error NotFound(string id = null)
            {
                string forId = id == null ? string.Empty : $" for Id '{id}'";
                return new Error("record.not.found", $"Record not found{forId}");
            }

            public static Error ValueIsInvalid(string name = null) => new("value.is.invalid", $"{GetLabel(name)} is invalid.");

            public static Error ValueIsRequired(string name = null) => new("value.is.required", $"{GetLabel(name)} is required.");

            public static Error InvalidLength(string name) => new Error("invalid.string.length", $"{GetLabel(name)} has invalid length.");

            private static string GetLabel(string name) => name ?? string.Empty;

            public static Error CollectionIsTooSmall(int min, int current) => new(
                    "collection.is.too.small",
                    $"The collection must contain {min} items or more. It contains {current} items.");

            public static Error CollectionIsTooLarge(int max, int current) => new(
                    "collection.is.too.large",
                    $"The collection must contain {max} items or more. It contains {current} items.");

            public static Error InternalServerError(string message) => new("internal.server.error", message);
        }
    }

}
