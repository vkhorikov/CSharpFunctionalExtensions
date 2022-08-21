using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CSharpFunctionalExtensions
{
    public abstract class EnumValueObject<TEnumeration, TId> : ValueObject
        where TEnumeration : EnumValueObject<TEnumeration, TId>
        where TId : struct
    {
        private int? _cachedHashCode;
        
        private static readonly Dictionary<TId, TEnumeration> EnumerationsById = GetEnumerations().ToDictionary(e => e.Id);
        private static readonly Dictionary<string, TEnumeration> EnumerationsByName = GetEnumerations().ToDictionary(e => e.Name);
        
        protected EnumValueObject(TId id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("The name cannot be null or empty");
            }
            
            Id = id;
            Name = name;
        }

        public TId Id { get; protected set; }
        
        public string Name { get; protected set; }
        
        public static bool operator ==(EnumValueObject<TEnumeration, TId> a, TId b)
        {
            if (a is null)
            {
                return false;
            }
            
            return a.Id.Equals(b);
        }

        public static bool operator !=(EnumValueObject<TEnumeration, TId> a, TId b)
        {
            return !(a == b);
        }

        public static bool operator ==(TId a, EnumValueObject<TEnumeration, TId> b)
        {
            return b == a;
        }

        public static bool operator !=(TId a, EnumValueObject<TEnumeration, TId> b)
        {
            return !(b == a);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetUnproxiedType(this) != GetUnproxiedType(obj))
                return false;

            var enumValueObject = (EnumValueObject<TEnumeration, TId>)obj;

            return GetEqualityComponents().SequenceEqual(enumValueObject.GetEqualityComponents());
        }
        
        public override int GetHashCode()
        {
            if (!_cachedHashCode.HasValue)
            {
                _cachedHashCode = GetEqualityComponents()
                    .Aggregate(1, (current, obj) =>
                    {
                        unchecked
                        {
                            return current * 23 + (obj?.GetHashCode() ?? 0);
                        }
                    });
            }

            return _cachedHashCode.Value;
        }
        
        public static Maybe<TEnumeration> FromId(TId id)
        {
            return EnumerationsById.ContainsKey(id)
                ? EnumerationsById[id]
                : null;
        }
        
        public static Maybe<TEnumeration> FromName(string name)
        {
            return EnumerationsByName.ContainsKey(name)
                ? EnumerationsByName[name]
                : null;
        }


#if NET40
        public static ICollection<TEnumeration> All = EnumerationsById.Values.OfType<TEnumeration>().ToList();
#else
        public static IReadOnlyCollection<TEnumeration> All = EnumerationsById.Values.OfType<TEnumeration>().ToList();
#endif

        public static bool Is(string possibleName) => All.Select(e => e.Name).Contains(possibleName);

        public static bool Is(TId possibleId) => All.Select(e => e.Id).Contains(possibleId);

        public override string ToString() => Name;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
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
    
    public abstract class EnumValueObject<TEnumeration> : ValueObject
        where TEnumeration : EnumValueObject<TEnumeration>
    {
        private int? _cachedHashCode;
        
        private static readonly Dictionary<string, TEnumeration> Enumerations = GetEnumerations().ToDictionary(e => e.Id);
        
        protected EnumValueObject(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("The enum key cannot be null or empty");
            }

            Id = id;
        }

#if NET40
        public static ICollection<TEnumeration> All = Enumerations.Values.OfType<TEnumeration>().ToList();
#else
        public static IReadOnlyCollection<TEnumeration> All = Enumerations.Values.OfType<TEnumeration>().ToList();
#endif

        public virtual string Id { get; protected set; }
        
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

            return a.Id.Equals(b);
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
        
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetUnproxiedType(this) != GetUnproxiedType(obj))
                return false;

            var enumValueObject = (EnumValueObject<TEnumeration>)obj;

            return GetEqualityComponents().SequenceEqual(enumValueObject.GetEqualityComponents());
        }
        
        public override int GetHashCode()
        {
            if (!_cachedHashCode.HasValue)
            {
                _cachedHashCode = GetEqualityComponents()
                    .Aggregate(1, (current, obj) =>
                    {
                        unchecked
                        {
                            return current * 23 + (obj?.GetHashCode() ?? 0);
                        }
                    });
            }

            return _cachedHashCode.Value;
        }
        
        public static Maybe<TEnumeration> FromId(string id)
        {
            return Enumerations.ContainsKey(id)
                ? Enumerations[id]
                : null;
        }

        public static bool Is(string possibleId) => All.Select(e => e.Id).Contains(possibleId);

        public override string ToString() => Id;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
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