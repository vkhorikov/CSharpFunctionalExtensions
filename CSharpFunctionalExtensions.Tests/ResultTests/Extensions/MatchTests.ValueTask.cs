using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class MatchTests_ValueTask : MatchTestsBase
    {
        [Fact]
        public async Task Match_ValueTask_Result_Success()
        {
            var result = Result.Success().AsValueTask();

            await result.Match(OnSuccess_ValueTask, OnFailure_String_ValueTask);

            AssertSuccess();
        }

        [Fact]
        public async Task Match_ValueTask_Result_Failure()
        {
            var result = Result.Failure(ErrorMessage).AsValueTask();

            await result.Match(OnSuccess_ValueTask, OnFailure_String_ValueTask);

            AssertFailure();
        }
        
        [Fact]
        public async Task Match_ValueTask_Result_Success_Returns_K()
        {
            var result = Result.Success().AsValueTask();

            var matched = await result.Match(OnSuccess_K_ValueTask, OnFailure_String_K_ValueTask);

            AssertSuccess();
            matched.Should().Be(K.Value);
        }

        [Fact]
        public async Task Match_ValueTask_Result_Failure_Returns_K()
        {
            var result = Result.Failure(ErrorMessage).AsValueTask();

            var matched = await result.Match(OnSuccess_K_ValueTask, OnFailure_String_K_ValueTask);

            AssertFailure();
            matched.Should().Be(K.Value2);
        }
        
        [Fact]
        public async Task Match_ValueTask_Result_T_Success()
        {
            var result = Result.Success(T.Value).AsValueTask();

            var matched = await result.Match(OnSuccess_T_K_ValueTask, OnFailure_String_K_ValueTask);

            AssertSuccess();
            
            matched.Should().Be(K.Value);
        }

        [Fact]
        public async Task Match_ValueTask_Result_T_Failure()
        {
            var result = Result.Failure<T>(ErrorMessage).AsValueTask();

            await result.Match(OnSuccess_T_ValueTask, OnFailure_String_ValueTask);

            AssertFailure();
        }
        
        [Fact]
        public async Task Match_ValueTask_Result_T_Success_Returns_K()
        {
            var result = Result.Success(T.Value).AsValueTask();

            var matched = await result.Match(OnSuccess_T_K_ValueTask, OnFailure_String_K_ValueTask);

            AssertSuccess();
            
            matched.Should().Be(K.Value);
        }

        [Fact]
        public async Task Match_ValueTask_Result_T_Failure_Returns_K()
        {
            var result = Result.Failure<T>(ErrorMessage).AsValueTask();

            var matched = await result.Match(OnSuccess_T_K_ValueTask, OnFailure_String_K_ValueTask);

            AssertFailure();
            
            matched.Should().Be(K.Value2);
        }
        
        [Fact]
        public async Task Match_ValueTask_Result_T_E_Success()
        {
            var result = Result.Success<T,E>(T.Value).AsValueTask();

            await result.Match(OnSuccess_T_ValueTask, OnFailure_E_ValueTask);

            AssertSuccess();
        }

        [Fact]
        public async Task Match_ValueTask_Result_T_E_Failure_Success()
        {
            var result = Result.Failure<T,E>(E.Value).AsValueTask();

            await result.Match(OnSuccess_T_ValueTask, OnFailure_E_ValueTask);

            AssertFailure();
        }
        
        [Fact]
        public async Task Match_ValueTask_Result_T_E_Success_Returns_K()
        {
            var result = Result.Success<T,E>(T.Value).AsValueTask();

            var matched = await result.Match(OnSuccess_T_K_ValueTask, OnFailure_E_K_ValueTask);

            AssertSuccess();
            
            matched.Should().Be(K.Value);
        }

        [Fact]
        public async Task Match_ValueTask_Result_T_E_Failure_Returns_K()
        {
            var result = Result.Failure<T,E>(E.Value).AsValueTask();

            var matched = await result.Match(OnSuccess_T_K_ValueTask, OnFailure_E_K_ValueTask);

            AssertFailure();
            
            matched.Should().Be(K.Value2);
        }
        
        [Fact]
        public async Task Match_ValueTask_UnitResult_E_Success()
        {
            var result = UnitResult.Success<E>().AsValueTask();

            await result.Match(OnSuccess_ValueTask, OnFailure_E_ValueTask);

            AssertSuccess();
        }

        [Fact]
        public async Task Match_ValueTask_UnitResult_E_Failure()
        {
            var result = UnitResult.Failure(E.Value).AsValueTask();

            await result.Match(OnSuccess_ValueTask, OnFailure_E_ValueTask);

            AssertFailure();
        }
    }
}