using System;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class MapFailureTests
    {
        #region string as Error

        [Fact]
        public void Can_not_convert_okResult_without_value_to_okResult_with_value()
        {
            var okResultWithoutValue = Result.Ok();

            Action action = () => okResultWithoutValue.MapFailure<MyValueClass>();

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Can_convert_failedResult_without_value_to_failedResult_with_value()
        {
            var failedResultWithoutValue = Result.Fail("Failed");

            Result<MyValueClass> failedResultWithValue = failedResultWithoutValue.MapFailure<MyValueClass>();

            failedResultWithValue.IsFailure.Should().BeTrue();
            failedResultWithValue.Error.Should().Be("Failed");
        }

        [Fact]
        public void Can_not_convert_okResult_with_value_to_okResult_without_value()
        {
            var okResultWithValue = Result.Ok(new MyValueClass());

            Action action = () => okResultWithValue.MapFailure();

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Can_convert_failedResult_with_value_to_failedResult_without_value()
        {
            var failedResultWithValue = Result.Fail<MyValueClass>("Failed");

            Result failedResultWithoutValue = failedResultWithValue;

            failedResultWithoutValue.IsFailure.Should().BeTrue();
            failedResultWithoutValue.Error.Should().Be("Failed");
        }

        [Fact]
        public void Can_not_convert_okResult_with_value_to_okResult_with_otherValue()
        {
            var okResultWithValue = Result.Ok(new MyValueClass());

            Action action = () => okResultWithValue.MapFailure<MyValueClass2>();

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Can_convert_failedResult_with_value_to_failedResult_with_other_value()
        {
            var failedResultWithValue = Result.Fail<MyValueClass>("Failed");

            Result<MyValueClass2> failedResultWithOtherValue = failedResultWithValue.MapFailure<MyValueClass2>();

            failedResultWithOtherValue.IsFailure.Should().BeTrue();
            failedResultWithOtherValue.Error.Should().Be("Failed");
        }

        #endregion

        #region ErrorClass as Error

        [Fact]
        public void ErrorClass_Can_not_convert_okResult_with_value_to_okResult_with_value()
        {
            var okResultWithValue = Result.Ok<MyValueClass, MyErrorClass>(new MyValueClass());

            Action action = () => okResultWithValue.MapFailure<MyValueClass2>();

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void ErrorClass_Can_convert_failedResult_with_value_to_failedResult_without_value()
        {
            var failedResultWithValue = Result.Fail<MyValueClass, MyErrorClass>(new MyErrorClass { Prop = "Failed" });

            Result<MyValueClass2, MyErrorClass> failedResultWithoutValue = failedResultWithValue.MapFailure<MyValueClass2>();

            failedResultWithoutValue.IsFailure.Should().BeTrue();
            failedResultWithoutValue.Error.ShouldBeEquivalentTo(new MyErrorClass
            {
                Prop = "Failed"
            });
        }

        #endregion
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