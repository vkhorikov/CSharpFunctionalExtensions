using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests
{
    public class ImplicitConversionTests
    {
        [Fact]
        public void Implicit_conversion_of_reference_type()
        {
            StringVO stringVo = default;
            
            // ReSharper disable once ExpressionIsAlwaysNull
            string stringPrimitive = stringVo;

            stringPrimitive.Should().BeNull();
        }

        [Fact]
        public void Implicit_conversion_of_value_type()
        {
            IntVO intVo = default;

            // ReSharper disable once ExpressionIsAlwaysNull
            int intPrimitive = intVo;

            intPrimitive.Should().Be(0);
        }

        public class StringVO : SimpleValueObject<string>
        {
            public StringVO(string value)
                : base(value)
            {
            }

            protected override IEnumerable<IComparable> GetEqualityComponents()
            {
                yield return Value.ToLower();
            }
        }

        public class IntVO : SimpleValueObject<int>
        {
            public IntVO(int value)
                : base(value)
            {
            }
        }
    }
}
