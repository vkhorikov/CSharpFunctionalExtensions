using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class ResultTests
    {
        [Fact]
        public void Create_argument_is_true_Success_result_expected()
        {
            Result result = Result.Create(true, string.Empty);

            result.IsSuccess.Should().BeTrue();
        }
        
        [Fact]
        public void Create_argument_is_false_Failure_result_expected()
        {
            Result result = Result.Create(false, "simple result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("simple result error");
        }
        
        [Fact]
        public void Create_predicate_is_true_Success_result_expected()
        {   
            Result result = Result.Create(() => true, string.Empty);

            result.IsSuccess.Should().BeTrue();
        }
        
        [Fact]
        public void Create_predicate_is_false_Failure_result_expected()
        {
            Result result = Result.Create(() => false, "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }
        
        [Fact]
        public async Task Create_async_predicate_is_true_Success_result_expected()
        {
            Result result = await Result.Create(() => Task.FromResult(true), string.Empty);

            result.IsSuccess.Should().BeTrue();
        }
        
        [Fact]
        public async Task Create_async_predicate_is_false_Failure_result_expected()
        {
            Result result = await Result.Create(() => Task.FromResult(false), "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }
        
        [Fact]
        public void Create_generic_argument_is_true_Success_result_expected()
        {
            byte val = 7;
            Result<byte> result = Result.Create(true, val, string.Empty);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }
        
        [Fact]
        public void Create_generic_argument_is_false_Failure_result_expected()
        {
            double val = .56;
            Result<double> result = Result.Create(false, val, "simple result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("simple result error");
        }
        
        [Fact]
        public void Create_generic_predicate_is_true_Success_result_expected()
        {
            DateTime val = new DateTime(2000, 1, 1);
            
            Result<DateTime> result = Result.Create(() => true, val, string.Empty);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }
        
        [Fact]
        public void Create_generic_predicate_is_false_Failure_result_expected()
        {
            string val = "string value";
            
            Result<string> result = Result.Create(() => false, val, "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }
        
        [Fact]
        public async Task Create_generic_async_predicate_is_true_Success_result_expected()
        {
            int val = 42;
            
            Result<int> result = await Result.Create(() => Task.FromResult(true), val, string.Empty);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }
        
        [Fact]
        public async Task Create_generic_async_predicate_is_false_Failure_result_expected()
        {
            bool val = true;
            
            Result<bool> result = await Result.Create(() => Task.FromResult(false), val, "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }
        
        
        [Fact]
        public void Create_error_generic_argument_is_true_Success_result_expected()
        {
            byte val = 7;
            Result<byte, Error> result = Result.Create(true, val, new Error());

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }
        
        [Fact]
        public void Create_error_generic_argument_is_false_Failure_result_expected()
        {
            double val = .56;
            var error = new Error();
            
            Result<double, Error> result = Result.Create(false, val, error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }
        
        [Fact]
        public void Create_error_generic_predicate_is_true_Success_result_expected()
        {
            DateTime val = new DateTime(2000, 1, 1);
            
            Result<DateTime, Error> result = Result.Create(() => true, val, new Error());

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }
        
        [Fact]
        public void Create_error_generic_predicate_is_false_Failure_result_expected()
        {
            string val = "string value";
            var error = new Error();
            
            Result<string, Error> result = Result.Create(() => false, val, error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }
        
        [Fact]
        public async Task Create_error_generic_async_predicate_is_true_Success_result_expected()
        {
            int val = 42;
            
            Result<int, Error> result = await Result.Create(() => Task.FromResult(true), val, new Error());

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }
        
        [Fact]
        public async Task Create_error_generic_async_predicate_is_false_Failure_result_expected()
        {
            bool val = true;
            var error = new Error();
            
            Result<bool, Error> result = await Result.Create(() => Task.FromResult(false), val, error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }
        
        [Fact]
        public void Can_work_with_nullable_sructs()
        {
            Result<DateTime?> result = Result.Ok((DateTime?)null);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(null);
        }
        
        [Fact]
        public void Can_work_with_maybe_of_struct()
        {
            Maybe<DateTime> maybe = Maybe<DateTime>.None;

            Result<Maybe<DateTime>> result = Result.Ok(maybe);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(Maybe<DateTime>.None);
        }
        
        [Fact]
        public void Can_work_with_maybe_of_ref_type()
        {
            Maybe<string> maybe = Maybe<string>.None;

            Result<Maybe<string>> result = Result.Ok(maybe);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(Maybe<string>.None);
        }

        [Fact]
        public void Try_execute_function_success_without_error_handler_function_result_expected()
        {
            Func<int> func = () => 5;
            
            var result = Result.Try(func);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(5);
        }
        
        [Fact]
        public void Try_execute_function_failed_without_error_handler_failed_result_expected()
        {
            Func<int> func = () => throw new Exception("func error");
            
            var result = Result.Try(func);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("func error");
        }
        
        [Fact]
        public void Try_execute_function_failed_with_error_handler_failed_result_expected()
        {
            Func<int> func = () => throw new Exception("func error");
            Func<Exception, string> handler = exc => "execute error";
            
            var result = Result.Try(func, handler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("execute error");
        }
        
        [Fact]
        public void Try_execute_action_success_without_error_handler_function_result_expected()
        {
            Action action = () => { };
            
            var result = Result.Try(action);

            result.IsSuccess.Should().BeTrue();
        }
        
        [Fact]
        public void Try_execute_action_failed_without_error_handler_failed_result_expected()
        {
            Action action = () => throw new Exception("func error");
            
            var result = Result.Try(action);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("func error");
        }
        
        [Fact]
        public void Try_execute_action_failed_with_error_handler_failed_result_expected()
        {
            Action action = () => throw new Exception("func error");
            Func<Exception, string> handler = exc => "execute error";
            
            var result = Result.Try(action, handler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("execute error");
        }

        [Fact]
        public void Try_with_error_execute_function_success_without_error_success_result_expected()
        {
            Func<string> func = () => "execution result";
            var error = new Error();
            
            var result = Result.Try(func, exc => error);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be("execution result");
        }
        
        [Fact]
        public void Try_with_error_execute_function_failed_with_error_handler_failed_result_expected()
        {
            Func<int> func = () => throw new Exception("func error");
            var error = new Error();
            
            var result = Result.Try(func, exc => error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }
        
        [Fact]
        public async Task Try_async_execute_function_success_without_error_handler_function_result_expected()
        {
            Func<Task<int>> func = () => Task.FromResult(5);
            
            var result = await Result.Try(func);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(5);
        }
        
        [Fact]
        public async Task Try_async_execute_function_failed_without_error_handler_failed_result_expected()
        {
            Func<Task<int>> func = () => Task.FromException<int>(new Exception("func error"));
            
            var result = await Result.Try(func);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("func error");
        }
        
        [Fact]
        public async Task Try_async_execute_function_failed_with_error_handler_failed_result_expected()
        {
            Func<Task<int>> func = () => Task.FromException<int>(new Exception("func error"));
            Func<Exception, string> handler = exc => "execute error";
            
            var result = await Result.Try(func, handler);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("execute error");
        }
        
        [Fact]
        public async Task Try_async_with_error_execute_function_success_without_error_success_result_expected()
        {
            Func<Task<string>> func = () => Task.FromResult("execution result");
            
            var result = await Result.Try(func, exc => new Error());

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be("execution result");
        }
        
        [Fact]
        public async Task Try_async_with_error_execute_function_failed_with_error_handler_failed_result_expected()
        {
            Func<Task<DateTime>> func = () => Task.FromException<DateTime>(new Exception("func error"));
            var error = new Error();
            
            var result = await Result.Try(func, exc => error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        private class Error
        {
        }
    }
}