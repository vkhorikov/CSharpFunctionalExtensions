using System;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        // ReSharper disable ConvertNullableToShortForm
        /// <summary>
        /// Converts the <see cref="Nullable"/> struct to a <see cref="Maybe{T}"/>.
        /// </summary>
        /// <returns>Returns the <see cref="Maybe{T}"/> equivalent to the <see cref="Nullable{T}"/>.</returns>
#if NET5_0_OR_GREATER
        public static Maybe<T> AsMaybe<T>(ref this Nullable<T> value)
            where T : struct
        {
            return System.Runtime.CompilerServices.Unsafe.As<Nullable<T>, Maybe<T>>(ref value);
        }
#else
        public static Maybe<T> AsMaybe<T>(in this Nullable<T> value)
            where T : struct
        {
            if (value.HasValue)
            {
                return value.Value;
            }
            return default;
        }
#endif
        // ReSharper restore ConvertNullableToShortForm

#nullable enable
        /// <summary>
        /// Wraps the class instance in a <see cref="Maybe{T}"/>.
        /// </summary>
        /// <returns>Returns <see cref="Maybe.None"/> if the class instance is null, otherwise returns <see cref="Maybe.From(T)"/>.</returns>
        public static Maybe<T> AsMaybe<T>(this T? value)
            where T : class
        {
            if (value is not null)
            {
                return value!;
            }

            return default;
        }
#nullable restore
    }
}