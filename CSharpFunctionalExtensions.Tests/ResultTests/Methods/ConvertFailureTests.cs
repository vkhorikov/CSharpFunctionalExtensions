using FluentAssertions;
using System;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class ConvertFailureTests : TestBase
    {
        [Fact]
        public void Can_not_convert_okResult_without_value_to_okResult_with_value()
        {
            var okResultWithoutValue = Result.Success();

            Action action = () => okResultWithoutValue.ConvertFailure<T>();

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Can_convert_failedResult_without_value_to_failedResult_with_value()
        {
            var failedResultWithoutValue = Result.Failure("Failed");

            Result<T> failedResultWithValue = failedResultWithoutValue.ConvertFailure<T>();

            failedResultWithValue.IsFailure.Should().BeTrue();
            failedResultWithValue.Error.Should().Be("Failed");
        }

        [Fact]
        public void Can_not_convert_okResult_with_value_to_okResult_without_value()
        {
            var okResultWithValue = Result.Success(T.Value);

            Action action = () => okResultWithValue.ConvertFailure();

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Can_convert_failedResult_with_value_to_failedResult_without_value()
        {
            var failedResultWithValue = Result.Failure<T>(ErrorMessage);

            Result failedResultWithoutValue = failedResultWithValue;

            failedResultWithoutValue.IsFailure.Should().BeTrue();
            failedResultWithoutValue.Error.Should().Be(ErrorMessage);
        }

        [Fact]
        public void Can_not_convert_okResult_with_value_to_okResult_with_otherValue()
        {
            var okResultWithValue = Result.Success(T.Value);

            Action action = () => okResultWithValue.ConvertFailure<K>();

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Can_convert_failedResult_with_value_to_failedResult_with_other_value()
        {
            var failedResultWithValue = Result.Failure<T>(ErrorMessage);

            Result<K> failedResultWithOtherValue = failedResultWithValue.ConvertFailure<K>();

            failedResultWithOtherValue.IsFailure.Should().BeTrue();
            failedResultWithOtherValue.Error.Should().Be(ErrorMessage);
        }

        [Fact]
        public void ErrorClass_Can_not_convert_okResult_with_value_to_okResult_with_value()
        {
            var okResultWithValue = Result.Success<T, E>(T.Value);

            Action action = () => okResultWithValue.ConvertFailure<K>();

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void ErrorClass_Can_convert_failedResult_with_value_to_failedResult_without_value()
        {
            var failedResultWithValue = Result.Failure<T, E>(E.Value);

            Result<K, E> failedResultWithoutValue = failedResultWithValue.ConvertFailure<K>();

            failedResultWithoutValue.IsFailure.Should().BeTrue();
            failedResultWithoutValue.Error.Should().BeEquivalentTo(E.Value);
        }

        [Fact]
        public void UnitResult_can_not_convert_okResult_with_value_to_okResult_with_value()
        {
            var okResultWithValue = UnitResult.Success<E>();

            Action action = () => okResultWithValue.ConvertFailure<K>();

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void UnitResult_can_convert_failedResult_with_value_to_failedResult_without_value()
        {
            var failedResultWithValue = UnitResult.Failure(E.Value);

            Result<K, E> failedResultWithoutValue = failedResultWithValue.ConvertFailure<K>();

            failedResultWithoutValue.IsFailure.Should().BeTrue();
            failedResultWithoutValue.Error.Should().BeEquivalentTo(E.Value);
        }
    }
}
