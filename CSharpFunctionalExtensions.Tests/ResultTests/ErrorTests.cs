namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Xunit;
    using static CSharpFunctionalExtensions.Tests.ValueObjectTests.BasicTests;

    public class ErrorTests
    {
        class MyError : ValueObject
        {
            public string Message;

            public MyError(string message)
            {
                Message = message;
            }

            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return Message;
            }
        }

        [Fact]
        public void Combine_ErrorListT_where_T_is_different()
        {
            // Arrange
            var emailResultSuccess = Result.Success<EmailAddress, ErrorList<MyError>>(new EmailAddress("xavier@somewhere.com"));
            var stringResultSuccess = Result.Success<string, ErrorList<MyError>>("one");
            var emailResultFailure = Result.Failure<EmailAddress, ErrorList<MyError>>(new MyError("Bad email address"));
            var stringResultFailure = Result.Failure<string, ErrorList<MyError>>(new MyError("firstName is required"));

            // Act
            var result = Result.Combine<ErrorList<MyError>>(emailResultSuccess, stringResultSuccess, emailResultFailure, stringResultFailure);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.HasErrors.Should().BeTrue();
            result.Error.Should().HaveCount(2);
            result.Error[0].Should().Be(new MyError("Bad email address"));
            result.Error[1].Should().Be(new MyError("firstName is required"));
        }
    }
}
