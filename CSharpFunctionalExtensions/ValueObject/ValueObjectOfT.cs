using System;

namespace CSharpFunctionalExtensions
{
    /// <summary>
    /// Use non-generic ValueObject whenever possible: http://bit.ly/vo-new
    /// </summary>
    [Serializable]
    public abstract class ValueObject<T>
        where T : ValueObject<T>
    {
        private int? _cachedHashCode;

        public override bool Equals(object obj)
        {
            var valueObject = obj as T;

            if (valueObject is null)
                return false;

            if (ValueObject.GetUnproxiedType(this) != ValueObject.GetUnproxiedType(obj))
                return false;

            return EqualsCore(valueObject);
        }

        protected abstract bool EqualsCore(T other);

        public override int GetHashCode()
        {
            if (!_cachedHashCode.HasValue)
            {
                _cachedHashCode = GetHashCodeCore();
            }

            return _cachedHashCode.Value;
        }

        protected abstract int GetHashCodeCore();

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }
    }
}
