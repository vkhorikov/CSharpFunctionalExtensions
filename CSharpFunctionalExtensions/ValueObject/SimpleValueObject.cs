using System;
using System.Collections.Generic;

namespace CSharpFunctionalExtensions
{
    [Serializable]
    public abstract class SimpleValueObject<T> : ComparableValueObject
        where T : IComparable
    {
        public T Value { get; }

        protected SimpleValueObject(T value)
        {
            Value = value;
        }

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value?.ToString();
        }

        public static implicit operator T(SimpleValueObject<T> valueObject)
        {
            return valueObject == null ? default : valueObject.Value;
        }
    }
}
