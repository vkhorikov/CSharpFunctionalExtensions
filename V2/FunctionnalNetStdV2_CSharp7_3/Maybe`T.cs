namespace System {
    using System.Diagnostics;
    [DebuggerStepThrough]
    public struct Maybe<T> : IEquatable<Maybe<T>> {
        public static readonly Maybe<T> Empty = new Maybe<T>();
        private readonly MaybeValueWrapper _value;
        private Maybe(T value) {
            _value = value == null ? null : new MaybeValueWrapper(value);
        }
        public static bool operator !=(Maybe<T> first, Maybe<T> second)
            => !(first == second);
        //  public static implicit operator Maybe<T>(T value) => new Maybe<T>(value);
        public static bool operator ==(Maybe<T> maybe, T value) {
            return maybe.IsEmpty ? false : maybe.Value.Equals(value);
        }
        public static bool operator !=(Maybe<T> maybe, T value)
                => !(maybe == value);
        public static bool operator ==(Maybe<T> first, Maybe<T> second)
            => first.Equals(second);
        public static Maybe<T> Create(T t) => new Maybe<T>(t);
        public override bool Equals(object obj) {
            if (obj is T) {
                obj = new Maybe<T>((T)obj);
            }
            if (!(obj is Maybe<T>))
                return false;
            Maybe<T> other = (Maybe<T>)obj;
            return Equals(other);
        }
        public bool Equals(Maybe<T> other) {
            if (IsEmpty && other.IsEmpty)
                return true;
            if (IsEmpty || other.IsEmpty)
                return false;
            return _value.Value.Equals(other._value.Value);
        }
        public override int GetHashCode() => IsFull ? _value.GetHashCode() : 0;
        //public K Unwrap<K>(Func<T, K> selector) {
        //    if(IsFull)
        //        return selector(Value);
        //    return default(K);
        //}
        public Maybe<T> OrValue(T alternative)
                => IsFull ? this : Maybe<T>.Create(alternative);
        /// <summary>
        /// THIS FUNCTION RELIES ON THE alternativeFactory NEVER throwing errors
        /// </summary>
        public Maybe<T> OrValue(Func<T> alternativeFactory) {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return IsFull ? this : Create(alternativeFactory());
        }
        public Maybe<T> OrMaybe(Maybe<T> alternative)
            => IsFull ? this : alternative;
        /// <summary>
        /// THIS FUNCTION RELIES ON THE alternativeFactory NEVER throwing errors
        /// </summary>
        public Maybe<T> OrMaybe(Func<Maybe<T>> alternativeFactory) {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return IsFull ? this : alternativeFactory();
        }
        public override string ToString() {
            if (IsEmpty)
                return "No value";
            return Value.ToString();
        }
        public string ToString(Func<T, string> func) => IsFull ? func(Value) : string.Empty;
        public T Unwrap() {
            if (IsFull)
                return Value;
            return default(T);
        }
        public bool IsEmpty
            => _value is null;
        public bool IsFull
            => _value != null;
        public T Value {
            get {
                if (IsEmpty)
                    throw new InvalidOperationException("Maybe is empty");
                return _value.Value;
            }
        }
        private class MaybeValueWrapper {
            public MaybeValueWrapper(T value) {
                Value = value;
            }
            internal readonly T Value;
        }
    }
}
