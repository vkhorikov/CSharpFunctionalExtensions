using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class CheckTests : CheckTestsBase
    {
        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, false)]
        public void Tap_T_func_result(bool resultSuccess, bool funcSuccess)
        {
            Result<T> result = Result.SuccessIf(resultSuccess, T.Value, ErrorMessage);

            var returned = result.Check(_ => GetResult(funcSuccess));

            actionExecuted.Should().Be(resultSuccess);
            returned.Should().Be(funcSuccess ? result : FailedResultT);
        }
        
        
        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, false)]
        public void Tap_T_func_result_K(bool resultSuccess, bool funcSuccess)
        {
            Result<T> result = Result.SuccessIf(resultSuccess, T.Value, ErrorMessage);

            var returned = result.Check(Func_Result_K(funcSuccess));

            actionExecuted.Should().Be(resultSuccess);
            returned.Should().Be(funcSuccess ? result : FailedResultT);
        }
        
        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, false)]
        public void Tap_T_func_result_KE(bool resultSuccess, bool funcSuccess)
        {
            Result<T, E> result = Result.SuccessIf(resultSuccess, T.Value, E.Value);

            var returned = result.Check(Func_Result_KE(funcSuccess));

            actionExecuted.Should().Be(resultSuccess);
            returned.Should().Be(funcSuccess ? result : returned);
        }
    }
}