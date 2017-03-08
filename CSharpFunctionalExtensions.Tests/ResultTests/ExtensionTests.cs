using FluentAssertions;
using System.Threading.Tasks;
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
        public void Can_return_inner_result_type_synchronous()
        {
            Result<string> combinedString = Result.Ok("string")
                .FlatMap(str => Result.Ok($"{str} appended"));

            combinedString.Value.Should().BeEquivalentTo("string appended");
        }

        [Fact]
        public async Task Can_return_inner_result_type_asynchronous()
        {
            Result<string> combinedString = await Task.Run(() => Result.Ok("string"))
                .FlatMap(str => Task.Run(() => Result.Ok($"{str} appended")));

            combinedString.Value.Should().BeEquivalentTo("string appended");
        }


        private class MyClass
        {
            public string Property { get; set; }
        }
    }
}
