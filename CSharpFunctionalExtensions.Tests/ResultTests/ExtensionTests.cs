using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class ExtensionTests
    {
        private static readonly string _errorMessage = "this failed";

        [Fact]
        public void Should_execute_action_on_failure()
        {
            bool myBool = false;

            Result myResult = Result.Fail(_errorMessage);
            myResult.OnFailure(() => myBool = true);

            myBool.Should().Be(true);
        }

        [Fact]
        public void Should_execute_action_on_generic_failure()
        {
            bool myBool = false;

            Result<MyClass> myResult = Result.Fail<MyClass>(_errorMessage);
            myResult.OnFailure(() => myBool = true);

            myBool.Should().Be(true);
        }

        [Fact]
        public void Should_exexcute_action_with_result_on_generic_failure()
        {
            string myError = string.Empty;

            Result<MyClass> myResult = Result.Fail<MyClass>(_errorMessage);
            myResult.OnFailure(error => myError = error);

            myError.Should().Be(_errorMessage);
        }

        [Fact]
        public void Should_exexcute_action_with_error_object_on_generic_failure()
        {
            string myError = string.Empty;

            Result<MyClass, MyClass> myResult = Result.Fail<MyClass, MyClass>(new MyClass {Property = _errorMessage});
            myResult.OnFailure(error => myError = error.Property);

            myError.Should().Be(_errorMessage);
        }

        [Fact]
        public void Should_execute_compensate_func_on_failure_returns_Ok()
        {
            var myResult = Result.Fail(_errorMessage);
            var newResult = myResult.OnFailureCompensate(() => Result.Ok());

            newResult.IsSuccess.Should().Be(true);
        }

        [Fact]
        public void Should_execute_compensate_func_on_generic_failure_returns_Ok()
        {
            var expectedValue = new MyClass();

            var myResult = Result.Fail<MyClass>(_errorMessage);
            var newResult = myResult.OnFailureCompensate(() => Result.Ok(expectedValue));

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(expectedValue);
        }

        [Fact]
        public void Should_execute_compensate_func_with_result_on_generic_failure_returns_Ok()
        {
            var expectedValue = new MyClass();

            var myResult = Result.Fail<MyClass>(_errorMessage);
            var newResult = myResult.OnFailureCompensate(error => Result.Ok(expectedValue));

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(expectedValue);
        }

        [Fact]
        public void Should_execute_compensate_func_with_error_object_on_generic_failure_returns_Ok()
        {
            var expectedValue = new MyClass();

            var myResult = Result.Fail<MyClass, MyClass>(new MyClass {Property = _errorMessage});
            var newResult = myResult.OnFailureCompensate(error => Result.Ok<MyClass, MyClass>(expectedValue));

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(expectedValue);
        }

        private class MyClass
        {
            public string Property { get; set; }
        }
    }
}
