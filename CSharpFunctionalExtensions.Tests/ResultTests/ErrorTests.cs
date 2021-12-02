namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    using FluentAssertions;
    using Xunit;
    using static CSharpFunctionalExtensions.Tests.ValueObjectTests.BasicTests;

    public class ErrorTests
    {
        [Fact]
        public void Combine_ErrorList_where_T_is_different()
        {
            // Arrange
            var emailResultSuccess = Result.Success<EmailAddress, ErrorList>(new EmailAddress("xavier@somewhere.com"));
            var stringResultSuccess = Result.Success<string, ErrorList>("one");
            var emailResultFailure = Result.Failure<EmailAddress, ErrorList>(Errors.General.ValueIsRequired("email"));
            var stringResultFailure = Result.Failure<string, ErrorList>(Errors.General.ValueIsRequired("firstName"));

            // Act
            var result = Result.Combine<ErrorList>(emailResultSuccess, stringResultSuccess, emailResultFailure, stringResultFailure);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.HasErrors.Should().BeTrue();
            result.Error.Should().HaveCount(2);
            result.Error[0].Should().Be(Errors.General.ValueIsRequired("email"));
            result.Error[1].Should().Be(Errors.General.ValueIsRequired("firstName"));
        }
    }
}
