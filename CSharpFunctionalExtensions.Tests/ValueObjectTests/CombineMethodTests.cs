using System.Collections.Generic;

using FluentAssertions;

using Xunit;


namespace CSharpFunctionalExtensions.Tests.ValueObjectTests
{
    public class BasicTests
    {
        [Fact]
        public void Derived_value_objects_dont_match()
        {
            var address = new Address("Street", "City");
            var derivedAddress = new DerivedAddress("Country", "Street", "City");

            address.Equals(derivedAddress).Should().BeFalse();
            derivedAddress.Equals(address).Should().BeFalse();
        }


        public class Address : ValueObject<Address>
        {
            public string Street { get; }
            public string City { get; }

            public Address(string street, string city)
            {
                Street = street;
                City = city;
            }

            protected override bool EqualsCore(Address other)
            {
                return Street == other.Street && City == other.City;
            }

            protected override int GetHashCodeCore()
            {
                unchecked
                {
                    int hashCode = Street.GetHashCode();
                    hashCode = (hashCode * 397) ^ City.GetHashCode();
                    return hashCode;
                }
            }
        }


        public class DerivedAddress : Address
        {
            public string Country { get; }

            public DerivedAddress(string country, string street, string city)
                : base(street, city)
            {
                Country = country;
            }

            protected override bool EqualsCore(Address other)
            {
                return other is DerivedAddress derived
                    && base.EqualsCore(derived)
                    && Country == derived.Country;
            }
        }
    }
}
