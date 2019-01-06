using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class EnsureMethodTests
    {
        [Fact]
        public void Ensure_source_result_is_failure_predicate_do_not_invoked_expect_is_result_failure()
        {
            Result sut = Result.Fail("some error");

            Result result = sut.Ensure(() => true, string.Empty);

            result.Should().Be(sut);
        }
        
        [Fact]
        public void Ensure_source_result_is_success_predicate_is_failed_expected_result_failure()
        {
            Result sut = Result.Ok();

            Result result = sut.Ensure(() => false, "predicate failed");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate failed");
        }
        
        [Fact]
        public void Ensure_source_result_is_success_predicate_is_passed_expected_result_success()
        {
            Result sut = Result.Ok();
            
            Result result = sut.Ensure(() => true, string.Empty);

            result.Should().Be(sut);
        }

        [Fact]
        public async Task Ensure_source_result_is_failure_async_predicate_do_not_invoked_expect_is_result_failure()
        {
            Result sut = Result.Fail("some error");

            Result result = await sut.Ensure(() => Task.FromResult(true), string.Empty);

            result.Should().Be(sut);
        }
        
        [Fact]
        public async Task Ensure_source_result_is_success_async_predicate_is_failed_expected_result_failure()
        {
            Result sut = Result.Ok();

            Result result = await sut.Ensure(() => Task.FromResult(false), "predicate problems");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate problems");
        }
        
        [Fact]
        public async Task Ensure_source_result_is_success_async_predicate_is_passed_expected_result_success()
        {
            Result sut = Result.Ok();

            Result result = await sut.Ensure(() => Task.FromResult(true), string.Empty);

            result.Should().Be(sut);
        }
        
        [Fact]
        public async Task Ensure_task_source_result_is_failure_predicate_do_not_invoked_expect_is_result_failure()
        {
            Task<Result> sut = Task.FromResult(Result.Fail("some error"));            

            Result result = await sut.Ensure(() => true, string.Empty);

            result.Should().Be(sut.Result);
        }
        
        [Fact]
        public async Task Ensure_task_source_result_is_success_predicate_is_failed_expected_result_failure()
        {
            Task<Result> sut = Task.FromResult(Result.Ok());

            Result result = await sut.Ensure(() => false, "predicate problems");

            result.Should().NotBe(sut.Result);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate problems");
        }
        
        [Fact]
        public async Task Ensure_task_source_result_is_success_predicate_is_passed_expected_result_success()
        {
            Task<Result> sut = Task.FromResult(Result.Ok());

            Result result = await sut.Ensure(() => true, string.Empty);

            result.Should().Be(sut.Result);
        }
        
        [Fact]
        public async Task Ensure_task_source_result_is_failure_async_predicate_do_not_invoked_expect_is_result_failure()
        {
            Task<Result> sut = Task.FromResult(Result.Fail("some error"));
            
            Result result = await sut.Ensure(() => Task.FromResult(false), string.Empty);

            result.Should().Be(sut.Result);
        }
        
        [Fact]
        public async Task Ensure_task_source_result_is_success_async_predicate_is_failed_expected_result_failure()
        {
            Task<Result> sut = Task.FromResult(Result.Ok());

            Result result = await sut.Ensure(() => Task.FromResult(false), "predicate problems");

            result.Should().NotBe(sut.Result);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate problems");
        }
        
        [Fact]
        public async Task Ensure_task_source_result_is_success_async_predicate_is_passed_expected_result_success()
        {
            Task<Result> sut = Task.FromResult(Result.Ok());

            Result result = await sut.Ensure(() => Task.FromResult(true), string.Empty);

            result.Should().Be(sut.Result);
        }
        
        [Fact]
        public void Ensure_generic_source_result_is_failure_predicate_do_not_invoked_expect_is_error_result_failure()
        {
            Result<TimeSpan> sut = Result.Fail<TimeSpan>("some error");

            Result<TimeSpan> result = sut.Ensure(time => true, "test error");

            result.Should().Be(sut);
        }
        
        [Fact]
        public void Ensure_generic_source_result_is_success_predicate_is_failed_expected_error_result_failure()
        {
            Result<int> sut = Result.Ok(10101);

            Result<int> result = sut.Ensure(i => false, "test error");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("test error");
        }
        
        [Fact]
        public void Ensure_generic_source_result_is_success_predicate_is_passed_expected_error_result_success()
        {
            Result<decimal> sut = Result.Ok(.03m);

            Result<decimal> result = sut.Ensure(d => true, "test error");

            result.Should().Be(sut);
        }
        
        [Fact]
        public async Task Ensure_generic_source_result_is_failure_async_predicate_do_not_invoked_expect_is_error_result_failure()
        {
            Result<DateTimeOffset> sut = Result.Fail<DateTimeOffset>("some result error");

            Result<DateTimeOffset> result = await sut.Ensure(d => Task.FromResult(true), "test ensure error");

            result.Should().Be(sut);
        }
        
        [Fact]
        public async Task Ensure_generic_source_result_is_success_async_predicate_is_failed_expected_error_result_failure()
        {
            Result<int> sut = Result.Ok(333);

            Result<int> result = await sut.Ensure(i => Task.FromResult(false), "test ensure error");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("test ensure error");
        }
        
        [Fact]
        public async Task Ensure_generic_source_result_is_success_async_predicate_is_passed_expected_error_result_success()
        {
            Result<decimal> sut = Result.Ok(.33m);

            Result<decimal> result = await sut.Ensure(d => Task.FromResult(true), "test error");

            result.Should().Be(sut);
        }
        
        [Fact]
        public async Task Ensure_generic_task_source_result_is_failure_async_predicate_do_not_invoked_expect_is_error_result_failure()
        {
            Task<Result<TimeSpan>> sut = Task.FromResult(Result.Fail<TimeSpan>("some result error"));

            Result<TimeSpan> result = await sut.Ensure(t => Task.FromResult(true), "test ensure error");

            result.Should().Be(sut.Result);
        }
        
        [Fact]
        public async Task Ensure_generic_task_source_result_is_success_async_predicate_is_failed_expected_error_result_failure()
        {
            Task<Result<long>> sut = Task.FromResult(Result.Ok<long>(333));

            Result<long> result = await sut.Ensure(l => Task.FromResult(false), "test ensure error");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("test ensure error");
        }
        
        [Fact]
        public async Task Ensure_generic_task_source_result_is_success_async_predicate_is_passed_expected_error_result_success()
        {
            Task<Result<double>> sut = Task.FromResult(Result.Ok(.33));

            Result<double> result = await sut.Ensure(d => Task.FromResult(true), "test error");

            result.Should().Be(sut.Result);
        }
        
        [Fact]
        public async Task Ensure_generic_task_source_result_is_failure_predicate_do_not_invoked_expect_is_error_result_failure()
        {
            Task<Result<TimeSpan>> sut = Task.FromResult(Result.Fail<TimeSpan>("some result error"));

            Result<TimeSpan> result = await sut.Ensure(t => true, "test ensure error");

            result.Should().Be(sut.Result);
        }
        
        [Fact]
        public async Task Ensure_generic_task_source_result_is_success_predicate_is_failed_expected_error_result_failure()
        {
            Task<Result<long>> sut = Task.FromResult(Result.Ok<long>(333));

            Result<long> result = await sut.Ensure(l => false, "test ensure error");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("test ensure error");
        }
        
        [Fact]
        public async Task Ensure_generic_task_source_result_is_success_predicate_is_passed_expected_error_result_success()
        {
            Task<Result<double>> sut = Task.FromResult(Result.Ok(.33));

            Result<double> result = await sut.Ensure(d => true, "test error");

            result.Should().Be(sut.Result);
        }
        
        [Fact]
        public async Task Ensure_generic_source_result_with_error_is_failure_async_predicate_do_not_invoked_expect_is_error_result_failure()
        {
            Result<DateTime, Error> sut = Result.Fail<DateTime, Error>(new Error());

            Result<DateTime, Error> result = await sut.Ensure(d => Task.FromResult(true), new Error());

            result.Should().Be(sut);
        }
        
        [Fact]
        public async Task Ensure_generic_source_result_with_error_is_success_async_predicate_is_failed_expected_error_result_failure()
        {
            Result<int, Error> sut = Result.Ok<int, Error>(101);
            var error = new Error();

            Result<int, Error> result = await sut.Ensure(i => Task.FromResult(false), error);

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }
        
        [Fact]
        public async Task Ensure_generic_source_result_with_error_is_success_async_predicate_is_passed_expected_error_result_success()
        {
            Result<decimal, Error> sut = Result.Ok<decimal, Error>(.0003m);

            Result<decimal, Error> result = await sut.Ensure(d => Task.FromResult(true), new Error());

            result.Should().Be(sut);
        }
        
        [Fact]
        public async Task Ensure_task_source_result_is_failure_async_predicate_with_arg_do_not_invoked_expect_is_error_result_failure()
        {
            Task<Result<DateTime, Error>> sut = Task.FromResult(Result.Fail<DateTime, Error>(new Error()));

            Result<DateTime, Error> result = await sut.Ensure(d => Task.FromResult(true), new Error());

            result.Should().Be(sut.Result);
        }
        
        [Fact]
        public async Task Ensure_task_source_result_is_success_async_predicate_with_arg_is_failed_expected_error_result_failure()
        {
            Task<Result<int, Error>> sut = Task.FromResult(Result.Ok<int, Error>(100));
            var error = new Error();

            Result<int, Error> result = await sut.Ensure(i => Task.FromResult(false), error);

            result.Should().NotBe(sut.Result);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }
        
        [Fact]
        public async Task Ensure_task_source_result_is_success_async_predicate_with_arg_is_passed_expected_error_result_success()
        {
            Task<Result<decimal, Error>> sut = Task.FromResult(Result.Ok<decimal, Error>(.3m));

            Result<decimal, Error> result = await sut.Ensure(d => Task.FromResult(true), new Error());

            result.Should().Be(sut.Result);
        }

        [Fact]
        public async Task Ensure_task_source_result_is_failure_predicate_with_arg_do_not_invoked_expect_is_error_result_failure()
        {
            Task<Result<TimeSpan, Error>> sut = Task.FromResult(Result.Fail<TimeSpan, Error>(new Error()));

            Result<TimeSpan, Error> result = await sut.Ensure(t => true, new Error());

            result.Should().Be(sut.Result);
        }
        
        [Fact]
        public async Task Ensure_task_source_result_is_success_predicate_with_arg_is_failed_expected_error_result_failure()
        {
            Task<Result<byte, Error>> sut = Task.FromResult(Result.Ok<byte, Error>(32));
            var error = new Error();

            Result<byte, Error> result = await sut.Ensure(b => false, error);

            result.Should().NotBe(sut.Result);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }
        
        [Fact]
        public async Task Ensure_task_source_result_is_success_predicate_with_arg_is_passed_expected_error_result_success()
        {
            Task<Result<double, Error>> sut = Task.FromResult(Result.Ok<double, Error>(.35));

            Result<double, Error> result = await sut.Ensure(d => true, new Error());

            result.Should().Be(sut.Result);
        }

        [Fact]
        public void Ensure_source_result_is_failure_predicate_with_arg_do_not_invoked_expect_is_error_result_failure()
        {
            Result<TimeSpan, Error> sut = Result.Fail<TimeSpan, Error>(new Error());

            Result<TimeSpan, Error> result = sut.Ensure(t => true, new Error());

            result.Should().Be(sut);
        }
        
        [Fact]
        public void Ensure_source_result_is_success_predicate_with_arg_is_failed_expected_error_result_failure()
        {
            Result<byte, Error> sut = Result.Ok<byte, Error>(32);
            var error = new Error();

            Result<byte, Error> result = sut.Ensure(b => false, error);

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }
        
        [Fact]
        public void Ensure_source_result_is_success_predicate_with_arg_is_passed_expected_error_result_success()
        {
            Result<double, Error> sut = Result.Ok<double, Error>(.35);

            Result<double, Error> result = sut.Ensure(d => true, new Error());

            result.Should().Be(sut);
        }

        private class Error
        {
        }
    }
}