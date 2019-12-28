﻿using System;
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

        [Fact]
        public void Two_VO_of_the_same_content_are_equal()
        {
            var address1 = new Address("Street", "City");
            var address2 = new Address("Street", "City");

            address1.Equals(address2).Should().BeTrue();
            address1.GetHashCode().Equals(address2.GetHashCode()).Should().BeTrue();
        }

        [Fact]
        public void Two_PVO_of_the_same_content_are_equal()
        {
            var emailAddress1 = new EmailAddress("a@b.com");
            var emailAddress2 = new EmailAddress("a@b.com");

            emailAddress1.Equals(emailAddress2).Should().BeTrue();
            emailAddress1.GetHashCode().Equals(emailAddress2.GetHashCode()).Should().BeTrue();
        }

        [Fact]
        public void It_is_possible_to_override_default_equality_comparison_behavior()
        {
            var money1 = new Money("usd", 2.2222m);
            var money2 = new Money("USD", 2.22m);

            money1.Equals(money2).Should().BeTrue();
            money1.GetHashCode().Equals(money2.GetHashCode()).Should().BeTrue();
        }

        [Fact]
        public void Comparing_value_objects_of_different_types_returns_false()
        {
            var vo1 = new VO1("1");
            var vo2 = new VO2("2");

            vo1.Equals(vo2).Should().BeFalse();
        }

        [Fact]
        public void Comparing_primitive_value_objects_of_different_types_returns_false()
        {
            var emailAddress1 = new EmailAddress("a@b.com");
            var emailAddress2 = new EmailAddress("c@d.com");

            emailAddress1.Equals(emailAddress2).Should().BeFalse();
        }

        public class VO1 : ValueObject
        {
            public string Value { get; }

            public VO1(string value)
            {
                Value = value;
            }

            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return Value;
            }
        }

        public class VO2 : ValueObject
        {
            public string Value { get; }

            public VO2(string value)
            {
                Value = value;
            }

            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return Value;
            }
        }

        public class Money : ValueObject
        {
            public string Currency { get; }
            public decimal Amount { get; }

            public Money(string currency, decimal amount)
            {
                Currency = currency;
                Amount = amount;
            }

            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return Currency.ToUpper();
                yield return Math.Round(Amount, 2);
            }
        }

        public class Address2 : ValueObject
        {
            public string Street { get; }
            public string City { get; }

            public Address2(string street, string city)
            {
                Street = street;
                City = city;
            }

            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return Street;
                yield return City;
            }
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
                return other is DerivedAddress derived && base.EqualsCore(derived) && Country == derived.Country;
            }
        }

        public class EmailAddress : PrimitiveValueObject<string>
        {
            public EmailAddress(string value) : base(value) { }
        }
    }
}
