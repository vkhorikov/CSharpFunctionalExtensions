using System;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        // ReSharper disable ConvertNullableToShortForm
        /// <summary>
        /// Converts the <see cref="Maybe{T}"/> to a <see cref="Nullable"/> struct.
        /// </summary>
        /// <returns>Returns the <see cref="Nullable{T}"/> equivalent to the <see cref="Maybe{T}"/>.</returns>
#if NET5_0_OR_GREATER
        public static Nullable<T> AsNullable<T>(ref this Maybe<T> value)
            where T : struct
        {
            return System.Runtime.CompilerServices.Unsafe.As<Maybe<T>, Nullable<T>>(ref value);
        }
#else
        public static Nullable<T> AsNullable<T>(in this Maybe<T> value)
            where T : struct
        {
            // Should use `return Unsafe.AsRef<(ref value);`
            if (value.TryGetValue(out var result))
            {
                return result;
            }
            return default;
        }
#endif
        // ReSharper restore ConvertNullableToShortForm
    }
}