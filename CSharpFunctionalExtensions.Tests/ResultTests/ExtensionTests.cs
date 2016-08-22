using FluentAssertions;
using System;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class ExtensionTests
    {
        private static readonly string _errorMessage = "this failed";

        [Fact]
        public void Should_execute_action_on_failure()
        {
            var myBool = false;

            var myResult = Result.Fail(_errorMessage);
            myResult.OnFailure(() => myBool = true);

            myBool.Should().Be(true);
        }

        [Fact]
        public void Should_execute_action_on_generic_failure()
        {
            var myBool = false;

            var myResult = Result.Fail<MyClass>(_errorMessage);
            myResult.OnFailure(() => myBool = true);

            myBool.Should().Be(true);
        }

        [Fact]
        public void Should_exexcute_action_with_result_on_generic_failure()
        {
            var myError = string.Empty;

            var myResult = Result.Fail<MyClass>(_errorMessage);
            myResult.OnFailure((r) => myError = r.Error);

            myError.Should().Be(_errorMessage);
        }

        private class MyClass
        {
            public string Property { get; set; }
        }
    }
}