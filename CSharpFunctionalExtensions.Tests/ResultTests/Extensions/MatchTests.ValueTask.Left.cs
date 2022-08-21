using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class MatchTests_ValueTask_Left : MatchTestsBase
    {
        [Fact]
        public async Task Match_ValueTask_Left_Result_Success()
        {
            var result = Result.Success().AsValueTask();

            await result.Match(OnSuccess, OnFailure_String);

            AssertSuccess();
        }

        [Fact]
        public async Task Match_ValueTask_Left_Result_Failure()
        {
            var result = Result.Failure(ErrorMessage).AsValueTask();

            await result.Match(OnSuccess, OnFailure_String);

            AssertFailure();
        }
        
        [Fact]
        public async Task Match_ValueTask_Left_Result_Success_Returns_K()
        {
            var result = Result.Success().AsValueTask();

            var matched = await result.Match(OnSuccess_K, OnFailure_String_K);

            AssertSuccess();
            matched.Should().Be(K.Value);
        }

        [Fact]
        public async Task Match_ValueTask_Left_Result_Failure_Returns_K()
        {
            var result = Result.Failure(ErrorMessage).AsValueTask();

            var matched = await result.Match(OnSuccess_K, OnFailure_String_K);

            AssertFailure();
            matched.Should().Be(K.Value2);
        }
        
        [Fact]
        public async Task Match_ValueTask_Left_Result_T_Success()
        {
            var result = Result.Success(T.Value).AsValueTask();

            var matched = await result.Match(OnSuccess_T_K, OnFailure_String_K);

            AssertSuccess();
            
            matched.Should().Be(K.Value);
        }

        [Fact]
        public async Task Match_ValueTask_Left_Result_T_Failure()
        {
            var result = Result.Failure<T>(ErrorMessage).AsValueTask();

            await result.Match(OnSuccess_T, OnFailure_String);

            AssertFailure();
        }
        
        [Fact]
        public async Task Match_ValueTask_Left_Result_T_Success_Returns_K()
        {
            var result = Result.Success(T.Value).AsValueTask();

            var matched = await result.Match(OnSuccess_T_K, OnFailure_String_K);

            AssertSuccess();
            
            matched.Should().Be(K.Value);
        }

        [Fact]
        public async Task Match_ValueTask_Left_Result_T_Failure_Returns_K()
        {
            var result = Result.Failure<T>(ErrorMessage).AsValueTask();

            var matched = await result.Match(OnSuccess_T_K, OnFailure_String_K);

            AssertFailure();
            
            matched.Should().Be(K.Value2);
        }
        
        [Fact]
        public async Task Match_ValueTask_Left_Result_T_E_Success()
        {
            var result = Result.Success<T,E>(T.Value).AsValueTask();

            await result.Match(OnSuccess_T, OnFailure_E);

            AssertSuccess();
        }

        [Fact]
        public async Task Match_ValueTask_Left_Result_T_E_Failure_Success()
        {
            var result = Result.Failure<T,E>(E.Value).AsValueTask();

            await result.Match(OnSuccess_T, OnFailure_E);

            AssertFailure();
        }
        
        [Fact]
        public async Task Match_ValueTask_Left_Result_T_E_Success_Returns_K()
        {
            var result = Result.Success<T,E>(T.Value);

            var matched = result.Match(OnSuccess_T_K, OnFailure_E_K);

            AssertSuccess();
            
            matched.Should().Be(K.Value);
        }

        [Fact]
        public async Task Match_ValueTask_Left_Result_T_E_Failure_Returns_K()
        {
            var result = Result.Failure<T,E>(E.Value);

            var matched = result.Match(OnSuccess_T_K, OnFailure_E_K);

            AssertFailure();
            
            matched.Should().Be(K.Value2);
        }
        
        [Fact]
        public async Task Match_ValueTask_Left_UnitResult_E_Success()
        {
            var result = UnitResult.Success<E>();

            result.Match(OnSuccess, OnFailure_E);

            AssertSuccess();
        }

        [Fact]
        public async Task Match_ValueTask_Left_UnitResult_E_Failure()
        {
            var result = UnitResult.Failure(E.Value);

            result.Match(OnSuccess, OnFailure_E);

            AssertFailure();
        }
    }
}