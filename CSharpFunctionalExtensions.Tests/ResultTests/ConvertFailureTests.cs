using FluentAssertions;
using System;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class ConvertFailureTests
    {
        [Fact]
        public void Can_not_convert_okResult_without_value_to_okResult_with_value()
        {
            var okResultWithoutValue = Result.Success();

            Action action = () => okResultWithoutValue.ConvertFailure<MyValueClass>();

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Can_convert_failedResult_without_value_to_failedResult_with_value()
        {
            var failedResultWithoutValue = Result.Failure("Failed");

            Result<MyValueClass> failedResultWithValue = failedResultWithoutValue.ConvertFailure<MyValueClass>();

            failedResultWithValue.IsFailure.Should().BeTrue();
            failedResultWithValue.Error.Should().Be("Failed");
        }

        [Fact]
        public void Can_not_convert_okResult_with_value_to_okResult_without_value()
        {
            var okResultWithValue = Result.Success(new MyValueClass());

            Action action = () => okResultWithValue.ConvertFailure();

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Can_convert_failedResult_with_value_to_failedResult_without_value()
        {
            var failedResultWithValue = Result.Failure<MyValueClass>("Failed");

            Result failedResultWithoutValue = failedResultWithValue;

            failedResultWithoutValue.IsFailure.Should().BeTrue();
            failedResultWithoutValue.Error.Should().Be("Failed");
        }

        [Fact]
        public void Can_not_convert_okResult_with_value_to_okResult_with_otherValue()
        {
            var okResultWithValue = Result.Success(new MyValueClass());

            Action action = () => okResultWithValue.ConvertFailure<MyValueClass2>();

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Can_convert_failedResult_with_value_to_failedResult_with_other_value()
        {
            var failedResultWithValue = Result.Failure<MyValueClass>("Failed");

            Result<MyValueClass2> failedResultWithOtherValue = failedResultWithValue.ConvertFailure<MyValueClass2>();

            failedResultWithOtherValue.IsFailure.Should().BeTrue();
            failedResultWithOtherValue.Error.Should().Be("Failed");
        }

        [Fact]
        public void ErrorClass_Can_not_convert_okResult_with_value_to_okResult_with_value()
        {
            var okResultWithValue = Result.Success<MyValueClass, MyErrorClass>(new MyValueClass());

            Action action = () => okResultWithValue.ConvertFailure<MyValueClass2>();

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void ErrorClass_Can_convert_failedResult_with_value_to_failedResult_without_value()
        {
            var failedResultWithValue = Result.Failure<MyValueClass, MyErrorClass>(new MyErrorClass { Prop = "Failed" });

            Result<MyValueClass2, MyErrorClass> failedResultWithoutValue = failedResultWithValue.ConvertFailure<MyValueClass2>();

            failedResultWithoutValue.IsFailure.Should().BeTrue();
            failedResultWithoutValue.Error.Should().BeEquivalentTo(new MyErrorClass
            {
                Prop = "Failed"
            });
        }
    }

    class MyValueClass
    {
        public int Prop { get; set; }
    }

    class MyValueClass2
    {
        public int Prop { get; set; }
    }

    public class MyErrorClass
    {
        public string Prop { get; set; }
    }
}
