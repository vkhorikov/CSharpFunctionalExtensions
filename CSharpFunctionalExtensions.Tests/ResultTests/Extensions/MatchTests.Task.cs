using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class MatchTests_Task : MatchTestsBase
    {
        [Fact]
        public async Task Match_Task_Result_Success()
        {
            var result = Result.Success().AsTask();

            await result.Match(OnSuccess_Task, OnFailure_String_Task);

            AssertSuccess();
        }

        [Fact]
        public async Task Match_Task_Result_Failure()
        {
            var result = Result.Failure(ErrorMessage).AsTask();

            await result.Match(OnSuccess_Task, OnFailure_String_Task);

            AssertFailure();
        }
        
        [Fact]
        public async Task Match_Task_Result_Success_Returns_K()
        {
            var result = Result.Success().AsTask();

            var matched = await result.Match(OnSuccess_K_Task, OnFailure_String_K_Task);

            AssertSuccess();
            matched.Should().Be(K.Value);
        }

        [Fact]
        public async Task Match_Task_Result_Failure_Returns_K()
        {
            var result = Result.Failure(ErrorMessage).AsTask();

            var matched = await result.Match(OnSuccess_K_Task, OnFailure_String_K_Task);

            AssertFailure();
            matched.Should().Be(K.Value2);
        }
        
        [Fact]
        public async Task Match_Task_Result_T_Success()
        {
            var result = Result.Success(T.Value).AsTask();

            var matched = await result.Match(OnSuccess_T_K_Task, OnFailure_String_K_Task);

            AssertSuccess();
            
            matched.Should().Be(K.Value);
        }

        [Fact]
        public async Task Match_Task_Result_T_Failure()
        {
            var result = Result.Failure<T>(ErrorMessage).AsTask();

            await result.Match(OnSuccess_T_Task, OnFailure_String_Task);

            AssertFailure();
        }
        
        [Fact]
        public async Task Match_Task_Result_T_Success_Returns_K()
        {
            var result = Result.Success(T.Value).AsTask();

            var matched = await result.Match(OnSuccess_T_K_Task, OnFailure_String_K_Task);

            AssertSuccess();
            
            matched.Should().Be(K.Value);
        }

        [Fact]
        public async Task Match_Task_Result_T_Failure_Returns_K()
        {
            var result = Result.Failure<T>(ErrorMessage).AsTask();

            var matched = await result.Match(OnSuccess_T_K_Task, OnFailure_String_K_Task);

            AssertFailure();
            
            matched.Should().Be(K.Value2);
        }
        
        [Fact]
        public async Task Match_Task_Result_T_E_Success()
        {
            var result = Result.Success<T,E>(T.Value).AsTask();

            await result.Match(OnSuccess_T_Task, OnFailure_E_Task);

            AssertSuccess();
        }

        [Fact]
        public async Task Match_Task_Result_T_E_Failure_Success()
        {
            var result = Result.Failure<T,E>(E.Value).AsTask();

            await result.Match(OnSuccess_T_Task, OnFailure_E_Task);

            AssertFailure();
        }
        
        [Fact]
        public async Task Match_Task_Result_T_E_Success_Returns_K()
        {
            var result = Result.Success<T,E>(T.Value).AsTask();

            var matched = await result.Match(OnSuccess_T_K_Task, OnFailure_E_K_Task);

            AssertSuccess();
            
            matched.Should().Be(K.Value);
        }

        [Fact]
        public async Task Match_Task_Result_T_E_Failure_Returns_K()
        {
            var result = Result.Failure<T,E>(E.Value).AsTask();

            var matched = await result.Match(OnSuccess_T_K_Task, OnFailure_E_K_Task);

            AssertFailure();
            
            matched.Should().Be(K.Value2);
        }
        
        [Fact]
        public async Task Match_Task_UnitResult_E_Success()
        {
            var result = UnitResult.Success<E>().AsTask();

            await result.Match(OnSuccess_Task, OnFailure_E_Task);

            AssertSuccess();
        }

        [Fact]
        public async Task Match_Task_UnitResult_E_Failure()
        {
            var result = UnitResult.Failure(E.Value).AsTask();

            await result.Match(OnSuccess_Task, OnFailure_E_Task);

            AssertFailure();
        }
        
        [Fact]
        public async Task Match_Task_UnitResult_E_Success_Returns_K()
        {
            var result = UnitResult.Success<E>().AsTask();

            await result.Match(OnSuccess_K_Task, OnFailure_E_K_Task);

            AssertSuccess();
        }

        [Fact]
        public async Task Match_Task_UnitResult_E_Failure_Returns_K()
        {
            var result = UnitResult.Failure(E.Value).AsTask();

            await result.Match(OnSuccess_K_Task, OnFailure_E_K_Task);

            AssertFailure();
        }
    }
}