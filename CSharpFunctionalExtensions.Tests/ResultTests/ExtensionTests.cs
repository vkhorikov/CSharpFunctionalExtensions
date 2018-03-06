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
        
        private class MyClass
        {
            public string Property { get; set; }
        }
    }
}
