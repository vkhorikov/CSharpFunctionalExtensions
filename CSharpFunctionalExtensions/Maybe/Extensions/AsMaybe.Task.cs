using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        // ReSharper disable ConvertNullableToShortForm
        /// <summary>
        /// Converts the <see cref="Nullable"/> struct to a <see cref="Maybe{T}"/>.
        /// </summary>
        /// <returns>Returns the <see cref="Maybe{T}"/> equivalent to the <see cref="Nullable{T}"/>.</returns>
        public static async Task<Maybe<T>> AsMaybe<T>(this Task<Nullable<T>> nullableTask)
            where T : struct
        {
            var nullable = await nullableTask.DefaultAwait();
            return nullable.AsMaybe();
        }

#nullable enable
        /// <summary>
        /// Wraps the class instance in a <see cref="Maybe{T}"/>.
        /// </summary>
        /// <returns>Returns <see cref="Maybe.None"/> if the class instance is null, otherwise returns <see cref="Maybe.From{T}(T)"/>.</returns>
        public static async Task<Maybe<T>> AsMaybe<T>(this Task<T?> nullableTask)
            where T : class
        {
            var nullable = await nullableTask.DefaultAwait();
            return nullable.AsMaybe();
        }
#nullable restore
    }
}
