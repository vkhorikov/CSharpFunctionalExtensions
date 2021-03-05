using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CSharpFunctionalExtensions
{
    public abstract class EnumValueObject<TEnumeration> : ValueObject
        where TEnumeration : EnumValueObject<TEnumeration>
    {
        protected EnumValueObject(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("The enum key cannot be null or empty");
            }

            Key = key;
        }

        public static IEnumerable<TEnumeration> All = GetEnumerations();

        public virtual string Key { get; protected set; }
        
        public static bool operator ==(EnumValueObject<TEnumeration> a, string b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Key.Equals(b);
        }

        public static bool operator !=(EnumValueObject<TEnumeration> a, string b)
        {
            return !(a == b);
        }

        public static bool operator ==(string a, EnumValueObject<TEnumeration> b)
        {
            return b == a;
        }

        public static bool operator !=(string a, EnumValueObject<TEnumeration> b)
        {
            return !(b == a);
        }
        
        public static Maybe<TEnumeration> FromKey(string key)
        {
            return All.SingleOrDefault(p => p.Key == key);
        }

        public static bool Is(string possibleKey) => All.Select(e => e.Key).Contains(possibleKey);

        public override string ToString() => Key;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Key;
        }
        
        private static TEnumeration[] GetEnumerations()
        {
            var enumerationType = typeof(TEnumeration);

            return enumerationType
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(info => info.FieldType == typeof(TEnumeration))
                .Select(info => (TEnumeration)info.GetValue(null))
                .ToArray();
        }
    }
}