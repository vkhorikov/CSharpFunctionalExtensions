using System;
using System.Collections.Generic;

namespace CSharpFunctionalExtensions
{
    public class ComparableSimpleValueObject<T> : ComparableValueObject
        where T : IComparable
    {
        public T Value { get; }

        protected ComparableSimpleValueObject(T value)
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

        public static implicit operator T(ComparableSimpleValueObject<T> valueObject)
        {
            return valueObject == null ? default : valueObject.Value;
        }
    }
}
