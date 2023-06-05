using System;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Gets the value of the result on success, otherwise returns the value returned by the function.
        /// </summary>
        public static T GetValueOrDefault<T>(in this Result<T> result, Func<T> defaultValue)
        {
            if (result.IsFailure)
                return defaultValue();

            return result.Value;
        }

        /// <summary>
        ///     Gets the value of the result on success, otherwise returns the value returned by the selector when called with the default value function.
        /// </summary>
        public static K GetValueOrDefault<T, K>(in this Result<T> result, Func<T, K> selector, K defaultValue = default)
        {
            if (result.IsFailure)
                return defaultValue;

            return selector(result.Value);
        }

        /// <summary>
        ///     Gets the value of the result on success, otherwise returns the value returned by the selector when called with the default value function.
        /// </summary>
        public static K GetValueOrDefault<T, K>(in this Result<T> result, Func<T, K> selector, Func<K> defaultValue)
        {
            if (result.IsFailure)
                return defaultValue();

            return selector(result.Value);
        }
    }
}
