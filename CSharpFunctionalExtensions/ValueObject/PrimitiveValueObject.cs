using System.Collections.Generic;

namespace CSharpFunctionalExtensions
{
    public abstract class PrimitiveValueObject<T> : ValueObject
    {
        public T Value { get; }

        protected PrimitiveValueObject(T value) { Value = value; }

        protected override IEnumerable<object> GetEqualityComponents() { yield return Value; }
    }
}
