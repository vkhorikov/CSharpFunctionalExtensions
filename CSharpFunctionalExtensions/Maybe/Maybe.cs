using System;

namespace CSharpFunctionalExtensions
{
    [Serializable]
    public struct Maybe<T> : IEquatable<Maybe<T>>
    {
        private readonly bool _isValueSet;

        private readonly T _value;

        public T GetValueOrThrow()
        {
            if (HasNoValue)
                throw new InvalidOperationException();

            return _value;
        }

        public T GetValueOrDefault(T defaultValue = default)
        {
            if (HasNoValue)
                return defaultValue;

            return _value;
        }

        [Obsolete("Use GetValueOrThrow() instead.")]
        public T Value => GetValueOrThrow();

        public static Maybe<T> None => new Maybe<T>();

        public bool HasValue => _isValueSet;
        public bool HasNoValue => !HasValue;

        private Maybe(T value)
        {
            if (value == null)
            {
                _isValueSet = false;
                _value = default;
                return;
            }

            _isValueSet = true;
            _value = value;
        }

        public static implicit operator Maybe<T>(T value)
        {
            if (value?.GetType() == typeof(Maybe<T>))
            {
                return (Maybe<T>)(object)value;
            }

            return new Maybe<T>(value);
        }

        public static implicit operator Maybe<T>(Maybe value) => None;

        public static Maybe<T> From(T obj)
        {
            return new Maybe<T>(obj);
        }

        public static bool operator ==(Maybe<T> maybe, T value)
        {
            if (value is Maybe<T>)
                return maybe.Equals(value);

            if (maybe.HasNoValue)
                return value is null;

            return maybe._value.Equals(value);
        }

        public static bool operator !=(Maybe<T> maybe, T value)
        {
            return !(maybe == value);
        }

        public static bool operator ==(Maybe<T> first, Maybe<T> second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Maybe<T> first, Maybe<T> second)
        {
            return !(first == second);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != typeof(Maybe<T>))
            {
                if (obj is T objT)
                {
                    obj = new Maybe<T>(objT);
                }

                if (!(obj is Maybe<T>))
                    return false;
            }

            var other = (Maybe<T>)obj;
            return Equals(other);
        }

        public bool Equals(Maybe<T> other)
        {
            if (HasNoValue && other.HasNoValue)
                return true;

            if (HasNoValue || other.HasNoValue)
                return false;

            return _value.Equals(other._value);
        }

        public override int GetHashCode()
        {
            if (HasNoValue)
                return 0;

            return _value.GetHashCode();
        }

        public override string ToString()
        {
            if (HasNoValue)
                return "No value";

            return _value.ToString();
        }
    }

    /// <summary>
    /// Non-generic entrypoint for <see cref="Maybe{T}" /> members
    /// </summary>
    public struct Maybe
    {
        public static Maybe None => new Maybe();

        /// <summary>
        /// Creates a new <see cref="Maybe{T}" /> from the provided <paramref name="value"/>
        /// </summary>
        public static Maybe<T> From<T>(T value) => Maybe<T>.From(value);
    }
}
