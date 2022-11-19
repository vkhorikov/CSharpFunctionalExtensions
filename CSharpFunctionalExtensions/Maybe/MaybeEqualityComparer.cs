using System.Collections.Generic;

namespace CSharpFunctionalExtensions
{
    public class MaybeEqualityComparer<T> : IEqualityComparer<Maybe<T>>
    {
        private readonly IEqualityComparer<T> _equalityComparer;

        public MaybeEqualityComparer(IEqualityComparer<T> equalityComparer = null)
        {
            _equalityComparer = equalityComparer ?? EqualityComparer<T>.Default;
        }

        public bool Equals(Maybe<T> x, Maybe<T> y)
        {
            if (x.HasNoValue && y.HasNoValue)
            {
                return true;
            }

            return x.HasValue && y.HasValue && _equalityComparer.Equals(x.Value, y.Value);
        }

        public int GetHashCode(Maybe<T> obj)
        {
            return obj.HasNoValue ? 0 : _equalityComparer.GetHashCode(obj.Value);
        }
    }
}
