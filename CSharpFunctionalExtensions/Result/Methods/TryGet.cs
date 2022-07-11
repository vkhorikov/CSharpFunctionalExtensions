#if NETCORE || NETSTANDARD || NET45_OR_GREATER
using System.Runtime.CompilerServices;
#endif
#if NET_5_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
#endif

namespace CSharpFunctionalExtensions
{
    partial struct Result
    {
#if NETCORE || NETSTANDARD || NET45_OR_GREATER
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public bool TryGetError(
#if NET_5_0_OR_GREATER
            [NotNullWhen(true), MaybeNullWhen(false)]
#endif
            out string error)
        {
            error = _error;
            return IsFailure;
        }
    }

    partial struct Result<T>
    {
#if NETCORE || NETSTANDARD || NET45_OR_GREATER
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public bool TryGetValue(
#if NET_5_0_OR_GREATER
            [NotNullWhen(true), MaybeNullWhen(false)]
#endif
            out T value)
        {
            value = _value;
            return IsSuccess;
        }

#if NETCORE || NETSTANDARD || NET45_OR_GREATER
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public bool TryGetError(
#if NET_5_0_OR_GREATER
            [NotNullWhen(true), MaybeNullWhen(false)]
#endif
            out string error)
        {
            error = _error;
            return IsFailure;
        }

#if NETCORE || NETSTANDARD || NET45_OR_GREATER
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public bool TryGetValue(
#if NET_5_0_OR_GREATER
            [NotNullWhen(true), MaybeNullWhen(false)]
#endif
            out T value,
#if NET_5_0_OR_GREATER
            [NotNullWhen(false), MaybeNullWhen(true)]
#endif
            out string error
            )
        {
            value = _value;
            error = _error;
            return IsSuccess;
        }

#if NETCORE || NETSTANDARD || NET45_OR_GREATER
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public bool TryGetError(
#if NET_5_0_OR_GREATER
            [NotNullWhen(true), MaybeNullWhen(false)]
#endif
            out string error,
#if NET_5_0_OR_GREATER
            [NotNullWhen(false), MaybeNullWhen(true)]
#endif
            out T value
            )
        {
            value = _value;
            error = _error;
            return IsFailure;
        }
    }

    partial struct Result<T, E>
    {

#if NETCORE || NETSTANDARD || NET45_OR_GREATER
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public bool TryGetValue(
#if NET_5_0_OR_GREATER
            [NotNullWhen(true), MaybeNullWhen(false)]
#endif
            out T value)
        {
            value = _value;
            return IsSuccess;
        }

#if NETCORE || NETSTANDARD || NET45_OR_GREATER
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public bool TryGetError(
#if NET_5_0_OR_GREATER
            [NotNullWhen(true), MaybeNullWhen(false)]
#endif
            out E error)
        {
            error = _error;
            return IsFailure;
        }

#if NETCORE || NETSTANDARD || NET45_OR_GREATER
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public bool TryGetValue(
#if NET_5_0_OR_GREATER
            [NotNullWhen(true), MaybeNullWhen(false)]
#endif
            out T value,
#if NET_5_0_OR_GREATER
            [NotNullWhen(false), MaybeNullWhen(true)]
#endif
            out E error
        )
        {
            value = _value;
            error = _error;
            return IsSuccess;
        }

#if NETCORE || NETSTANDARD || NET45_OR_GREATER
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public bool TryGetError(
#if NET_5_0_OR_GREATER
            [NotNullWhen(true), MaybeNullWhen(false)]
#endif
            out E error,
#if NET_5_0_OR_GREATER
            [NotNullWhen(false), MaybeNullWhen(true)]
#endif
            out T value
        )
        {
            value = _value;
            error = _error;
            return IsFailure;
        }
    }

    partial struct UnitResult<E>
    {
#if NETCORE || NETSTANDARD || NET45_OR_GREATER
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public bool TryGetError(
#if NET_5_0_OR_GREATER
            [NotNullWhen(true), MaybeNullWhen(false)]
#endif
            out E error)
        {
            error = _error;
            return IsFailure;
        }
    }
}