using System.Collections.Generic;

namespace CSharpFunctionalExtensions
{
    public abstract class SimpleValueObject<T> : ValueObject
    {
        public T Value { get; }

        protected SimpleValueObject(T value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value?.ToString();
        }
    }
}
