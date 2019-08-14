using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    class MyValueClass
    {
        public int Prop { get; set; }
    }

    class MyValueClass2
    {
        public int Prop { get; set; }
    }

    struct MyValueStruct
    {
        public int Prop { get; set; }
    }

    struct MyValueStruct2
    {
        public int Prop { get; set; }
    }

    public class ConversionTests
    {
        #region ValueClass

        [Fact]
        public void Convert_OkResultWithoutValue_To_OkResultWithValue()
        {
            var okResultWithoutValue = Result.Ok();

            Result<MyValueClass> okResultWithValue = okResultWithoutValue.ToResult<MyValueClass>();

            okResultWithValue.IsSuccess.Should().BeTrue();
            okResultWithValue.Value.Should().Be(null);
        }

        [Fact]
        public void Convert_FailedResultWithoutValue_To_FailedResultWithValue()
        {
            var failedResultWithoutValue = Result.Fail("Failed");

            Result<MyValueClass> failedResultWithValue = failedResultWithoutValue.ToResult<MyValueClass>();

            failedResultWithValue.IsFailure.Should().BeTrue();
            failedResultWithValue.Error.Should().Be("Failed");
        }

        [Fact]
        public void Convert_OkResultWithValue_To_OkResultWithoutValue()
        {
            var okResultWithValue = Result.Ok(new MyValueClass());

            Result okResultWithoutValue = okResultWithValue;

            okResultWithoutValue.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Convert_FailedResultWithValue_To_FailedResultWithoutValue()
        {
            var failedResultWithValue = Result.Fail<MyValueClass>("Failed");

            Result failedResultWithoutValue = failedResultWithValue;

            failedResultWithoutValue.IsFailure.Should().BeTrue();
            failedResultWithoutValue.Error.Should().Be("Failed");
        }

        [Fact]
        public void Convert_OkResultWithValue_To_OkResultWithOtherValue()
        {
            var okResultWithValue = Result.Ok(new MyValueClass());

            Result<MyValueClass2> okResultWithOtherValue = okResultWithValue.ToResult<MyValueClass2>();

            okResultWithOtherValue.IsSuccess.Should().BeTrue();
            okResultWithOtherValue.Value.Should().Be(null);
        }

        [Fact]
        public void Convert_FailedResultWithValue_To_FailedResultWithOtherValue()
        {
            var failedResultWithValue = Result.Fail<MyValueClass>("Failed");

            Result<MyValueClass2> failedResultWithOtherValue = failedResultWithValue.ToResult<MyValueClass2>();

            failedResultWithOtherValue.IsFailure.Should().BeTrue();
            failedResultWithOtherValue.Error.Should().Be("Failed");
        }

        #endregion

        #region ValueStruct

        [Fact]
        public void Convert_OkResultWithoutValueStruct_To_OkResultWithValueStruct()
        {
            var okResultWithoutValue = Result.Ok();

            Result<MyValueStruct> okResultWithValue = okResultWithoutValue.ToResult<MyValueStruct>();

            okResultWithValue.IsSuccess.Should().BeTrue();
            okResultWithValue.Value.Should().Be(new MyValueStruct());
        }

        [Fact]
        public void Convert_FailedResultWithoutValueStruct_To_FailedResultWithValueStruct()
        {
            var failedResultWithoutValue = Result.Fail("Failed");

            Result<MyValueStruct> failedResultWithValue = failedResultWithoutValue.ToResult<MyValueStruct>();

            failedResultWithValue.IsFailure.Should().BeTrue();
            failedResultWithValue.Error.Should().Be("Failed");
        }

        [Fact]
        public void Convert_OkResultWithValueStruct_To_OkResultWithoutValueStruct()
        {
            var okResultWithValue = Result.Ok(new MyValueStruct());

            Result okResultWithoutValue = okResultWithValue;

            okResultWithoutValue.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Convert_FailedResultWithValueStruct_To_FailedResultWithoutValueStruct()
        {
            var failedResultWithValue = Result.Fail<MyValueStruct>("Failed");

            Result failedResultWithoutValue = failedResultWithValue;

            failedResultWithoutValue.IsFailure.Should().BeTrue();
            failedResultWithoutValue.Error.Should().Be("Failed");
        }

        [Fact]
        public void Convert_OkResultWithValueStruct_To_OkResultWithOtherValueStruct()
        {
            var okResultWithValue = Result.Ok(new MyValueStruct());

            Result<MyValueStruct2> okResultWithOtherValue = okResultWithValue.ToResult<MyValueStruct2>();

            okResultWithOtherValue.IsSuccess.Should().BeTrue();
            okResultWithOtherValue.Value.Should().Be(new MyValueStruct2());
        }

        [Fact]
        public void Convert_FailedResultWithValueStruct_To_FailedResultWithOtherValueStruct()
        {
            var failedResultWithValue = Result.Fail<MyValueStruct>("Failed");

            Result<MyValueStruct2> failedResultWithOtherValue = failedResultWithValue.ToResult<MyValueStruct2>();

            failedResultWithOtherValue.IsFailure.Should().BeTrue();
            failedResultWithOtherValue.Error.Should().Be("Failed");
        }

        #endregion
    }

    public class MyErrorClass
    {
    }
}