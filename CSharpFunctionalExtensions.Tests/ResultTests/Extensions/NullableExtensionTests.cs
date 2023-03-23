#if NETCOREAPP3_0_OR_GREATER
namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    using System;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Xunit;

    public class NullableExtensionTests
    {
        [Fact]
        public void Convert_nullable_struct_to_result_pass()
        {
            // Arrange
            DateTime? date = DateTime.Now;

            // Act
            var result = date.ToResult("Date not set.");

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(date.Value);
        }

        [Fact]
        public void Convert_nullable_struct_to_result_fail()
        {
            // Arrange
            DateTime? date = default;

            // Act
            var result = date.ToResult("Date not set.");

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("Date not set.");

        }

        [Fact]
        public void Convert_nullable_class_to_result_pass()
        {
            // Arrange
            MyClass myClass = new();

            // Act
            var result = myClass.ToResult("MyClass is not set.");

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(myClass);
        }

        [Fact]
        public void Convert_nullable_class_to_result_fail()
        {
            // Arrange
            MyClass myClass = default;

            // Act
            var result = myClass.ToResult("MyClass is not set.");

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("MyClass is not set.");
        }

        // async class
        [Fact]
        public async Task Convert_task_nullable_class_to_result_pass()
        {
            // Arrange
            MyClass my = new();
            var myClassTask = Task.FromResult(my);

            // Act
            var result = await myClassTask.ToResultAsync("MyClass is not set.");

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(my);
        }

        [Fact]
        public async Task Convert_task_nullable_class_to_result_fail()
        {
            // Arrange
            MyClass my = null;
            var myClassTask = Task.FromResult(my);

            // Act
            var result = await myClassTask.ToResultAsync("MyClass is not set.");

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("MyClass is not set.");
        }

        [Fact]
        public async Task Convert_valuetask_nullable_class_to_result_pass()
        {
            // Arrange
            MyClass my = new();

            var myClassTask = ValueTask.FromResult(my);

            // Act
            var result = await myClassTask.ToResultAsync("MyClass is not set.");

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(my);
        }

        [Fact]
        public async Task Convert_valuetask_nullable_class_to_result_fail()
        {
            // Arrange
            MyClass my = null;
            var myClassTask = ValueTask.FromResult(my);

            // Act
            var result = await myClassTask.ToResultAsync("MyClass is not set.");

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("MyClass is not set.");
        }

        // async struct
        [Fact]
        public async Task Convert_task_nullable_struct_to_result_pass()
        {
            // Arrange
            DateTime? my = DateTime.Now;
            var myClassTask = Task.FromResult(my);

            // Act
            var result = await myClassTask.ToResultAsync("Date is not set.");

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(my.Value);
        }

        [Fact]
        public async Task Convert_task_nullable_struct_to_result_fail()
        {
            // Arrange
            DateTime? my = default;
            var myClassTask = Task.FromResult(my);

            // Act
            var result = await myClassTask.ToResultAsync("Date is not set.");

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("Date is not set.");
        }

        [Fact]
        public async Task Convert_valuetask_nullable_struct_to_result_pass()
        {
            // Arrange
            DateTime? my = DateTime.Now;

            var myClassTask = ValueTask.FromResult(my);

            // Act
            var result = await myClassTask.ToResultAsync("Date is not set.");

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(my.Value);
        }

        [Fact]
        public async Task Convert_valuetask_nullable_struct_to_result_fail()
        {
            // Arrange
            MyClass my = null;
            var myClassTask = ValueTask.FromResult(my);

            // Act
            var result = await myClassTask.ToResultAsync("Date is not set.");

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("Date is not set.");
        }
    }

    internal class MyClass
    {
    }
}
#endif
