using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static T GetValueOrDefault<T>(in this Result<T> result, Func<T> defaultValue)
        {
            if (result.IsFailure)
                return defaultValue();

            return result.Value;
        }

        public static K GetValueOrDefault<T, K>(in this Result<T> result, Func<T, K> selector, K defaultValue = default)
        {
            if (result.IsFailure)
                return defaultValue;

            return selector(result.Value);
        }

        public static K GetValueOrDefault<T, K>(in this Result<T> result, Func<T, K> selector, Func<K> defaultValue)
        {
            if (result.IsFailure)
                return defaultValue();

            return selector(result.Value);
        }
    }
}
