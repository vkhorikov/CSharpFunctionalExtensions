using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class EnsureMethodTests
    {
        [Fact]
        public void Ensure_source_result_is_failure_predicate_do_not_invoked_expect_is_result_failure()
        {
            Result sut = Result.Fail("some error");
            var predicateMock = new Mock<Func<bool>>();

            Result result = sut.Ensure(predicateMock.Object, string.Empty);

            result.Should().Be(sut);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public void Ensure_source_result_is_success_predicate_is_failed_expected_result_failure()
        {
            Result sut = Result.Ok();
            
            var predicateMock = new Mock<Func<bool>>();
            predicateMock
                .Setup(x => x())
                .Returns(false);

            Result result = sut.Ensure(predicateMock.Object, "predicate failed");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate failed");
            
            predicateMock.Verify(x => x(), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public void Ensure_source_result_is_success_predicate_is_passed_expected_result_success()
        {
            Result sut = Result.Ok();
            
            Mock<Func<bool>> predicateMock = new Mock<Func<bool>>();
            predicateMock
                .Setup(x => x())
                .Returns(true);

            Result result = sut.Ensure(predicateMock.Object, string.Empty);

            result.Should().Be(sut);
            
            predicateMock.Verify(x => x(), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task Ensure_source_result_is_failure_async_predicate_do_not_invoked_expect_is_result_failure()
        {
            Result sut = Result.Fail("some error");
            var predicateMock = new Mock<Func<Task<bool>>>();

            Result result = await sut.Ensure(predicateMock.Object, string.Empty);

            result.Should().Be(sut);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_source_result_is_success_async_predicate_is_failed_expected_result_failure()
        {
            Result sut = Result.Ok();
            
            var predicateMock = new Mock<Func<Task<bool>>>();
            predicateMock
                .Setup(x => x())
                .ReturnsAsync(false);

            Result result = await sut.Ensure(predicateMock.Object, "predicate problems");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate problems");
            
            predicateMock.Verify(x => x(), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_source_result_is_success_async_predicate_is_passed_expected_result_success()
        {
            Result sut = Result.Ok();
            
            var predicateMock = new Mock<Func<Task<bool>>>();
            predicateMock
                .Setup(x => x())
                .ReturnsAsync(true);

            Result result = await sut.Ensure(predicateMock.Object, string.Empty);

            result.Should().Be(sut);
            
            predicateMock.Verify(x => x(), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_task_source_result_is_failure_predicate_do_not_invoked_expect_is_result_failure()
        {
            Task<Result> sut = Task.FromResult(Result.Fail("some error"));            
            var predicateMock = new Mock<Func<bool>>();

            Result result = await sut.Ensure(predicateMock.Object, string.Empty);

            result.Should().Be(sut.Result);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_task_source_result_is_success_predicate_is_failed_expected_result_failure()
        {
            Task<Result> sut = Task.FromResult(Result.Ok());
            
            var predicateMock = new Mock<Func<bool>>();
            predicateMock
                .Setup(x => x())
                .Returns(false);

            Result result = await sut.Ensure(predicateMock.Object, "predicate problems");

            result.Should().NotBe(sut.Result);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate problems");
            
            predicateMock.Verify(x => x(), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_task_source_result_is_success_predicate_is_passed_expected_result_success()
        {
            Task<Result> sut = Task.FromResult(Result.Ok());
            
            var predicateMock = new Mock<Func<bool>>();
            predicateMock
                .Setup(x => x())
                .Returns(true);

            Result result = await sut.Ensure(predicateMock.Object, string.Empty);

            result.Should().Be(sut.Result);
            
            predicateMock.Verify(x => x(), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_task_source_result_is_failure_async_predicate_do_not_invoked_expect_is_result_failure()
        {
            Task<Result> sut = Task.FromResult(Result.Fail("some error"));
            
            var predicateMock = new Mock<Func<Task<bool>>>();
            predicateMock
                .Setup(x => x())
                .ReturnsAsync(false);

            Result result = await sut.Ensure(predicateMock.Object, string.Empty);

            result.Should().Be(sut.Result);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_task_source_result_is_success_async_predicate_is_failed_expected_result_failure()
        {
            Task<Result> sut = Task.FromResult(Result.Ok());
            
            var predicateMock = new Mock<Func<Task<bool>>>();
            predicateMock
                .Setup(x => x())
                .ReturnsAsync(false);

            Result result = await sut.Ensure(predicateMock.Object, "predicate problems");

            result.Should().NotBe(sut.Result);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate problems");
            
            predicateMock.Verify(x => x(), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_task_source_result_is_success_async_predicate_is_passed_expected_result_success()
        {
            Task<Result> sut = Task.FromResult(Result.Ok());
            
            var predicateMock = new Mock<Func<Task<bool>>>();
            predicateMock
                .Setup(x => x())
                .ReturnsAsync(true);

            Result result = await sut.Ensure(predicateMock.Object, string.Empty);

            result.Should().Be(sut.Result);
            
            predicateMock.Verify(x => x(), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public void Ensure_generic_source_result_is_failure_predicate_do_not_invoked_expect_is_error_result_failure()
        {
            Result<TimeSpan> sut = Result.Fail<TimeSpan>("some error");
            var predicateMock = new Mock<Func<TimeSpan, bool>>();

            Result<TimeSpan> result = sut.Ensure(predicateMock.Object, "test error");

            result.Should().Be(sut);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public void Ensure_generic_source_result_is_success_predicate_is_failed_expected_error_result_failure()
        {
            Result<int> sut = Result.Ok<int>(10101);
            
            var predicateMock = new Mock<Func<int, bool>>();
            predicateMock
                .Setup(x => x(10101))
                .Returns(false);

            Result<int> result = sut.Ensure(predicateMock.Object, "test error");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("test error");
            
            predicateMock.Verify(x => x(10101), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public void Ensure_generic_source_result_is_success_predicate_is_passed_expected_error_result_success()
        {
            Result<decimal> sut = Result.Ok<decimal>(.03m);
            
            var predicateMock = new Mock<Func<decimal, bool>>();
            predicateMock
                .Setup(x => x(.03m))
                .Returns(true);

            Result<decimal> result = sut.Ensure(predicateMock.Object, "test error");

            result.Should().Be(sut);
            
            predicateMock.Verify(x => x(.03m), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_generic_source_result_is_failure_async_predicate_do_not_invoked_expect_is_error_result_failure()
        {
            Result<DateTimeOffset> sut = Result.Fail<DateTimeOffset>("some result error");
            var predicateMock = new Mock<Func<DateTimeOffset, Task<bool>>>();

            Result<DateTimeOffset> result = await sut.Ensure(predicateMock.Object, "test ensure error");

            result.Should().Be(sut);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_generic_source_result_is_success_async_predicate_is_failed_expected_error_result_failure()
        {
            Result<int> sut = Result.Ok<int>(333);
            
            var predicateMock = new Mock<Func<int, Task<bool>>>();
            predicateMock
                .Setup(x => x(333))
                .ReturnsAsync(false);

            Result<int> result = await sut.Ensure(predicateMock.Object, "test ensure error");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("test ensure error");
            
            predicateMock.Verify(x => x(333), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_generic_source_result_is_success_async_predicate_is_passed_expected_error_result_success()
        {
            Result<decimal> sut = Result.Ok<decimal>(.33m);
            
            var predicateMock = new Mock<Func<decimal, Task<bool>>>();
            predicateMock
                .Setup(x => x(.33m))
                .ReturnsAsync(true);

            Result<decimal> result = await sut.Ensure(predicateMock.Object, "test error");

            result.Should().Be(sut);
            
            predicateMock.Verify(x => x(.33m), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_generic_task_source_result_is_failure_async_predicate_do_not_invoked_expect_is_error_result_failure()
        {
            Task<Result<TimeSpan>> sut = Task.FromResult(Result.Fail<TimeSpan>("some result error"));
            var predicateMock = new Mock<Func<TimeSpan, Task<bool>>>();

            Result<TimeSpan> result = await sut.Ensure(predicateMock.Object, "test ensure error");

            result.Should().Be(sut.Result);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_generic_task_source_result_is_success_async_predicate_is_failed_expected_error_result_failure()
        {
            Task<Result<long>> sut = Task.FromResult(Result.Ok<long>(333));
            
            var predicateMock = new Mock<Func<long, Task<bool>>>();
            predicateMock
                .Setup(x => x(333))
                .ReturnsAsync(false);

            Result<long> result = await sut.Ensure(predicateMock.Object, "test ensure error");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("test ensure error");
            
            predicateMock.Verify(x => x(333), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_generic_task_source_result_is_success_async_predicate_is_passed_expected_error_result_success()
        {
            Task<Result<double>> sut = Task.FromResult(Result.Ok<double>(.33));
            
            var predicateMock = new Mock<Func<double, Task<bool>>>();
            predicateMock
                .Setup(x => x(.33))
                .ReturnsAsync(true);

            Result<double> result = await sut.Ensure(predicateMock.Object, "test error");

            result.Should().Be(sut.Result);
            
            predicateMock.Verify(x => x(.33), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_generic_task_source_result_is_failure_predicate_do_not_invoked_expect_is_error_result_failure()
        {
            Task<Result<TimeSpan>> sut = Task.FromResult(Result.Fail<TimeSpan>("some result error"));
            var predicateMock = new Mock<Func<TimeSpan, bool>>();

            Result<TimeSpan> result = await sut.Ensure(predicateMock.Object, "test ensure error");

            result.Should().Be(sut.Result);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_generic_task_source_result_is_success_predicate_is_failed_expected_error_result_failure()
        {
            Task<Result<long>> sut = Task.FromResult(Result.Ok<long>(333));
            
            var predicateMock = new Mock<Func<long, bool>>();
            predicateMock
                .Setup(x => x(333))
                .Returns(false);

            Result<long> result = await sut.Ensure(predicateMock.Object, "test ensure error");

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("test ensure error");
            
            predicateMock.Verify(x => x(333), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_generic_task_source_result_is_success_predicate_is_passed_expected_error_result_success()
        {
            Task<Result<double>> sut = Task.FromResult(Result.Ok<double>(.33));
            
            var predicateMock = new Mock<Func<double, bool>>();
            predicateMock
                .Setup(x => x(.33))
                .Returns(true);

            Result<double> result = await sut.Ensure(predicateMock.Object, "test error");

            result.Should().Be(sut.Result);
            
            predicateMock.Verify(x => x(.33), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_generic_source_result_with_error_is_failure_async_predicate_do_not_invoked_expect_is_error_result_failure()
        {
            Result<DateTime, Error> sut = Result.Fail<DateTime, Error>(new Error());
            var predicateMock = new Mock<Func<DateTime, Task<bool>>>();

            Result<DateTime, Error> result = await sut.Ensure(predicateMock.Object, new Error());

            result.Should().Be(sut);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_generic_source_result_with_error_is_success_async_predicate_is_failed_expected_error_result_failure()
        {
            Result<int, Error> sut = Result.Ok<int, Error>(101);
            var error = new Error();
            
            var predicateMock = new Mock<Func<int, Task<bool>>>();
            predicateMock
                .Setup(x => x(101))
                .ReturnsAsync(false);

            Result<int, Error> result = await sut.Ensure(predicateMock.Object, error);

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
            
            predicateMock.Verify(x => x(101), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_generic_source_result_with_error_is_success_async_predicate_is_passed_expected_error_result_success()
        {
            Result<decimal, Error> sut = Result.Ok<decimal, Error>(.0003m);
            
            var predicateMock = new Mock<Func<decimal, Task<bool>>>();
            predicateMock
                .Setup(x => x(.0003m))
                .ReturnsAsync(true);

            Result<decimal, Error> result = await sut.Ensure(predicateMock.Object, new Error());

            result.Should().Be(sut);
            
            predicateMock.Verify(x => x(.0003m), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_task_source_result_is_failure_async_predicate_with_arg_do_not_invoked_expect_is_error_result_failure()
        {
            Task<Result<DateTime, Error>> sut = Task.FromResult(Result.Fail<DateTime, Error>(new Error()));
            var predicateMock = new Mock<Func<DateTime, Task<bool>>>();

            Result<DateTime, Error> result = await sut.Ensure(predicateMock.Object, new Error());

            result.Should().Be(sut.Result);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_task_source_result_is_success_async_predicate_with_arg_is_failed_expected_error_result_failure()
        {
            Task<Result<int, Error>> sut = Task.FromResult(Result.Ok<int, Error>(100));
            var error = new Error();
            
            var predicateMock = new Mock<Func<int, Task<bool>>>();
            predicateMock
                .Setup(x => x(100))
                .ReturnsAsync(false);

            Result<int, Error> result = await sut.Ensure(predicateMock.Object, error);

            result.Should().NotBe(sut.Result);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
            
            predicateMock.Verify(x => x(100), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_task_source_result_is_success_async_predicate_with_arg_is_passed_expected_error_result_success()
        {
            Task<Result<decimal, Error>> sut = Task.FromResult(Result.Ok<decimal, Error>(.3m));
            
            var predicateMock = new Mock<Func<decimal, Task<bool>>>();
            predicateMock
                .Setup(x => x(.3m))
                .ReturnsAsync(true);

            Result<decimal, Error> result = await sut.Ensure(predicateMock.Object, new Error());

            result.Should().Be(sut.Result);
            
            predicateMock.Verify(x => x(.3m), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task Ensure_task_source_result_is_failure_predicate_with_arg_do_not_invoked_expect_is_error_result_failure()
        {
            Task<Result<TimeSpan, Error>> sut = Task.FromResult(Result.Fail<TimeSpan, Error>(new Error()));
            var predicateMock = new Mock<Func<TimeSpan, bool>>();

            Result<TimeSpan, Error> result = await sut.Ensure(predicateMock.Object, new Error());

            result.Should().Be(sut.Result);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_task_source_result_is_success_predicate_with_arg_is_failed_expected_error_result_failure()
        {
            Task<Result<byte, Error>> sut = Task.FromResult(Result.Ok<byte, Error>(32));
            var error = new Error();
            
            var predicateMock = new Mock<Func<byte, bool>>();
            predicateMock
                .Setup(x => x(100))
                .Returns(false);

            Result<byte, Error> result = await sut.Ensure(predicateMock.Object, error);

            result.Should().NotBe(sut.Result);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
            
            predicateMock.Verify(x => x(32), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task Ensure_task_source_result_is_success_predicate_with_arg_is_passed_expected_error_result_success()
        {
            Task<Result<double, Error>> sut = Task.FromResult(Result.Ok<double, Error>(.35));
            
            var predicateMock = new Mock<Func<double, bool>>();
            predicateMock
                .Setup(x => x(.35))
                .Returns(true);

            Result<double, Error> result = await sut.Ensure(predicateMock.Object, new Error());

            result.Should().Be(sut.Result);
            
            predicateMock.Verify(x => x(.35), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }
        
                [Fact]
        public void Ensure_source_result_is_failure_predicate_with_arg_do_not_invoked_expect_is_error_result_failure()
        {
            Result<TimeSpan, Error> sut = Result.Fail<TimeSpan, Error>(new Error());
            var predicateMock = new Mock<Func<TimeSpan, bool>>();

            Result<TimeSpan, Error> result = sut.Ensure(predicateMock.Object, new Error());

            result.Should().Be(sut);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public void Ensure_source_result_is_success_predicate_with_arg_is_failed_expected_error_result_failure()
        {
            Result<byte, Error> sut = Result.Ok<byte, Error>(32);
            var error = new Error();
            
            var predicateMock = new Mock<Func<byte, bool>>();
            predicateMock
                .Setup(x => x(100))
                .Returns(false);

            Result<byte, Error> result = sut.Ensure(predicateMock.Object, error);

            result.Should().NotBe(sut);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
            
            predicateMock.Verify(x => x(32), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }
        
        [Fact]
        public void Ensure_source_result_is_success_predicate_with_arg_is_passed_expected_error_result_success()
        {
            Result<double, Error> sut = Result.Ok<double, Error>(.35);
            
            var predicateMock = new Mock<Func<double, bool>>();
            predicateMock
                .Setup(x => x(.35))
                .Returns(true);

            Result<double, Error> result = sut.Ensure(predicateMock.Object, new Error());

            result.Should().Be(sut);
            
            predicateMock.Verify(x => x(.35), Times.Once);
            predicateMock.VerifyNoOtherCalls();
        }

        private class Error
        {
        }
    }
}